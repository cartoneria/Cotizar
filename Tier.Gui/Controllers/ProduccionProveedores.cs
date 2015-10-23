using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ProduccionController : BaseController
    {
        //
        // GET: /AdministracionProveedores/

        public ActionResult ListaProveedores()
        {
            return View(SAL.Proveedores.RecuperarProveedoresTodas());
        }

        public ActionResult CrearProveedor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProveedor(CotizarService.ProveedorModel obj)
        {
            if (ModelState.IsValid)
            {
                int? idproveedor;

                IList<CotizarService.ProveedorLinea> lstProveedoresLineas = this.CargarProveedoresLineas(obj.hfdlineas).ToList();

                CotizarService.Proveedor _proveedor = new CotizarService.Proveedor
                {
                    nombre = obj.nombre,
                    activo = obj.activo,
                    lineas = this.CargarProveedoresLineas(obj.hfdlineas).ToList()
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Proveedor_Insertar(_proveedor, out idproveedor) && idproveedor != null)
                {
                    base.RegistrarNotificación("El proveedor fue creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaProveedores", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }

            }

            return ListaProveedores();
        }

        public ActionResult EditarProveedor(byte idProveedor)
        {
            //Consultar información de proveedor y las lineas asociadas
            CotizarService.Proveedor obj = SAL.Proveedores.RecuperarXId(idProveedor);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProveedor(CotizarService.ProveedorModel obj)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }
        
        public ActionResult EliminarProveedor(int idProveedor)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Proveedor_Eliminar(new CotizarService.Proveedor() { idproveedor = idProveedor }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado la máquina.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("La máquina no pudo ser eliminada. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaMaquinas", "Produccion");
        }

        private string GenerarJsonVP(IEnumerable<CotizarService.ProveedorLinea> lstProveedorLinea)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstProveedorLinea)
            {
                strResultado.Append("{\"idproveedor\":\"" + item.proveedor_idproveedor.ToString() + "\"," +
                    "\"idprovrlinea\":\"" + item.nombre.ToString() + "\"," +
                    "\"nombre\":\"" + item.nombre.ToString() + "\"," +
                    "\"activo\":\"" + item.activo.ToString() + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        private IEnumerable<CotizarService.ProveedorLinea> CargarProveedoresLineas(string strJsonProvLineas)
        {
            List<CotizarService.ProveedorLinea> lstProveedoresLineas = new List<CotizarService.ProveedorLinea>();

            JArray jsonArray = JArray.Parse(strJsonProvLineas);
            if (jsonArray.Count > 0)
            {
                foreach (var objProvLinea in jsonArray.Children())
                {
                    try
                    {
                        /*ph: intph, phun: intphun, phunnomb: strphunnomb, ta: intta, taun: inttaun, taunnomb: strtaunnomb*/
                        //id: idProvLinea, nombreLinea: nombreProvLinea, activo: activo

                        dynamic objArrVari = JObject.Parse(objProvLinea.ToString());
                        int intIdVP;

                        lstProveedoresLineas.Add(new CotizarService.ProveedorLinea()
                        {
                            idproveedor_linea = (int.TryParse(objArrVari.id.ToString(), out intIdVP) ? intIdVP : new Nullable<int>()),
                            nombre = objArrVari.nombreLinea,
                            activo = objArrVari.activo
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lstProveedoresLineas;

        }

    }
}
