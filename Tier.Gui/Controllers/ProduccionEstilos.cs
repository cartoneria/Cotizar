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
        public ActionResult ListaEstilos()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ListaEstilos(string txtNombre, string txtCodigo)
        {
            IEnumerable<CotizarService.Estilo> lst = SAL.Estilos.RecuperarFiltrados(new CotizarService.Estilo()
            {
                codigo = string.IsNullOrEmpty(txtCodigo) ? null : txtCodigo,
                nombre = string.IsNullOrEmpty(txtNombre) ? null : txtNombre
            });

            return PartialView("_TablaEstilos", lst);
        }
    }
}