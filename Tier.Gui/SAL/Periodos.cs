using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Tier.Gui.SAL
{
    public static class Periodos
    {
        public static IEnumerable<CotizarService.Periodo> RecuperarTodos(Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsPeriodos().RecuperarFiltrados(new CotizarService.Periodo() { empresa_idempresa = idEmpresa }, objCompuesto);
        }

        public static IEnumerable<CotizarService.ParametroPredefinido> RecuperarParametrosPredefinidos()
        {
            return new clsPeriodos().RecuperarParametrosPredefinidos();
        }

        public static CotizarService.Periodo RecuperarXId(int idParam, Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsPeriodos().RecuperarFiltrados(new CotizarService.Periodo() { idPeriodo = idParam, empresa_idempresa = idEmpresa }, objCompuesto).FirstOrDefault(); ;
        }
    }

    internal class clsPeriodos : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Periodo> RecuperarFiltrados(CotizarService.Periodo obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Periodo_RecuperarFiltros(obj, objCompuesto);
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
    }
}