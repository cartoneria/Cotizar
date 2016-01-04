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
            var insumos = SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList();

            if (obj != null)
            {
                ViewBag.cliente_idcliente = new SelectList(SAL.Clientes.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idcliente", "nombre", obj.cliente_idcliente);
                ViewBag.troquel_idtroquel = new SelectList(SAL.Troqueles.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idtroquel", "descripcion", obj.troquel_idtroquel);
                //Segun BD, el carton es tipo 39
                ViewBag.insumo_idinsumo_material = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 39), "idinsumo", "nombre", obj.insumo_idinsumo_material);
                //Segun BD, los acetatos son tipo 40
                ViewBag.insumo_idinsumo_acetato = new SelectList(SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).Where(c => c.itemlista_iditemlista_tipo == 39).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_acetato);
                //Segun BD, los acabados son tipo 42
                ViewBag.insumo_idinsumo_acabadoderecho = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 42), "idinsumo", "nombre", obj.insumo_idinsumo_acabadoderecho);
                ViewBag.insumo_idinsumo_acabadoreverso = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 42), "idinsumo", "nombre", obj.insumo_idinsumo_acabadoreverso);
                //Segun BD, los reempaques son tipo 44
                ViewBag.insumo_idinsumo_reempaque = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 42).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_reempaque);

                //Segun BD, el carton es tipo 39
                ViewBag.insumo_idinsumo_colaminado = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 39).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_colaminado);

                ViewBag.maquinavariprod_idVariacion_rutaconversion = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 9).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaconversion);
                ViewBag.maquinavariprod_idVariacion_rutaguillotinado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 8).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaguillotinado);
                ViewBag.maquinavariprod_idVariacion_rutalitografia = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 6).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutalitografia);
                ViewBag.maquinavariprod_idVariacion_rutaplastificado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 10).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaplastificado);
                ViewBag.maquinavariprod_idVariacion_rutacolaminado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 12).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutacolaminado);
                ViewBag.maquinavariprod_idVariacion_rutatroquelado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 7).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutatroquelado);

                ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "true" }, new SelectListItem { Text = "Pinza ancho", Value = "false" } };
            }
            else
            {
                ViewBag.cliente_idcliente = new SelectList(SAL.Clientes.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idcliente", "nombre");
                ViewBag.troquel_idtroquel = new SelectList(SAL.Troqueles.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idtroquel", "descripcion");

                //Segun BD, el carton es tipo 39
                ViewBag.insumo_idinsumo_material = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 39), "idinsumo", "nombre");
                //Segun BD, los acetatos son tipo 40
                ViewBag.insumo_idinsumo_acetato = new SelectList(SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).Where(c => c.itemlista_iditemlista_tipo == 39).ToList(), "idinsumo", "nombre");
                //Segun BD, los acabados son tipo 42
                ViewBag.insumo_idinsumo_acabadoderecho = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 42), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_acabadoreverso = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 42), "idinsumo", "nombre");
                //Segun BD, los reempaques son tipo 44
                ViewBag.insumo_idinsumo_reempaque = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 42).ToList(), "idinsumo", "nombre");

                //Segun BD, el carton es tipo 39
                ViewBag.insumo_idinsumo_colaminado = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 39).ToList(), "idinsumo", "nombre");

                //Segun BD, las máquinas tienen la siguente distribución de IdItemlista:
                ViewBag.maquinavariprod_idVariacion_rutaconversion = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 9).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutaguillotinado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 8).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutalitografia = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 6).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutaplastificado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 10).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutacolaminado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 12).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutatroquelado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 7).ToList(), "idVariacion", "nombre");

                ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "false" }, new SelectListItem { Text = "Pinza ancho", Value = "true" } };
            }

            ViewBag.panton_idpanton = new SelectList(SAL.Pantones.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idpantone", "nombre");
            ViewBag.accesorio_idaccesorio = new SelectList(SAL.Accesorios.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idaccesorio", "nombre");
            //Segun BD, los pegantes son tipo 41
            ViewBag.insumo_idinsumo_materialpegue = new SelectList(SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).Where(c => c.itemlista_iditemlista_tipo == 41).ToList(), "idinsumo", "nombre");

            ViewBag.maquinavariprod_idVariacion_rutapegue = new SelectList(SAL.Maquinas.RecuperarRutasProduccionTodas(base.SesionActual.empresa.idempresa, 11).ToList(), "idVariacion", "nombre");
            ViewBag.IdCliente = obj.cliente_idcliente;
        }

        public ActionResult ListaProductos(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            this.CargarListasProductos(new CotizarService.ProductoMetadata() { cliente_idcliente = id });
            return View(SAL.Productos.RecuperarTodos(id).ToList());
        }

        public ActionResult CrearProducto(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            this.CargarListasProductos(new CotizarService.ProductoMetadata() { cliente_idcliente = id });
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
                    referenciacliente = obj.referenciacliente,
                    cliente_idcliente = obj.cliente_idcliente,
                    observaciones = obj.observaciones,
                    factorprecio = obj.factorprecio,
                    catidadpredeterminada = obj.catidadpredeterminada,
                    preciopredeterminado = obj.preciopredeterminado,
                    troquel_idtroquel = obj.troquel_idtroquel,
                    insumo_idinsumo_material = obj.insumo_idinsumo_material,
                    largobobina = obj.largobobina,
                    anchobobina = obj.anchobobina,
                    cabidaancho = obj.cabidaancho,
                    cabidalargo = obj.cabidalargo,
                    insumo_idinsumo_acetato = obj.insumo_idinsumo_acetato,
                    insumo_idinsumo_acabadoderecho = obj.insumo_idinsumo_acabadoderecho,
                    anchomaquina_acabadoderecho = obj.anchomaquina_acabadoderecho,
                    recorrido_acabadoderecho = obj.recorrido_acabadoderecho,
                    insumo_idinsumo_acabadoreverso = obj.insumo_idinsumo_acabadoreverso,
                    anchomaquina_acabadoreverso = obj.anchomaquina_acabadoreverso,
                    recorrido_acabadoreverso = obj.recorrido_acabadoreverso,
                    posicionplanchas = obj.posicionplanchas,
                    pasadaslitograficas = obj.pasadaslitograficas,
                    imagenartegrafico = GuardarArchivoImagenProducto(obj.imgPrdto),
                    pinzalitografica = obj.pinzalitografica,
                    insumo_idinsumo_colaminado = obj.insumo_idinsumo_colaminado,
                    colaminadoancho = obj.colaminadoancho,
                    colaminadoalargo = obj.colaminadoalargo,
                    colaminadocabidalargo = obj.colaminadocabidalargo,
                    colaminadocabidaancho = obj.colaminadocabidaancho,
                    insumo_idinsumo_reempaque = obj.insumo_idinsumo_reempaque,
                    factorrendimientoreempaque = obj.factorrendimientoreempaque,
                    maquinavariprod_idVariacion_rutaconversion = obj.maquinavariprod_idVariacion_rutaconversion,
                    maquinavariprod_idVariacion_rutaguillotinado = obj.maquinavariprod_idVariacion_rutaguillotinado,
                    maquinavariprod_idVariacion_rutalitografia = obj.maquinavariprod_idVariacion_rutalitografia,
                    maquinavariprod_idVariacion_rutaplastificado = obj.maquinavariprod_idVariacion_rutaplastificado,
                    maquinavariprod_idVariacion_rutacolaminado = obj.maquinavariprod_idVariacion_rutacolaminado,
                    maquinavariprod_idVariacion_rutatroquelado = obj.maquinavariprod_idVariacion_rutatroquelado,
                    //maquinavariprod_idVariacion_rutapegue = obj.maquinavariprod_idVariacion_rutapegue,
                    accesorios = CargarPrdAccesorios(obj.hdfAccesorios).ToList(),
                    espectro = CargarPrdEspectros(obj.hdfEspectro).ToList(),
                    pegues = CargarPrdPegues(obj.hdfPegues).ToList(),

                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Producto_Insertar(_producto, out _idProducto) && _idProducto != null)
                {
                    base.RegistrarNotificación("Producto creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaProductos", "Produccion", obj.cliente_idcliente);
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

            this.CargarListasProductos(obj);
            return View(obj);
        }

        private string GenerarJsonProductosAccesorios(IEnumerable<CotizarService.ProductoAccesorio> lstPrdAcs)
        {
            StringBuilder strResultado = new StringBuilder();
            IList<CotizarService.Accesorio> accesorios = SAL.Accesorios.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList();

            strResultado.Append("[");
            if (lstPrdAcs != null)
            {
                foreach (var item in lstPrdAcs)
                {
                    strResultado.Append("{\"id\":\"" + item.idproducto_accesorio.ToString() + "\"," +
                        "\"idProducto\":\"" + item.producto_idproducto.ToString() + "\"," +
                        "\"idAccesorio\":\"" + item.accesorio_idaccesorio.ToString() + "\"," +
                        "\"activo\":\"" + item.activo.ToString() + "\"," +
                        "\"cantAccsr\":\"" + item.cantidad.ToString() + "\"," +
                        "\"nomAccr\":\"" + accesorios.Where(c => c.idaccesorio == item.accesorio_idaccesorio).FirstOrDefault().nombre + "\"},");
                }
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        private IEnumerable<CotizarService.ProductoAccesorio> CargarPrdAccesorios(string strJsonPrdAccesorio)
        {
            List<CotizarService.ProductoAccesorio> lstPrdAccesorios = new List<CotizarService.ProductoAccesorio>();
            if (strJsonPrdAccesorio != null)
            {
                JArray jsonArray = JArray.Parse(strJsonPrdAccesorio);
                if (jsonArray.Count > 0)
                {
                    foreach (var objPrdAccesorio in jsonArray.Children())
                    {
                        try
                        {
                            /*
                                id: strid, idProducto: idProducto, cantAccsr: cantidad,
                                idAccesorio: idAccesorio, nomAccr: nombreAccesorio, activo: activio
                             */

                            dynamic objArrAccesorio = JObject.Parse(objPrdAccesorio.ToString());
                            int intIdPrdAccesr;

                            lstPrdAccesorios.Add(new CotizarService.ProductoAccesorio()
                            {
                                idproducto_accesorio = (int.TryParse(objArrAccesorio.id.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                                producto_idproducto = (int.TryParse(objArrAccesorio.idProducto.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                                accesorio_idaccesorio = (int.TryParse(objArrAccesorio.idAccesorio.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                                cantidad = (int.TryParse(objArrAccesorio.cantAccsr.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                                activo = objArrAccesorio.activo
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            return lstPrdAccesorios;

        }

        private string GenerarJsonProductosEspectro(IEnumerable<CotizarService.ProductoEspectro> lstPrdEspect)
        {
            StringBuilder strResultado = new StringBuilder();

            //id: guidPanton, idProducto: idProducto, 
            //idPanton: idPanton, porcentaje: porcentajePanton, hex: hexPanton

            strResultado.Append("[");
            if (lstPrdEspect != null)
            {
                foreach (var item in lstPrdEspect)
                {
                    strResultado.Append("{\"id\":\"" + item.idproducto_espectro.ToString() + "\"," +
                        "\"idProducto\":\"" + item.producto_idproducto.ToString() + "\"," +
                        "\"idPanton\":\"" + item.pantone_idpantone.ToString() + "\"," +
                        "\"porcentaje\":\"" + item.porcentajecubrimiento.ToString() + "\"," +
                        "\"hex\":\"#" + (SAL.Pantones.RecuperarTodos(base.SesionActual.empresa.idempresa).Where(c => c.idpantone == item.pantone_idpantone).FirstOrDefault().hex) + "\"," +
                        "\"activo\":\"" + item.activo.ToString() + "\"," +
                        "\"fechacreacion\":\"" + item.pantone.ToString() + "\"},");
                }
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        private IEnumerable<CotizarService.ProductoEspectro> CargarPrdEspectros(string strJsonPrdEspectros)
        {
            List<CotizarService.ProductoEspectro> lstPrdEspectros = new List<CotizarService.ProductoEspectro>();

            if (strJsonPrdEspectros.Length > 0)
            {
                JArray jsonArray = JArray.Parse(strJsonPrdEspectros);
                if (jsonArray.Count > 0)
                {
                    foreach (var objPrdEspectro in jsonArray.Children())
                    {
                        try
                        {
                            /*
                                id: guidPanton, idProducto: idProducto, idPanton: idPanton, porcentaje: porcentajePanton, hex: hexPanton
                             */

                            dynamic objArrEspectro = JObject.Parse(objPrdEspectro.ToString());
                            int intIdPrdAccesr;

                            lstPrdEspectros.Add(new CotizarService.ProductoEspectro()
                            {
                                idproducto_espectro = (int.TryParse(objArrEspectro.id.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                                producto_idproducto = objArrEspectro.idProducto,
                                pantone_idpantone = objArrEspectro.idPanton,
                                porcentajecubrimiento = objArrEspectro.porcentaje,
                                activo = true
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }

            return lstPrdEspectros;

        }

        private string GenerarJsonProductosPegues(IEnumerable<CotizarService.ProductoPegue> lstPrdPegue)
        {
            StringBuilder strResultado = new StringBuilder();

            //id: guidPanton, idProducto: idProducto, 
            //idPanton: idPanton, porcentaje: porcentajePanton, hex: hexPanton

            strResultado.Append("[");
            if (lstPrdPegue != null)
            {
                foreach (var item in lstPrdPegue)
                {
                    /*
                                        id: strid, idProducto: idProducto, insumoPegue: idInsumoPegue,
                                        maquinarutapegue: idMaquinaRutaPegue, largoPegue: largoPegue, anchoPegue: anchoPegue,
                                        nomPegue: nombrePegue, nomMaquina: nombreMaquina, activo: activio
                             */

                    strResultado.Append("{\"id\":\"" + item.idproducto_pegue.ToString() + "\"," +
                        "\"idProducto\":\"" + item.producto_idproducto.ToString() + "\"," +
                        "\"insumoPegue\":\"" + item.insumo_idinsumo.ToString() + "\"," +
                        "\"maquinarutapegue\":\"" + item.maquinavariprod_idVariacion.ToString() + "\"," +
                        "\"nomPegue\":\"" + (SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).Where(c => c.idinsumo == item.insumo_idinsumo).FirstOrDefault().nombre).ToString() + "\"," +
                        "\"nomMaquina\":\"" + ObtenerMaquinaVariacion().Where(c => c.idMaquinaVariacion == item.maquinavariprod_idVariacion).FirstOrDefault().nombreMezclado.ToString() + "\"," +
                        "\"largoPegue\":\"" + item.largo.ToString() + "\"," +
                        "\"anchoPegue\":\"" + item.ancho.ToString() + "\"," +
                        "\"activo\":\"" + item.activo.ToString() + "\"},");
                }
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        private IEnumerable<CotizarService.ProductoPegue> CargarPrdPegues(string strJsonPrdPegues)
        {
            List<CotizarService.ProductoPegue> lstPrdPegues = new List<CotizarService.ProductoPegue>();

            if (strJsonPrdPegues != null)
            {
                JArray jsonArray = JArray.Parse(strJsonPrdPegues);
                if (jsonArray.Count > 0)
                {
                    foreach (var objPrdPegue in jsonArray.Children())
                    {
                        try
                        {
                            /*
                                        id: strid, idProducto: idProducto, insumoPegue: idInsumoPegue,
                                        maquinarutapegue: idMaquinaRutaPegue, largoPegue: largoPegue, anchoPegue: anchoPegue,
                                        nomPegue: nombrePegue, nomMaquina: nombreMaquina, activo: activio
                             */

                            dynamic objArrPegue = JObject.Parse(objPrdPegue.ToString());
                            int intIdPrdPegue;
                            int idProducto;
                            lstPrdPegues.Add(new CotizarService.ProductoPegue()
                            {
                                idproducto_pegue = (int.TryParse(objArrPegue.id.ToString(), out intIdPrdPegue) ? intIdPrdPegue : new Nullable<int>()),
                                producto_idproducto = (int.TryParse(objArrPegue.idProducto.ToString(), out idProducto) ? idProducto : new Nullable<int>()),
                                maquinavariprod_idVariacion = Convert.ToInt16(objArrPegue.maquinarutapegue),
                                largo = Convert.ToInt32(objArrPegue.largoPegue),
                                ancho = Convert.ToInt32(objArrPegue.anchoPegue),
                                insumo_idinsumo = Convert.ToInt32(objArrPegue.insumoPegue)
                            });
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
            }
            return lstPrdPegues;
        }

        public ActionResult EditarProducto(int id)
        {
            CotizarService.Producto objProducto = SAL.Productos.RecuperarXId(id);
            if (objProducto != null)
            {
                CotizarService.ProductoModel objEditar = new CotizarService.ProductoModel()
                    {
                        idproducto = objProducto.idproducto,
                        referenciacliente = objProducto.referenciacliente,
                        cliente_idcliente = objProducto.cliente_idcliente,
                        observaciones = objProducto.observaciones,
                        factorprecio = objProducto.factorprecio,
                        catidadpredeterminada = objProducto.catidadpredeterminada,
                        preciopredeterminado = objProducto.preciopredeterminado,
                        troquel_idtroquel = objProducto.troquel_idtroquel,
                        insumo_idinsumo_material = objProducto.insumo_idinsumo_material,
                        largobobina = objProducto.largobobina,
                        anchobobina = objProducto.anchobobina,
                        cabidaancho = objProducto.cabidaancho,
                        cabidalargo = objProducto.cabidalargo,
                        insumo_idinsumo_acetato = objProducto.insumo_idinsumo_acetato,
                        insumo_idinsumo_acabadoderecho = objProducto.insumo_idinsumo_acabadoderecho,
                        anchomaquina_acabadoderecho = objProducto.anchomaquina_acabadoderecho,
                        recorrido_acabadoderecho = objProducto.recorrido_acabadoderecho,
                        insumo_idinsumo_acabadoreverso = objProducto.insumo_idinsumo_acabadoreverso,
                        anchomaquina_acabadoreverso = objProducto.anchomaquina_acabadoreverso,
                        recorrido_acabadoreverso = objProducto.recorrido_acabadoreverso,
                        posicionplanchas = objProducto.posicionplanchas,
                        pasadaslitograficas = objProducto.pasadaslitograficas,
                        pinzalitografica = objProducto.pinzalitografica,
                        insumo_idinsumo_colaminado = objProducto.insumo_idinsumo_colaminado,
                        colaminadoancho = objProducto.colaminadoancho,
                        colaminadoalargo = objProducto.colaminadoalargo,
                        colaminadocabidalargo = objProducto.colaminadocabidalargo,
                        colaminadocabidaancho = objProducto.colaminadocabidaancho,
                        insumo_idinsumo_reempaque = objProducto.insumo_idinsumo_reempaque,
                        factorrendimientoreempaque = objProducto.factorrendimientoreempaque,
                        maquinavariprod_idVariacion_rutaconversion = objProducto.maquinavariprod_idVariacion_rutaconversion,
                        maquinavariprod_idVariacion_rutaguillotinado = objProducto.maquinavariprod_idVariacion_rutaguillotinado,
                        maquinavariprod_idVariacion_rutalitografia = objProducto.maquinavariprod_idVariacion_rutalitografia,
                        maquinavariprod_idVariacion_rutaplastificado = objProducto.maquinavariprod_idVariacion_rutaplastificado,
                        maquinavariprod_idVariacion_rutacolaminado = objProducto.maquinavariprod_idVariacion_rutacolaminado,
                        maquinavariprod_idVariacion_rutatroquelado = objProducto.maquinavariprod_idVariacion_rutatroquelado,
                        //maquinavariprod_idVariacion_rutapegue = objProducto.maquinavariprod_idVariacion_rutapegue,
                        hdfAccesorios = this.GenerarJsonProductosAccesorios(objProducto.accesorios),
                        hdfEspectro = this.GenerarJsonProductosEspectro(objProducto.espectro),
                        hdfPegues = this.GenerarJsonProductosPegues(objProducto.pegues),
                        imagenartegrafico = objProducto.imagenartegrafico
                    };

                ViewBag.urlImgProducto = Url.Content(ConfigurationManager.AppSettings["RutaImagenes"].ToString() + "Productos\\" + objProducto.imagenartegrafico);
                this.CargarListasProductos(objEditar);
                return View(objEditar);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarProducto(CotizarService.ProductoModel obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.Producto objProducto = new CotizarService.Producto()
                {
                    idproducto = obj.idproducto,
                    referenciacliente = obj.referenciacliente,
                    cliente_idcliente = obj.cliente_idcliente,
                    observaciones = obj.observaciones,
                    factorprecio = obj.factorprecio,
                    catidadpredeterminada = obj.catidadpredeterminada,
                    preciopredeterminado = obj.preciopredeterminado,
                    troquel_idtroquel = obj.troquel_idtroquel,
                    insumo_idinsumo_material = obj.insumo_idinsumo_material,
                    largobobina = obj.largobobina,
                    anchobobina = obj.anchobobina,
                    cabidaancho = obj.cabidaancho,
                    cabidalargo = obj.cabidalargo,
                    insumo_idinsumo_acetato = obj.insumo_idinsumo_acetato,
                    insumo_idinsumo_acabadoderecho = obj.insumo_idinsumo_acabadoderecho,
                    anchomaquina_acabadoderecho = obj.anchomaquina_acabadoderecho,
                    recorrido_acabadoderecho = obj.recorrido_acabadoderecho,
                    insumo_idinsumo_acabadoreverso = obj.insumo_idinsumo_acabadoreverso,
                    anchomaquina_acabadoreverso = obj.anchomaquina_acabadoreverso,
                    recorrido_acabadoreverso = obj.recorrido_acabadoreverso,
                    posicionplanchas = obj.posicionplanchas,
                    pasadaslitograficas = obj.pasadaslitograficas,
                    imagenartegrafico = obj.imgPrdto != null ? GuardarArchivoImagenProducto(obj.imgPrdto) : obj.imagenartegrafico,
                    pinzalitografica = obj.pinzalitografica,
                    insumo_idinsumo_colaminado = obj.insumo_idinsumo_colaminado,
                    colaminadoancho = obj.colaminadoancho,
                    colaminadoalargo = obj.colaminadoalargo,
                    colaminadocabidalargo = obj.colaminadocabidalargo,
                    colaminadocabidaancho = obj.colaminadocabidaancho,
                    insumo_idinsumo_reempaque = obj.insumo_idinsumo_reempaque,
                    factorrendimientoreempaque = obj.factorrendimientoreempaque,
                    maquinavariprod_idVariacion_rutaconversion = obj.maquinavariprod_idVariacion_rutaconversion,
                    maquinavariprod_idVariacion_rutaguillotinado = obj.maquinavariprod_idVariacion_rutaguillotinado,
                    maquinavariprod_idVariacion_rutalitografia = obj.maquinavariprod_idVariacion_rutalitografia,
                    maquinavariprod_idVariacion_rutaplastificado = obj.maquinavariprod_idVariacion_rutaplastificado,
                    maquinavariprod_idVariacion_rutacolaminado = obj.maquinavariprod_idVariacion_rutacolaminado,
                    maquinavariprod_idVariacion_rutatroquelado = obj.maquinavariprod_idVariacion_rutatroquelado,
                    accesorios = CargarPrdAccesorios(obj.hdfAccesorios).ToList(),
                    espectro = CargarPrdEspectros(obj.hdfEspectro).ToList(),
                    pegues = CargarPrdPegues(obj.hdfPegues).ToList(),

                };
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Producto_Actualizar(objProducto))
                {
                    base.RegistrarNotificación("Se ha actualizado el producto.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaProductos", "Produccion", obj.cliente_idcliente);
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

            this.CargarListasProductos(obj);
            return View(obj);
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
                string carpeta = "Productos\\";
                if (!Directory.Exists(rutaFisica + carpeta))
                {
                    Directory.CreateDirectory(rutaFisica + carpeta);
                }
                Random r = new Random();
                string FileName = ImgFile.FileName;
                if (ImgFile.FileName.Length > 40)
                {
                    FileName = ImgFile.FileName.Substring(0, 40).ToString();
                }
                FileName = Convert.ToString(r.Next(1000, 10000)) + "_" + FileName;

                string fileSavePath = Path.Combine(rutaFisica + carpeta, FileName);

                ImgFile.SaveAs(fileSavePath);
                resultado = FileName;
            }
            return resultado;
        }

        public JsonResult ObtenerListaMaquinasVariacion()
        {
            IList<CotizarService.MaquinaVariacionProdMetadata> lstMaqVar = new List<CotizarService.MaquinaVariacionProdMetadata>();
            lstMaqVar = ObtenerMaquinaVariacion();
            return Json(lstMaqVar, JsonRequestBehavior.AllowGet);
        }

        public IList<CotizarService.MaquinaVariacionProdMetadata> ObtenerMaquinaVariacion()
        {
            IList<CotizarService.MaquinaVariacionProdMetadata> lstMaqVar = new List<CotizarService.MaquinaVariacionProdMetadata>();
            IList<CotizarService.Maquina> lstMaquinas = SAL.Maquinas.RecuperarActivas(base.SesionActual.empresa.idempresa).ToList();
            foreach (var maquina in lstMaquinas)
            {
                if (maquina.VariacionesProduccion.Count <= 0)
                {
                    CotizarService.MaquinaVariacionProdMetadata obj = new CotizarService.MaquinaVariacionProdMetadata()
                    {
                        idMaquina = maquina.idmaquina,
                        idMaquinaVariacion = -1,
                        nombreMaquina = maquina.nombre,
                        nombreVariacion = "",
                        nombreMezclado = maquina.nombre + " - sin variación",
                        numeroTintas = maquina.numerotintas
                    };
                    lstMaqVar.Add(obj);
                }
                else
                {
                    foreach (var variacion in maquina.VariacionesProduccion)
                    {
                        CotizarService.MaquinaVariacionProdMetadata obj = new CotizarService.MaquinaVariacionProdMetadata()
                        {
                            idMaquina = maquina.idmaquina,
                            idMaquinaVariacion = variacion.idVariacion,
                            nombreMaquina = maquina.nombre,
                            nombreVariacion = variacion.nombre_variacion_produccion,
                            nombreMezclado = maquina.nombre + " - " + variacion.nombre_variacion_produccion,
                            tipoMaquina = maquina.itemlista_iditemlistas_tipo,
                            numeroTintas = maquina.numerotintas
                        };
                        lstMaqVar.Add(obj);
                    }
                }

            }

            return lstMaqVar;
        }

        public JsonResult anchoMaterial()
        {

            IList<CotizarService.Insumo> insumos = SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList();

            return Json(insumos, JsonRequestBehavior.AllowGet);
        }
    }
}
