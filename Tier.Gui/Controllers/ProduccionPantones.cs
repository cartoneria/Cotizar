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
        public ActionResult ListaPantones()
        {
            return View(SAL.Pantones.RecuperarTodos());
        }

        public ActionResult CrearPantone()
        {
            return View();
        }

        public JsonResult ValidaNombrePantone(string nombre, string nombreinicial, bool editando)
        {
            if (editando && (nombre.Equals(nombreinicial)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
            if (objService.Pantone_ValidaNombre(new CotizarService.Pantone() { nombre = nombre }))
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

        public JsonResult ValidaColorHEXPantone(string hex, string hexinicial, bool editando)
        {
            if (editando && (hex.Equals(hexinicial)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
            if (objService.Pantone_ValidaColor(new CotizarService.Pantone() { hex = hex }))
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

            return View(obj);
        }

        [HttpPost]
        public JsonResult ObtenerPantonesTodosJson()
        {
            IList<CotizarService.Pantone> pantones = SAL.Pantones.RecuperarTodos().ToList();

            return Json(pantones, JsonRequestBehavior.AllowGet);
        }

    }
}