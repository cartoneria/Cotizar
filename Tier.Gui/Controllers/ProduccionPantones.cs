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
        private void CargarListasPantones(CotizarService.Pantone obj)
        {
            if (obj != null)
            {

            }
            else
            {

            }

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaPantones()
        {
            return View(SAL.Pantones.RecuperarTodos());
        }

        public ActionResult CrearPantone()
        {
            this.CargarListasPantones(null);
            return View();
        }

        public JsonResult ValidaNombrePantone(string nombre, string nombreinicial, byte empresa_idempresa, bool editando)
        {
            if (editando && (nombre.Equals(nombreinicial) && empresa_idempresa.Equals(base.SesionActual.empresa.idempresa)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
            if (objService.Pantone_ValidaNombre(new CotizarService.Pantone() { nombre = nombre, empresa_idempresa = empresa_idempresa }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", nombre);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = nombre + i.ToString();
                if (objService.Pantone_ValidaNombre(new CotizarService.Pantone() { nombre = altCandidate }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", nombre, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ValidaColorHEXPantone(string hex, string hexinicial, byte empresa_idempresa, bool editando)
        {
            if (editando && (hex.Equals(hexinicial) && empresa_idempresa.Equals(base.SesionActual.empresa.idempresa)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
            if (objService.Pantone_ValidaColor(new CotizarService.Pantone() { hex = hex, empresa_idempresa = empresa_idempresa }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", hex);

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPantone(CotizarService.Pantone obj)
        {
            if (ModelState.IsValid)
            {
                Nullable<int> _IdPantone;

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Pantone_Insertar(obj, out _IdPantone) && _IdPantone != null)
                {
                    base.RegistrarNotificación("Pantone creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaPantones", "Produccion");
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

            this.CargarListasPantones(obj);
            return View(obj);
        }

        public ActionResult EditarPantone(int id)
        {
            CotizarService.Pantone objPantone = SAL.Pantones.RecuperarXId(id);

            this.CargarListasPantones(objPantone);
            return View(objPantone);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPantone(CotizarService.Pantone obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Pantone_Actualizar(obj))
                {
                    base.RegistrarNotificación("Pantone actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaPantones", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de actualización.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasPantones(obj);
            return View(obj);
        }

        public ActionResult EliminarPantone(int id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Pantone_Eliminar(new CotizarService.Pantone() { idpantone = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el pantone.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El pentone no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaPantones", "Produccion");
        }

        [HttpPost]
        public JsonResult ObtenerPantonesTodosJson()
        {
            IList<CotizarService.Pantone> pantones = SAL.Pantones.RecuperarTodos().ToList();

            return Json(pantones, JsonRequestBehavior.AllowGet);
        }

    }
}