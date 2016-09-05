using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Estilos
    {
        public static IEnumerable<CotizarService.Estilo> RecuperarFiltrados(CotizarService.Estilo obj)
        {
            return new clsEstilos().RecuperarFiltrados(obj);
        }

        public static CotizarService.Estilo RecuperarXId(int idEstilo, Nullable<byte> idEmpresa)
        {
            return new clsEstilos().RecuperarFiltrados(new CotizarService.Estilo() { idestilo = idEstilo, empresa_idempresa = idEmpresa }).FirstOrDefault();
        }
    }

    internal class clsEstilos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Estilo> RecuperarFiltrados(CotizarService.Estilo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Estilo_RecuperarFiltros(obj);
        }
    }
}