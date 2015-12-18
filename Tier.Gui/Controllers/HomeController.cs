using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            base.ActualizarMenuUsuario();
            return View();
        }
    }
}