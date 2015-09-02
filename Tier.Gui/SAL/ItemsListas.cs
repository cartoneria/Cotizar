﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class ItemsListas
    {
        public static IEnumerable<CotizarService.ItemLista> RecuperarGrupo(byte intIdGrupo)
        {
            return new clsItemsListas().RecuperarGrupo(intIdGrupo);
        }

        public static IEnumerable<CotizarService.ItemLista> RecuperarActivosGrupo(byte intIdGrupo)
        {
            return new clsItemsListas().RecuperarActivosGrupo(intIdGrupo);
        }
    }

    internal class clsItemsListas : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.ItemLista> RecuperarGrupo(byte intIdGrupo)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.ItemLista_RecuperarFiltros(new CotizarService.ItemLista() { grupo = intIdGrupo });
        }

        internal IEnumerable<CotizarService.ItemLista> RecuperarActivosGrupo(byte intIdGrupo)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.ItemLista_RecuperarFiltros(new CotizarService.ItemLista() { grupo = intIdGrupo, activo = true });
        }
    }
}