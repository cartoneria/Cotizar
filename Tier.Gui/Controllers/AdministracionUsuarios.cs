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
        private void CargarListasUsuarios(CotizarService.Usuario obj)
        {
            if (obj != null)
            {
                ViewBag.rol_idrol = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre", obj.rol_idrol);
                ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", obj.empresa_idempresa);
                ViewBag.itemlista_iditemlistas_area = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre", obj.itemlista_iditemlistas_area);
            }
            else
            {
                ViewBag.rol_idrol = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre");
                ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
                ViewBag.itemlista_iditemlistas_area = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre");
            }
        }

        public ActionResult ListaUsuarios()
        {
            return View(SAL.Usuarios.RecuperarTodos(base.SesionActual.empresa.idempresa));
        }

        public ActionResult CrearUsuario()
        {
            this.CargarListasUsuarios(null);
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
            CotizarService.Usuario _objUsuario = SAL.Usuarios.RecuperarXId(id, base.SesionActual.empresa.idempresa);

            if (_objUsuario != null)
            {
                this.CargarListasUsuarios(_objUsuario);

                return View(_objUsuario);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaUsuarios", "Administracion");
            }
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