using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Tier.Gui.Helpers
{
    public static class CustomHtmlHelpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementosmenu"></param>
        /// <returns></returns>
        public static IHtmlString Menu(IEnumerable<Dto.Funcionalidad> elementosmenu)
        {
            StringBuilder htmlString = new StringBuilder();

            if (elementosmenu.Count() <= 0)
            {
                htmlString.Append("<div style=\"width: 80%;text-align: center;margin: 0 auto;font-size: smaller;color: darkorange;\"><span>No se han configurado permisos para el rol asociado al usuario</span></div>");
            }

            foreach (Dto.Funcionalidad item in elementosmenu)
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
        private static string MenuElementosHijo(Dto.Funcionalidad menuprincipal)
        {
            StringBuilder htmlStringHijos = new StringBuilder();

            foreach (Dto.Funcionalidad item in menuprincipal.funcionalidades)
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
    }
}