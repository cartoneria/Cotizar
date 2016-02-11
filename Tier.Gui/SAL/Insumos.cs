using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Insumos
    {
        public static IEnumerable<CotizarService.Insumo> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsInsumos().RecuperarFiltrados(new CotizarService.Insumo() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Insumo RecuperarXId(int intIdInsumo, Nullable<byte> idEmpresa)
        {
            return new clsInsumos().RecuperarXId(new CotizarService.Insumo() { idinsumo = intIdInsumo, empresa_idempresa = idEmpresa });
        }

        public static IEnumerable<CotizarService.Insumo> RecuperarFiltrados(CotizarService.Insumo obj)
        {
            return new clsInsumos().RecuperarFiltrados(obj);
        }
    }

    internal class clsInsumos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Insumo> RecuperarFiltrados(CotizarService.Insumo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(obj);
        }

        internal CotizarService.Insumo RecuperarXId(CotizarService.Insumo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Insumo_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}