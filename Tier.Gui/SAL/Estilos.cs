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

        public static IEnumerable<CotizarService.EstiloPegue> RecuperarPeguesFiltrados(CotizarService.Estilo obj)
        {
            return new clsEstilos().RecuperarPeguesFiltrados(new CotizarService.EstiloPegue() { estilo_idestilo = obj.idestilo });
        }

        public static CotizarService.Estilo RecuperarXId(int idEstilo)
        {
            return new clsEstilos().RecuperarFiltrados(new CotizarService.Estilo() { idestilo = idEstilo }).FirstOrDefault();
        }

        public static IEnumerable<CotizarService.Estilo> RecuperarEstilosActivos(Nullable<byte> idEmpresa)
        {
            return new clsEstilos().RecuperarFiltrados(new CotizarService.Estilo() { activo = true, empresa_idempresa = idEmpresa }).ToList();
        }
    }

    internal class clsEstilos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Estilo> RecuperarFiltrados(CotizarService.Estilo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Estilo_RecuperarFiltros(obj);
        }

        internal IEnumerable<CotizarService.EstiloPegue> RecuperarPeguesFiltrados(CotizarService.EstiloPegue obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Estilo_RecuperarPegues(obj);
        }
    }
}