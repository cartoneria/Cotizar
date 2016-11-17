using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Tier.Gui.Controllers
{
    public partial class ComercialController : BaseController
    {
        private void CargarListasPedidos(CotizarService.PedidoModel obj)
        {
            var objCotizacion = SAL.Cotizaciones.RecuperarXId((int)obj.cotizacion_idcotizacion, true);
            var objCliente = SAL.Clientes.RecuperarXId((int)objCotizacion.cliente_idcliente, base.SesionActual.empresa.idempresa);
            ViewBag.Cliente = objCliente;
            ViewBag.Cotizacion = objCotizacion;

            ViewBag.Cartera = SAL.Cartera.RecuperarVencidaXCliente(objCliente.idcliente);
        }

        public ActionResult ListaPedidos(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            var objCliente = SAL.Clientes.RecuperarXId((int)id, base.SesionActual.empresa.idempresa);
            ViewBag.Cliente = objCliente;

            return View(SAL.Pedidos.RecuperarXCliente((int)id, false));
        }

        [HttpPost]
        public ActionResult CargarModeloPedido(FormCollection controles)
        {
            CotizarService.PedidoModel objPedido = new CotizarService.PedidoModel();

            objPedido.cotizacion_idcotizacion = Convert.ToInt32(controles["idcotizacion"]);
            objPedido.detalle = this.CargarPedidoDetalle(controles["hdfProdPedido"]).ToList();

            this.TempPedido = objPedido;

            return RedirectToAction("CrearPedido", "Comercial");
        }

        private IEnumerable<CotizarService.PedidoDetalle> CargarPedidoDetalle(string strJsonPedidoDetalle)
        {
            List<CotizarService.PedidoDetalle> lstDetalle = new List<CotizarService.PedidoDetalle>();
            if (strJsonPedidoDetalle != null)
            {
                JArray jsonArray = JArray.Parse(strJsonPedidoDetalle);
                if (jsonArray.Count > 0)
                {
                    foreach (var objCantidad in jsonArray.Children())
                    {
                        try
                        {
                            dynamic objArrCant = JObject.Parse(objCantidad.ToString());

                            lstDetalle.Add(new CotizarService.PedidoDetalle()
                            {
                                cotizacion_detalle_idcotizacion_detalle = objArrCant.cd,
                                observaciones = objArrCant.observaciones,
                                cantidad = objArrCant.cant
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            return lstDetalle;
        }

        public ActionResult CrearPedido()
        {
            CotizarService.PedidoModel objPedido = this.TempPedido;

            if (this.Request.UrlReferrer == null && objPedido == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cotización.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            Single costoTotalPlachas = 0;
            Single costoTotalTroqueles = 0;
            IList<int> lstIdProd = new List<int>();

            this.CargarListasPedidos(objPedido);

            CotizarService.Cotizacion objCot = (CotizarService.Cotizacion)ViewBag.Cotizacion;

            foreach (CotizarService.PedidoDetalle pd in objPedido.detalle)
            {
                CotizarService.CotizacionDetalle objcd = objCot.detalle.Where(ee => ee.idcotizacion_detalle == pd.cotizacion_detalle_idcotizacion_detalle).FirstOrDefault();

                if (objcd != null && objcd.producto_idproducto.HasValue)
                {
                    lstIdProd.Add((int)objcd.producto_idproducto);
                }
            }

            CalcularCostoPlanchasTroqueles((int)objCot.periodo_idPeriodo, lstIdProd.ToArray(), ref costoTotalPlachas, ref costoTotalTroqueles);

            objPedido.costosplancha = costoTotalPlachas;
            objPedido.costostroqueles = costoTotalTroqueles;
            objPedido.hfddetalle = Newtonsoft.Json.JsonConvert.SerializeObject(objPedido.detalle);

            return View(objPedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearPedido(CotizarService.PedidoModel obj)
        {

            if (ModelState.IsValid)
            {
                int? _idPedido;

                CotizarService.Pedido _pedido = new CotizarService.Pedido
                {
                    cotizacion_idcotizacion = obj.cotizacion_idcotizacion,
                    costosplancha = obj.costosplancha,
                    costostroqueles = obj.costostroqueles,
                    detalle = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CotizarService.PedidoDetalle>>(obj.hfddetalle),
                    identificadorsiigo = obj.identificadorsiigo,
                    itemlista_iditemlista_estado = (int)Models.Enumeradores.EstadosPedido.Creacion,
                    observaciones = obj.observaciones,
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Pedido_Insertar(_pedido, out _idPedido) && _idPedido != null)
                {
                    base.RegistrarNotificación("Pedido creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ConsultarPedido", "Comercial", new { id = _idPedido });
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

            this.CargarListasPedidos(obj);

            return View(obj);
        }

        public ActionResult ConsultarPedido(int id)
        {
            CotizarService.Pedido objpedido = SAL.Pedidos.RecuperarXId(id, true);

            CotizarService.PedidoModel objPedidoModel = new CotizarService.PedidoModel()
            {
                activo = objpedido.activo,
                costosplancha = objpedido.costosplancha,
                costostroqueles = objpedido.costostroqueles,
                cotizacion_idcotizacion = objpedido.cotizacion_idcotizacion,
                detalle = objpedido.detalle,
                fechacreacion = objpedido.fechacreacion,
                hfddetalle = Newtonsoft.Json.JsonConvert.SerializeObject(objpedido.detalle),
                identificadorsiigo = objpedido.identificadorsiigo,
                idpedido = objpedido.idpedido,
                itemlista_iditemlista_estado = objpedido.itemlista_iditemlista_estado,
                observaciones = objpedido.observaciones,
                itemlista_iditemlista_descestado = objpedido.itemlista_iditemlista_descestado,
                fechaproduccion = objpedido.fechaproduccion
            };

            this.CargarListasPedidos(objPedidoModel);
            return View(objPedidoModel);
        }

        public ActionResult CambiarEstadoPedido(int id, int estado, string observ, string idsiigo)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Pedido objpedido = SAL.Pedidos.RecuperarXId(id, false);

                CotizarService.Pedido _pedido = new CotizarService.Pedido
                {
                    idpedido = id,
                    activo = objpedido.activo,
                    itemlista_iditemlista_estado = estado,
                    observaciones = observ,
                    cotizacion_idcotizacion = objpedido.cotizacion_idcotizacion,
                    identificadorsiigo = idsiigo,
                    fechaproduccion = (estado == (int)Models.Enumeradores.EstadosPedido.EnFabricacion ? DateTime.Now : new Nullable<DateTime>())
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Pedido_Actualizar(_pedido))
                {
                    base.RegistrarNotificación("Pedido creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ConsultarPedido", "Comercial", new { id = id });
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

            return RedirectToAction("ConsultarPedido", "Comercial", new { id = id });
        }

        public ActionResult EliminarPedido(int idPedido, int idCotizacion)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

                if (objService.Pedido_Eliminar(new CotizarService.Pedido() { idpedido = idPedido, cotizacion_idcotizacion = idCotizacion }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el pedido.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El pedido no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            CotizarService.Cotizacion objCoti = SAL.Cotizaciones.RecuperarXId(idCotizacion, false);

            return RedirectToAction("ListaPedidos", "Comercial", new { id = objCoti.cliente_idcliente });
        }

        public ActionResult GestionarPedido(int id)
        {
            CotizarService.Pedido objpedido = SAL.Pedidos.RecuperarXId(id, true);

            CotizarService.PedidoModel objPedidoModel = new CotizarService.PedidoModel()
            {
                activo = objpedido.activo,
                costosplancha = objpedido.costosplancha,
                costostroqueles = objpedido.costostroqueles,
                cotizacion_idcotizacion = objpedido.cotizacion_idcotizacion,
                detalle = objpedido.detalle,
                fechacreacion = objpedido.fechacreacion,
                hfddetalle = Newtonsoft.Json.JsonConvert.SerializeObject(objpedido.detalle),
                identificadorsiigo = objpedido.identificadorsiigo,
                idpedido = objpedido.idpedido,
                itemlista_iditemlista_estado = objpedido.itemlista_iditemlista_estado,
                observaciones = objpedido.observaciones,
                itemlista_iditemlista_descestado = objpedido.itemlista_iditemlista_descestado
            };

            this.CargarListasPedidos(objPedidoModel);
            return View(objPedidoModel);
        }
    }
}
