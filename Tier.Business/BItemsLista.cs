using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BItemsLista
    {
        public IEnumerable<Dto.ItemLista> RecuperarFiltrado(Dto.ItemLista obj)
        {
            IEnumerable<Dto.ItemLista> lst = new Data.DItemsLista().RecuperarFiltrados(obj).ToList();
            this.RecuperarItemsHijo_ItemLista(lst);

            return lst;
        }

        private void RecuperarItemsHijo_ItemLista(IEnumerable<Dto.ItemLista> lst)
        {
            foreach (Dto.ItemLista elem in lst)
            {
                List<Dto.ItemLista> lstHijos = new Data.DItemsLista().RecuperarFiltrados(new Dto.ItemLista() { idpadre = elem.iditemlista }).ToList();

                if (lstHijos.Count > 0)
                {
                    this.RecuperarItemsHijo_ItemLista(lstHijos);
                }

                elem.items = lstHijos;
            }
        }
    }
}
