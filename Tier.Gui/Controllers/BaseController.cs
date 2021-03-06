﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tier.Gui.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        public CotizarService.Sesion SesionActual
        {
            get
            {
                return (CotizarService.Sesion)Session["SesionActual"];
            }
            set
            {
                Session["SesionActual"] = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public CotizarService.PedidoModel TempPedido
        {
            get
            {
                return (CotizarService.PedidoModel)Session["tempPedido"];
            }
            set
            {
                Session["tempPedido"] = value;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool blnSaltarAutorizacion = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (this.SesionActual != null || blnSaltarAutorizacion)
            {
                //if (!(filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Comercial" && filterContext.ActionDescriptor.ActionName == "CrearPedido"))
                //{
                //    this.TempPedido = null;
                //}

                base.OnActionExecuting(filterContext);
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    { "controller", "Seguridad" },
                    { "action", "InicioSesion" },
                    { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                });
            }
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            System.Diagnostics.Debugger.Break();

            string modulo = Logs.GetControllerName(filterContext.Controller.ToString());

            Logs.Error(filterContext.Exception, modulo);
            base.OnException(filterContext);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Tipo"></param>
        /// <param name="Titulo"></param>
        protected void RegistrarNotificación(string Mensaje, Models.Enumeradores.TiposNotificaciones Tipo, string Titulo)
        {
            TempData["MostrarNotificacion"] = new HtmlString("{" + string.Format("\"Mensaje\":\"{0}\",\"TipoNotificaciones\":\"{1}\",\"Titulo\":\"{2}\"", Mensaje, Tipo, Titulo) + "}");
        }

        /// <summary>
        /// 
        /// </summary>
        protected void ActualizarMenuUsuario()
        {
            this.SesionActual = SAL.Usuarios.ActualizarMenuUsuario(this.SesionActual.usuario.idusuario, this.SesionActual.usuario.empresa_idempresa);
        }

        protected void AlistarRutaArchivo(string ruta)
        {
            // Determine whether the directory exists.
            if (System.IO.Directory.Exists(ruta))
            {
                return;
            }

            // Try to create the directory.
            System.IO.DirectoryInfo di = System.IO.Directory.CreateDirectory(ruta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="troqueles"></param>
        protected void ComplementarNombreTroquel(IEnumerable<CotizarService.Troquel> troqueles)
        {
            foreach (var item in troqueles)
            {
                item.descripcion = string.Format("{0} E:{1}, T:{2}, F:{3}, CF:{4}, CT:{5}, LA:{6}, AL:{7}, AN:{8}", item.descripcion, item.estilo_codestilo, item.tamanio, item.fibra, item.contrafibra, (item.cabidafibra * item.cabidacontrafibra), item.largo, item.alto, item.ancho);
            }
        }
    }

    public static class Logs
    {
        #region [Logs]
        /// <summary>
        /// 
        /// </summary>
        public enum TraceTypes : byte
        {
            error = 1,
            warning = 2,
            info = 3
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContextController"></param>
        public static string GetControllerName(string filterContextController)
        {
            string result = string.Empty;

            string[] arr = filterContextController.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            result = arr.Where(ee => ee.Contains("Controller")).LastOrDefault().Replace("Controller", string.Empty);

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="module"></param>
        public static void Error(Exception ex, string module)
        {
            WriteEntry(ex.ToString(), TraceTypes.error, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Warning(string message, string module)
        {
            WriteEntry(message, TraceTypes.warning, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Info(string message, string module)
        {
            WriteEntry(message, TraceTypes.info, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="module"></param>
        private static void WriteEntry(string message, TraceTypes type, string module)
        {
            Trace.WriteLine(string.Format("{0}|{1}|{2}|{3}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                type,
                module,
                message)
            );
        }
        #endregion
    }
}