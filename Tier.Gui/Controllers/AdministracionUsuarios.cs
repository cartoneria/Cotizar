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
        public ActionResult ListaUsuarios()
        {
            return View(SAL.Usuarios.RecuperarTodos());
        }

        public ActionResult CrearUsuario()
        {
            ViewBag.lstRoles = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre");
            ViewBag.lstEmpresas = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.lstAreas = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre");

            return View();
        }

        public JsonResult ValidaNombreUsuario(string usuario, bool editando, string usuarioinicial)
        {
                if (editando && (usuario == usuarioinicial))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Usuario_ValidaNombreUsuario(new CotizarService.Usuario() { usuario = usuario }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", usuario);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = usuario + i.ToString();
                if (objService.Usuario_ValidaNombreUsuario(new CotizarService.Usuario() { usuario = altCandidate }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", usuario, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(CotizarService.Usuario obj)
        {
            //La clave se la asigna la logica del servicio.
            if (ModelState.IsValid)
            {
                short? _idUsuario;
                
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Usuario_Insertar(obj, out _idUsuario) && obj != null)
                {
                    base.RegistrarNotificación("Usuario creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaUsuarios", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            ViewBag.lstRoles = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre");
            ViewBag.lstEmpresas = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.lstAreas = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre");

            return View(obj);
        }

        public ActionResult EditarUsuario(short id)
        {
            CotizarService.Usuario _objUsuario = SAL.Usuarios.RecuperarTodos().Where(m => m.idusuario == id).FirstOrDefault();

            ViewBag.rol_idrol = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre", _objUsuario.rol_idrol.ToString());
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", _objUsuario.empresa_idempresa.ToString());
            ViewBag.itemlista_iditemlistas_area = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre", _objUsuario.itemlista_iditemlistas_area.ToString());

            return View(_objUsuario);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(CotizarService.Usuario obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Usuario_Actualizar(obj))
                {
                    base.RegistrarNotificación("Usuario actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaUsuarios", "Administracion");
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

        [HttpGet]
        public ActionResult EliminarUsuario(short id)
        {
            try
            {

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();

                if (_Service.Usuario_Eliminar(new CotizarService.Usuario { idusuario = id }))
                {

                    base.RegistrarNotificación("Usuario eliminado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaUsuarios", "Administracion");
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
            return RedirectToAction("ListaUsuarios", "Administracion");
        }
    }
}