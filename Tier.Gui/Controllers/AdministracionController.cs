using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;

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
            ViewBag.lstRoles = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre");
            ViewBag.lstEmpresas = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.lstAreas = new SelectList(SAL.ItemsListas.RecuperarAreasActivas(), "iditemlista", "nombre");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(CotizarService.Usuario obj)
        {
            //La clave se la asigna la logica del servicio.

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
        [ValidateAntiForgeryToken]
        public ActionResult CrearRol(CotizarService.RolModel obj)
        {
            obj.permisos = this.CargarPermisosRol(obj.permisosseleccionados);

            return View();
        }

        private IEnumerable<CotizarService.Permiso> CargarPermisosRol(string strJsonPermisos)
        {
            List<CotizarService.Permiso> lstPerm = new List<CotizarService.Permiso>();

            JArray jsonArray = JArray.Parse(strJsonPermisos);
            if (jsonArray.Count > 0)
            {
                foreach (var objDescuento in jsonArray.Children())
                {
                    string listaDePaises = string.Empty;

                    try
                    {
                        dynamic objArrPerm = JObject.Parse(objDescuento.ToString());
                        lstPerm.Add(new CotizarService.Permiso() { accion_idaccion = objArrPerm.accion, funcionalidad_idfuncionalidad = objArrPerm.funcionalidad });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lstPerm;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearItemLista(CotizarService.ItemLista obj)
        {
            return View();
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
            if (ModelState.IsValid)
            {
                if (obj.ImageUpload != null)
                {

                    string path = Server.MapPath("~/images/") + obj.ImageUpload.FileName;
                    obj.ImageUpload.SaveAs(path);
                    obj.urilogo = obj.ImageUpload.FileName;
                }

                byte? _idEmpresa;
                CotizarService.Empresa _nEmpresa = new CotizarService.Empresa
                {
                    activo = obj.activo,
                    direccion = obj.direccion,
                    nit = obj.nit,
                    razonsocial = obj.razonsocial,
                    representantelegal = obj.representantelegal,
                    telefono = obj.telefono,
                    urilogo = obj.urilogo

                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Empresa_Insertar(_nEmpresa, out _idEmpresa) && _idEmpresa != null)
                {
                    TempData["Exito"] = "Empresa creada con exito.";
                    return View("ListaEmpresas", SAL.Empresas.RecuperarEmpresasActivas());
                }
                else
                {
                    ModelState.AddModelError("ErrorService", "falla en el servicio de inserción.");
                }
            }
            else
            {
                ModelState.AddModelError("ErrorData", "Algunos valores no son validos.");
            }
            return View();
        }
        #endregion

    }
}
