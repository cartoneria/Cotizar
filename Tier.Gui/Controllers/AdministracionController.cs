using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class AdministracionController : Controller
    {
        //
        // GET: /Administracion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaUsuarios()
        {
            return View(new Business.BUsuario().RecuperarFiltrado(new Dto.Usuario()));
        }

        public ActionResult ListaRoles()
        {
            return View(new Business.BRol().RecuperarFiltrado(new Dto.Rol()));
        }

        public ActionResult ListaListas()
        {
            return View(new Business.BItemsLista().RecuperarFiltrado(new Dto.ItemLista()));
        }

        public ActionResult ListaEmpresas()
        {
            return View(new Business.BEmpresa().RecuperarFiltrado(new Dto.Empresa()));
        }
    }
}
