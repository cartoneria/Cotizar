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
        private void CargarListasMaquinas(CotizarService.MaquinaModel obj)
        {
            if (obj != null)
            {
                ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaquina), "iditemlista", "nombre", obj.itemlista_iditemlistas_tipo);
                ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
                ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarTodos(base.SesionActual.empresa.idempresa), "idPeriodo", "nombre");
            }
            else
            {
                ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaquina), "iditemlista", "nombre");
                ViewBag.unidades_medida = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");
                ViewBag.periodos = new SelectList(SAL.Periodos.RecuperarTodos(base.SesionActual.empresa.idempresa), "idPeriodo", "nombre");
            }

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaMaquinas()
        {
            ViewBag.ddlTipoMaquina = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaquina), "iditemlista", "nombre");
            return View();
        }

        [HttpPost]
        public PartialViewResult ListaMaquinas(string txtNombre, string txtCodigo, Nullable<int> ddlTipoMaquina)
        {
            IEnumerable<CotizarService.Maquina> lst = SAL.Maquinas.RecuperarFiltrados(new CotizarService.Maquina()
            {
                codigo = string.IsNullOrEmpty(txtCodigo) ? null : txtCodigo,
                nombre = string.IsNullOrEmpty(txtNombre) ? null : txtNombre,
                itemlista_iditemlistas_tipo = ddlTipoMaquina,
                empresa_idempresa = base.SesionActual.empresa.idempresa
            });

            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaquina), "iditemlista", "nombre");
            return PartialView("_TablaMaquinas", lst);
        }

        public ActionResult CrearMaquina()
        {
            this.CargarListasMaquinas(null);

            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="empresa_idempresa"></param>
        /// <param name="editando"></param>
        /// <returns></returns>
        public JsonResult ValidaCodigoMaquina(string codigo, byte empresa_idempresa, bool editando, string codigoinicial)
        {
            if (editando && (codigo.Equals(codigoinicial) && empresa_idempresa.Equals(base.SesionActual.empresa.idempresa)))
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
                    numerotintas = obj.numerotintas,
                    valorplancha = obj.valorplancha
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

            this.CargarListasMaquinas(obj);
            return View(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strJsonVariaciones"></param>
        /// <returns></returns>
        private IEnumerable<CotizarService.MaquinaVariacionProduccion> CargarVariacionesProduccion(string strJsonVariaciones)
        {
            List<CotizarService.MaquinaVariacionProduccion> lstVariaciones = new List<CotizarService.MaquinaVariacionProduccion>();

            if (!string.IsNullOrEmpty(strJsonVariaciones))
            {
                JArray jsonArray = JArray.Parse(strJsonVariaciones);
                if (jsonArray.Count > 0)
                {
                    foreach (var objVariacion in jsonArray.Children())
                    {
                        try
                        {
                            dynamic objArrVari = JObject.Parse(objVariacion.ToString());
                            int intIdVP;

                            lstVariaciones.Add(new CotizarService.MaquinaVariacionProduccion()
                            {
                                idVariacion = (int.TryParse(objArrVari.id.ToString(), out intIdVP) ? intIdVP : new Nullable<int>()),
                                itemlista_iditemlista_produnimed = objArrVari.phun,
                                produccioncant = objArrVari.ph,
                                tiempoalistamiento = objArrVari.ta,
                                nombre_variacion_produccion = objArrVari.pvnombre
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
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

            if (!string.IsNullOrEmpty(strJsonDatosPeriodicos))
            {
                JArray jsonArray = JArray.Parse(strJsonDatosPeriodicos);
                if (jsonArray.Count > 0)
                {
                    foreach (var objVariacion in jsonArray.Children())
                    {
                        try
                        {
                            /*periodo: intperiodo, periodonomb: strperiodonomb, avaluo: intavaluo, presupuesto: intpresupuesto, tm: inttm, tmum: inttmum, mumnomb: strtmumnomb*/
                            dynamic objArrVari = JObject.Parse(objVariacion.ToString());
                            int intIdDP;

                            lstDatos.Add(new CotizarService.MaquinaDatoPeriodico()
                            {
                                idmaquinadatosperiodos = (int.TryParse(objArrVari.id.ToString(), out intIdDP) ? intIdDP : new Nullable<int>()),
                                avaluocomercial = objArrVari.avaluo,
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
            }

            return lstDatos;
        }

        public ActionResult EditarMaquina(short id)
        {
            CotizarService.Maquina _objMaquina = SAL.Maquinas.RecuperarXId(id, base.SesionActual.empresa.idempresa);

            if (_objMaquina != null)
            {
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
                    hfdCfgProduccion = this.GenerarJsonVP(_objMaquina.VariacionesProduccion),
                    hfdDatosPeriodicos = this.GenerarJsonDP(_objMaquina.DatosPeriodicos),
                    numerotintas = _objMaquina.numerotintas,
                    valorplancha = _objMaquina.valorplancha
                };

                this.CargarListasMaquinas(_objMaqModel);

                return View(_objMaqModel);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaMaquinas", "Produccion");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstVP"></param>
        /// <param name="lstIL"></param>
        /// <returns></returns>
        private string GenerarJsonVP(IEnumerable<CotizarService.MaquinaVariacionProduccion> lstVP)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstVP)
            {
                strResultado.Append("{\"id\":\"" + item.idVariacion.ToString() + "\"," +
                    "\"ph\":\"" + item.produccioncant.ToString() + "\"," +
                    "\"phun\":\"" + item.itemlista_iditemlista_produnimed.ToString() + "\"," +
                    "\"phunnomb\":\"" + item.itemlista_iditemlista_descunimed + "\"," +
                    "\"ta\":\"" + item.tiempoalistamiento.ToString() + "\"," +
                    "\"pvnombre\":\"" + item.nombre_variacion_produccion.ToString() + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstDP"></param>
        /// <param name="lstIL"></param>
        /// <returns></returns>
        private string GenerarJsonDP(IEnumerable<CotizarService.MaquinaDatoPeriodico> lstDP)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstDP)
            {
                strResultado.Append("{\"id\":\"" + item.idmaquinadatosperiodos.ToString() + "\"," +
                    "\"periodo\":\"" + item.periodo_idPeriodo.ToString() + "\"," +
                    "\"periodonomb\":\"" + item.periodo_descperiodo + "\"," +
                    "\"avaluo\":\"" + string.Format("{0:f}", item.avaluocomercial) + "\"," +
                    "\"presupuesto\":\"" + string.Format("{0:f}", item.presupuesto) + "\"," +
                    "\"tm\":\"" + item.tiempomtto.ToString() + "\"},");
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
                    numerotintas = obj.numerotintas,
                    valorplancha = obj.valorplancha
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

            this.CargarListasMaquinas(obj);

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