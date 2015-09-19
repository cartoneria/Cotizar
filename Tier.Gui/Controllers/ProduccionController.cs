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
    public class ProduccionController : BaseController
    {
        //
        // GET: /Produccion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaMaquinas()
        {
            return View(SAL.Maquinas.RecuperarTodas());
        }

        public ActionResult CrearMaquina()
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");
            ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
            ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarActivos(), "idPeriodo", "nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearMaquina(CotizarService.MaquinaModel obj)
        {
            if (ModelState.IsValid)
            {
                short? _idMaquina;

                CotizarService.Maquina _nMaquina = new CotizarService.Maquina
                {
                    anchomaxmp = obj.anchomaxmp,
                    anchominmp = obj.anchominmp,
                    areaancho = obj.areaancho,
                    arealargo = obj.arealargo,
                    codigo = obj.codigo,
                    consumonominal = obj.consumonominal,
                    empresa_idempresa = obj.empresa_idempresa,
                    itemlista_iditemlistas_tipo = obj.itemlista_iditemlistas_tipo,
                    largomaxmp = obj.largomaxmp,
                    largominmp = obj.largominmp,
                    nombre = obj.nombre,
                    turnos = obj.turnos,
                    DatosPeriodicos = this.CargarDatosPeriodicos(obj.hfdDatosPeriodicos).ToList(),
                    VariacionesProduccion = this.CargarVariacionesProduccion(obj.hfdCfgProduccion).ToList(),

                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Maquina_Insertar(_nMaquina, out _idMaquina) && _idMaquina != null)
                {
                    base.RegistrarNotificación("Máquina creada con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaMaquinas", "Produccion");
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

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");
            ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
            ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarActivos(), "idPeriodo", "nombre");

            return View(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="empresa_idempresa"></param>
        /// <param name="editando"></param>
        /// <returns></returns>
        public JsonResult ValidaCodigoMaquina(string codigo, byte empresa_idempresa, bool editando)
        {
            if (editando)
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Maquina_ValidaCodigo(new CotizarService.Maquina() { codigo = codigo, empresa_idempresa = empresa_idempresa }))
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strJsonVariaciones"></param>
        /// <returns></returns>
        private IEnumerable<CotizarService.MaquinaVariacionProduccion> CargarVariacionesProduccion(string strJsonVariaciones)
        {
            List<CotizarService.MaquinaVariacionProduccion> lstVariaciones = new List<CotizarService.MaquinaVariacionProduccion>();

            JArray jsonArray = JArray.Parse(strJsonVariaciones);
            if (jsonArray.Count > 0)
            {
                foreach (var objVariacion in jsonArray.Children())
                {
                    string listaDePaises = string.Empty;

                    try
                    {
                        /*ph: intph, phun: intphun, phunnomb: strphunnomb, ta: intta, taun: inttaun, taunnomb: strtaunnomb*/
                        dynamic objArrVari = JObject.Parse(objVariacion.ToString());
                        int intIdVP;

                        lstVariaciones.Add(new CotizarService.MaquinaVariacionProduccion()
                        {
                            idVariacion = (int.TryParse(objArrVari.id.ToString(), out intIdVP) ? intIdVP : new Nullable<int>()),
                            itemlista_iditemlista_produnimed = objArrVari.phun,
                            itemlista_iditemlista_taunimed = objArrVari.taun,
                            produccioncant = objArrVari.ph,
                            tiempoalistamiento = objArrVari.ta
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lstVariaciones;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strJsonDatosPeriodicos"></param>
        /// <returns></returns>
        private IEnumerable<CotizarService.MaquinaDatoPeriodico> CargarDatosPeriodicos(string strJsonDatosPeriodicos)
        {
            List<CotizarService.MaquinaDatoPeriodico> lstDatos = new List<CotizarService.MaquinaDatoPeriodico>();

            JArray jsonArray = JArray.Parse(strJsonDatosPeriodicos);
            if (jsonArray.Count > 0)
            {
                foreach (var objVariacion in jsonArray.Children())
                {
                    string listaDePaises = string.Empty;

                    try
                    {
                        /*periodo: intperiodo, periodonomb: strperiodonomb, avaluo: intavaluo, presupuesto: intpresupuesto, tm: inttm, tmum: inttmum, mumnomb: strtmumnomb*/
                        dynamic objArrVari = JObject.Parse(objVariacion.ToString());
                        int intIdDP;

                        lstDatos.Add(new CotizarService.MaquinaDatoPeriodico()
                        {
                            idmaquinadatosperiodos = (int.TryParse(objArrVari.id.ToString(), out intIdDP) ? intIdDP : new Nullable<int>()),
                            avaluocomercial = objArrVari.avaluo,
                            itemlista_iditemlista_tmunimed = objArrVari.tmum,
                            periodo_idPeriodo = objArrVari.periodo,
                            presupuesto = objArrVari.presupuesto,
                            tiempomtto = objArrVari.tm
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lstDatos;
        }

        public ActionResult EditarMaquina(short id)
        {
            IEnumerable<CotizarService.ItemLista> lstIL = SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida);
            IEnumerable<CotizarService.Periodo> lstPer = SAL.Periodos.RecuperarActivos();

            CotizarService.Maquina _objMaquina = SAL.Maquinas.RecuperarXId(id);
            CotizarService.MaquinaModel _objMaqModel = new CotizarService.MaquinaModel()
            {
                activo = _objMaquina.activo,
                anchomaxmp = _objMaquina.anchomaxmp,
                anchominmp = _objMaquina.anchominmp,
                areaancho = _objMaquina.areaancho,
                arealargo = _objMaquina.arealargo,
                codigo = _objMaquina.codigo,
                consumonominal = _objMaquina.consumonominal,
                DatosPeriodicos = _objMaquina.DatosPeriodicos,
                empresa_idempresa = _objMaquina.empresa_idempresa,
                fechacreacion = _objMaquina.fechacreacion,
                idmaquina = _objMaquina.idmaquina,
                itemlista_iditemlistas_tipo = _objMaquina.itemlista_iditemlistas_tipo,
                largomaxmp = _objMaquina.largomaxmp,
                largominmp = _objMaquina.largominmp,
                nombre = _objMaquina.nombre,
                turnos = _objMaquina.turnos,
                VariacionesProduccion = _objMaquina.VariacionesProduccion,
                hfdCfgProduccion = this.GenerarJsonVP(_objMaquina.VariacionesProduccion, lstPer, lstIL),
                hfdDatosPeriodicos = this.GenerarJsonDP(_objMaquina.DatosPeriodicos, lstPer, lstIL)
            };

            ViewBag.empresa_idempresa = new SelectList(
                SAL.Empresas.RecuperarEmpresasActivas(),
                "idempresa",
                "razonsocial",
                _objMaqModel.empresa_idempresa.ToString()
                );

            ViewBag.itemlista_iditemlistas_tipo = new SelectList(
                SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina),
                "iditemlista",
                "nombre",
                _objMaqModel.itemlista_iditemlistas_tipo.ToString()
                );

            ViewBag.unidades_medida = new SelectList(lstIL, "iditemlista", "nombre");
            ViewBag.periodos = new SelectList(lstPer, "idPeriodo", "nombre");

            return View(_objMaqModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstVP"></param>
        /// <param name="lstPer"></param>
        /// <param name="lstIL"></param>
        /// <returns></returns>
        private string GenerarJsonVP(IEnumerable<CotizarService.MaquinaVariacionProduccion> lstVP,
            IEnumerable<CotizarService.Periodo> lstPer,
            IEnumerable<CotizarService.ItemLista> lstIL)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstVP)
            {
                strResultado.Append("{\"id\":\"" + item.idVariacion.ToString() + "\"," +
                    "\"ph\":\"" + item.produccioncant.ToString() + "\"," +
                    "\"phun\":\"" + item.itemlista_iditemlista_produnimed.ToString() + "\"," +
                    "\"phunnomb\":\"" + lstIL.Where(ee => ee.iditemlista == item.itemlista_iditemlista_produnimed).FirstOrDefault().nombre + "\"," +
                    "\"ta\":\"" + item.tiempoalistamiento.ToString() + "\"," +
                    "\"taun\":\"" + item.itemlista_iditemlista_taunimed.ToString() + "\"," +
                    "\"taunnomb\":\"" + lstIL.Where(ee => ee.iditemlista == item.itemlista_iditemlista_taunimed).FirstOrDefault().nombre + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstDP"></param>
        /// <param name="lstPer"></param>
        /// <param name="lstIL"></param>
        /// <returns></returns>
        private string GenerarJsonDP(IEnumerable<CotizarService.MaquinaDatoPeriodico> lstDP,
            IEnumerable<CotizarService.Periodo> lstPer,
            IEnumerable<CotizarService.ItemLista> lstIL)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstDP)
            {
                strResultado.Append("{\"id\":\"" + item.idmaquinadatosperiodos.ToString() + "\"," +
                    "\"periodo\":\"" + item.periodo_idPeriodo.ToString() + "\"," +
                    "\"periodonomb\":\"" + lstPer.Where(ee => ee.idPeriodo == item.periodo_idPeriodo).FirstOrDefault().nombre + "\"," +
                    "\"avaluo\":\"" + string.Format("{0:f}", item.avaluocomercial) + "\"," +
                    "\"presupuesto\":\"" + string.Format("{0:f}", item.presupuesto) + "\"," +
                    "\"tm\":\"" + item.tiempomtto.ToString() + "\"," +
                    "\"tmum\":\"" + item.itemlista_iditemlista_tmunimed.ToString() + "\"," +
                    "\"mumnomb\":\"" + lstIL.Where(ee => ee.iditemlista == item.itemlista_iditemlista_tmunimed).FirstOrDefault().nombre + "\"},");
            }

            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarMaquina(CotizarService.MaquinaModel obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Maquina _nMaquina = new CotizarService.Maquina
                {
                    activo = obj.activo,
                    anchomaxmp = obj.anchomaxmp,
                    anchominmp = obj.anchominmp,
                    areaancho = obj.areaancho,
                    arealargo = obj.arealargo,
                    codigo = obj.codigo,
                    consumonominal = obj.consumonominal,
                    empresa_idempresa = obj.empresa_idempresa,
                    idmaquina = obj.idmaquina,
                    itemlista_iditemlistas_tipo = obj.itemlista_iditemlistas_tipo,
                    largomaxmp = obj.largomaxmp,
                    largominmp = obj.largominmp,
                    nombre = obj.nombre,
                    turnos = obj.turnos,
                    DatosPeriodicos = this.CargarDatosPeriodicos(obj.hfdDatosPeriodicos).ToList(),
                    VariacionesProduccion = this.CargarVariacionesProduccion(obj.hfdCfgProduccion).ToList(),
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Maquina_Actualizar(_nMaquina))
                {
                    base.RegistrarNotificación("Máquina actualizada con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaMaquinas", "Produccion");
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

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", obj.empresa_idempresa.ToString());
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre", obj.itemlista_iditemlistas_tipo.ToString());
            ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
            ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarActivos(), "idPeriodo", "nombre");

            return View(obj);
        }

        public ActionResult EliminarMaquina(byte id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Maquina_Eliminar(new CotizarService.Maquina() { idmaquina = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado la máquina.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("La máquina no pudo ser eliminada. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaMaquinas", "Produccion");
        }
    }
}
