using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.Models
{
    public static class Enumeradores
    {
        /// <summary>
        /// Enumerador para los tipos de listas admininistrables
        /// </summary>
        public enum TiposLista : byte
        {
            Areas = 1,
            TiposMaquina = 2,
            UnidadesMedida = 3,
            TiposRegimen = 4,
            TiposIdentificacion = 5,
            FormasPago = 6,
            TiposContacto = 7,
            TiposMaterial = 8,
            TiposInsumo = 9,
            TiposAcabado = 10
        }

        /// <summary>
        /// Enumerador para identificar las notificaciones del sistema del lado del cliente.
        /// </summary>
        public enum TiposNotificaciones : byte
        {
            success,
            info,
            notice,
            error,
            dark
        }

        /// <summary>
        /// Enumeador para marcar los tipos de materiales según las listas administrables.
        /// </summary>
        public enum TiposMateriales
        {
            Carton = 40,
            Acetato = 41,
            Acabados = 43,
            Reenpaques = 45,
            Pegantes = 42
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ProcesosProduccion
        {
            Litografia = 6,
            Troquelado = 7,
            Guillotinado = 8,
            Conversion = 9,
            Acabado = 10,
            Pegue = 11,
            Colaminado = 12
        }

        /// <summary>
        /// 
        /// </summary>
        public enum EstadosCotizacion
        {
            Creacion = 47,
            Pedido = 48,
            Fabricación = 49,
            Despachacdo = 50,
            Entregada = 51,
            Cerrada = 52
        }
    }
}