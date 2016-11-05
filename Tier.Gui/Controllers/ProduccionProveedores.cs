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
        private void CargarListasProveedores()
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaProveedores()
        {
            return View(SAL.Proveedores.RecuperarTodos(base.SesionActual.empresa.idempresa));
        }

        public ActionResult CrearProveedor()
        {
            this.CargarListasProveedores();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProveedor(CotizarService.ProveedorModel obj)
        {
            if (ModelState.IsValid)
            {
                int? idproveedor;
                //IList<CotizarService.ProveedorLinea> lstProveedoresLineas = this.CargarProveedoresLineas(obj.hfdlineas).ToList();
                CotizarService.Proveedor _proveedor = new CotizarService.Proveedor
                {
                    nombre = obj.nombre,
                    activo = obj.activo,
                    lineas = this.CargarProveedoresLineas(obj.hfdlineas).ToList(),
                    empresa_idempresa = obj.empresa_idempresa
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

        public ActionResult EditarProveedor(int id)
        {
            CotizarService.Proveedor objProv = SAL.Proveedores.RecuperarXId(id, base.SesionActual.empresa.idempresa);

            if (objProv != null)
            {
                CotizarService.ProveedorModel objModel = new CotizarService.ProveedorModel()
                {
                    activo = objProv.activo,
                    fechacreacion = objProv.fechacreacion,
                    hfdlineas = this.GenerarJsonProvLineas(objProv.lineas),
                    idproveedor = objProv.idproveedor,
                    nombre = objProv.nombre,
                    empresa_idempresa = objProv.empresa_idempresa
                };

                this.CargarListasProveedores();
                return View(objModel);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaProveedores", "Produccion");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProveedor(CotizarService.ProveedorModel obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Proveedor _proveedor = new CotizarService.Proveedor
                {
                    idproveedor = obj.idproveedor,
                    nombre = obj.nombre,
                    activo = obj.activo,
                    lineas = this.CargarProveedoresLineas(obj.hfdlineas).ToList(),
                    empresa_idempresa = obj.empresa_idempresa
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Proveedor_Actualizar(_proveedor))
                {
                    base.RegistrarNotificación("El proveedor fue actualizado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaProveedores", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            this.CargarListasProveedores();
            return View(obj);
        }

        public ActionResult EliminarProveedor(int id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Proveedor_Eliminar(new CotizarService.Proveedor() { idproveedor = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el proveedor.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El proveedor no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaProveedores", "Produccion");
        }

        private string GenerarJsonProvLineas(IEnumerable<CotizarService.ProveedorLinea> lstProveedorLinea)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstProveedorLinea)
            {
                strResultado.Append("{\"id\":\"" + item.idproveedor_linea.ToString() + "\"," +
                    "\"nombreLinea\":\"" + item.nombre.ToString() + "\"," +
                    "\"activo\":\"" + item.activo.ToString() + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        private IEnumerable<CotizarService.ProveedorLinea> CargarProveedoresLineas(string strJsonProvLineas)
        {
            List<CotizarService.ProveedorLinea> lstProveedoresLineas = new List<CotizarService.ProveedorLinea>();

            if (!string.IsNullOrEmpty(strJsonProvLineas))
            {
                JArray jsonArray = JArray.Parse(strJsonProvLineas);
                if (jsonArray.Count > 0)
                {
                    foreach (var objProvLinea in jsonArray.Children())
                    {
                        try
                        {
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
            }

            return lstProveedoresLineas;

        }
    }
}
