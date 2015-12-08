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
using Newtonsoft.Json;

namespace Tier.Gui.Controllers
{
    public partial class AdministracionController : BaseController
    {
        private void CargarListasPeriodos(CotizarService.Periodo obj)
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);

            ViewBag.ParametrosPredefinidos = JsonConvert.SerializeObject(SAL.Periodos.RecuperarParametrosPredefinidos());
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
            if (ModelState.IsValid)
            {

            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasPeriodos(obj);
            return View(obj);
        }
    }
}