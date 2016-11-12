using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Estilos
    {
        public static IEnumerable<CotizarService.Estilo> RecuperarFiltrados(CotizarService.Estilo obj, bool objCompuesto)
        {
            return new clsEstilos().RecuperarFiltrados(obj, objCompuesto);
        }

        public static IEnumerable<CotizarService.EstiloPegue> RecuperarPeguesFiltrados(CotizarService.Estilo obj)
        {
            return new clsEstilos().RecuperarPeguesFiltrados(new CotizarService.EstiloPegue() { estilo_idestilo = obj.idestilo });
        }

        public static CotizarService.Estilo RecuperarXId(int idEstilo, bool objCompuesto)
        {
            return new clsEstilos().RecuperarFiltrados(new CotizarService.Estilo() { idestilo = idEstilo }, objCompuesto).FirstOrDefault();
        }

        public static IEnumerable<CotizarService.Estilo> RecuperarEstilosActivos(Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsEstilos().RecuperarFiltrados(new CotizarService.Estilo() { activo = true, empresa_idempresa = idEmpresa }, objCompuesto);
        }
    }

    internal class clsEstilos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Estilo> RecuperarFiltrados(CotizarService.Estilo obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Estilo_RecuperarFiltros(obj, objCompuesto);
        }

        internal IEnumerable<CotizarService.EstiloPegue> RecuperarPeguesFiltrados(CotizarService.EstiloPegue obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Estilo_RecuperarPegues(obj);
        }
    }
}