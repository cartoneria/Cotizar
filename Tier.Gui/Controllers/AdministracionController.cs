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
            ViewBag.lstAreas = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre");

            return View();
        }

        public JsonResult ValidaNombreUsuario(string usuario, bool editando)
        {
            if (editando)
                return Json(true, JsonRequestBehavior.AllowGet);

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
                    usuario = obj.usuario,
                    fechacreacion = DateTime.Now

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
            ViewBag.lstAreas = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre");

            return View(obj);
        }

        public ActionResult EditarUsuario(short id)
        {
            CotizarService.Usuario _objUsuario = SAL.Usuarios.RecuperarTodos().Where(m => m.idusuario == id).FirstOrDefault();

            ViewBag.rol_idrol = new SelectList(SAL.Roles.RecuperarActivos(), "idrol", "nombre", _objUsuario.rol_idrol.ToString());
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", _objUsuario.empresa_idempresa.ToString());
            ViewBag.itemlista_iditemlistas_area = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.Areas), "iditemlista", "nombre", _objUsuario.itemlista_iditemlistas_area.ToString());

            return View(_objUsuario);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarUsuario(CotizarService.Usuario obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Usuario_Actualizar(obj))
                {
                    base.RegistrarNotificación("Usuario actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaUsuarios", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            return View(obj);

        }

        [HttpGet]
        public ActionResult EliminarUsuario(short id)
        {
            try
            {

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();

                if (_Service.Usuario_Eliminar(new CotizarService.Usuario { idusuario = id }))
                {

                    base.RegistrarNotificación("Usuario eliminado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaUsuarios", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                }

            }
            catch (Exception)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }
            return RedirectToAction("ListaUsuarios", "Administracion");
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
                    permisos = this.CargarPermisosRol(obj.hfdPermisosSeleccionados, null).ToList()
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
            return View(obj);
        }

        private IEnumerable<CotizarService.Permiso> CargarPermisosRol(string strJsonPermisos, Nullable<short> intIdRol)
        {
            List<CotizarService.Permiso> lstPerm = new List<CotizarService.Permiso>();

            JArray jsonArray = JArray.Parse(strJsonPermisos);
            if (jsonArray.Count > 0)
            {
                foreach (var objPermiso in jsonArray.Children())
                {
                    string listaDePaises = string.Empty;

                    try
                    {
                        dynamic objArrPerm = JObject.Parse(objPermiso.ToString());
                        lstPerm.Add(new CotizarService.Permiso()
                        {
                            accion_idaccion = objArrPerm.accion,
                            funcionalidad_idfuncionalidad = objArrPerm.funcionalidad,
                            rol_idrol = (intIdRol == null ? new Nullable<short>() : intIdRol)
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lstPerm;
        }

        public JsonResult ValidaNombreRol(string nombre, bool editando)
        {
            if (editando)
                return Json(true, JsonRequestBehavior.AllowGet);

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

        public ActionResult EditarRol(short id)
        {
            CotizarService.Rol objRol = SAL.Roles.RecuperarXId(id);
            CotizarService.RolModel objRolModel = new CotizarService.RolModel()
            {
                activo = objRol.activo,
                descripcion = objRol.descripcion,
                fechacreacion = objRol.fechacreacion,
                idrol = objRol.idrol,
                nombre = objRol.nombre,
                permisos = objRol.permisos,
                hfdPermisosSeleccionados = this.GenerarJsonPermisos(objRol.permisos)
            };

            ViewBag.lstFuncionalidades = SAL.Funcionalidad.RecuperarActivas();

            return View(objRolModel);
        }

        private string GenerarJsonPermisos(IEnumerable<CotizarService.Permiso> lstPermisos)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstPermisos)
            {
                strResultado.Append("{\"funcionalidad\":\"" + item.funcionalidad_idfuncionalidad.ToString() + "\","
                    + "\"accion\":\"" + item.accion_idaccion.ToString() + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarRol(CotizarService.RolModel obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Rol _nRol = new CotizarService.Rol
                {
                    idrol = obj.idrol,
                    activo = obj.activo,
                    descripcion = obj.descripcion,
                    nombre = obj.nombre,
                    permisos = this.CargarPermisosRol(obj.hfdPermisosSeleccionados, obj.idrol).ToList()
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Rol_Actualizar(_nRol))
                {
                    base.RegistrarNotificación("Rol actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaRoles", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de actualización.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            ViewBag.lstFuncionalidades = SAL.Funcionalidad.RecuperarActivas();
            return View(obj);
        }

        [HttpGet]
        public ActionResult EliminarRol(short id)
        {
            try
            {

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();

                if (_Service.Rol_Eliminar(new CotizarService.Rol { idrol = id }))
                {
                    base.RegistrarNotificación("Rol eliminado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaRoles", "Administracion");
                }
                else
                {
                    base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                }

            }
            catch (Exception)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }
            return RedirectToAction("ListaRoles", "Administracion");
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

        public JsonResult ValidaNombreItemLista(string nombre, byte grupo, bool editando)
        {
            if (editando)
                return Json(true, JsonRequestBehavior.AllowGet);

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
            return View(SAL.Empresas.RecuperarEmpresasTodas());
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
                    string strNombreImagen;
                    if (obj.ImageUpload.FileName.Contains(@"\"))
                    {
                        int intInicio = obj.ImageUpload.FileName.LastIndexOf(@"\") + 1;

                        strNombreImagen = obj.ImageUpload.FileName.Substring(intInicio);
                    }
                    else
                    {
                        strNombreImagen = obj.ImageUpload.FileName;
                    }

                    string path = Server.MapPath("~/images/") + strNombreImagen;

                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    obj.ImageUpload.SaveAs(path);
                    obj.urilogo = strNombreImagen;
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

            return View(obj);
        }

        public ActionResult EditarEmpresa(byte id)
        {
            CotizarService.Empresa model = SAL.Empresas.RecuperarXId(id);

            return View(new CotizarService.EmpresaModel()
            {
                activo = model.activo,
                direccion = model.direccion,
                idempresa = model.idempresa,
                nit = model.nit,
                razonsocial = model.razonsocial,
                representantelegal = model.representantelegal,
                telefono = model.telefono,
                urilogo = model.urilogo
            });
        }

        [HttpPost]
        public ActionResult EditarEmpresa(CotizarService.EmpresaModel obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.ImageUpload != null)
                {
                    string strNombreImagen;
                    if (obj.ImageUpload.FileName.Contains(@"\"))
                    {
                        int intInicio = obj.ImageUpload.FileName.LastIndexOf(@"\") + 1;

                        strNombreImagen = obj.ImageUpload.FileName.Substring(intInicio);
                    }
                    else
                    {
                        strNombreImagen = obj.ImageUpload.FileName;
                    }

                    string path = Server.MapPath("~/images/") + strNombreImagen;

                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    obj.ImageUpload.SaveAs(path);
                    obj.urilogo = strNombreImagen;
                }

                CotizarService.Empresa _nEmpresa = new CotizarService.Empresa
                {
                    activo = obj.activo,
                    direccion = obj.direccion,
                    nit = obj.nit,
                    razonsocial = obj.razonsocial,
                    representantelegal = obj.representantelegal,
                    telefono = obj.telefono,
                    urilogo = obj.urilogo,
                    idempresa = obj.idempresa
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Empresa_Actualizar(_nEmpresa))
                {
                    if (System.IO.File.Exists(Server.MapPath("~/images/") + obj.urilogo))
                        System.IO.File.Delete(Server.MapPath("~/images/") + obj.urilogo);

                    base.RegistrarNotificación("Empresa actualizada con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
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

            return View(obj);
        }

        public ActionResult EliminarEmpresa(byte id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Empresa_Eliminar(new CotizarService.Empresa() { idempresa = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado la empresa.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("La empresa no pudo ser eliminadoa. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaEmpresas", "Administracion");
        }
        #endregion
    }
}
