using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Clientes
    {
        public static IEnumerable<CotizarService.Cliente> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsClientes().RecuperarFiltrados(new CotizarService.Cliente() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Cliente RecuperarXId(int idCliente, Nullable<byte> idEmpresa)
        {
            return new clsClientes().RecuperarXId(new CotizarService.Cliente() { idcliente = idCliente, empresa_idempresa = idEmpresa });
        }

        public static IEnumerable<CotizarService.Cliente> RecuperarFiltrados(CotizarService.Cliente obj)
        {
            return new clsClientes().RecuperarFiltrados(obj);
        }
    }

    internal class clsClientes : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cliente> RecuperarFiltrados(CotizarService.Cliente obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cliente_RecuperarFiltros(obj);
        }

        internal CotizarService.Cliente RecuperarXId(CotizarService.Cliente obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cliente_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}