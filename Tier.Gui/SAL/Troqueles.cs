using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Troqueles
    {
        public static IEnumerable<CotizarService.Troquel> RecuperarTodos(Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsTroqueles().RecuperarFiltrados(new CotizarService.Troquel() { empresa_idempresa = idEmpresa }, objCompuesto);
        }

        public static CotizarService.Troquel RecuperarXId(int idTroquel, Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsTroqueles().RecuperarFiltrados(new CotizarService.Troquel() { idtroquel = idTroquel, empresa_idempresa = idEmpresa }, objCompuesto).FirstOrDefault();
        }

        public static CotizarService.Troquel RecuperarXId(int idTroquel, bool objCompuesto)
        {
            return new clsTroqueles().RecuperarFiltrados(new CotizarService.Troquel() { idtroquel = idTroquel }, objCompuesto).FirstOrDefault();
        }

        public static IEnumerable<CotizarService.Troquel> RecuperarFiltrados(CotizarService.Troquel obj, bool objCompuesto)
        {
            return new clsTroqueles().RecuperarFiltrados(obj, objCompuesto);
        }
    }

    internal class clsTroqueles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Troquel> RecuperarFiltrados(CotizarService.Troquel obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Troquel_RecuperarFiltros(obj, objCompuesto);
        }
    }
}