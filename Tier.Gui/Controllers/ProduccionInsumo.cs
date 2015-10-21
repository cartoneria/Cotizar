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
        public ActionResult ListaInsumos()
        {
            ViewBag.lstTipoInsumo = SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo);
            return View(SAL.Insimos.RecuperarTodos());
        }

        public ActionResult CrearInsumo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearInsumo()
        {
            return View();
        }
    }
}