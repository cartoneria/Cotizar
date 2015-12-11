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
                string altCandidate = nombre + "-" + i.ToString();
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
                    parametros = this.CargarParametros(obj.hfdparametros).ToList(),
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strJsonDatosPeriodicos"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strJsonParametros"></param>
        /// <returns></returns>
        private IEnumerable<CotizarService.Parametro> CargarParametros(string strJsonParametros)
        {
            List<CotizarService.Parametro> lstParametros = new List<CotizarService.Parametro>();

            if (!string.IsNullOrEmpty(strJsonParametros))
            {
                JArray jsonArray = JArray.Parse(strJsonParametros);
                if (jsonArray.Count > 0)
                {
                    foreach (var objParam in jsonArray.Children())
                    {
                        try
                        {
                            dynamic objArrParam = JObject.Parse(objParam.ToString());
                            int intIdParam;

                            lstParametros.Add(new CotizarService.Parametro()
                            {
                                idparametro = (int.TryParse(objArrParam.idparametro.ToString(), out intIdParam) ? intIdParam : new Nullable<int>()),
                                nombre = objArrParam.nombre,
                                tipo = objArrParam.tipo,
                                valorboleano = objArrParam.valorboleano,
                                valorfecha = objArrParam.valorfecha,
                                valornumero = objArrParam.valornumero,
                                valortexto = objArrParam.valortexto
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            return lstParametros;
        }

        public ActionResult EditarPeriodo(int id)
        {
            CotizarService.Periodo objPeriodo = SAL.Periodos.RecuperarXId(id);

            CotizarService.PeriodoModel objPeriodoModel = new CotizarService.PeriodoModel()
            {
                centros = objPeriodo.centros,
                empresa_idempresa = objPeriodo.empresa_idempresa,
                fechafin = objPeriodo.fechafin,
                fechainicio = objPeriodo.fechainicio,
                gasto = objPeriodo.gasto,
                hfdcentros = this.GenerarJsonCentros(objPeriodo.centros),
                hfdparametros = this.GenerarJsonParametros(objPeriodo.parametros),
                idPeriodo = objPeriodo.idPeriodo,
                impuestoicacree = objPeriodo.impuestoicacree,
                nombre = objPeriodo.nombre,
                parametros = objPeriodo.parametros,
                porcenalzageneral = objPeriodo.porcenalzageneral,
                porcenfinanciacion = objPeriodo.porcenfinanciacion,
                utilidad = objPeriodo.utilidad,
                vigente = objPeriodo.vigente
            };

            this.CargarListasPeriodos(objPeriodoModel);

            return View(objPeriodoModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstCentros"></param>
        /// <returns></returns>
        private string GenerarJsonCentros(IEnumerable<CotizarService.MaquinaDatoPeriodico> lstCentros)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstCentros)
            {
                strResultado.Append("{\"activo\": " + item.activo.ToString().ToLower() + ", "
                    + "\"avaluocomercial\": " + string.Format("{0:F}", item.avaluocomercial) + ", "
                    + "\"idmaquinadatosperiodos\": " + item.idmaquinadatosperiodos.ToString() + ", "
                    + "\"maquina_empresa_idempresa\": " + item.maquina_empresa_idempresa.ToString() + ", "
                    + "\"maquina_idmaquina\": " + item.maquina_idmaquina.ToString() + ", "
                    + "\"periodo_idPeriodo\": " + item.periodo_idPeriodo.ToString() + ", "
                    + "\"presupuesto\": " + string.Format("{0:F}", item.presupuesto) + ", "
                    + "\"tiempomtto\": " + item.tiempomtto.ToString() + "},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstParametros"></param>
        /// <returns></returns>
        private string GenerarJsonParametros(IEnumerable<CotizarService.Parametro> lstParametros)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstParametros)
            {
                strResultado.Append("{\"idparametro\": " + item.idparametro.ToString() + ", "
                    + "\"nombre\": \"" + item.nombre.ToString() + "\", "
                    + "\"periodo_idPeriodo\": " + item.periodo_idPeriodo.ToString() + ", "
                    + "\"tipo\": " + item.tipo.ToString() + ", "
                    + "\"valorboleano\": " + (item.valorboleano.HasValue ? item.valorboleano.ToString().ToLower() : "null") + ", "
                    + "\"valorfecha\": " + (item.valorfecha.HasValue ? "\"" + item.valorfecha.Value.ToShortDateString() + "\"" : "null") + ", "
                    + "\"valornumero\": " + (item.valornumero.HasValue ? string.Format("{0:F}", item.valornumero) : "null") + ", "
                    + "\"valortexto\": " + (!string.IsNullOrEmpty(item.valortexto) ? "\"" + item.valortexto + "\"" : "null") + "},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarPeriodo(CotizarService.PeriodoModel obj)
        {
            return View();
        }
    }
}