using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class ProduccionController : BaseController
    {
        //
        // GET: /Produccion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaMaquinas()
        {
            return View(SAL.Maquinas.RecuperarTodas());
        }

        public ActionResult CrearMaquina()
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", 1);
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");
            return View();
        }

        [HttpPost]
        public ActionResult CrearMaquina(CotizarService.Maquina obj)
        {
            return View();
        }
    }
}
