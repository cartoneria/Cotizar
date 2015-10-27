using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ProduccionController : BaseController
    {
        public ActionResult ListaInsumos()
        {
            ViewBag.lstTipoInsumo = SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo);
            return View(SAL.Insumos.RecuperarTodos());
        }

        public ActionResult CrearInsumo()
        {
            //Proveedores
            ViewBag.proveedor_linea_proveedor_idproveedor = new SelectList(SAL.Proveedores.RecuperarProveedoresActivas(), "idproveedor", "nombre");

            //ProveedoresLineas
            ViewBag.proveedoreslinea_idproveedorlinea = new SelectList(new List<CotizarService.ProveedorLinea>(), "idlinea", "nombre");

            //ItemLista Tipo
            ViewBag.itemlista_iditemlista_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo), "iditemlista", "nombre");

            //ItemLista UnidadMedida
            ViewBag.itemlista_iditemlista_unimedcomp = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");

            //ItemLista UnidadRendimiento
            ViewBag.itemlista_iditemlista_unimedrendi = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");

            return View();
        }

        [HttpPost]
        public ActionResult CrearInsumo(CotizarService.Insumo obj)
        {
            if (ModelState.IsValid)
            {
                int? idinsumo;

                CotizarService.Insumo objInsumo = new CotizarService.Insumo
                {
                    activo = obj.activo,
                    ancho = obj.ancho,
                    calibre = obj.calibre,
                    factorrendimiento = obj.factorrendimiento,
                    itemlista_iditemlista_tipo = obj.itemlista_iditemlista_tipo,
                    itemlista_iditemlista_unimedcomp = obj.itemlista_iditemlista_unimedcomp,
                    itemlista_iditemlista_unimedrendi = obj.itemlista_iditemlista_unimedrendi,
                    observaciones = obj.observaciones,
                    proveedor_linea_idproveedor_linea = obj.proveedor_linea_idproveedor_linea,
                    proveedor_linea_proveedor_idproveedor = obj.proveedor_linea_proveedor_idproveedor,
                    valor = obj.valor
                };

                CotizarService.CotizarServiceClient _service = new CotizarService.CotizarServiceClient();
                if (_service.Insumo_Insertar(objInsumo, out idinsumo) && idinsumo != null)
                {
                    base.RegistrarNotificación("El insumo fue creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaInsumos", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }

            }

            return View(obj);
        }


        public ActionResult EditarInsumo(int idinsumo)
        {
            IList<CotizarService.Insumo> lstIns = SAL.Insumos.RecuperarTodos().ToList();


            CotizarService.Insumo objInsumo = SAL.Insumos.RecuperarTodos().ToList().Where(c=> c.idinsumo == idinsumo).FirstOrDefault();
            if (objInsumo != null)
            {
                //Proveedores
                ViewBag.proveedor_linea_proveedor_idproveedor = new SelectList(
                    SAL.Proveedores.RecuperarProveedoresActivas(), 
                    "idproveedor",
                    "nombre",
                    objInsumo.proveedor_linea_proveedor_idproveedor
                    );

                //ProveedoresLineas
                ViewBag.proveedoreslinea_idproveedorlinea = new SelectList(
                    new List<CotizarService.ProveedorLinea>(), 
                    "idlinea", 
                    "nombre",
                    objInsumo.proveedor_linea_idproveedor_linea
                    );

                //ItemLista Tipo
                ViewBag.itemlista_iditemlista_tipo = new SelectList(
                    SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo),
                    "iditemlista", 
                    "nombre",
                    objInsumo.itemlista_iditemlista_tipo
                    );

                //ItemLista UnidadMedida
                ViewBag.itemlista_iditemlista_unimedcomp = new SelectList(
                    SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), 
                    "iditemlista", 
                    "nombre",
                    objInsumo.itemlista_iditemlista_unimedcomp
                    );

                //ItemLista UnidadRendimiento
                ViewBag.itemlista_iditemlista_unimedrendi = new SelectList(
                    SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), 
                    "iditemlista", 
                    "nombre",
                    objInsumo.itemlista_iditemlista_unimedrendi
                    );
            }
            else
            {
                return ListaInsumos();
            }           


            return View(objInsumo);
        }

        [HttpPost]
        public ActionResult EditarInsumo(CotizarService.Insumo obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Insumo objInsumo = new CotizarService.Insumo
                {
                    activo = obj.activo,
                    ancho = obj.ancho,
                    calibre = obj.calibre,
                    factorrendimiento = obj.factorrendimiento,
                    itemlista_iditemlista_tipo = obj.itemlista_iditemlista_tipo,
                    itemlista_iditemlista_unimedcomp = obj.itemlista_iditemlista_unimedcomp,
                    itemlista_iditemlista_unimedrendi = obj.itemlista_iditemlista_unimedrendi,
                    observaciones = obj.observaciones,
                    proveedor_linea_idproveedor_linea = obj.proveedor_linea_idproveedor_linea,
                    proveedor_linea_proveedor_idproveedor = obj.proveedor_linea_proveedor_idproveedor,
                    valor = obj.valor
                };

                CotizarService.CotizarServiceClient _service = new CotizarService.CotizarServiceClient();
                if (_service.Insumo_Actualizar(objInsumo))
                {
                    base.RegistrarNotificación("El insumo fue actualizado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaInsumos", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }

            }

            return View(obj);
        }

        [HttpPost]
        public JsonResult RecuperarLineasProveedor(int idProveedor)
        {
            return Json(SAL.Proveedores.RecuperarXId(idProveedor).lineas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarInsumo(int idinsumo)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Insumo_Eliminar(new CotizarService.Insumo() { idinsumo = idinsumo }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el insumo.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El insumo no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaInsumos", "Produccion");
        }

    }
}