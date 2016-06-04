using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tier.Business
{
    public static class Utilidades
    {
        #region [Enumeradores]
        /// <summary>
        /// 
        /// </summary>
        public enum PlantillasCorreo
        {
            CreaciónUsuario = 1,
            RestablecerClave = 2,
            CambioClave = 3
        }
        #endregion

        #region [Propiedades]
        /// <summary>
        /// 
        /// </summary>
        internal static string RutaPlantillasReportes
        {
            get
            {
                string strRuta = System.Configuration.ConfigurationManager.AppSettings["RutaPlantillasReportes"].ToString();
                return (strRuta.EndsWith(@"\") ? strRuta : strRuta + @"\");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string RutaPlantillasCorreos
        {
            get
            {
                string strRuta = System.Configuration.ConfigurationManager.AppSettings["RutaPlantillasCorreo"].ToString();
                return (strRuta.EndsWith(@"\") ? strRuta : strRuta + @"\");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string RutaRecursos
        {
            get
            {
                string strRuta = System.Configuration.ConfigurationManager.AppSettings["RutaRecursos"].ToString();
                return (strRuta.EndsWith(@"\") ? strRuta : strRuta + @"\");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string URILoginAplicacionWeb
        {
            get
            {
                return System.Configuration.ConfigurationManager.AppSettings["URILoginAplicacionWeb"].ToString();
            }
        }
        #endregion

        #region [Metodos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="destinatario"></param>
        /// <param name="asunto"></param>
        /// <param name="plantilla"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static bool EnviarCorreo(string destinatario, string asunto, PlantillasCorreo plantilla, params object[] datos)
        {
            try
            {
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();

                var smtpSection = (System.Net.Configuration.SmtpSection)System.Configuration.ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                string username = smtpSection.Network.UserName;

                asunto = Recursos.NombreAplicacion + " - " + asunto;

                System.Net.Mail.MailMessage objMail = new System.Net.Mail.MailMessage(username, destinatario, asunto, GenerarCuerpoCorreo(plantilla, asunto, datos));
                objMail.IsBodyHtml = true;
                objMail.BodyEncoding = UTF8Encoding.UTF8;
                objMail.DeliveryNotificationOptions = System.Net.Mail.DeliveryNotificationOptions.OnFailure;

                client.Send(objMail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="asunto"></param>
        /// <param name="datos"></param>
        /// <returns></returns>
        private static string GenerarCuerpoCorreo(PlantillasCorreo plantilla, string asunto, params object[] datos)
        {
            string strResult;

            switch (plantilla)
            {
                case PlantillasCorreo.CreaciónUsuario:
                    strResult = System.IO.File.ReadAllText(RutaPlantillasCorreos + "UsuarioCreacionUsuario.html");
                    strResult = strResult.Replace("[xxAsuntoxxx]", asunto);
                    strResult = strResult.Replace("[xxxNombreCompletoxxx]", (string)datos[0]);
                    strResult = strResult.Replace("[xxxUsuarioxxx]", (string)datos[1]);
                    strResult = strResult.Replace("[xxxClavexxx]", (string)datos[2]);
                    strResult = strResult.Replace("[xxxDireccionAplicacionxxx]", URILoginAplicacionWeb);
                    break;
                case PlantillasCorreo.RestablecerClave:
                    strResult = System.IO.File.ReadAllText(RutaPlantillasCorreos + "UsuarioRestablecerClave.html");
                    strResult = strResult.Replace("[xxAsuntoxxx]", asunto);
                    strResult = strResult.Replace("[xxxUsuarioxxx]", (string)datos[0]);
                    strResult = strResult.Replace("[xxxClavexxx]", (string)datos[1]);
                    strResult = strResult.Replace("[xxxDireccionAplicacionxxx]", URILoginAplicacionWeb);
                    break;
                case PlantillasCorreo.CambioClave:
                    strResult = System.IO.File.ReadAllText(RutaPlantillasCorreos + "UsuarioCambioClave.html");
                    strResult = strResult.Replace("[xxAsuntoxxx]", asunto);
                    strResult = strResult.Replace("[xxxUsuarioxxx]", (string)datos[0]);
                    strResult = strResult.Replace("[xxxClavexxx]", (string)datos[1]);
                    strResult = strResult.Replace("[xxxDireccionAplicacionxxx]", URILoginAplicacionWeb);
                    break;
                default:
                    strResult = string.Empty;
                    break;
            }

            return strResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string RecuperarXMLParametrosPredefinidos()
        {
            return System.IO.File.ReadAllText(RutaRecursos + "ParametrosPredefinidos.xml");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Dto.Esacala> RecuperarEscalas()
        {
            string strXmlEsclas = System.IO.File.ReadAllText(RutaRecursos + "EscalasCotizaciones.xml");
            XDocument objXmlDocEscalas = new XDocument();
            objXmlDocEscalas = XDocument.Parse(strXmlEsclas);

            return objXmlDocEscalas.Descendants("escala").Select(ee => new Dto.Esacala()
            {
                Nombre = ee.Value,
                Orden = Convert.ToByte(ee.Attribute("orden").Value),
                Cantidad = Convert.ToInt16(ee.Attribute("cant").Value)
            }).ToList();
        }
        #endregion
    }
}
