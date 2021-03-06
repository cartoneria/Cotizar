﻿using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

namespace Tier.Gui.Controllers
{
    public partial class ProduccionController : BaseController
    {
        private void CargarListasTroqueles(CotizarService.TroquelModel obj)
        {
            if (obj != null)
            {
                ViewBag.estilo_idestilo = new SelectList(SAL.Estilos.RecuperarEstilosActivos(base.SesionActual.empresa.idempresa, false), "idestilo", "nombre", obj.estilo_idestilo);
                ViewBag.itemlista_iditemlista_material = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposCarton, false), "iditemlista", "nombre", obj.itemlista_iditemlista_material);
            }
            else
            {
                ViewBag.estilo_idestilo = new SelectList(SAL.Estilos.RecuperarEstilosActivos(base.SesionActual.empresa.idempresa, false), "idestilo", "nombre");
                ViewBag.itemlista_iditemlista_material = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposCarton, false), "iditemlista", "nombre");
            }

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas().Where(c => c.idempresa == base.SesionActual.empresa.idempresa), "idempresa", "razonsocial", base.SesionActual.empresa.idempresa);
        }

        public ActionResult ListaTroqueles()
        {
            ViewBag.ddlMaterial = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposCarton, false), "iditemlista", "nombre");
            ViewBag.ddlEstilo = new SelectList(SAL.Estilos.RecuperarEstilosActivos(base.SesionActual.empresa.idempresa, false), "idestilo", "nombre");
            return View();
        }

        [HttpPost]
        public PartialViewResult ListaTroqueles(string txtDescripcion, Nullable<int> ddlMaterial, string txtMarcacion, Nullable<int> ddlEstilo, Nullable<Single> txtAlto, Nullable<Single> txtAncho, Nullable<Single> txtLargo)
        {
            IEnumerable<CotizarService.Troquel> lst = SAL.Troqueles.RecuperarFiltrados(new CotizarService.Troquel()
            {
                descripcion = string.IsNullOrEmpty(txtDescripcion) ? null : txtDescripcion,
                marca = string.IsNullOrEmpty(txtMarcacion) ? null : txtMarcacion,
                itemlista_iditemlista_material = ddlMaterial,
                empresa_idempresa = base.SesionActual.empresa.idempresa,
                estilo_idestilo = ddlEstilo,
                alto = txtAlto,
                ancho = txtAncho,
                largo = txtLargo
            }, false);

            ViewBag.itemlista_iditemlista_material = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposCarton, false), "iditemlista", "nombre");
            return PartialView("_TablaTroqueles", lst);
        }

        public ActionResult CrearTroquel()
        {
            this.CargarListasTroqueles(null);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearTroquel(CotizarService.TroquelModel obj)
        {
            if (ModelState.IsValid)
            {
                int? _idTroquel;

                CotizarService.Troquel _nTroquel = new CotizarService.Troquel
                {
                    alto = obj.alto,
                    ancho = obj.ancho,
                    cabidacontrafibra = obj.cabidacontrafibra,
                    cabidafibra = obj.cabidafibra,
                    contrafibra = obj.contrafibra,
                    descripcion = obj.descripcion,
                    fibra = obj.fibra,
                    itemlista_iditemlista_material = obj.itemlista_iditemlista_material,
                    largo = obj.largo,
                    estilo_idestilo = obj.estilo_idestilo,
                    observaciones = obj.observaciones,
                    tamanio = obj.tamanio,
                    ventanas = this.CargarVentanas(obj.hfdVentanas).ToList(),
                    empresa_idempresa = obj.empresa_idempresa,
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Troquel_Insertar(_nTroquel, out _idTroquel) && _idTroquel != null)
                {
                    base.RegistrarNotificación("Troquel creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaTroqueles", "Produccion");
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

            this.CargarListasTroqueles(obj);
            return View(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strJsonVentanas"></param>
        /// <returns></returns>
        private IEnumerable<CotizarService.TroquelVentana> CargarVentanas(string strJsonVentanas)
        {
            List<CotizarService.TroquelVentana> lstVentanas = new List<CotizarService.TroquelVentana>();

            if (!string.IsNullOrEmpty(strJsonVentanas))
            {
                JArray jsonArray = JArray.Parse(strJsonVentanas);
                if (jsonArray.Count > 0)
                {
                    foreach (var objVentana in jsonArray.Children())
                    {
                        try
                        {
                            dynamic objArrVent = JObject.Parse(objVentana.ToString());
                            int intIdV;

                            lstVentanas.Add(new CotizarService.TroquelVentana()
                            {
                                idtroquel_ventana = (int.TryParse(objArrVent.id.ToString(), out intIdV) ? intIdV : new Nullable<int>()),
                                largo = objArrVent.Largo,
                                alto = objArrVent.Alto,
                                activo = objArrVent.Activo,
                                troquel_idtroquel = objArrVent.Troquel
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            return lstVentanas;
        }

        public ActionResult EditarTroquel(int id)
        {
            CotizarService.Troquel objTroquel = SAL.Troqueles.RecuperarXId(id, base.SesionActual.empresa.idempresa, true);

            if (objTroquel != null)
            {
                CotizarService.TroquelModel objEditar = new CotizarService.TroquelModel()
                    {
                        activo = objTroquel.activo,
                        alto = objTroquel.alto,
                        ancho = objTroquel.ancho,
                        cabidacontrafibra = objTroquel.cabidacontrafibra,
                        cabidafibra = objTroquel.cabidafibra,
                        contrafibra = objTroquel.contrafibra,
                        descripcion = objTroquel.descripcion,
                        fechacreacion = objTroquel.fechacreacion,
                        fibra = objTroquel.fibra,
                        idtroquel = objTroquel.idtroquel,
                        itemlista_iditemlista_material = objTroquel.itemlista_iditemlista_material,
                        largo = objTroquel.largo,
                        estilo_idestilo = objTroquel.estilo_idestilo,
                        ubicacion = objTroquel.ubicacion,
                        marca = objTroquel.marca,
                        observaciones = objTroquel.observaciones,
                        tamanio = objTroquel.tamanio,
                        hfdVentanas = this.GenerarJsonVentanas(objTroquel.ventanas),
                        empresa_idempresa = objTroquel.empresa_idempresa,
                    };

                this.CargarListasTroqueles(objEditar);

                return View(objEditar);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaTroqueles", "Produccion");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lstV"></param>
        /// <returns></returns>
        private string GenerarJsonVentanas(IEnumerable<CotizarService.TroquelVentana> lstV)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstV)
            {
                strResultado.Append("{\"id\":\"" + item.idtroquel_ventana.ToString() + "\"," +
                    "\"Largo\":\"" + item.largo.ToString() + "\"," +
                    "\"Alto\":\"" + item.alto.ToString() + "\"," +
                    "\"Activo\":\"" + item.activo.ToString() + "\"," +
                    "\"Troquel\":\"" + item.troquel_idtroquel.ToString() + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarTroquel(CotizarService.TroquelModel obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Troquel _nTroquel = new CotizarService.Troquel
                {
                    activo = obj.activo,
                    alto = obj.alto,
                    ancho = obj.ancho,
                    cabidacontrafibra = obj.cabidacontrafibra,
                    cabidafibra = obj.cabidafibra,
                    contrafibra = obj.contrafibra,
                    descripcion = obj.descripcion,
                    fibra = obj.fibra,
                    idtroquel = obj.idtroquel,
                    itemlista_iditemlista_material = obj.itemlista_iditemlista_material,
                    largo = obj.largo,
                    estilo_idestilo = obj.estilo_idestilo,
                    observaciones = obj.observaciones,
                    tamanio = obj.tamanio,
                    ventanas = this.CargarVentanas(obj.hfdVentanas).ToList(),
                    empresa_idempresa = obj.empresa_idempresa,
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Troquel_Actualizar(_nTroquel))
                {
                    base.RegistrarNotificación("Troquel actualizado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaTroqueles", "Produccion");
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

            this.CargarListasTroqueles(obj);

            return View(obj);
        }

        public ActionResult EliminarTroquel(byte id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Troquel_Eliminar(new CotizarService.Troquel() { idtroquel = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el troquel.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El troquel no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaTroqueles", "Produccion");
        }

        public PartialViewResult TablaPeguesEstiloTroquel(Nullable<int> id)
        {
            IEnumerable<CotizarService.EstiloPegue> lstPegues;

            if (id != null)
            {
                CotizarService.Troquel objTroquel = SAL.Troqueles.RecuperarXId((int)id, false);
                lstPegues = SAL.Estilos.RecuperarPeguesFiltrados(new CotizarService.Estilo() { idestilo = objTroquel.estilo_idestilo });
            }
            else
            {
                lstPegues = new List<CotizarService.EstiloPegue>();
            }
            return PartialView("_ListaPeguesEstilo", lstPegues);
        }
    }
}