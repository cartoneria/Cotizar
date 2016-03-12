using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Troqueles
    {
        public static IEnumerable<CotizarService.Troquel> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsTroqueles().RecuperarFiltrados(new CotizarService.Troquel() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Troquel RecuperarXId(int idTroquel, Nullable<byte> idEmpresa)
        {
            return new clsTroqueles().RecuperarFiltrados(new CotizarService.Troquel() { idtroquel = idTroquel, empresa_idempresa = idEmpresa }).FirstOrDefault();
        }

        public static CotizarService.Troquel RecuperarXId(int idTroquel)
        {
            return new clsTroqueles().RecuperarFiltrados(new CotizarService.Troquel() { idtroquel = idTroquel }).FirstOrDefault();
        }

        public static IEnumerable<CotizarService.Troquel> RecuperarFiltrados(CotizarService.Troquel obj)
        {
            return new clsTroqueles().RecuperarFiltrados(obj);
        }
    }

    internal class clsTroqueles : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Troquel> RecuperarFiltrados(CotizarService.Troquel obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Troquel_RecuperarFiltros(obj);
        }
    }
}