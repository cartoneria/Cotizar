using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class ItemsListas
    {
        public static IEnumerable<CotizarService.ItemLista> RecuperarGrupo(byte intIdGrupo, bool objCompuesto)
        {
            return new clsItemsListas().RecuperarFiltrados(new CotizarService.ItemLista() { grupo = intIdGrupo }, objCompuesto);
        }

        public static IEnumerable<CotizarService.ItemLista> RecuperarActivosGrupo(byte intIdGrupo, bool objCompuesto)
        {
            return new clsItemsListas().RecuperarFiltrados(new CotizarService.ItemLista() { grupo = intIdGrupo, activo = true }, objCompuesto);
        }

        public static CotizarService.ItemLista RecuperarItemListaXId(int intIdItemLista, bool objCompuesto)
        {
            return new clsItemsListas().RecuperarFiltrados(new CotizarService.ItemLista() { iditemlista = intIdItemLista }, objCompuesto).FirstOrDefault();
        }
    }

    internal class clsItemsListas : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.ItemLista> RecuperarFiltrados(CotizarService.ItemLista obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.ItemLista_RecuperarFiltros(obj, objCompuesto);
        }
    }
}