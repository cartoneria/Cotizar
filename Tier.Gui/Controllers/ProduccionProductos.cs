using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ProduccionController : BaseController
    {

        private void CargarListasProductos(CotizarService.ProductoMetadata obj)
        {
            if (obj != null)
            {
                ViewBag.cliente_idcliente = new SelectList(SAL.Clientes.RecuperarTodos().ToList(), "idcliente", "nombre", obj.cliente_idcliente);
                ViewBag.troquel_idtroquel = new SelectList(SAL.Troqueles.RecuperarTodos().ToList(), "idtroquel", "descripcion");
                ViewBag.insumo_idinsumo_material = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_acetato = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.itemlista_iditemlista_acabadoderecho = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre");
                ViewBag.itemlista_iditemlista_acabadoreverso = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre");
                ViewBag.maquina_idmaquina_peque = new SelectList(SAL.Clientes.RecuperarTodos().ToList(), "idcliente", "nombre");
                ViewBag.insumo_idinsumo_reempaque = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_colaminado = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_materialpegue = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
            }
            else
            {
                ViewBag.cliente_idcliente = new SelectList(SAL.Clientes.RecuperarTodos().ToList(), "idcliente", "nombre");
                ViewBag.troquel_idtroquel = new SelectList(SAL.Troqueles.RecuperarTodos().ToList(), "idtroquel", "descripcion");
                ViewBag.insumo_idinsumo_material = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_acetato = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.itemlista_iditemlista_acabadoderecho = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre");
                ViewBag.itemlista_iditemlista_acabadoreverso = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre");
                ViewBag.maquina_idmaquina_peque = new SelectList(SAL.Clientes.RecuperarTodos().ToList(), "idcliente", "nombre");
                ViewBag.insumo_idinsumo_reempaque = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_colaminado = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_materialpegue = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre");
            }
        }


        public ActionResult ListaProductos()
        {
            this.CargarListasProductos(null);
            return View(SAL.Productos.RecuperarTodos());
        }

        public ActionResult CrearProducto()
        {
            this.CargarListasProductos(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearProducto(CotizarService.ProductoModel obj)
        {
            if (ModelState.IsValid)
            {
                int? _idProducto;

                CotizarService.Producto _producto = new CotizarService.Producto
                {
                    cliente_idcliente = obj.cliente_idcliente,
                    troquel_idtroquel = obj.troquel_idtroquel,
                    insumo_idinsumo_material  = obj.insumo_idinsumo_material,
                    largobobina = obj.largobobina,
                    cabidaancho = obj.cabidaancho,
                    cabidalargo = obj.cabidalargo,
                    insumo_idinsumo_acetato = obj.insumo_idinsumo_acetato,
                    itemlista_iditemlista_acabadoderecho = obj.itemlista_iditemlista_acabadoderecho,
                    anchomaquina_acabadoderecho = obj.anchomaquina_acabadoderecho,
                    recorrido_acabadoderecho = obj.recorrido_acabadoderecho,
                    itemlista_iditemlista_acabadoreverso = obj.itemlista_iditemlista_acabadoreverso,
                    anchomaquina_acabadoreverso = obj.anchomaquina_acabadoreverso,
                    recorrido_acabadoreverso = obj.recorrido_acabadoreverso,
                    posicionplanchas = obj.posicionplanchas,
                    pasadaslitograficas = obj.pasadaslitograficas,
                    referenciacliente = obj.referenciacliente,
                    observaciones = obj.observaciones,
                    maquina_idmaquina_peque = obj.maquina_idmaquina_peque,
                    insumo_idinsumo_reempaque = obj.insumo_idinsumo_reempaque,
                    factorprecio = obj.factorprecio,
                    catidadpredeterminada = obj.catidadpredeterminada,
                    preciopredeterminado = obj.preciopredeterminado,
                    insumo_idinsumo_colaminado = obj.insumo_idinsumo_colaminado,
                    colaminadoancho = obj.colaminadoancho,
                    colaminadoalargo = obj.colaminadoalargo,
                    colaminadocabidalargo = obj.colaminadocabidalargo,
                    imagenartegrafico = GuardarArchivoImagenProducto(obj.imgFile),
                    insumo_idinsumo_materialpegue = obj.insumo_idinsumo_materialpegue,
                    recorrigopegue = obj.recorrigopegue                    

                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Producto_Insertar(_producto, out _idProducto) && _idProducto != null)
                {
                    base.RegistrarNotificación("Producto creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaProductos", "Produccion");
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
            return View();
        }

        private string GenerarJsonProductosAccesorios(IEnumerable<CotizarService.ProductoAccesorio> lstPrdAcs)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstPrdAcs)
            {
                strResultado.Append("{\"id\":\"" + item.accesorio_idaccesorio.ToString() + "\"," +
                    "\"idProducto\":\"" + item.producto_idproducto.ToString() + "\"," +
                    "\"idAccesorio\":\"" + item.accesorio_idaccesorio.ToString() + "\"," +
                    "\"activo\":\"" + item.activo.ToString() + "\"," +
                    "\"fechacreacion\":\"" + item.fechacreacion.ToString() + "\"," +
                    "\"accesorio\":\"" + item.accesorio.ToString() + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }
        private IEnumerable<CotizarService.ProductoAccesorio> CargarPrdAccesorios(string strJsonPrdAccesorio)
        {
            List<CotizarService.ProductoAccesorio> lstPrdAccesorios = new List<CotizarService.ProductoAccesorio>();

            JArray jsonArray = JArray.Parse(strJsonPrdAccesorio);
            if (jsonArray.Count > 0)
            {
                foreach (var objPrdAccesorio in jsonArray.Children())
                {
                    try
                    {
                        /*ph: intph, phun: intphun, phunnomb: strphunnomb, ta: intta, taun: inttaun, taunnomb: strtaunnomb*/
                        //id: idProvLinea, nombreLinea: nombreProvLinea, activo: activo

                        dynamic objArrVari = JObject.Parse(objPrdAccesorio.ToString());
                        int intIdPrdAccesr;

                        lstPrdAccesorios.Add(new CotizarService.ProductoAccesorio()
                        {
                            accesorio_idaccesorio = (int.TryParse(objArrVari.id.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                            activo = objArrVari.activo
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lstPrdAccesorios;

        }

        private string GenerarJsonProductosEspectro(IEnumerable<CotizarService.ProductoEspectro> lstPrdEspect)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            foreach (var item in lstPrdEspect)
            {
                strResultado.Append("{\"id\":\"" + item.idproducto_espectro.ToString() + "\"," +
                    "\"idProducto\":\"" + item.producto_idproducto.ToString() + "\"," +
                    "\"idPantone\":\"" + item.pantone_idpantone.ToString() + "\"," +
                    "\"porCubrimiento\":\"" + item.porcentajecubrimiento.ToString() + "\"," +
                    "\"activo\":\"" + item.activo.ToString() + "\"," +
                    "\"fechacreacion\":\"" + item.fechacreacion.ToString() + "\"," +
                    "\"pantone\":\"" + item.pantone.ToString() + "\"},");
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        public ActionResult EditarProducto(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProducto(CotizarService.ProductoModel obj)
        {
            return View();
        }

        public ActionResult EliminarProducto(int id)
        {
            return ListaProductos();
        }

        private string GuardarArchivoImagenProducto(HttpPostedFileBase ImgFile)
        {
            string resultado = "";
            if (ImgFile != null)
            {
                string rutaFisica = Server.MapPath(ConfigurationManager.AppSettings["RutaImagenes"].ToString());
                string carpeta = "Productos/";
                if (!Directory.Exists(rutaFisica + carpeta))
                {
                    Directory.CreateDirectory(rutaFisica);
                }
                Random r = new Random();
                string FileName = ImgFile.FileName;
                if (ImgFile.FileName.Length > 40)
                {
                    FileName = ImgFile.FileName.Substring(0, 40).ToString();
                }
                FileName = carpeta + Convert.ToString(r.Next(1000, 10000)) + "_" + FileName;

                string fileSavePath = Path.Combine(rutaFisica, FileName);

                ImgFile.SaveAs(fileSavePath);
                resultado = FileName;
            }
            return resultado;
        }

    }
}
