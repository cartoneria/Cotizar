using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class ComercialController : BaseController
    {
        //
        // GET: /Comercial/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaAsesores()
        {
            return View(SAL.Asesores.RecuperarTodos());
        }

        public ActionResult CrearAsesor()
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            return View();
        }

        [HttpPost]
        public ActionResult CrearAsesor(CotizarService.Asesor obj)
        {
            return View();
        }
    }
}
