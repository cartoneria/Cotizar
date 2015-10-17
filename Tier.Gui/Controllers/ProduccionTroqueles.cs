﻿using Newtonsoft.Json.Linq;
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
        private void CargarListas(CotizarService.TroquelModel obj)
        {
            if (obj != null)
            {
                ViewBag.itemlista_iditemlista_material = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre", obj.itemlista_iditemlista_material);
            }
            else
            {
                ViewBag.itemlista_iditemlista_material = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre");
            }
        }

        public ActionResult ListaTroqueles()
        {
            return View(SAL.Troqueles.RecuperarTodos());
        }

        public ActionResult CrearTroquel()
        {
            this.CargarListas(null);

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
                    modelo = obj.modelo,
                    observaciones = obj.observaciones,
                    tamanio = obj.tamanio,
                    ventanas = this.CargarVentanas(obj.hfdVentanas).ToList()
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

            this.CargarListas(obj);
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

            return lstVentanas;
        }

        public ActionResult EditarTroquel(int id)
        {
            CotizarService.Troquel objTroquel = SAL.Troqueles.RecuperarXId(id);
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
                modelo = objTroquel.modelo,
                observaciones = objTroquel.observaciones,
                tamanio = objTroquel.tamanio,
                hfdVentanas = this.GenerarJsonVentanas(objTroquel.ventanas)
            };

            this.CargarListas(objEditar);

            return View(objEditar);
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
                    modelo = obj.modelo,
                    observaciones = obj.observaciones,
                    tamanio = obj.tamanio,
                    ventanas = this.CargarVentanas(obj.hfdVentanas).ToList()
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

            this.CargarListas(obj);

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
    }
}