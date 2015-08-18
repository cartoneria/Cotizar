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
            return View(new Business.BAsesor().RecuperarFiltrado(new Dto.Asesor()));
        }
    }
}
