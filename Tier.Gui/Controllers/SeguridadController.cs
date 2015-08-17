using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class SeguridadController : BaseController
    {
        // GET: Seguridad
        [AllowAnonymous]
        public ActionResult InicioSesion()
        {
            ViewBag.ddlEmpresas = new SelectList(new Business.BEmpresa().RecuperarFiltrado(new Dto.Empresa()), "idempresa", "razonsocial");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult InicioSesion(string txtUsuarioIniciar, string txtClaveIniciar, Nullable<byte> ddlEmpresaIngresar)
        {
            Dto.Sesion objSesion = new Business.BUsuario().IniciarSesion(new Dto.Usuario() { usuario = txtUsuarioIniciar, clave = txtClaveIniciar, empresa_idempresa = ddlEmpresaIngresar });
            if (objSesion != null)
            {
                base.SesionActual = objSesion;
                return Json(new { blnResultado = true });
            }
            else
                return Json(new { blnResultado = false, blnMensaje = Recursos.InicioSesionNoUsuario });
        }

        [AllowAnonymous]
        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("InicioSesion", "Seguridad");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RestablecerClave()
        {
            return View();
        }
    }
}