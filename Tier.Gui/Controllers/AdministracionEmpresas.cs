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
            CotizarService.Empresa objempresa = SAL.Empresas.RecuperarXId(id);

            if (objempresa != null)
            {
                CotizarService.EmpresaModel _objModelo = new CotizarService.EmpresaModel()
                    {
                        activo = objempresa.activo,
                        direccion = objempresa.direccion,
                        idempresa = objempresa.idempresa,
                        nit = objempresa.nit,
                        razonsocial = objempresa.razonsocial,
                        representantelegal = objempresa.representantelegal,
                        telefono = objempresa.telefono,
                        urilogo = objempresa.urilogo
                    };

                return View(_objModelo);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaEmpresas", "Administracion");
            }
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
    }
}