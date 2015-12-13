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
        private void CargarListasInsumos(CotizarService.InsumoMetadata objInsumo)
        {
            if (objInsumo == null)
            {
                ViewBag.proveedor_linea_proveedor_idproveedor = new SelectList(SAL.Proveedores.RecuperarActivos(base.SesionActual.empresa.idempresa), "idproveedor", "nombre");
                ViewBag.proveedor_linea_idproveedor_linea = new SelectList(new List<CotizarService.ProveedorLinea>(), "idproveedor_linea", "nombre");
                ViewBag.itemlista_iditemlista_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo), "iditemlista", "nombre");
                ViewBag.itemlista_iditemlista_unimedcomp = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
                ViewBag.itemlista_iditemlista_unimedrendi = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
            }
            else
            {
                ViewBag.proveedor_linea_proveedor_idproveedor = new SelectList(SAL.Proveedores.RecuperarActivos(base.SesionActual.empresa.idempresa), "idproveedor", "nombre", objInsumo.proveedor_linea_proveedor_idproveedor);
                ViewBag.proveedor_linea_idproveedor_linea = new SelectList(SAL.Proveedores.RecuperarXId((int)objInsumo.proveedor_linea_proveedor_idproveedor, base.SesionActual.empresa.idempresa).lineas.Where(c => c.activo == true), "idproveedor_linea", "nombre", objInsumo.proveedor_linea_idproveedor_linea);
                ViewBag.itemlista_iditemlista_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo), "iditemlista", "nombre", objInsumo.itemlista_iditemlista_tipo);
                ViewBag.itemlista_iditemlista_unimedcomp = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre", objInsumo.itemlista_iditemlista_unimedcomp);
                ViewBag.itemlista_iditemlista_unimedrendi = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre", objInsumo.itemlista_iditemlista_unimedrendi);
            }

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaInsumos()
        {
            this.CargarListasInsumos(null);

            return View(SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa));
        }

        public ActionResult CrearInsumo()
        {
            this.CargarListasInsumos(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearInsumo(CotizarService.InsumoMetadata obj)
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
                    valor = obj.valor,
                    nombre = obj.nombre,
                    valorflete = obj.valorflete,
                    empresa_idempresa = obj.empresa_idempresa,
                    conversionflete = obj.conversionflete
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
            else
            {
                base.RegistrarNotificación("Algunos valores no son válidos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasInsumos(obj);

            return View(obj);
        }

        public ActionResult EditarInsumo(int id)
        {
            CotizarService.InsumoMetadata objInsumo = new CotizarService.InsumoMetadata();
            CotizarService.Insumo _objInsumo = SAL.Insumos.RecuperarXId(id, base.SesionActual.empresa.idempresa);

            if (_objInsumo != null)
            {
                objInsumo = new CotizarService.InsumoMetadata()
                {
                    activo = _objInsumo.activo,
                    ancho = _objInsumo.ancho,
                    calibre = _objInsumo.calibre,
                    factorrendimiento = _objInsumo.factorrendimiento,
                    fechacreacion = _objInsumo.fechacreacion,
                    idinsumo = _objInsumo.idinsumo,
                    itemlista_iditemlista_tipo = _objInsumo.itemlista_iditemlista_tipo,
                    itemlista_iditemlista_unimedcomp = _objInsumo.itemlista_iditemlista_unimedcomp,
                    itemlista_iditemlista_unimedrendi = _objInsumo.itemlista_iditemlista_unimedrendi,
                    observaciones = _objInsumo.observaciones,
                    proveedor_linea_idproveedor_linea = _objInsumo.proveedor_linea_idproveedor_linea,
                    proveedor_linea_proveedor_idproveedor = _objInsumo.proveedor_linea_proveedor_idproveedor,
                    valor = _objInsumo.valor,
                    nombre = _objInsumo.nombre,
                    valorflete = _objInsumo.valorflete,
                    empresa_idempresa = _objInsumo.empresa_idempresa,
                    conversionflete = _objInsumo.conversionflete
                };
            }
            else
            {
                return RedirectToAction("ListaInsumos", "Produccion");
            }

            this.CargarListasInsumos(objInsumo);

            return View(objInsumo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarInsumo(CotizarService.InsumoMetadata obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Insumo objInsumo = new CotizarService.Insumo
                {
                    activo = obj.activo,
                    ancho = obj.ancho,
                    calibre = obj.calibre,
                    factorrendimiento = obj.factorrendimiento,
                    idinsumo = obj.idinsumo,
                    itemlista_iditemlista_tipo = obj.itemlista_iditemlista_tipo,
                    itemlista_iditemlista_unimedcomp = obj.itemlista_iditemlista_unimedcomp,
                    itemlista_iditemlista_unimedrendi = obj.itemlista_iditemlista_unimedrendi,
                    observaciones = obj.observaciones,
                    proveedor_linea_idproveedor_linea = obj.proveedor_linea_idproveedor_linea,
                    proveedor_linea_proveedor_idproveedor = obj.proveedor_linea_proveedor_idproveedor,
                    valor = obj.valor,
                    nombre = obj.nombre,
                    valorflete = obj.valorflete,
                    empresa_idempresa = obj.empresa_idempresa,
                    conversionflete = obj.conversionflete
                };

                CotizarService.CotizarServiceClient _service = new CotizarService.CotizarServiceClient();
                if (_service.Insumo_Actualizar(objInsumo))
                {
                    base.RegistrarNotificación("El insumo fue actualizado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaInsumos", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de actualización.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son válidos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasInsumos(obj);

            return View(obj);
        }

        [HttpPost]
        public JsonResult RecuperarLineasProveedor(int idProveedor)
        {
            return Json(SAL.Proveedores.RecuperarXId(idProveedor, base.SesionActual.empresa.idempresa).lineas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarInsumo(int id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Insumo_Eliminar(new CotizarService.Insumo() { idinsumo = id }))
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