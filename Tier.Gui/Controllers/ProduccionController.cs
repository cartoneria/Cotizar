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
        [ValidateAntiForgeryToken]
        public ActionResult CrearMaquina(CotizarService.Maquina obj)
        {
            if (ModelState.IsValid)
            {
                short? idMaquina = null;
                CotizarService.Maquina _nMaquina = new CotizarService.Maquina
                {
                    activo = obj.activo,
                    anchomax = obj.anchomax,
                    anchomin = obj.anchomin,
                    codigo = obj.codigo,
                    descripcion = obj.descripcion,
                    fechacreacion = DateTime.Now,
                    largomax = obj.largomax,
                    largomin = obj.largomin,
                    nombre = obj.nombre,
                    empresa_idempresa = obj.empresa_idempresa,
                    itemlista_iditemlistas_tipo = obj.itemlista_iditemlistas_tipo
                };

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Maquina_Insertar(_nMaquina, out idMaquina) && idMaquina != null)
                {
                    ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", 1);
                    ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");

                    TempData["Exito"] = "Maquina creada con exito.";
                    return RedirectToAction("ListaMaquinas", "Produccion");
                }

            }
            else
            {
                ModelState.AddModelError("ErrorData", "Algunos valores no son validos.");
            }
            return View();
        }
    }
}
