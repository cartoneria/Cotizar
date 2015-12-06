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
        private void CargarListasPeriodos(CotizarService.Periodo obj)
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaPeriodos()
        {
            return View(SAL.Periodos.RecuperarTodos());
        }

        public ActionResult CrearPeriodo()
        {
            this.CargarListasPeriodos(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPeriodo(CotizarService.PeriodoModel obj)
        {
            this.CargarListasPeriodos(obj);
            return View(obj);
        }
    }
}