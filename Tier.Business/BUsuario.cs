using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BUsuario : ParentBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Usuario obj)
        {
            char[] arrCaracteres = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] arrNumeros = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            char[] arrSimbolos = new char[] { '!', '.', '%', '&', '/', '(', ')', '=', '?', '*', '|', '#', '\\', '@', '[', ']', '{', '}', '-', '_', '+' };

            string strClave = obj.usuario.Substring(0, 4)
                + arrNumeros[new Random().Next(10)]
                + arrNumeros[new Random().Next(10)]
                + arrCaracteres[new Random().Next(25)]
                + arrSimbolos[new Random().Next(20)];

            obj.clave = strClave;

            return new Data.DUsuario().Insertar(obj);
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
    }
}
