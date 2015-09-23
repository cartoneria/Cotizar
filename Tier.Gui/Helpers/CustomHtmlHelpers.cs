using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace Tier.Gui.Helpers
{
    public static class CustomHtmlHelpers
    {
        #region [Propiedades]
        public static string ApplicationName
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["ApplicationName"].ToString();
            }
        }
        #endregion

        #region [Menú]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="menuprincipal"></param>
        /// <returns></returns>
        public static string MenuElementosHijo(CotizarService.Funcionalidad menuprincipal)
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
    }
}