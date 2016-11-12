using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Maquinas
    {
        public static IEnumerable<CotizarService.Maquina> RecuperarTodas(Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsMaquinas().RecuperarFiltrados(new CotizarService.Maquina() { empresa_idempresa = idEmpresa }, objCompuesto);
        }

        public static CotizarService.Maquina RecuperarXId(short idMaquina, Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsMaquinas().RecuperarFiltrados(new CotizarService.Maquina() { idmaquina = idMaquina, empresa_idempresa = idEmpresa }, objCompuesto).FirstOrDefault();
        }

        public static IEnumerable<CotizarService.Maquina> RecuperarActivas(Nullable<byte> idEmpresa, bool objCompuesto)
        {
            return new clsMaquinas().RecuperarFiltrados(new CotizarService.Maquina() { activo = true, empresa_idempresa = idEmpresa }, objCompuesto);
        }

        public static IEnumerable<CotizarService.RutaProduccion> RecuperarRutasProduccionXTipo(Nullable<byte> idEmpresa, Nullable<int> idtipomaquina)
        {
            return new clsMaquinas().RecuperarRutasProduccionFiltrados(new CotizarService.RutaProduccion() { idempresa = idEmpresa, idtipomaquina = idtipomaquina });
        }

        public static IEnumerable<CotizarService.Maquina> RecuperarFiltrados(CotizarService.Maquina obj, bool objCompuesto)
        {
            return new clsMaquinas().RecuperarFiltrados(obj, objCompuesto);
        }

        public static CotizarService.Maquina RecuperarXIdRutaProduccion(int idRutaProduccion, bool objCompuesto)
        {
            CotizarService.MaquinaVariacionProduccion objVariProd = new clsMaquinas().RecuperarVariacionProduccionFiltrados(new CotizarService.MaquinaVariacionProduccion()
            {
                idVariacion = idRutaProduccion
            }).FirstOrDefault();

            return new clsMaquinas().RecuperarFiltrados(new CotizarService.Maquina() { idmaquina = objVariProd.maquina_idmaquina }, objCompuesto).FirstOrDefault();
        }

        public static CotizarService.MaquinaVariacionProduccion RecuperarRutaProduccionXId(int idRutaProduccion)
        {
            return new clsMaquinas().RecuperarVariacionProduccionFiltrados(new CotizarService.MaquinaVariacionProduccion()
            {
                idVariacion = idRutaProduccion
            }).FirstOrDefault();
        }
    }

    internal class clsMaquinas : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Maquina> RecuperarFiltrados(CotizarService.Maquina obj, bool objCompuesto)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarFiltros(obj, objCompuesto);
        }

        internal IEnumerable<CotizarService.RutaProduccion> RecuperarRutasProduccionFiltrados(CotizarService.RutaProduccion obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarRutasProduccionFiltros(obj);
        }

        internal IEnumerable<CotizarService.MaquinaVariacionProduccion> RecuperarVariacionProduccionFiltrados(CotizarService.MaquinaVariacionProduccion obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Maquina_RecuperarVariacionesProduccionFiltros(obj);
        }

    }
}