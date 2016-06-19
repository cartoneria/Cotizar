using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;

namespace Tier.Gui.Helpers
{
    public static class CustomHtmlHelpers
    {
        #region [Propiedades]
        /// <summary>
        /// 
        /// </summary>
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
            string strDominioSitio = System.Configuration.ConfigurationManager.AppSettings["SubdominioSitio"];

            foreach (CotizarService.Funcionalidad item in menuprincipal.funcionalidades)
            {
                htmlStringHijos.Append("<li><a href=\"" + (string.IsNullOrEmpty(strDominioSitio) ? string.Empty : strDominioSitio) + "/" + item.mvccontroller + "/" + item.mvcaction + "\">" + item.titulo + "</a>");

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

        #region [Metodos Estáticos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sl"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RecTextoSL(SelectList sl, object value)
        {
            SelectListItem sli = sl.Where(ee => ee.Value == value.ToString()).FirstOrDefault();
            return (sli != null ? sli.Text : "N/A");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstDetalles"></param>
        /// <param name="objDetalle"></param>
        /// <returns></returns>
        public static float ObtenerCantidadMaxPedido(IList<Tier.Gui.CotizarService.CotizacionDetalle> lstDetalles, Tier.Gui.CotizarService.CotizacionDetalle objDetalle)
        {
            float cantMax = -1;

            int idx = lstDetalles.IndexOf(objDetalle);

            if (idx == (lstDetalles.Count - 1))
            {
                cantMax = int.MaxValue;
            }
            else
            {
                cantMax = lstDetalles.ElementAt(idx + 1).escala.HasValue ? ((float)lstDetalles.ElementAt(idx + 1).escala - 1) : -1;
            }

            return cantMax;
        }
        #endregion
    }
}