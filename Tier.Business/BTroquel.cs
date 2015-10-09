﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BTroquel
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Troquel obj)
        {
            return new Data.DTroquel().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Troquel> RecuperarFiltrado(Dto.Troquel obj)
        {
            return new Data.DTroquel().RecuperarFiltrados(obj).ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Troquel obj)
        {
            return new Data.DTroquel().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Troquel obj)
        {
            return new Data.DTroquel().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaCodigo(Dto.Troquel obj)
        {
            Dto.Troquel objExiste = new Data.DTroquel().RecuperarFiltrados(obj).FirstOrDefault();
            if (objExiste != null)
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