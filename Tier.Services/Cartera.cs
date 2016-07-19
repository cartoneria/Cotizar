using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Cartera> Cartera_RecuperarFiltros(Dto.Cartera objFiltros)
        {
            try
            {
                return new Business.BCartera().RecuperarFiltrado(objFiltros);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Cartera);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool Cartera_ActualizarCarteraLote(IEnumerable<Dto.Cartera> lst)
        {
            try
            {
                return new Business.BCartera().ActualizarCarteraLote(lst);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Cartera);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cartera_Actualizar(Dto.Cliente obj)
        {
            try
            {
                return new Business.BCliente().Actualizar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Cartera);
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cartera_Eliminar(Dto.Cliente obj)
        {
            try
            {
                return new Business.BCliente().Eliminar(obj);
            }
            catch (Exception ex)
            {
                Logs.Error(ex, Logs.ModulosAplicacion.Cartera);
                throw;
            }
        }
    }
}
