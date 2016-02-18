using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ComercialController : BaseController
    {
        //
        // GET: /ComercialCotizar/
        private void CargarListasCotizar(Nullable<int> obj)
        {

            var objCliente = SAL.Clientes.RecuperarXId((int)obj, base.SesionActual.empresa.idempresa);
            ViewBag.Cliente = objCliente;
            ViewBag.Departamento = SAL.Departamentos.RecuperarXId(objCliente.municipio_departamento_iddepartamento);
            ViewBag.Municipio = SAL.Municipios.RecuperarXId(objCliente.municipio_idmunicipio);
            ViewBag.cliente_idCliente = objCliente.idcliente;
            var insumos = SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList();
            ViewBag.producto_idproducto = new SelectList(SAL.Productos.RecuperarTodos(objCliente.idcliente).ToList(), "idproducto", "referenciacliente");
            ViewBag.insumo_idinsumo_flete = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 46).ToList(), "idinsumo", "nombre");
            ViewBag.periodo_idPeriodo = new SelectList(SAL.Periodos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idperiodo", "nombre");
        }

        public ActionResult ListaCotizaciones(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            this.CargarListasCotizar(id);
            return View(SAL.Cotizaciones.RecuperarXCliente((int)id));
        }

        public ActionResult CrearCotizacion(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            this.CargarListasCotizar(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCotizacion(CotizarService.CotizacionModelo obj)
        {
            if (ModelState.IsValid)
            {
                int? _idCotizacion;

                CotizarService.Cotizacion _cotizacion = new CotizarService.Cotizacion
                {
                    activo = obj.activo,
                    cliente_idcliente = obj.cliente_idcliente,
                    detalle = CargarCotizacionProductoDetalle(obj.hdfProdCotizar),
                    itemlista_iditemlista_estado = obj.itemlista_iditemlista_estado,
                    observaciones = obj.observaciones,
                    periodo_idPeriodo = obj.periodo_idPeriodo,
                    valoresplancha = obj.valoresplancha,
                    valorestroqueles = obj.valorestroqueles
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Cotizacion_Insertar(_cotizacion, out _idCotizacion) && _idCotizacion != null)
                {
                    base.RegistrarNotificación("Cotización creada con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaCotizaciones", "Comercial", new { id = obj.cliente_idcliente });
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


            this.CargarListasCotizar(obj.cliente_idcliente);
            return View(obj);
        }

        private List<CotizarService.CotizacionDetalle> CargarCotizacionProductoDetalle(string strJsonCotProdDetalle)
        {
            List<CotizarService.CotizacionDetalle> lstCotProdDetalle = new List<CotizarService.CotizacionDetalle>();

            if (!string.IsNullOrEmpty(strJsonCotProdDetalle))
            {
                JArray jsonArray = JArray.Parse(strJsonCotProdDetalle);
                if (jsonArray.Count > 0)
                {
                    foreach (var objCotProd in jsonArray.Children())
                    {
                        try
                        {
                            /*
                             * id: strguid, idProducto: idProducto, nombreProducto: nombreProducto,
                                tipoCarton: tipoCarton, nombreTroquel: nombreTroquel,
                                idInsumoFlete: idInsumoFlete, nombreInsumoFlete: nombreInsumoFlete,
                                comentarioAdicional: comentarioAdicional,
                                detalleProdCoti: detalleProdCoti
                             */

                            dynamic objCotProdDetalle = JObject.Parse(objCotProd.ToString());
                            var objCotProdDetalleEscala = objCotProdDetalle.detalleProdCoti;
                            foreach (var itemDetalleEscala in objCotProdDetalleEscala)
                            {
                                int intIdCotProdDetalle;
                                var idcotizacion_detalle = (int.TryParse(itemDetalleEscala.idcotizacion_detalle.ToString(), out intIdCotProdDetalle) ? intIdCotProdDetalle : new Nullable<int>());

                                lstCotProdDetalle.Add(new CotizarService.CotizacionDetalle()
                                {
                                    idcotizacion_detalle = (int.TryParse(itemDetalleEscala.idcotizacion_detalle.ToString(), out intIdCotProdDetalle) ? intIdCotProdDetalle : new Nullable<int>()),
                                    areaacader = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.areaacader, 0))),
                                    areaacarev = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.areaacarev, 0))),
                                    areacartoncaja = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.areacartoncaja, 0))),
                                    cabidaconversion = Convert.ToByte(itemDetalleEscala.cabidaconversion),
                                    cabidatroquel = Convert.ToByte(itemDetalleEscala.cabidatroquel),
                                    canttintas = Convert.ToByte(itemDetalleEscala.canttintas),
                                    costoacabadoder = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoacabadoder, 0))),
                                    costoacabadorev = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoacabadorev, 0))),
                                    costoaccesorios = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoaccesorios, 0))),
                                    costoacetato = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoacetato, 0))),
                                    costoaportegastounidad = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoaportegastounidad, 0))),
                                    costocartoncaja = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costocartoncaja, 0))),
                                    costocartoncolaminado = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costocartoncolaminado, 0))),
                                    costodesperdiciocaja = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costodesperdiciocaja, 0))),
                                    costoflete = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoflete, 0))),
                                    costonetocaja = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costonetocaja, 0))),
                                    costopegante = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costopegante, 0))),
                                    costopliegosdesper = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costopliegosdesper, 0))),
                                    costoprocacabadoder = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoprocacabadoder, 0))),
                                    costoprocacabadorev = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoprocacabadorev, 0))),
                                    costoproccolaminado = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoproccolaminado, 0))),
                                    costoprocconversion = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoprocconversion, 0))),
                                    costoprocguillotinado = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoprocguillotinado, 0))),
                                    costoproclitografia = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoproclitografia, 0))),
                                    costoprocpegue = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoprocpegue, 0))),
                                    costoproctroqelado = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoproctroqelado, 0))),
                                    costoreempaque = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costoreempaque, 0))),
                                    costotintas = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costotintas, 0))),
                                    costototalfabricacion = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costototalfabricacion, 0))),
                                    costototalmaterialunidad = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costototalmaterialunidad, 0))),
                                    costototalprocesosunidad = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.costototalprocesosunidad, 0))),
                                    escala = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.escala, 0))),
                                    insumo_idinsumo_flete = Convert.ToInt32(objCotProdDetalle.idInsumoFlete),
                                    observaciones = objCotProdDetalle.comentarioAdicional,
                                    porceadmfinanciacion = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.porceadmfinanciacion, 0))),
                                    porcealzageneral = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.porcealzageneral, 0))),
                                    porcecomisionasesor = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.porcecomisionasesor, 0))),
                                    porcedesperdiciocaja = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.porcedesperdiciocaja, 0))),
                                    porceicacree = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.porceicacree, 0))),
                                    porceprecioproducto = float.Parse(Convert.ToString(Math.Round((decimal)itemDetalleEscala.porceprecioproducto, 0))),
                                    producto_idproducto = Convert.ToInt32(itemDetalleEscala.producto_idproducto)
                                });
                            }
                        }
                        catch (Exception ex)
                        {

                            throw ex;
                        }
                    }
                }
            }

            return lstCotProdDetalle;
        }

        private string GenerarJsonCotProdDetalle(List<CotizarService.CotizacionDetalle> lstCotProdDetalle, int periodo_idPeriodo)
        {
            StringBuilder strResultado = new StringBuilder();
            IList<CotizarService.CotizacionDetalle> lstCotDet = new List<CotizarService.CotizacionDetalle>();
            List<int> idProductos = new List<int>();
            /*
                id: strguid, idProducto: idProducto, nombreProducto: nombreProducto,
                tipoCarton: tipoCarton, nombreTroquel: nombreTroquel,
                idInsumoFlete: idInsumoFlete, nombreInsumoFlete: nombreInsumoFlete,
                comentarioAdicional: comentarioAdicional,
                detalleProdCoti: detalleProdCoti
            */

            strResultado.Append("[");

            if (lstCotProdDetalle != null)
            {
                foreach (var item in lstCotProdDetalle)
                {
                    int cantProducto = 0;
                    cantProducto = idProductos.Where(c => c.Equals(item.producto_idproducto)).Count();
                    //Valida si el producto fue adicionado con anterioridad.
                    if (cantProducto == 0)
                    {
                        int idProducto = Convert.ToInt32(item.producto_idproducto);
                        int idFlete = Convert.ToInt32(item.insumo_idinsumo_flete);
                        JsonResult itemCotProdDet = InformacionProductoEscala(idProducto, periodo_idPeriodo, idFlete);
                        dynamic objItemCotProdDet = JObject.Parse(itemCotProdDet.ToString());
                        strResultado.Append(@"{\'id':'" + item.idcotizacion_detalle + "', " +
                            "'idProducto':'" + item.producto_idproducto + "'" +
                            "'nombreProducto':'" + objItemCotProdDet.productoNombre + "'" +
                            "'tipoCarton':'" + objItemCotProdDet.insumo_nombreInsumo + "'" +
                            "'nombreTroquel':'" + objItemCotProdDet.troquel_nombreTroquel + "'" +
                            "'idInsumoFlete':'" + item.insumo_idinsumo_flete + "'" +
                            "'nombreInsumoFlete':'" + SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList().Where(c => c.idinsumo == item.insumo_idinsumo_flete).FirstOrDefault().nombre + "'" +
                            "'comentarioAdicional':'" + item.observaciones + "'" +
                            "'detalleProdCoti':'" + objItemCotProdDet.lstCotDet + "'" +
                            "");
                    }
                }
            }


            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");

        }

        [HttpGet]
        public JsonResult InformacionProductoEscala(int idProducto, int idPeriodo, int idFlete)
        {
            IList<CotizarService.CotizacionDetalle> lstCotDet = new List<CotizarService.CotizacionDetalle>();
            CotizarService.Producto producto = new CotizarService.Producto();
            CotizarService.CotizarServiceClient service = new CotizarService.CotizarServiceClient();
            string troquel_nombreTroquel = "";
            string insumo_nombreInsumo = "";

            try
            {
                lstCotDet = service.Cotizacion_Cotizar(idProducto, idPeriodo, idFlete);
                producto = service.Producto_RecuperarFiltros(new CotizarService.Producto() { idproducto = idProducto }).FirstOrDefault();
                insumo_nombreInsumo = service.Insumo_RecuperarFiltros(new CotizarService.Insumo() { idinsumo = producto.insumo_idinsumo_material }).FirstOrDefault().nombre;
                troquel_nombreTroquel = service.Troquel_RecuperarFiltros(new CotizarService.Troquel() { idtroquel = producto.troquel_idtroquel }).FirstOrDefault().descripcion;
            }
            catch (Exception ex)
            {
                return Json(ex, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                lstCotDet,
                productoNombre = producto.referenciacliente,
                insumo_nombreInsumo = insumo_nombreInsumo,
                troquel_nombreTroquel = troquel_nombreTroquel
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DetalleCotizarProductoEscala(CotizarService.CotizacionDetalle obj)
        {
            return PartialView("_DetalleCotizarProductoEscala", obj);
        }


    }
}

