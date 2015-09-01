using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Tier.Gui.Helpers
{
    public static class CustomHtmlHelpers
    {
        #region [Menú]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementosmenu"></param>
        /// <returns></returns>
        public static IHtmlString Menu(IEnumerable<CotizarService.Funcionalidad> elementosmenu)
        {
            StringBuilder htmlString = new StringBuilder();

            if (elementosmenu.Count() <= 0)
            {
                htmlString.Append("<div style=\"width: 80%;text-align: center;margin: 0 auto;font-size: smaller;color: darkorange;\"><span>" + Recursos.RolSinPermisos + "</span></div>");
            }

            foreach (CotizarService.Funcionalidad item in elementosmenu)
            {
                htmlString.Append("<li>");
                htmlString.Append("<a><i class=\"fa " + item.icono + "\"></i> " + item.titulo + " <span class=\"fa fa-chevron-down\"></span></a>");
                htmlString.Append("<ul class=\"nav child_menu\" style=\"display: none\">");
                htmlString.Append(MenuElementosHijo(item));
                htmlString.Append("</ul>");
                htmlString.Append("</li>");
            }

            return new HtmlString(htmlString.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuprincipal"></param>
        /// <returns></returns>
        private static string MenuElementosHijo(CotizarService.Funcionalidad menuprincipal)
        {
            StringBuilder htmlStringHijos = new StringBuilder();

            foreach (CotizarService.Funcionalidad item in menuprincipal.funcionalidades)
            {
                htmlStringHijos.Append("<li><a href=\"" + "/" + item.mvccontroller + "/" + item.mvcaction + "\">" + item.titulo + "</a>");

                if (item.funcionalidades.Count() > 0)
                {
                    htmlStringHijos.Append("<ul class=\"nav child_menu\" style=\"display: none\">");
                    htmlStringHijos.Append(MenuElementosHijo(item));
                    htmlStringHijos.Append("</ul>");
                }

                htmlStringHijos.Append("</li>");
            }

            return htmlStringHijos.ToString();
        }
        #endregion

        #region [Rol]
        public static IHtmlString RolFuncionalidades(IEnumerable<CotizarService.Funcionalidad> funcionalidades)
        {
            StringBuilder htmlString = new StringBuilder();

            if (funcionalidades.Count() <= 0)
            {
                htmlString.Append("<div style=\"width: 80%;text-align: center;margin: 0 auto;font-size: smaller;color: darkorange;\"><span>" + Recursos.ApplicacionSinFuncionalidades + "</span></div>");
            }

            htmlString.Append("<div class=\"col-xs-3\">");
            htmlString.Append("<!-- required for floating -->");
            htmlString.Append("<!-- Nav tabs -->");
            htmlString.Append("<ul class=\"nav nav-tabs tabs-left\">");

            //Se filtran las funcionalidades hijas del menú principal.
            IEnumerable<CotizarService.Funcionalidad> funcionalidadesHijas = funcionalidades.Where(ee => ee.idpadre != null).AsEnumerable();

            string strNombreContenedor = string.Empty;

            foreach (var funci in funcionalidadesHijas)
            {
                strNombreContenedor = funci.mvccontroller + "_" + funci.mvcaction;

                htmlString.Append("<li><a href=\"#" + strNombreContenedor + "\" data-toggle=\"tab\">" + funci.titulo + "</a></li>");
            }

            htmlString.Append("</ul>");
            htmlString.Append("</div>");

            htmlString.Append("<div class=\"col-xs-9\">");
            htmlString.Append("<!-- Tab panes -->");
            htmlString.Append("<div class=\"tab-content\">");
            foreach (var funci in funcionalidadesHijas)
            {
                strNombreContenedor = funci.mvccontroller + "_" + funci.mvcaction;
                htmlString.Append("<div class=\"tab-pane\" id=\"" + strNombreContenedor + "\">");
                htmlString.Append("<h4>Acciones permitidas</h4>");
                //htmlString.Append("<span class=\"label label-primary\">Seleccionar todos</span>");
                //htmlString.Append("&nbsp;");
                //htmlString.Append("<span class=\"label label-danger\">Ninguno</span>");

                foreach (CotizarService.Accion acc in funci.acciones)
                {
                    htmlString.Append("<div class=\"checkbox\">");
                    htmlString.Append("<label><input type=\"checkbox\" id=\"" + "chk_" + funci.idfuncionalidad + "_" + acc.idaccion + "\" value=\"\">" + acc.nombre + "</label>");
                    htmlString.Append("</div>");
                }

                htmlString.Append("</div>");
            }

            htmlString.Append("</div>");
            htmlString.Append("</div>");

            return new HtmlString(htmlString.ToString());
        }
        #endregion
    }
}