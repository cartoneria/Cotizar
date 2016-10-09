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
            return View();
        }
    }
}