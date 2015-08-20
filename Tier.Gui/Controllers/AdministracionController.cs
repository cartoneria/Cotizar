using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class AdministracionController : BaseController
    {
        //
        // GET: /Administracion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaUsuarios()
        {
            return View(SAL.Usuarios.RecuperarTodos());
        }

        public ActionResult ListaRoles()
        {
            return View(SAL.Roles.RecuperarTodos());
        }

        public ActionResult ListaListas()
        {
            return View();
        }

        public ActionResult ListaEmpresas()
        {
            return View(SAL.Empresas.RecuperarEmpresasActivas());
        }
    }
}
