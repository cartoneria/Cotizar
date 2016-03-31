using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Business
{
    public class BPedido
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Crear(Dto.Pedido obj)
        {
            return new Data.DPedido().Insertar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Pedido> RecuperarFiltrado(Dto.Pedido obj)
        {
            IEnumerable<Dto.Pedido> lstResult = new Data.DPedido().RecuperarFiltrados(obj);
            foreach (var item in lstResult)
            {
                item.detalle = this.RecuperarDetalle(new Dto.PedidoDetalle() { pedido_idpedido = item.idpedido });
            }

            return lstResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Actualizar(Dto.Pedido obj)
        {
            return new Data.DPedido().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Eliminar(Dto.Pedido obj)
        {
            return new Data.DPedido().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public IEnumerable<Dto.PedidoDetalle> RecuperarDetalle(Dto.PedidoDetalle obj)
        {
            return new Data.DPedidoDetalle().RecuperarFiltrados(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Pedido> RecuperarXCliente(int idCliente)
        {
            IEnumerable<Dto.Pedido> lstResult = new Data.DPedido().RecuperarXCliente(idCliente);

            foreach (var item in lstResult)
            {
                item.detalle = this.RecuperarDetalle(new Dto.PedidoDetalle() { pedido_idpedido = item.idpedido });
            }

            return lstResult;
        }
    }
}
