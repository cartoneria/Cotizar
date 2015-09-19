using Newtonsoft.Json.Linq;
using System;
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
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");
            ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
            ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarActivos(), "idPeriodo", "nombre");

            return View();
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
                        lstVariaciones.Add(new CotizarService.MaquinaVariacionProduccion()
                        {
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
                        lstDatos.Add(new CotizarService.MaquinaDatoPeriodico()
                        {
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

        public ActionResult EditarMaquna(short id)
        {
            CotizarService.Maquina _objMaquina = SAL.Maquinas.RecuperarXId(id);

            ViewBag.empresa_idempresa = new SelectList(
                SAL.Empresas.RecuperarEmpresasActivas(),
                "idempresa",
                "razonsocial",
                _objMaquina.empresa_idempresa.ToString()
                );

            ViewBag.itemlista_iditemlistas_tipo = new SelectList(
                SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina),
                "iditemlista",
                "nombre",
                _objMaquina.itemlista_iditemlistas_tipo.ToString()
                );

            ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
            ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarActivos(), "idPeriodo", "nombre");

            return View(_objMaquina);
        }

        [HttpPost]
        public ActionResult EditarMaquna(CotizarService.Maquina obj)
        {
            return View();
        }

        public ActionResult EliminarMaquna(byte id)
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
