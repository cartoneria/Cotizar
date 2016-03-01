using System;
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

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            bool blnSaltarAutorizacion = filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true)
                || filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), inherit: true);

            if (this.SesionActual != null || blnSaltarAutorizacion)
                base.OnActionExecuting(filterContext);
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