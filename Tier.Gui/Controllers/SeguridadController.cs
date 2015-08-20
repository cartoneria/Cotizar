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
            //Recuperar listado de empresas ddlEmpresas
            ViewBag.ddlEmpresas = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult InicioSesion(string txtUsuarioIniciar, string txtClaveIniciar, Nullable<byte> ddlEmpresaIngresar)
        {
            JsonResult objRespuesta;

            //Buscar usuario con las credenciales suministradas.
            CotizarService.Sesion objSesion = SAL.Usuarios.IniciarSesion(txtUsuarioIniciar, txtClaveIniciar, ddlEmpresaIngresar);
            if (objSesion != null)
            {
                base.SesionActual = objSesion;
                objRespuesta = Json(new { blnResultado = true, strMensaje = Recursos.InicioSesionOk });
            }
            else
                objRespuesta = Json(new { blnResultado = false, strMensaje = Recursos.InicioSesionNoUsuario });

            return objRespuesta;
        }

        [AllowAnonymous]
        public ActionResult CerrarSesion()
        {
            Session.Abandon();
            return RedirectToAction("InicioSesion", "Seguridad");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RestablecerClave(string txtUsuarioRecuperar, string txtEmailRecuperar, Nullable<byte> ddlEmpresaRecuperar)
        {
            JsonResult respuesta;

            try
            {
                //Buscar usuario con esos datos
                CotizarService.Usuario objUsuario = SAL.Usuarios.RecuperarUsuarioRestablecerClave(txtUsuarioRecuperar, txtEmailRecuperar, ddlEmpresaRecuperar);

                if (objUsuario != null)
                {
                    //Restablecer clave
                    bool blnRespuesta = SAL.Usuarios.RestablecerClave(objUsuario.idusuario, objUsuario.usuario, objUsuario.correoelectronico);

                    //Notificar resultado restablecer
                    if (blnRespuesta)
                        respuesta = Json(new { blnResultado = true, strMensaje = Recursos.RestablecerClaveOk });
                    else
                        respuesta = Json(new { blnResultado = false, strMensaje = Recursos.RestablecerClaveFallo });
                }
                else
                {
                    respuesta = Json(new { blnResultado = false, strMensaje = Recursos.InicioSesionNoUsuario });
                }
            }
            catch (Exception)
            {
                //Tratar el error.
                respuesta = Json(new { blnResultado = false, strMensaje = Recursos.ErrorGeneral });
            }

            return respuesta;
        }
    }
}