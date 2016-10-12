using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Tier.Gui.Controllers
{
    public partial class ComercialController : BaseController
    {
        public ActionResult GestionComercial()
        {
            CotizarService.ReporteGestionComercial objModel = SAL.GestionComercial.ObtenerReporteGestionComercial();
            return View(objModel);
        }

        public PartialViewResult ObtenerTablaPedidosGestionXAgrupacion(byte id)
        {
            IEnumerable<CotizarService.PedidoGestion> lstPedidos = SAL.GestionComercial.ObtenerPedidosGestionXAgrupacion(id);

            return PartialView("_TablaPedidosGestion", lstPedidos);
        }
    }
}