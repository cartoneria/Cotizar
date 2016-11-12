using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Pedido> Pedido_RecuperarFiltros(Dto.Pedido objFiltros, bool objCompuesto)
        {
            try
            {
                return new Business.BPedido().RecuperarFiltrado(objFiltros, objCompuesto);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pedidos);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idpedido"></param>
        /// <returns></returns>
        public bool Pedido_Insertar(Dto.Pedido obj, out int? idpedido)
        {
            try
            {
                bool blnRespuesta = new Business.BPedido().Crear(obj);

                if (blnRespuesta)
                    idpedido = obj.idpedido;
                else
                    idpedido = null;

                return blnRespuesta;
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pedidos);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pedido_Actualizar(Dto.Pedido obj)
        {
            try
            {
                return new Business.BPedido().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pedidos);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pedido_Eliminar(Dto.Pedido obj)
        {
            try
            {
                return new Business.BPedido().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pedidos);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.PedidoDetalle> Pedido_RecuperarDetalle(Dto.PedidoDetalle objFiltros)
        {
            try
            {
                return new Business.BPedido().RecuperarDetalle(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pedidos);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Pedido> Pedido_RecuperarXCliente(int idCliente, bool objCompuesto)
        {
            try
            {
                return new Business.BPedido().RecuperarXCliente(idCliente, objCompuesto);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Pedidos);
                throw;
            }
        }
    }
}
