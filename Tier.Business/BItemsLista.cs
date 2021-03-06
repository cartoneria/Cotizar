﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BItemsLista : ParentBusiness
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.ItemLista> RecuperarFiltrado(Dto.ItemLista obj, bool objCompuesto)
        {
            IEnumerable<Dto.ItemLista> lst = new Data.DItemsLista().RecuperarFiltrados(obj);

            if (objCompuesto)
            {
                this.RecuperarItemsHijo_ItemLista(lst);
            }

            return lst;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        private void RecuperarItemsHijo_ItemLista(IEnumerable<Dto.ItemLista> lst)
        {
            foreach (Dto.ItemLista elem in lst)
            {
                IEnumerable<Dto.ItemLista> lstHijos = new Data.DItemsLista().RecuperarFiltrados(new Dto.ItemLista() { idpadre = elem.iditemlista });

                if (lstHijos.Count() > 0)
                {
                    this.RecuperarItemsHijo_ItemLista(lstHijos);
                }

                elem.items = lstHijos;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.ItemLista obj)
        {
            return new Data.DItemsLista().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.ItemLista obj)
        {
            return new Data.DItemsLista().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.ItemLista obj)
        {
            return new Data.DItemsLista().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ValidaNombre(Dto.ItemLista obj)
        {
            Dto.ItemLista objExiste = new Data.DItemsLista().RecuperarFiltrados(obj).FirstOrDefault();
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
