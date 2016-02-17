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
            ViewBag.periodo_idperiodo = new SelectList(SAL.Periodos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idperiodo", "nombre");
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

                CotizarService.CotizarServiceClient service = new CotizarService.CotizarServiceClient();

            }


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

                                lstCotProdDetalle.Add(new CotizarService.CotizacionDetalle()
                                {
                                    idcotizacion_detalle = (int.TryParse(itemDetalleEscala.id.ToString(), out intIdCotProdDetalle) ? intIdCotProdDetalle : new Nullable<int>()),
                                    areaacader = float.Parse(Convert.ToString(itemDetalleEscala.areaacader)),
                                    areaacarev = float.Parse(Convert.ToString(itemDetalleEscala.areaacarev)),
                                    areacartoncaja = float.Parse(Convert.ToString(itemDetalleEscala.areacartoncaja)),
                                    cabidaconversion = Convert.ToByte(itemDetalleEscala.cabidaconversion),
                                    cabidatroquel = Convert.ToByte(itemDetalleEscala.cabidatroquel),
                                    canttintas = Convert.ToByte(itemDetalleEscala.canttintas),
                                    costoacabadoder = float.Parse(Convert.ToString(itemDetalleEscala.costoacabadoder)),
                                    costoacabadorev = float.Parse(Convert.ToString(itemDetalleEscala.costoacabadorev)),
                                    costoaccesorios = float.Parse(Convert.ToString(itemDetalleEscala.costoaccesorios)),
                                    costoacetato = float.Parse(Convert.ToString(itemDetalleEscala.costoacetato)),
                                    costoaportegastounidad = float.Parse(Convert.ToString(itemDetalleEscala.costoaportegastounidad)),
                                    costocartoncaja = float.Parse(Convert.ToString(itemDetalleEscala.costocartoncaja)),
                                    costocartoncolaminado = float.Parse(Convert.ToString(itemDetalleEscala.costocartoncolaminado)),
                                    costodesperdiciocaja = float.Parse(Convert.ToString(itemDetalleEscala.costodesperdiciocaja)),
                                    costoflete = float.Parse(Convert.ToString(itemDetalleEscala.costoflete)),
                                    costonetocaja = float.Parse(Convert.ToString(itemDetalleEscala.costonetocaja)),
                                    costopegante = float.Parse(Convert.ToString(itemDetalleEscala.costopegante)),
                                    costopliegosdesper = float.Parse(Convert.ToString(itemDetalleEscala.costopliegosdesper)),
                                    costoprocacabadoder = float.Parse(Convert.ToString(itemDetalleEscala.costoprocacabadoder)),
                                    costoprocacabadorev = float.Parse(Convert.ToString(itemDetalleEscala.costoprocacabadorev)),
                                    costoproccolaminado = float.Parse(Convert.ToString(itemDetalleEscala.costoproccolaminado)),
                                    costoprocconversion = float.Parse(Convert.ToString(itemDetalleEscala.costoprocconversion)),
                                    costoprocguillotinado = float.Parse(Convert.ToString(itemDetalleEscala.costoprocguillotinado)),
                                    costoproclitografia = float.Parse(Convert.ToString(itemDetalleEscala.costoproclitografia)),
                                    costoprocpegue = float.Parse(Convert.ToString(itemDetalleEscala.costoprocpegue)),
                                    costoproctroqelado = float.Parse(Convert.ToString(itemDetalleEscala.costoproctroqelado)),
                                    costoreempaque = float.Parse(Convert.ToString(itemDetalleEscala.costoreempaque)),
                                    costotintas = float.Parse(Convert.ToString(itemDetalleEscala.costotintas)),
                                    costototalfabricacion = float.Parse(Convert.ToString(itemDetalleEscala.costototalfabricacion)),
                                    costototalmaterialunidad = float.Parse(Convert.ToString(itemDetalleEscala.costototalmaterialunidad)),
                                    costototalprocesosunidad = float.Parse(Convert.ToString(itemDetalleEscala.costototalprocesosunidad)),
                                    escala = float.Parse(Convert.ToString(itemDetalleEscala.escala)),
                                    insumo_idinsumo_flete = objCotProdDetalle.IdInsumoFlete,
                                    observaciones = objCotProdDetalle.comentarioAdicional,
                                    porceadmfinanciacion = float.Parse(Convert.ToString(itemDetalleEscala.porceadmfinanciacion)),
                                    porcealzageneral = float.Parse(Convert.ToString(itemDetalleEscala.porceadmfinanciacion)),
                                    porcecomisionasesor = float.Parse(Convert.ToString(itemDetalleEscala.porceadmfinanciacion)),
                                    porcedesperdiciocaja = float.Parse(Convert.ToString(itemDetalleEscala.porceadmfinanciacion)),
                                    porceicacree = float.Parse(Convert.ToString(itemDetalleEscala.porceadmfinanciacion)),
                                    porceprecioproducto = float.Parse(Convert.ToString(itemDetalleEscala.porceadmfinanciacion)),
                                    producto_idproducto = float.Parse(Convert.ToString(itemDetalleEscala.porceadmfinanciacion)),

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
                    if (cantProducto == 0)
                    {
                        int idProducto = Convert.ToInt32(item.producto_idproducto);
                        int idFlete = Convert.ToInt32(item.insumo_idinsumo_flete);
                        JsonResult itemCotProdDet = InformacionProductoEscala(idProducto, periodo_idPeriodo, idFlete);
                        strResultado.Append(@"{\'id':'" + item.idcotizacion_detalle + "', " +
                            "'idProducto':'" + item.producto_idproducto + "'" +
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

            return Json(new { lstCotDet, productoNombre = producto.referenciacliente, insumo_nombreInsumo = insumo_nombreInsumo, troquel_nombreTroquel = troquel_nombreTroquel }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult DetalleCotizarProductoEscala(CotizarService.CotizacionDetalle obj)
        {
            return PartialView("_DetalleCotizarProductoEscala", obj);
        }


    }
}

