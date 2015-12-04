using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using System.Globalization;
using System.Text;

namespace Tier.Gui.Controllers
{
    public partial class AdministracionController : BaseController
    {
        public ActionResult ListaPeriodos()
        {
            return View(SAL.Periodos.RecuperarTodos());
        }
    }
}