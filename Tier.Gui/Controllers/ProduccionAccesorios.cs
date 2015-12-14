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
        private void CargarListasAccesorios(CotizarService.Accesorio obj)
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaAccesorios()
        {
            return View(SAL.Accesorios.RecuperarTodos(base.SesionActual.empresa.idempresa));
        }

        public ActionResult CrearAccesorio()
        {
            this.CargarListasAccesorios(null);
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="editando"></param>
        /// <param name="codigoinicial"></param>
        /// <returns></returns>
        public JsonResult ValidaCodigoAccesorio(string codigo, bool editando, string codigoinicial)
        {
            if (editando && (codigo.Equals(codigoinicial)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Accesorio_ValidaCodigo(new CotizarService.Accesorio() { codigo = codigo }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", codigo);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = codigo + i.ToString();
                if (objService.Accesorio_ValidaCodigo(new CotizarService.Accesorio() { codigo = altCandidate }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", codigo, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearAccesorio(CotizarService.Accesorio obj)
        {
            if (ModelState.IsValid)
            {
                int? _idAccesorio;

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Accesorio_Insertar(obj, out _idAccesorio) && _idAccesorio != null)
                {
                    base.RegistrarNotificación("Accesorio creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaAccesorios", "Produccion");
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

            this.CargarListasAccesorios(obj);
            return View(obj);
        }

        public ActionResult EditarAccesorio(int id)
        {
            CotizarService.Accesorio obj = SAL.Accesorios.RecuperarXId(id, base.SesionActual.empresa.idempresa);

            if (obj != null)
            {
                this.CargarListasAccesorios(obj);

                return View(obj);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaAccesorios", "Produccion");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarAccesorio(CotizarService.Accesorio obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Accesorio_Actualizar(obj))
                {
                    base.RegistrarNotificación("Accesorio actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaAccesorios", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de actualizacion.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasAccesorios(obj);
            return View(obj);
        }

        public ActionResult EliminarAccesorio(int id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Accesorio_Eliminar(new CotizarService.Accesorio() { idaccesorio = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el accesorio.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El accesorio no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaAccesorios", "Produccion");
        }
    }
}