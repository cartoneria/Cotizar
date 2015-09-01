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

        #region [Usuarios]

        public ActionResult ListaUsuarios()
        {
            return View(SAL.Usuarios.RecuperarTodos());
        }

        public ActionResult CrearUsuario()
        {
            return View();
        }

        #endregion

        #region [Roles]

        public ActionResult ListaRoles()
        {
            return View(SAL.Roles.RecuperarTodos());
        }

        public ActionResult CrearRol()
        {
            ViewBag.lstFuncionalidades = SAL.Funcionalidad.RecuperarActivas();
            return View();
        }

        [HttpPost]
        public ActionResult CrearRol(CotizarService.Rol obj)
        {
            return View();
        }
        #endregion

        #region [ItemsLista]

        public ActionResult ListaListas()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult RecuperarItemsListaGrupo(byte intIdGrupo)
        {
            IEnumerable<CotizarService.ItemLista> lst = SAL.ItemsListas.RecuperarGrupo(intIdGrupo);
            return PartialView("_ItemsListaGrupo", lst);
        }
        #endregion

        #region [Empresa]

        public ActionResult ListaEmpresas()
        {
            return View(SAL.Empresas.RecuperarEmpresasActivas());
        }

        public ActionResult CrearEmpresa()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEmpresa(CotizarService.EmpresaModel obj)
        {
            return View();
        }
        #endregion

    }
}
