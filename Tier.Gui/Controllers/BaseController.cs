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
        public Dto.Sesion SesionActual
        {
            get
            {
                return (Dto.Sesion)Session["SesionActual"];
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

        protected void HandleException(Exception ex)
        {

        }
    }
}