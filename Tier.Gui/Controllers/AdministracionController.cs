using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Schema;
using System.Globalization;

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

        public JsonResult ValidaNombreUsuario(string usuario)
        {
            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Usuario_ValidaNombreUsuario(new CotizarService.Usuario() { usuario = usuario }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", usuario);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = usuario + i.ToString();
                if (objService.Usuario_ValidaNombreUsuario(new CotizarService.Usuario() { usuario = altCandidate }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", usuario, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearUsuario(CotizarService.Usuario obj)
        {
            //La clave se la asigna la logica del servicio.
            if (ModelState.IsValid)
            {
                short? _idUsuario;

                CotizarService.Usuario _nUsuario = new CotizarService.Usuario
                {
                    activo = obj.activo,
                    cargo = obj.cargo,
                    celular = obj.celular,
                    correoelectronico = obj.correoelectronico,
                    empresa_idempresa = obj.empresa_idempresa,
                    itemlista_iditemlistas_area = obj.itemlista_iditemlistas_area,
                    nombrecompleto = obj.nombrecompleto,
                    rol_idrol = obj.rol_idrol,
                    usuario = obj.usuario
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Usuario_Insertar(_nUsuario, out _idUsuario) && _nUsuario != null)
                {
                    base.RegistrarNotificación("Usuario creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaUsuarios", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            ViewBag.lstRoles = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre");
            ViewBag.lstEmpresas = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.lstAreas = new SelectList(SAL.ItemsListas.RecuperarAreasActivas(), "iditemlista", "nombre");
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
            if (ModelState.IsValid)
            {
                short? _idRol;

                CotizarService.Rol _nRol = new CotizarService.Rol
                {
                    activo = obj.activo,
                    descripcion = obj.descripcion,
                    nombre = obj.nombre,
                    permisos = this.CargarPermisosRol(obj.permisosseleccionados).ToList()
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Rol_Insertar(_nRol, out _idRol) && _idRol != null)
                {
                    base.RegistrarNotificación("Rol creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaRoles", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            ViewBag.lstFuncionalidades = SAL.Funcionalidad.RecuperarActivas();
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

        public JsonResult ValidaNombreRol(string nombre)
        {
            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Rol_ValidaNombre(new CotizarService.Rol() { nombre = nombre }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", nombre);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = nombre + i.ToString();
                if (objService.Rol_ValidaNombre(new CotizarService.Rol() { nombre = altCandidate }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", nombre, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
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

            if (ModelState.IsValid)
            {
                int? idItem;
                CotizarService.ItemLista _nitemLista = new CotizarService.ItemLista
                {
                    activo = obj.activo,
                    grupo = obj.grupo,
                    iditemlista = obj.iditemlista,
                    idpadre = obj.idpadre,
                    items = obj.items,
                    nombre = obj.nombre
                };

                CotizarService.CotizarServiceClient _Client = new CotizarService.CotizarServiceClient();
                if (_Client.ItemLista_Insertar(_nitemLista, out idItem) && idItem != null)
                {
                    base.RegistrarNotificación("El item se ha creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaListas", "Administracion");
                }

                else
                {
                    base.RegistrarNotificación("Error en el servicio de inserción", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            return View("ListaListas");
        }

        public JsonResult ValidaNombreItemLista(string nombre, byte grupo)
        {
            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.ItemLista_ValidaNombre(new CotizarService.ItemLista() { nombre = nombre, grupo = grupo }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", nombre);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = nombre + i.ToString();
                if (objService.ItemLista_ValidaNombre(new CotizarService.ItemLista() { nombre = altCandidate, grupo = grupo }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", nombre, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
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
                    base.RegistrarNotificación("Empresa creada con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaEmpresas", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            return View();
        }
        #endregion
    }
}
