using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using System.Globalization;
using System.Text;

namespace Tier.Gui.Controllers
{
    public partial class AdministracionController : BaseController
    {
        public ActionResult ListaListas()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult RecuperarItemsListaGrupo(byte intIdGrupo)
        {
            IEnumerable<CotizarService.ItemLista> lst = SAL.ItemsListas.RecuperarGrupo(intIdGrupo);
            return PartialView("_ItemsListaGrupo", lst);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearItemLista(CotizarService.ItemLista obj)
        {

            if (ModelState.IsValid)
            {
                int? idItem;
                CotizarService.ItemLista _nitemLista = new CotizarService.ItemLista
                {
                    activo = obj.activo,
                    grupo = obj.grupo,
                    iditemlista = obj.iditemlista,
                    idpadre = obj.idpadre,
                    items = obj.items,
                    nombre = obj.nombre
                };

                CotizarService.CotizarServiceClient _Client = new CotizarService.CotizarServiceClient();
                if (_Client.ItemLista_Insertar(_nitemLista, out idItem) && idItem != null)
                {
                    base.RegistrarNotificación("El item se ha creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaListas", "Administracion");
                }

                else
                {
                    base.RegistrarNotificación("Error en el servicio de inserción", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            return View("ListaListas");
        }

        public JsonResult ValidaNombreItemLista(string nombre, byte grupo, bool editando)
        {
            if (editando)
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.ItemLista_ValidaNombre(new CotizarService.ItemLista() { nombre = nombre, grupo = grupo }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", nombre);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = nombre + i.ToString();
                if (objService.ItemLista_ValidaNombre(new CotizarService.ItemLista() { nombre = altCandidate, grupo = grupo }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", nombre, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EliminarItemLista(short id)
        {
            try
            {
                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();

                if (_Service.ItemLista_Eliminar(new CotizarService.ItemLista { iditemlista = id }))
                {
                    base.RegistrarNotificación("Item eliminado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaListas", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                }
            }
            catch (Exception)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaListas", "Administracion");
        }

        [HttpGet]
        public JsonResult EditarItemLista(short iditem, byte idgrupo)
        {
            IEnumerable<CotizarService.ItemLista> lst = SAL.ItemsListas.RecuperarGrupo(idgrupo);

            lst = lst.Where(i => i.iditemlista == iditem);

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarItemLista(CotizarService.ItemLista obj)
        {

            if (ModelState.IsValid)
            {
                //int? idItem;
                CotizarService.ItemLista _nitemLista = new CotizarService.ItemLista
                {
                    activo = obj.activo,
                    grupo = obj.grupo,
                    iditemlista = obj.iditemlista,
                    idpadre = obj.idpadre,
                    items = obj.items,
                    nombre = obj.nombre
                };

                CotizarService.CotizarServiceClient _Client = new CotizarService.CotizarServiceClient();
                //&& idItem != null  -> Pendiente
                if (_Client.ItemLista_Actualizar(_nitemLista))
                {
                    base.RegistrarNotificación("El item se ha actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaListas", "Administracion");
                }

                else
                {
                    base.RegistrarNotificación("Error en el servicio de actualización", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            return View("ListaListas");
        }
    }
}