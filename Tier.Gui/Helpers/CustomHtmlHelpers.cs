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
        /// <summary>
        /// 
        /// </summary>
        public static string RutaImagenes
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["RutaImagenes"].ToString();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="opcion"></param>
        /// <param name="estadoPedido"></param>
        /// <returns></returns>
        public static bool ValidarVisibilidadOpcionesPedido(string opcion, Models.Enumeradores.EstadosPedido estadoPedido, bool procesado)
        {
            bool blnVisible = false;

            switch (opcion)
            {
                case "guardar":
                    if (estadoPedido == Models.Enumeradores.EstadosPedido.Creacion ||
                        ((estadoPedido == Models.Enumeradores.EstadosPedido.BloqueadoCartera ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.BloqueadoMaterial) &&
                        !procesado))
                    {
                        blnVisible = true;
                    }
                    break;
                case "formato":
                    if (estadoPedido != Models.Enumeradores.EstadosPedido.Creacion && procesado)
                    {
                        blnVisible = true;
                    }
                    break;
                case "bloqueo":
                    if (estadoPedido == Models.Enumeradores.EstadosPedido.Creacion ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.EnFabricacion ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.Devuelto)
                    {
                        blnVisible = true;
                    }
                    break;
                case "cancelar":
                    if (estadoPedido != Models.Enumeradores.EstadosPedido.Despachado &&
                        estadoPedido != Models.Enumeradores.EstadosPedido.Entregado &&
                        estadoPedido != Models.Enumeradores.EstadosPedido.Cancelado &&
                        estadoPedido != Models.Enumeradores.EstadosPedido.Terminado)
                    {
                        blnVisible = true;
                    }
                    break;
                case "fabricacion":
                    if (estadoPedido == Models.Enumeradores.EstadosPedido.BloqueadoCartera ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.BloqueadoMaterial ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.Devuelto)
                    {
                        blnVisible = true;
                    }
                    break;
                case "logistica":
                    if (estadoPedido == Models.Enumeradores.EstadosPedido.BloqueadoCartera ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.BloqueadoMaterial ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.EnFabricacion ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.Devuelto ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.Despachado)
                    {
                        blnVisible = true;
                    }
                    break;
                case "devuelto":
                    if (estadoPedido == Models.Enumeradores.EstadosPedido.Despachado)
                    {
                        blnVisible = true;
                    }
                    break;
                case "terminar":
                    if (estadoPedido == Models.Enumeradores.EstadosPedido.Entregado ||
                        estadoPedido == Models.Enumeradores.EstadosPedido.Cancelado)
                    {
                        blnVisible = true;
                    }
                    break;
                default:
                    blnVisible = false;
                    break;
            }

            return blnVisible;
        }

        #endregion
    }
}