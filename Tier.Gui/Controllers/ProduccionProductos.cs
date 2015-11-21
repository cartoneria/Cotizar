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
                ViewBag.troquel_idtroquel = new SelectList(SAL.Troqueles.RecuperarTodos().ToList(), "idtroquel", "descripcion", obj.troquel_idtroquel);
                ViewBag.insumo_idinsumo_material = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_material);
                ViewBag.insumo_idinsumo_acetato = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_acetato);
                ViewBag.itemlista_iditemlista_acabadoderecho = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre", obj.itemlista_iditemlista_acabadoderecho);
                ViewBag.itemlista_iditemlista_acabadoreverso = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposMaterial), "iditemlista", "nombre", obj.itemlista_iditemlista_acabadoreverso);
                ViewBag.maquina_idmaquina_peque = new SelectList(SAL.Clientes.RecuperarTodos().ToList(), "idcliente", "nombre", obj.maquina_idmaquina_peque);
                ViewBag.insumo_idinsumo_reempaque = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_reempaque);
                ViewBag.insumo_idinsumo_colaminado = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_colaminado);
                ViewBag.insumo_idinsumo_materialpegue = new SelectList(SAL.Insumos.RecuperarTodos().ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_materialpegue);
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
                    anchomaquina_acabadoderecho = obj.anchomaquina_acabadoderecho,
                    anchomaquina_acabadoreverso = obj.anchomaquina_acabadoreverso,
                    cabidaancho = obj.cabidaancho,
                    cabidalargo = obj.cabidalargo,
                    catidadpredeterminada = obj.catidadpredeterminada,
                    cliente_idcliente = obj.cliente_idcliente,
                    colaminadoalargo = obj.colaminadoalargo,
                    colaminadoancho = obj.colaminadoancho,
                    colaminadocabidalargo = obj.colaminadocabidalargo,
                    factorprecio = obj.factorprecio,
                    imagenartegrafico = GuardarArchivoImagenProducto(obj.imgProducto),
                    insumo_idinsumo_acetato = obj.insumo_idinsumo_acetato,
                    insumo_idinsumo_colaminado = obj.insumo_idinsumo_colaminado,
                    insumo_idinsumo_material = obj.insumo_idinsumo_material,
                    insumo_idinsumo_materialpegue = obj.insumo_idinsumo_materialpegue,
                    insumo_idinsumo_reempaque = obj.insumo_idinsumo_reempaque,
                    itemlista_iditemlista_acabadoderecho = obj.itemlista_iditemlista_acabadoderecho,
                    itemlista_iditemlista_acabadoreverso = obj.itemlista_iditemlista_acabadoreverso,
                    largobobina = obj.largobobina,
                    maquina_idmaquina_peque = obj.maquina_idmaquina_peque,
                    observaciones = obj.observaciones,
                    pasadaslitograficas = obj.pasadaslitograficas,
                    posicionplanchas = obj.posicionplanchas,
                    preciopredeterminado = obj.preciopredeterminado,
                    recorrido_acabadoderecho = obj.recorrido_acabadoderecho,
                    recorrido_acabadoreverso = obj.recorrido_acabadoreverso,
                    recorrigopegue = obj.recorrigopegue,
                    referenciacliente = obj.referenciacliente,
                    troquel_idtroquel = obj.troquel_idtroquel


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

                        dynamic objArrAccesorio = JObject.Parse(objPrdAccesorio.ToString());
                        int intIdPrdAccesr;

                        lstPrdAccesorios.Add(new CotizarService.ProductoAccesorio()
                        {
                            accesorio_idaccesorio = (int.TryParse(objArrAccesorio.id.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                            activo = objArrAccesorio.activo
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

        private IEnumerable<CotizarService.ProductoEspectro> CargarPrdEspectros(string strJsonPrdEspectros)
        {
            List<CotizarService.ProductoEspectro> lstPrdEspectros = new List<CotizarService.ProductoEspectro>();

            JArray jsonArray = JArray.Parse(strJsonPrdEspectros);
            if (jsonArray.Count > 0)
            {
                foreach (var objPrdEspectro in jsonArray.Children())
                {
                    try
                    {
                        /*ph: intph, phun: intphun, phunnomb: strphunnomb, ta: intta, taun: inttaun, taunnomb: strtaunnomb*/
                        //id: idProvLinea, nombreLinea: nombreProvLinea, activo: activo

                        dynamic objArrEspectro = JObject.Parse(objPrdEspectro.ToString());
                        int intIdPrdAccesr;

                        lstPrdEspectros.Add(new CotizarService.ProductoEspectro()
                        {
                            idproducto_espectro = (int.TryParse(objArrEspectro.id.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                            activo = objArrEspectro.activo
                        });
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return lstPrdEspectros;

        }

        public ActionResult EditarProducto(int id)
        {
            CotizarService.Producto objProducto = SAL.Productos.RecuperarXId(id);
            CotizarService.ProductoModel objEditar = new CotizarService.ProductoModel()
            {
                accesorios = objProducto.accesorios,
                activo = objProducto.activo,
                anchomaquina_acabadoderecho = objProducto.anchomaquina_acabadoderecho,
                anchomaquina_acabadoreverso = objProducto.anchomaquina_acabadoreverso,
                cabidaancho = objProducto.cabidaancho,
                cabidalargo = objProducto.cabidalargo,
                catidadpredeterminada = objProducto.catidadpredeterminada,
                cliente_idcliente = objProducto.cliente_idcliente,
                colaminadoalargo = objProducto.colaminadoalargo,
                colaminadoancho = objProducto.colaminadoancho,
                colaminadocabidalargo = objProducto.colaminadocabidalargo,
                espectro = objProducto.espectro,
                factorprecio = objProducto.factorprecio,
                fechacreacion = objProducto.fechacreacion,
                hdfAccesorios = this.GenerarJsonProductosAccesorios(objProducto.accesorios),
                hdfEspectro = this.GenerarJsonProductosEspectro(objProducto.espectro),
                idproducto = objProducto.idproducto,
                imagenartegrafico = objProducto.imagenartegrafico,
                insumo_idinsumo_acetato = objProducto.insumo_idinsumo_acetato,
                insumo_idinsumo_colaminado = objProducto.insumo_idinsumo_colaminado,
                insumo_idinsumo_material = objProducto.insumo_idinsumo_material,
                insumo_idinsumo_materialpegue = objProducto.insumo_idinsumo_materialpegue,
                insumo_idinsumo_reempaque = objProducto.insumo_idinsumo_reempaque,
                itemlista_iditemlista_acabadoderecho = objProducto.itemlista_iditemlista_acabadoderecho,
                itemlista_iditemlista_acabadoreverso = objProducto.itemlista_iditemlista_acabadoreverso,
                largobobina = objProducto.largobobina,
                maquina_idmaquina_peque = objProducto.maquina_idmaquina_peque,
                observaciones = objProducto.observaciones,
                pasadaslitograficas = objProducto.pasadaslitograficas,
                posicionplanchas = objProducto.posicionplanchas,
                preciopredeterminado = objProducto.preciopredeterminado,
                recorrido_acabadoderecho = objProducto.recorrido_acabadoderecho,
                recorrido_acabadoreverso = objProducto.recorrido_acabadoreverso,
                recorrigopegue = objProducto.recorrigopegue,
                referenciacliente = objProducto.referenciacliente,
                troquel_idtroquel = objProducto.troquel_idtroquel
            };

            ViewBag.urlImgProducto = Url.Content(ConfigurationManager.AppSettings["RutaImagenes"].ToString() + "Productos\\" + objProducto.imagenartegrafico);
            this.CargarListasProductos(objEditar);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProducto(CotizarService.ProductoModel obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Producto objProducto = new CotizarService.Producto()
                {
                    accesorios = this.CargarPrdAccesorios(obj.hdfAccesorios).ToList(),
                    activo = obj.activo,
                    anchomaquina_acabadoderecho = obj.anchomaquina_acabadoderecho,
                    anchomaquina_acabadoreverso = obj.anchomaquina_acabadoreverso,
                    cabidaancho = obj.cabidaancho,
                    cabidalargo = obj.cabidalargo,
                    catidadpredeterminada = obj.catidadpredeterminada,
                    cliente_idcliente = obj.cliente_idcliente,
                    colaminadoalargo = obj.colaminadoalargo,
                    colaminadoancho = obj.colaminadoancho,
                    colaminadocabidalargo = obj.colaminadocabidalargo,
                    factorprecio = obj.factorprecio,
                    espectro = this.CargarPrdEspectros(obj.hdfEspectro).ToList(),
                    imagenartegrafico = (obj.imgProducto != null) ? GuardarArchivoImagenProducto(obj.imgProducto) : obj.imagenartegrafico,
                    insumo_idinsumo_acetato = obj.insumo_idinsumo_acetato,
                    insumo_idinsumo_colaminado = obj.insumo_idinsumo_colaminado,
                    insumo_idinsumo_material = obj.insumo_idinsumo_material,
                    insumo_idinsumo_materialpegue = obj.insumo_idinsumo_materialpegue,
                    insumo_idinsumo_reempaque = obj.insumo_idinsumo_reempaque,
                    itemlista_iditemlista_acabadoderecho = obj.itemlista_iditemlista_acabadoderecho,
                    itemlista_iditemlista_acabadoreverso = obj.itemlista_iditemlista_acabadoreverso,
                    largobobina = obj.largobobina,
                    maquina_idmaquina_peque = obj.maquina_idmaquina_peque,
                    observaciones = obj.observaciones,
                    pasadaslitograficas = obj.pasadaslitograficas,
                    posicionplanchas = obj.posicionplanchas,
                    preciopredeterminado = obj.preciopredeterminado,
                    recorrido_acabadoderecho = obj.recorrido_acabadoderecho,
                    recorrido_acabadoreverso = obj.recorrido_acabadoreverso,
                    recorrigopegue = obj.recorrigopegue,
                    referenciacliente = obj.referenciacliente,
                    troquel_idtroquel = obj.troquel_idtroquel

                };
            }


            return View();
        }

        public ActionResult EliminarProducto(int id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Producto_Eliminar(new CotizarService.Producto() { idproducto = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el producto.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El producto no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaProductos", "Produccion");
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
