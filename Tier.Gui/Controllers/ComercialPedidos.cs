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
            var objCotizacion = SAL.Cotizaciones.RecuperarXId((int)obj.cotizacion_idcotizacion);
            var objCliente = SAL.Clientes.RecuperarXId((int)objCotizacion.cliente_idcliente, base.SesionActual.empresa.idempresa);
            ViewBag.Cliente = objCliente;
            ViewBag.Cotizacion = objCotizacion;

            ViewBag.Departamento = SAL.Departamentos.RecuperarXId(objCliente.municipio_departamento_iddepartamento);
            ViewBag.Municipio = SAL.Municipios.RecuperarXId(objCliente.municipio_idmunicipio);
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


            return View(objPedido);
        }

        [HttpPost]
        public ActionResult CrearPedido(CotizarService.PedidoModel obj)
        {
            return View();
        }
    }
}