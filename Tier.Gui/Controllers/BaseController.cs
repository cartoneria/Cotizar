using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tier.Gui.Controllers
{
    public class BaseController : Controller
    {
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
                    { "client", filterContext.RouteData.Values[ "client" ] },
                    { "controller", "Seguridad" },
                    { "action", "InicioSesion" },
                    { "ReturnUrl", filterContext.HttpContext.Request.RawUrl }
                });
            }
        }

        protected void RegistrarNotificación(string Mensaje, Models.Enumeradores.TiposNotificaciones Tipo, string Titulo)
        {
            TempData["MostrarNotificacion"] = new HtmlString("{" + string.Format("\"Mensaje\":\"{0}\",\"TipoNotificaciones\":\"{1}\",\"Titulo\":\"{2}\"", Mensaje, Tipo, Titulo) + "}");
        }

        protected void HandleException(Exception ex)
        {

        }
    }
}