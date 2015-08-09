using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BUsuario : ParentBusiness
    {
        internal char[] arrCaracteres = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        internal char[] arrNumeros = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        internal char[] arrSimbolos = new char[] { '!', '.', '%', '&', '/', '(', ')', '=', '?', '*', '|', '#', '\\', '@', '[', ']', '{', '}', '-', '_', '+' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Usuario obj)
        {
            string strClave = obj.usuario.Substring(0, 4)
                + arrNumeros[new Random().Next(10)]
                + arrNumeros[new Random().Next(10)]
                + arrCaracteres[new Random().Next(26)]
                + arrSimbolos[new Random().Next(21)];

            obj.clave = strClave;

            bool blnResul = new Data.DUsuario().Insertar(obj);
            if (blnResul)
            {
                try
                {
                    Utilidades.EnviarCorreo(obj.correoelectronico, Recursos.MsgMailUsuarioCreacion, Utilidades.PlantillasCorreo.CreaciónUsuario, obj.nombrecompleto, obj.usuario, obj.clave);
                }
                catch (Exception)
                {
                    //Procesar error
                    throw;
                }
            }

            return blnResul;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Usuario> RecuperarFiltrado(Dto.Usuario obj)
        {
            return new Data.DUsuario().RecuperarFiltrados(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Usuario obj)
        {
            return new Data.DUsuario().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Usuario obj)
        {
            return new Data.DUsuario().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool RestablecerClave(Dto.Usuario obj)
        {
            string strClave = obj.usuario.Substring(0, 4)
                + arrNumeros[new Random().Next(10)]
                + arrNumeros[new Random().Next(10)]
                + arrCaracteres[new Random().Next(26)]
                + arrSimbolos[new Random().Next(21)];

            obj.clave = strClave;

            bool blnResult = new Data.DUsuario().RestablecerClave(obj);
            if (blnResult)
            {
                try
                {
                    Utilidades.EnviarCorreo(obj.correoelectronico, Recursos.MsgMailUsuarioRestablecerClave, Utilidades.PlantillasCorreo.RestablecerClave, obj.usuario, obj.clave);
                }
                catch (Exception)
                {
                    //Procesar error
                    throw;
                }
            }

            return blnResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool CambiarClave(Dto.Usuario obj)
        {
            bool blnResult = new Data.DUsuario().CambiarClave(obj);
            if (blnResult)
            {
                try
                {
                    Utilidades.EnviarCorreo(obj.correoelectronico, Recursos.MsgMailUsuarioCambioClave, Utilidades.PlantillasCorreo.CambioClave, obj.usuario, obj.clave);
                }
                catch (Exception)
                {
                    //Procesar error
                    throw;
                }
            }

            return blnResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaNombreUsuario(Dto.Usuario obj)
        {
            Dto.Usuario objUsuario = new Data.DUsuario().RecuperarFiltrados(obj).FirstOrDefault();
            if (objUsuario != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
