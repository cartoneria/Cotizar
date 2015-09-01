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
            if (ModelState.IsValid)
            {
                byte? _idAsesor;

                CotizarService.Asesor _nAsesor = new CotizarService.Asesor
                {
                    activo = obj.activo,
                    codigo = obj.codigo,
                    comision = obj.comision,
                    correoelectronico = obj.correoelectronico,
                    empresa_idempresa = obj.empresa_idempresa,
                    fechacreacion = DateTime.Now,
                    nombre = obj.nombre,
                    telefono = obj.telefono
                };

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Asesor_Insertar(_nAsesor, out _idAsesor) && _idAsesor != null)
                {
                    TempData["Exito"] = "Asesor creado con exito.";
                    return View("ListaAsesores", SAL.Asesores.RecuperarTodos());
                }
                else
                {
                    ModelState.AddModelError("ErrorService", "falla en el servicio de inserción.");
                }


            }
            else
            {
                ModelState.AddModelError("ErrorData", "Algunos valores no validos.");
            }

            return View();
        }
    }
}
