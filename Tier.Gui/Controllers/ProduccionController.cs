using System;
using System.Collections.Generic;
using System.Globalization;
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
            return View();
        }

        public ActionResult CrearMaquina()
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");
            ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
            ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarActivos(), "idPeriodo", "nombre");

            return View();
        }
    }
}
