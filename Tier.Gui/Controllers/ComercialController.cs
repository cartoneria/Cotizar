using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ComercialController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPeriodo"></param>
        /// <param name="arrProductos"></param>
        /// <param name="costoTotalPlachas"></param>
        /// <param name="costoTotalTroqueles"></param>
        private static void CalcularCostoPlanchasTroqueles(int idPeriodo, int[] arrProductos, ref Single costoTotalPlachas, ref Single costoTotalTroqueles)
        {
            int cantTintas = 0;
            Single costoPlancha = 0;

            CotizarService.Parametro paramCostoTroquel = SAL.Periodos.RecuperarParametroXIdPeriodoNombre(idPeriodo, "VTROQ");

            foreach (var item in arrProductos)
            {
                CotizarService.Producto objProd = SAL.Productos.RecuperarXId(item);

                if (objProd != null && objProd.nuevo.HasValue && objProd.nuevo == true)
                {

                    if (objProd.maquinavariprod_idVariacion_rutalitografia.HasValue)
                    {
                        CotizarService.Maquina objMaquina = SAL.Maquinas.RecuperarXIdRutaProduccion((int)objProd.maquinavariprod_idVariacion_rutalitografia);

                        cantTintas = objProd.espectro.Count;
                        costoPlancha = (objMaquina != null && objMaquina.valorplancha.HasValue ? (Single)objMaquina.valorplancha : 0);
                    }

                    Single costoTroquel = (paramCostoTroquel != null && paramCostoTroquel.valornumero.HasValue ? (Single)paramCostoTroquel.valornumero : 0);

                    costoTotalTroqueles += costoTroquel;
                    costoTotalPlachas += (cantTintas * costoPlancha);
                }
            }
        }

    }
}
