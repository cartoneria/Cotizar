using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ProduccionController : BaseController
    {
        private void CargarListasEstilos(CotizarService.EstiloModel obj)
        {
            ViewBag.maquinavariprod_idVariacion_rutapegue = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Pegue, null, null).ToList(), "idVariacion", "nombre");
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaEstilos()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult ListaEstilos(string txtNombre, string txtCodigo)
        {
            IEnumerable<CotizarService.Estilo> lst = SAL.Estilos.RecuperarFiltrados(new CotizarService.Estilo()
            {
                codigo = string.IsNullOrEmpty(txtCodigo) ? null : txtCodigo,
                nombre = string.IsNullOrEmpty(txtNombre) ? null : txtNombre,
                empresa_idempresa = base.SesionActual.empresa.idempresa
            }, false);

            return PartialView("_TablaEstilos", lst);
        }

        public ActionResult CrearEstilo()
        {
            this.CargarListasEstilos(null);
            return View();
        }

        public JsonResult ValidaCodigoEstilo(string codigo, byte empresa_idempresa, bool editando, string codigoinicial)
        {
            if (editando && (codigo.Equals(codigoinicial) && empresa_idempresa.Equals(base.SesionActual.empresa.idempresa)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Estilo_ValidaCodigo(new CotizarService.Estilo() { codigo = codigo, empresa_idempresa = empresa_idempresa }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", codigo);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = codigo + i.ToString();
                if (objService.Maquina_ValidaCodigo(new CotizarService.Maquina() { codigo = altCandidate, empresa_idempresa = empresa_idempresa }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", codigo, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearEstilo(CotizarService.EstiloModel obj)
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

                    string path = Server.MapPath("~/images/Estilos/");
                    string fullPath = path + strNombreImagen;

                    base.AlistarRutaArchivo(path);

                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);

                    obj.ImageUpload.SaveAs(fullPath);
                    obj.nombreimagen = strNombreImagen;
                }

                int? _idEstilo;

                CotizarService.Estilo _nEstilo = new CotizarService.Estilo
                {
                    codigo = obj.codigo,
                    empresa_idempresa = obj.empresa_idempresa,
                    nombre = obj.nombre,
                    nombreimagen = obj.nombreimagen,
                    pegues = this.CargarPegues(obj.hfdpegues).ToList()
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Estilo_Insertar(_nEstilo, out _idEstilo) && _idEstilo != null)
                {
                    base.RegistrarNotificación("Estilo creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaEstilos", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son válidos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasEstilos(obj);
            return View(obj);
        }

        private IEnumerable<CotizarService.EstiloPegue> CargarPegues(string strJsonPegues)
        {
            List<CotizarService.EstiloPegue> lstDatos = new List<CotizarService.EstiloPegue>();

            if (!string.IsNullOrEmpty(strJsonPegues))
            {
                JArray jsonArray = JArray.Parse(strJsonPegues);
                if (jsonArray.Count > 0)
                {
                    foreach (var objArrEP in jsonArray.Children())
                    {
                        try
                        {
                            dynamic objEP = JObject.Parse(objArrEP.ToString());
                            int intIdEP;

                            lstDatos.Add(new CotizarService.EstiloPegue()
                            {
                                idestilo_pegue = (int.TryParse(objEP.id.ToString(), out intIdEP) ? intIdEP : new Nullable<int>()),
                                cantidad = objEP.cant,
                                maquinavariprod_idVariacion_rutapegue = objEP.tp,
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            return lstDatos;
        }

        public ActionResult EditarEstilo(int id)
        {
            CotizarService.Estilo _objEstilo = SAL.Estilos.RecuperarXId(id, true);

            if (_objEstilo != null)
            {
                CotizarService.EstiloModel _objMaqModel = new CotizarService.EstiloModel()
                {
                    activo = _objEstilo.activo,
                    codigo = _objEstilo.codigo,
                    empresa_idempresa = _objEstilo.empresa_idempresa,
                    fechacreacion = _objEstilo.fechacreacion,
                    hfdpegues = this.GenerarJsonPegues(_objEstilo.pegues),
                    idestilo = _objEstilo.idestilo,
                    nombre = _objEstilo.nombre,
                    nombreimagen = _objEstilo.nombreimagen,
                    pegues = _objEstilo.pegues
                };

                this.CargarListasEstilos(_objMaqModel);

                return View(_objMaqModel);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaMaquinas", "Produccion");
            }
        }

        private string GenerarJsonPegues(IEnumerable<CotizarService.EstiloPegue> lstPegues)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstPegues)
            {
                strResultado.Append("{\"id\":\"" + item.idestilo_pegue.ToString() + "\"," +
                    "\"tp\":\"" + item.maquinavariprod_idVariacion_rutapegue.ToString() + "\"," +
                    "\"tpdesc\":\"" + item.maquinavariprod_idVariacion_descrutapegue + "\"," +
                    "\"cant\":" + item.cantidad + "},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarEstilo(CotizarService.EstiloModel obj)
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

                    string path = Server.MapPath("~/images/Estilos/");
                    string fullPath = path + strNombreImagen;

                    base.AlistarRutaArchivo(path);

                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);

                    obj.ImageUpload.SaveAs(fullPath);
                    obj.nombreimagen = strNombreImagen;
                }

                CotizarService.Estilo _nEstilo = new CotizarService.Estilo
                {
                    idestilo = obj.idestilo,
                    activo = obj.activo,
                    codigo = obj.codigo,
                    nombre = obj.nombre,
                    nombreimagen = obj.nombreimagen,
                    pegues = this.CargarPegues(obj.hfdpegues).ToList()
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Estilo_Actualizar(_nEstilo))
                {
                    base.RegistrarNotificación("Estilo actualizado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaEstilos", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de actualización.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son válidos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListasEstilos(obj);

            return View(obj);
        }

        public ActionResult EliminarEstilo(int id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Estilo_Eliminar(new CotizarService.Estilo() { idestilo = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el estilo de troquel.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El estilo de troquel no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaEstilos", "Produccion");
        }
    }
}