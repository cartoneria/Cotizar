﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class SeguridadController : BaseController
    {
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

        public ActionResult Misdatos()
        {
            ViewBag.areas = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas, false), "iditemlista", "nombre", base.SesionActual.usuario.itemlista_iditemlistas_area.ToString());
            return View(SesionActual);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Misdatos(CotizarService.Sesion model)
        {
            if (!string.IsNullOrEmpty(model.usuario.nombrecompleto) && !string.IsNullOrEmpty(model.usuario.celular) && !string.IsNullOrEmpty(model.usuario.correoelectronico))
            {
                CotizarService.Usuario _obj = new CotizarService.Usuario
                {
                    idusuario = model.usuario.idusuario,
                    rol_idrol = model.usuario.rol_idrol,
                    empresa_idempresa = model.usuario.empresa_idempresa,
                    celular = model.usuario.celular,
                    correoelectronico = model.usuario.correoelectronico,
                    nombrecompleto = model.usuario.nombrecompleto,
                    activo = true
                };

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Usuario_Actualizar(_obj))
                {
                    base.RegistrarNotificación("Datos actualizados con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    SesionActual.usuario = model.usuario;
                    return RedirectToAction("Index", "Home");
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

            ViewBag.areas = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas, false), "iditemlista", "nombre", base.SesionActual.usuario.itemlista_iditemlistas_area.ToString());
            return View(SesionActual);
        }


        [AllowAnonymous]
        public ActionResult TimeOut()
        {
            Session.Abandon();
            return View("TimeOut");
        }

        public ActionResult ContinueSession()
        {
            return new EmptyResult();
        }
    }
}