using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ProduccionController : BaseController
    {
        public ActionResult ListaInsumos(Nullable<int> id)
        {
            ViewBag.lstTipoInsumo = SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo);
            ViewBag.idProveedor = id;

            return View(SAL.Insimos.RecuperarXProveedor(id));
        }

        public ActionResult CrearInsumo(Nullable<int> id)
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult CrearInsumo(CotizarService.Insumo obj)
        {
            return View();
        }
    }
}