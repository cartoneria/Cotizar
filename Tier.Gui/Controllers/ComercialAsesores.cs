﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ComercialController : BaseController
    {
        private void CargarListasAsesores(CotizarService.Asesor obj)
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaAsesores()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ListaAsesores(string txtNombre, string txtCodigo)
        {
            IEnumerable<CotizarService.Asesor> lst = SAL.Asesores.RecuperarFiltrados(new CotizarService.Asesor()
            {
                nombre = string.IsNullOrEmpty(txtNombre) ? null : txtNombre,
                codigo = string.IsNullOrEmpty(txtCodigo) ? null : txtCodigo,
                empresa_idempresa = base.SesionActual.empresa.idempresa
            });

            return PartialView("_TablaAsesores", lst);
        }

        public ActionResult CrearAsesor()
        {
            this.CargarListasAsesores(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearAsesor(CotizarService.Asesor obj)
        {
            if (ModelState.IsValid)
            {
                byte? _idAsesor;

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Asesor_Insertar(obj, out _idAsesor) && _idAsesor != null)
                {
                    base.RegistrarNotificación("Asesor creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaAsesores", "Comercial");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasAsesores(obj);

            return View(obj);
        }

        public JsonResult ValidaCodigoAsesor(string codigo, byte empresa_idempresa, bool editando, string codigoinicial)
        {
            if (editando && (codigo.Equals(codigoinicial)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
            if (objService.Asesor_ValidaCodigo(new CotizarService.Asesor() { codigo = codigo, empresa_idempresa = empresa_idempresa }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", codigo);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = codigo + i.ToString();
                if (objService.Asesor_ValidaCodigo(new CotizarService.Asesor() { codigo = altCandidate, empresa_idempresa = empresa_idempresa }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", codigo, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditarAsesor(byte id)
        {
            CotizarService.Asesor obj = SAL.Asesores.RecuperarXId(id, base.SesionActual.empresa.idempresa);

            if (obj != null)
            {
                this.CargarListasAsesores(obj);

                return View(obj);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaAsesores", "Comercial");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAsesor(CotizarService.Asesor obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Asesor_Actualizar(obj))
                {
                    base.RegistrarNotificación("Asesor actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaAsesores", "Comercial");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasAsesores(obj);

            return View(obj);
        }

        public ActionResult EliminarAsesor(byte id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Asesor_Eliminar(new CotizarService.Asesor() { idasesor = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el asesor.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El asesor no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaAsesores", "Comercial");
        }
    }
}