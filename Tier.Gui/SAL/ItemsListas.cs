using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class ItemsListas
    {
        public static IEnumerable<CotizarService.ItemLista> RecuperarGrupo(byte intIdGrupo)
        {
            return new clsItemsListas().RecuperarGrupo(new CotizarService.ItemLista() { grupo = intIdGrupo });
        }

        public static IEnumerable<CotizarService.ItemLista> RecuperarActivosGrupo(byte intIdGrupo)
        {
            return new clsItemsListas().RecuperarActivosGrupo(new CotizarService.ItemLista() { grupo = intIdGrupo, activo = true });
        }

        public static CotizarService.ItemLista RecuperarItemListaXId(int intIdItemLista)
        {
            return new clsItemsListas().RecuperarItemListaXId(new CotizarService.ItemLista() { iditemlista = intIdItemLista });
        }
    }

    internal class clsItemsListas : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.ItemLista> RecuperarGrupo(CotizarService.ItemLista obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.ItemLista_RecuperarFiltros(obj);
        }

        internal IEnumerable<CotizarService.ItemLista> RecuperarActivosGrupo(CotizarService.ItemLista obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.ItemLista_RecuperarFiltros(obj);
        }

        internal CotizarService.ItemLista RecuperarItemListaXId(CotizarService.ItemLista obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.ItemLista_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}