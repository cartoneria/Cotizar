using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class ComercialController : BaseController
    {
        //
        // GET: /Comercial/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaAsesores()
        {
            return View(SAL.Asesores.RecuperarTodos());
        }

        public ActionResult CrearAsesor()
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearAsesor(CotizarService.Asesor obj)
        {
            if (ModelState.IsValid)
            {
                byte? _idAsesor;

                CotizarService.Asesor _nAsesor = new CotizarService.Asesor
                {
                    activo = obj.activo,
                    codigo = obj.codigo,
                    comision = obj.comision,
                    correoelectronico = obj.correoelectronico,
                    empresa_idempresa = obj.empresa_idempresa,
                    fechacreacion = DateTime.Now,
                    nombre = obj.nombre,
                    telefono = obj.telefono
                };

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Asesor_Insertar(_nAsesor, out _idAsesor) && _idAsesor != null)
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

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            return View();
        }

        public JsonResult ValidaCodigoAsesor(string codigo, byte empresa_idempresa)
        {
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
    }
}
