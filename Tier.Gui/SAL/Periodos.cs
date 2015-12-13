using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tier.Gui.SAL
{
    public static class Periodos
    {
        public static IEnumerable<CotizarService.Periodo> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsPeriodos().RecuperarTodos(new CotizarService.Periodo() { empresa_idempresa = idEmpresa });
        }

        public static IEnumerable<CotizarService.ParametroPredefinido> RecuperarParametrosPredefinidos()
        {
            return new clsPeriodos().RecuperarParametrosPredefinidos();
        }

        public static CotizarService.Periodo RecuperarXId(int intId, Nullable<byte> idEmpresa)
        {
            return new clsPeriodos().RecuperarXId(new CotizarService.Periodo() { idPeriodo = intId, empresa_idempresa = idEmpresa });
        }
    }

    internal class clsPeriodos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Periodo> RecuperarTodos(CotizarService.Periodo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Periodo_RecuperarFiltros(obj);
        }

        internal IEnumerable<CotizarService.ParametroPredefinido> RecuperarParametrosPredefinidos()
        {
            string strXMLParametros;
            XDocument xmlDocParametros = new XDocument();

            List<CotizarService.ParametroPredefinido> lstParametros = new List<CotizarService.ParametroPredefinido>();

            objProxy = new CotizarService.CotizarServiceClient();
            strXMLParametros = objProxy.Periodo_RecuperarParametrosPredefinidos();

            xmlDocParametros = XDocument.Parse(strXMLParametros);
            foreach (var item in xmlDocParametros.Descendants("parametros").Descendants("parametro"))
            {
                lstParametros.Add(new CotizarService.ParametroPredefinido()
                {
                    nombre = item.Descendants("nombre").First().Value,
                    tipo = Convert.ToByte(item.Descendants("tipo").First().Value),
                    descripcion = item.Descendants("descripcion").First().Value
                });
            }

            return lstParametros;
        }

        internal CotizarService.Periodo RecuperarXId(CotizarService.Periodo obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Periodo_RecuperarFiltros(obj).FirstOrDefault();
        }
    }
}