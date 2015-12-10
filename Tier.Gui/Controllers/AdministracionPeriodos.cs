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
using Newtonsoft.Json;

namespace Tier.Gui.Controllers
{
    public partial class AdministracionController : BaseController
    {
        private void CargarListasPeriodos(CotizarService.Periodo obj)
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
            ViewBag.ParametrosPredefinidos = JsonConvert.SerializeObject(SAL.Periodos.RecuperarParametrosPredefinidos());
            ViewBag.MaquinasActivas = JsonConvert.SerializeObject(SAL.Maquinas.RecuperarActivas());
        }

        public ActionResult ListaPeriodos()
        {
            return View(SAL.Periodos.RecuperarTodos());
        }

        public ActionResult CrearPeriodo()
        {
            this.CargarListasPeriodos(null);

            return View();
        }

        public JsonResult ValidaNombrePeriodo(string nombre, string nombreinicial, byte empresa_idempresa, bool editando)
        {
            if (editando && (nombre.Equals(nombreinicial) && empresa_idempresa.Equals(base.SesionActual.empresa.idempresa)))
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
            if (objService.Periodo_ValidaNombre(new CotizarService.Periodo() { nombre = nombre, empresa_idempresa = empresa_idempresa }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", nombre);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = nombre + i.ToString();
                if (objService.Periodo_ValidaNombre(new CotizarService.Periodo() { nombre = altCandidate, empresa_idempresa = empresa_idempresa }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", nombre, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPeriodo(CotizarService.PeriodoModel obj)
        {
            if (ModelState.IsValid)
            {
                int? _idPeriodo;

                CotizarService.Periodo _nPeriodo = new CotizarService.Periodo
                {
                    centros = this.CargarDatosPeriodicos(obj.hfdcentros).ToList(),
                    empresa_idempresa = base.SesionActual.empresa.idempresa,
                    fechafin = obj.fechafin,
                    fechainicio = obj.fechainicio,
                    gasto = obj.gasto,
                    impuestoicacree = obj.impuestoicacree,
                    nombre = obj.nombre,
                    parametros = null,
                    porcenalzageneral = obj.porcenalzageneral,
                    porcenfinanciacion = obj.porcenfinanciacion,
                    utilidad = obj.utilidad,
                    vigente = true,
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Periodo_Insertar(_nPeriodo, out _idPeriodo) && _idPeriodo != null)
                {
                    base.RegistrarNotificación("Periodo creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaPeriodos", "Administracion");
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

            this.CargarListasPeriodos(obj);
            return View(obj);
        }

        private IEnumerable<CotizarService.MaquinaDatoPeriodico> CargarDatosPeriodicos(string strJsonDatosPeriodicos)
        {
            List<CotizarService.MaquinaDatoPeriodico> lstDatos = new List<CotizarService.MaquinaDatoPeriodico>();

            if (!string.IsNullOrEmpty(strJsonDatosPeriodicos))
            {
                JArray jsonArray = JArray.Parse(strJsonDatosPeriodicos);
                if (jsonArray.Count > 0)
                {
                    foreach (var objDP in jsonArray.Children())
                    {
                        try
                        {
                            dynamic objArrVari = JObject.Parse(objDP.ToString());
                            int intIdDP;

                            lstDatos.Add(new CotizarService.MaquinaDatoPeriodico()
                            {
                                idmaquinadatosperiodos = (int.TryParse(objArrVari.idmaquinadatosperiodos.ToString(), out intIdDP) ? intIdDP : new Nullable<int>()),
                                avaluocomercial = objArrVari.avaluocomercial,
                                maquina_empresa_idempresa = objArrVari.maquina_empresa_idempresa,
                                maquina_idmaquina = objArrVari.maquina_idmaquina,
                                presupuesto = objArrVari.presupuesto,
                                tiempomtto = objArrVari.tiempomtto
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

    }
}