using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Cartera
    {
        public static IEnumerable<CotizarService.Cartera> RecuperarVencidaXCliente(Nullable<int> idCliente)
        {
            return new clsCartera().RecuperarTodos(new CotizarService.Cartera() { cliente_idcliente = idCliente }).Where(ee => ee.dias < 0).ToList();
        }
    }

    internal class clsCartera : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Cartera> RecuperarTodos(CotizarService.Cartera obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Cartera_RecuperarFiltros(obj);
        }
    }
}