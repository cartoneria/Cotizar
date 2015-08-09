using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Services
{
    public static class Utilidades
    {
        /// <summary>
        /// 
        /// </summary>
        public enum PlantillasCorreo
        {
            CreaciónUsuario = 1,
            RestablecerClave = 2
        }

        /// <summary>
        /// 
        /// </summary>
        internal static string RutaPlantillasCorreos
        {
            get
            {
#if DEBUG
                return AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug", string.Empty);
#else
                return HttpContext.Current.Server.MapPath(".");
#endif
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
                    strResult = System.IO.File.ReadAllText(RutaPlantillasCorreos + "PlantillasCorreos\\UsuarioCreacionUsuario.html");
                    strResult = strResult.Replace("[xxasuntoxxx]", asunto);
                    strResult = strResult.Replace("[xxxNombreCompletoxxx]", (string)datos[0]);
                    strResult = strResult.Replace("[xxxUsuarioxxx]", (string)datos[1]);
                    strResult = strResult.Replace("[xxxClavexxx]", (string)datos[2]);
                    strResult = strResult.Replace("[xxxDireccionAplicacionxxx]", URILoginAplicacionWeb);
                    break;
                case PlantillasCorreo.RestablecerClave:
                    strResult = System.IO.File.ReadAllText(RutaPlantillasCorreos + "PlantillasCorreos\\UsuarioRestablecerClave.html");
                    strResult = strResult.Replace("[xxasuntoxxx]", asunto);
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
    }
}
