using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class AdministracionController : BaseController
    {
        //
        // GET: /AdministracionProveedores/

        public ActionResult ListaProveedores()
        {
            //return View(SAL);
            return View();
        }

        public ActionResult CrearProveedor() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProveedor(CotizarService.Empresa s)
        {
            if(ModelState.IsValid)
            {

            }

            return View();
        }



        public ActionResult EditarProveedor(short idProveedor)
        {
            //Consultar información de proveedor y las lineas asociadas
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProveedor(CotizarService.Empresa s)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

    }
}
