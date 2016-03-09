using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;

namespace Tier.Services
{
    public partial class CotizarService : ICotizarService
    {

    }

    public static class Logs
    {
        #region [Logs]
        /// <summary>
        /// 
        /// </summary>
        public enum TraceTypes : byte
        {
            error = 1,
            warning = 2,
            info = 3
        }

        /// <summary>
        /// 
        /// </summary>
        public enum ModulosAplicacion : byte
        {
            Usuarios = 1,
            Roles = 2,
            Funcionalidades = 3,
            Empresas = 4,
            Periodos = 5,
            Listas = 6,
            Departamentos = 7,
            Municipios = 8,
            Asesores = 9,
            Clientes = 10,
            Espectros = 11,
            Maquinas = 12,
            Pantones = 13,
            Troqueles = 14,
            Proveedores = 15,
            Productos = 16,
            Insumos = 17,
            Cotizaciones = 18,
            Accesorios = 19,
            Pedidos = 20,
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="module"></param>
        public static void Error(Exception ex, ModulosAplicacion module)
        {
            WriteEntry(ex.ToString(), TraceTypes.error, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Warning(string message, ModulosAplicacion module)
        {
            WriteEntry(message, TraceTypes.warning, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Info(string message, ModulosAplicacion module)
        {
            WriteEntry(message, TraceTypes.info, module);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        /// <param name="module"></param>
        private static void WriteEntry(string message, TraceTypes type, ModulosAplicacion module)
        {
            Trace.WriteLine(string.Format("{0}|{1}|{2}|{3}",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                type,
                module,
                message)
            );
        }
        #endregion
    }
}
