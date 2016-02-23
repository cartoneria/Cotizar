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
            //Cargar 
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
                    itemlista_iditemlista_estado = (int)Models.Enumeradores.EstadosCotizacion.Creacion,
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

        [HttpGet]
        public ActionResult ConsultarCotizacion(int idCotizacion)
        {
            CotizarService.CotizarServiceClient service = new CotizarService.CotizarServiceClient();
            CotizarService.Cotizacion cotizacion = new CotizarService.Cotizacion();
            CotizarService.CotizacionModelo objCotizar = new CotizarService.CotizacionModelo();
            try
            {
                cotizacion = service.Cotizacion_RecuperarFiltros(new CotizarService.Cotizacion { idcotizacion = idCotizacion }).FirstOrDefault();

                if (cotizacion != null)
                {
                    objCotizar.activo = cotizacion.activo;
                    objCotizar.cliente_idcliente = cotizacion.cliente_idcliente;
                    objCotizar.hdfProdCotizar = this.GenerarJsonCotProdDetalle(cotizacion.detalle.ToList(), (int)cotizacion.periodo_idPeriodo);
                    objCotizar.fechacreacion = cotizacion.fechacreacion;
                    objCotizar.idcotizacion = cotizacion.idcotizacion;
                    objCotizar.observaciones = cotizacion.observaciones;
                    objCotizar.periodo_idPeriodo = cotizacion.periodo_idPeriodo;
                    objCotizar.valoresplancha = cotizacion.valoresplancha;
                    objCotizar.valorestroqueles = cotizacion.valorestroqueles;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (objCotizar != null && objCotizar.idcotizacion != 0)
            {
                this.CargarListasCotizar(cotizacion.cliente_idcliente);
                return View(objCotizar);
            }
            else
            {
                base.RegistrarNotificación("Error al cargar la cotización.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            if (cotizacion != null && cotizacion.cliente_idcliente != 0)
            {
                return RedirectToAction("ListaCotizaciones", "Comercial", new { id = cotizacion.cliente_idcliente });
            }
            return RedirectToAction("ListaClientes", "Comercial");
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

                                lstCotProdDetalle.Add(new CotizarService.CotizacionDetalle()
                                {
                                    idcotizacion_detalle = (int.TryParse(itemDetalleEscala.idcotizacion_detalle.ToString(), out intIdCotProdDetalle) ? intIdCotProdDetalle : new Nullable<int>()),
                                    areaacader = itemDetalleEscala.areaacader,
                                    areaacarev = itemDetalleEscala.areaacarev,
                                    areacartoncaja = itemDetalleEscala.areacartoncaja,
                                    cabidaconversion = itemDetalleEscala.cabidaconversion,
                                    cabidatroquel = Convert.ToByte(itemDetalleEscala.cabidatroquel),
                                    canttintas = itemDetalleEscala.canttintas,
                                    costoacabadoder = itemDetalleEscala.costoacabadoder,
                                    costoacabadorev = itemDetalleEscala.costoacabadorev,
                                    costoaccesorios = itemDetalleEscala.costoaccesorios,
                                    costoacetato = itemDetalleEscala.costoacetato,
                                    costoaportegastounidad = itemDetalleEscala.costoaportegastounidad,
                                    costocartoncaja = itemDetalleEscala.costocartoncaja,
                                    costocartoncolaminado = itemDetalleEscala.costocartoncolaminado,
                                    costodesperdiciocaja = itemDetalleEscala.costodesperdiciocaja,
                                    costoflete = itemDetalleEscala.costoflete,
                                    costonetocaja = itemDetalleEscala.costonetocaja,
                                    costopegante = itemDetalleEscala.costopegante,
                                    costopliegosdesper = itemDetalleEscala.costopliegosdesper,
                                    costoprocacabadoder = itemDetalleEscala.costoprocacabadoder,
                                    costoprocacabadorev = itemDetalleEscala.costoprocacabadorev,
                                    costoproccolaminado = itemDetalleEscala.costoproccolaminado,
                                    costoprocconversion = itemDetalleEscala.costoprocconversion,
                                    costoprocguillotinado = itemDetalleEscala.costoprocguillotinado,
                                    costoproclitografia = itemDetalleEscala.costoproclitografia,
                                    costoprocpegue = itemDetalleEscala.costoprocpegue,
                                    costoproctroqelado = itemDetalleEscala.costoproctroqelado,
                                    costoreempaque = itemDetalleEscala.costoreempaque,
                                    costotintas = itemDetalleEscala.costotintas,
                                    costototalfabricacion = itemDetalleEscala.costototalfabricacion,
                                    costototalmaterialunidad = itemDetalleEscala.costototalmaterialunidad,
                                    costototalprocesosunidad = itemDetalleEscala.costototalprocesosunidad,
                                    escala = itemDetalleEscala.escala,
                                    insumo_idinsumo_flete = objCotProdDetalle.idInsumoFlete,
                                    observaciones = objCotProdDetalle.comentarioAdicional,
                                    porceadmfinanciacion = itemDetalleEscala.porceadmfinanciacion,
                                    porcealzageneral = itemDetalleEscala.porcealzageneral,
                                    porcecomisionasesor = itemDetalleEscala.porcecomisionasesor,
                                    porcedesperdiciocaja = itemDetalleEscala.porcedesperdiciocaja,
                                    porceicacree = itemDetalleEscala.porceicacree,
                                    porceprecioproducto = itemDetalleEscala.porceprecioproducto,
                                    producto_idproducto = itemDetalleEscala.producto_idproducto,
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
                            "'detalleProdCoti':'" + objItemCotProdDet.lstCotDet + "'" + "}");
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

        [HttpPost]
        public ActionResult DetalleCotizarProductoEscala(CotizarService.CotizacionDetalle obj)
        {
            return PartialView("_DetalleCotizarProductoEscala", obj);
        }

        [HttpPost]
        public JsonResult ImagenProdCotizar(int idProducto)
        {
            CotizarService.Producto producto = new CotizarService.Producto();
            CotizarService.CotizarServiceClient service = new CotizarService.CotizarServiceClient();
            try
            {
                producto = service.Producto_RecuperarFiltros(new CotizarService.Producto() { idproducto = idProducto }).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return Json(new { estado = false, respuesta = ex.Message }, JsonRequestBehavior.AllowGet);
                throw;
            }

            return Json(new { estado = true, respuesta = producto.imagenartegrafico });
        }

    }
}

