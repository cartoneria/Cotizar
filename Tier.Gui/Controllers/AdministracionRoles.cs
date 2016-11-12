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
    public partial class AdministracionController : BaseController
    {
        private void CargarListasRoles(CotizarService.Rol obj)
        {
            ViewBag.lstFuncionalidades = SAL.Funcionalidad.RecuperarActivas(true);
        }

        public ActionResult ListaRoles()
        {
            return View(SAL.Roles.RecuperarTodos(false));
        }

        public ActionResult CrearRol()
        {
            this.CargarListasRoles(null);
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

            this.CargarListasRoles(obj);
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

        public JsonResult ValidaNombreRol(string nombre, bool editando, string nombreinicial)
        {
            if (editando && (nombre == nombreinicial))
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
            CotizarService.Rol objRol = SAL.Roles.RecuperarXId(id, true);

            if (objRol != null)
            {
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

                this.CargarListasRoles(null);

                return View(objRolModel);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaRoles", "Administracion");
            }
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

            this.CargarListasRoles(obj);
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
    }
}