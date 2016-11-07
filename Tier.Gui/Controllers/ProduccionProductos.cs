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
        private void CargarListasProductos(CotizarService.Producto obj)
        {
            var insumos = SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList();

            if (obj != null)
            {
                if (obj.troquel_idtroquel != null)
                {
                    ViewBag.troquel_idtroquel = new SelectList(SAL.Troqueles.RecuperarFiltrados(new CotizarService.Troquel() { idtroquel = obj.troquel_idtroquel }).ToList(), "idtroquel", "descripcion", obj.troquel_idtroquel);

                    CotizarService.Troquel objTroquel = SAL.Troqueles.RecuperarXId((int)obj.troquel_idtroquel);
                    ViewBag.troquelEstiloPegues = SAL.Estilos.RecuperarPeguesFiltrados(new CotizarService.Estilo() { idestilo = objTroquel.estilo_idestilo });
                }
                else
                {
                    ViewBag.troquel_idtroquel = new SelectList(new List<CotizarService.Troquel>(), "idtroquel", "descripcion");
                }

                if (obj.insumo_idinsumo_material != null)
                {
                    ViewBag.insumo_idinsumo_material = new SelectList(SAL.Insumos.RecuperarFiltrados(new CotizarService.Insumo() { idinsumo = obj.insumo_idinsumo_material }).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_material);
                }
                else
                {
                    ViewBag.insumo_idinsumo_material = new SelectList(new List<CotizarService.Insumo>(), "idinsumo", "nombre");
                }

                ViewBag.insumo_idinsumo_acetato = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acetato).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_acetato);
                ViewBag.insumo_idinsumo_acabadoderecho = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acabados), "idinsumo", "nombre", obj.insumo_idinsumo_acabadoderecho);
                ViewBag.insumo_idinsumo_acabadoreverso = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acabados), "idinsumo", "nombre", obj.insumo_idinsumo_acabadoreverso);
                ViewBag.insumo_idinsumo_reempaque = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Reenpaques).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_reempaque);
                ViewBag.insumo_idinsumo_colaminado = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Carton).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_colaminado);
                ViewBag.insumo_idinsumo_colaminadopegante = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Pegantes), "idinsumo", "nombre", obj.insumo_idinsumo_colaminadopegante);

                ViewBag.maquinavariprod_idVariacion_rutaconversion = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Conversion).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaconversion);
                ViewBag.maquinavariprod_idVariacion_rutaguillotinado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Guillotinado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaguillotinado);
                ViewBag.maquinavariprod_idVariacion_rutalitografia = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Litografia).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutalitografia);
                ViewBag.maquinavariprod_idVariacion_rutaacabadoderecho = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Acabado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaacabadoderecho);
                ViewBag.maquinavariprod_idVariacion_rutaacabadoreverso = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Acabado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaacabadoreverso);
                ViewBag.maquinavariprod_idVariacion_rutacolaminado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Colaminado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutacolaminado);
                ViewBag.maquinavariprod_idVariacion_rutatroquelado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Troquelado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutatroquelado);

                if (obj.pinzalitografica != null && obj.pinzalitografica == true)
                {
                    ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "true", Selected = true }, new SelectListItem { Text = "Pinza ancho", Value = "false" } };
                }
                else if (obj.pinzalitografica != null && obj.pinzalitografica == false)
                {
                    ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "true" }, new SelectListItem { Text = "Pinza ancho", Value = "false", Selected = true } };
                }
                else
                {
                    ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "false" }, new SelectListItem { Text = "Pinza ancho", Value = "true" } };
                }
            }
            else
            {
                ViewBag.troquel_idtroquel = new SelectList(new List<CotizarService.Troquel>(), "idtroquel", "descripcion");
                ViewBag.troquelEstiloPegues = new List<CotizarService.EstiloPegue>();
                ViewBag.insumo_idinsumo_material = new SelectList(new List<CotizarService.Insumo>(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_acetato = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acetato).ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_acabadoderecho = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acabados), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_acabadoreverso = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acabados), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_reempaque = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Reenpaques).ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_colaminado = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Carton).ToList(), "idinsumo", "nombre");
                ViewBag.insumo_idinsumo_colaminadopegante = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Pegantes), "idinsumo", "nombre");

                ViewBag.maquinavariprod_idVariacion_rutaconversion = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Conversion).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutaguillotinado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Guillotinado).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutalitografia = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Litografia).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutaacabadoderecho = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Acabado).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutaacabadoreverso = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Acabado).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutacolaminado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Colaminado).ToList(), "idVariacion", "nombre");
                ViewBag.maquinavariprod_idVariacion_rutatroquelado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Troquelado).ToList(), "idVariacion", "nombre");

                ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "false" }, new SelectListItem { Text = "Pinza ancho", Value = "true" } };
            }

            IEnumerable<CotizarService.Cliente> lstclientes = new List<CotizarService.Cliente>() { SAL.Clientes.RecuperarXId((int)obj.cliente_idcliente, base.SesionActual.empresa.idempresa) };
            ViewBag.cliente_idcliente = new SelectList(lstclientes, "idcliente", "nombre", obj.cliente_idcliente);

            ViewBag.panton_idpanton = new SelectList(SAL.Pantones.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idpantone", "nombre");

            ViewBag.accesorio_idaccesorio = new SelectList(SAL.Accesorios.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idaccesorio", "nombre");
            ViewBag.insumo_idinsumo_materialpegue = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Pegantes), "idinsumo", "nombre");

            ViewBag.maquinavariprod_idVariacion_rutapegue = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Pegue).ToList(), "idVariacion", "nombre");

            ViewBag.IdCliente = obj.cliente_idcliente;
        }

        private void CargarListasProductoClonar(CotizarService.Producto obj)
        {
            var insumos = SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList();

            if (obj.troquel_idtroquel != null)
            {
                ViewBag.troquel_idtroquel = new SelectList(SAL.Troqueles.RecuperarFiltrados(new CotizarService.Troquel() { idtroquel = obj.troquel_idtroquel }).ToList(), "idtroquel", "descripcion", obj.troquel_idtroquel);

                CotizarService.Troquel objTroquel = SAL.Troqueles.RecuperarXId((int)obj.troquel_idtroquel);
                ViewBag.troquelEstiloPegues = SAL.Estilos.RecuperarPeguesFiltrados(new CotizarService.Estilo() { idestilo = objTroquel.estilo_idestilo });
            }
            else
            {
                ViewBag.troquel_idtroquel = new SelectList(new List<CotizarService.Troquel>(), "idtroquel", "descripcion");
            }

            if (obj.insumo_idinsumo_material != null)
            {
                ViewBag.insumo_idinsumo_material = new SelectList(SAL.Insumos.RecuperarFiltrados(new CotizarService.Insumo() { idinsumo = obj.insumo_idinsumo_material }).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_material);
            }
            else
            {
                ViewBag.insumo_idinsumo_material = new SelectList(new List<CotizarService.Insumo>(), "idinsumo", "nombre");
            }

            ViewBag.insumo_idinsumo_acetato = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acetato).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_acetato);
            ViewBag.insumo_idinsumo_acabadoderecho = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acabados), "idinsumo", "nombre", obj.insumo_idinsumo_acabadoderecho);
            ViewBag.insumo_idinsumo_acabadoreverso = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Acabados), "idinsumo", "nombre", obj.insumo_idinsumo_acabadoreverso);
            ViewBag.insumo_idinsumo_reempaque = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Reenpaques).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_reempaque);
            ViewBag.insumo_idinsumo_colaminado = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Carton).ToList(), "idinsumo", "nombre", obj.insumo_idinsumo_colaminado);
            ViewBag.insumo_idinsumo_colaminadopegante = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Pegantes), "idinsumo", "nombre", obj.insumo_idinsumo_colaminadopegante);

            ViewBag.maquinavariprod_idVariacion_rutaconversion = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Conversion).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaconversion);
            ViewBag.maquinavariprod_idVariacion_rutaguillotinado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Guillotinado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaguillotinado);
            ViewBag.maquinavariprod_idVariacion_rutalitografia = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Litografia).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutalitografia);
            ViewBag.maquinavariprod_idVariacion_rutaacabadoderecho = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Acabado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaacabadoderecho);
            ViewBag.maquinavariprod_idVariacion_rutaacabadoreverso = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Acabado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutaacabadoreverso);
            ViewBag.maquinavariprod_idVariacion_rutacolaminado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Colaminado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutacolaminado);
            ViewBag.maquinavariprod_idVariacion_rutatroquelado = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Troquelado).ToList(), "idVariacion", "nombre", obj.maquinavariprod_idVariacion_rutatroquelado);

            if (obj.pinzalitografica != null && obj.pinzalitografica == true)
            {
                ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "true", Selected = true }, new SelectListItem { Text = "Pinza ancho", Value = "false" } };
            }
            else if (obj.pinzalitografica != null && obj.pinzalitografica == false)
            {
                ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "true" }, new SelectListItem { Text = "Pinza ancho", Value = "false", Selected = true } };
            }
            else
            {
                ViewBag.pinzalitografica = new List<SelectListItem> { new SelectListItem { Text = "Pinza largo", Value = "false" }, new SelectListItem { Text = "Pinza ancho", Value = "true" } };
            }

            ViewBag.cliente_idcliente = new SelectList(SAL.Clientes.RecuperarFiltrados(new CotizarService.Cliente() { idcliente = obj.cliente_idcliente }).ToList(), "idcliente", "nombre", obj.cliente_idcliente);
            ViewBag.panton_idpanton = new SelectList(SAL.Pantones.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idpantone", "nombre");
            ViewBag.accesorio_idaccesorio = new SelectList(SAL.Accesorios.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList(), "idaccesorio", "nombre");

            ViewBag.insumo_idinsumo_materialpegue = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == (int)Models.Enumeradores.TiposMateriales.Pegantes), "idinsumo", "nombre");
            ViewBag.maquinavariprod_idVariacion_rutapegue = new SelectList(SAL.Maquinas.RecuperarRutasProduccionXTipo(base.SesionActual.empresa.idempresa, (int)Models.Enumeradores.ProcesosProduccion.Pegue).ToList(), "idVariacion", "nombre");

            ViewBag.IdCliente = obj.cliente_idcliente;
        }

        public ActionResult ListaProductos(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            var objCliente = SAL.Clientes.RecuperarXId((int)id, base.SesionActual.empresa.idempresa);
            ViewBag.Cliente = objCliente;

            return View(SAL.Productos.RecuperarTodos(id).ToList());
        }

        public ActionResult CrearProducto(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            this.CargarListasProductos(new CotizarService.Producto() { cliente_idcliente = id });
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
                    insumo_idinsumo_colaminadopegante = obj.insumo_idinsumo_colaminadopegante,
                    colaminadoancho = obj.colaminadoancho,
                    colaminadoalargo = obj.colaminadoalargo,
                    colaminadocabidalargo = obj.colaminadocabidalargo,
                    colaminadocabidaancho = obj.colaminadocabidaancho,
                    insumo_idinsumo_reempaque = obj.insumo_idinsumo_reempaque,
                    factorrendimientoreempaque = obj.factorrendimientoreempaque,
                    maquinavariprod_idVariacion_rutaconversion = obj.maquinavariprod_idVariacion_rutaconversion,
                    maquinavariprod_idVariacion_rutaguillotinado = obj.maquinavariprod_idVariacion_rutaguillotinado,
                    maquinavariprod_idVariacion_rutalitografia = obj.maquinavariprod_idVariacion_rutalitografia,
                    maquinavariprod_idVariacion_rutaacabadoderecho = obj.maquinavariprod_idVariacion_rutaacabadoderecho,
                    maquinavariprod_idVariacion_rutaacabadoreverso = obj.maquinavariprod_idVariacion_rutaacabadoreverso,
                    maquinavariprod_idVariacion_rutacolaminado = obj.maquinavariprod_idVariacion_rutacolaminado,
                    maquinavariprod_idVariacion_rutatroquelado = obj.maquinavariprod_idVariacion_rutatroquelado,
                    accesorios = CargarPrdAccesorios(obj.hdfAccesorios).ToList(),
                    espectro = this.CargarPrdEspectros(obj.hdfEspectro).ToList(),
                    pegues = this.CargarPrdPegues(obj.hdfPegues).ToList(),
                };

                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Producto_Insertar(_producto, out _idProducto) && _idProducto != null)
                {
                    base.RegistrarNotificación("Producto creado con éxito", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("CrearCotizacion", "Comercial", new { id = obj.cliente_idcliente });
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
                        "\"nomAccr\":\"" + item.accesorio_descaccesorio + "\"},");
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

            strResultado.Append("[");
            if (lstPrdEspect != null)
            {
                foreach (var item in lstPrdEspect)
                {
                    strResultado.Append("{\"id\":\"" + item.idproducto_espectro.ToString() + "\"," +
                        "\"idProducto\":\"" + item.producto_idproducto.ToString() + "\"," +
                        "\"idPanton\":\"" + item.pantone_idpantone.ToString() + "\"," +
                        "\"porcentaje\":\"" + item.porcentajecubrimiento.ToString() + "\"," +
                        "\"hex\":\"#" + item.pantone_hex + "\"," +
                        "\"derechoreverso\":" + item.derechoreverso.ToString().ToLower() + "," +
                        "\"activo\":\"" + item.activo.ToString().ToLower() + "\"," +
                        "\"fechacreacion\":\"" + item.pantone.ToString() + "\"},");
                }
            }
            strResultado.Append("]");

            return strResultado.ToString().Replace("},]", "}]");
        }

        private IEnumerable<CotizarService.ProductoEspectro> CargarPrdEspectros(string strJsonPrdEspectros)
        {
            List<CotizarService.ProductoEspectro> lstPrdEspectros = new List<CotizarService.ProductoEspectro>();

            if (!string.IsNullOrEmpty(strJsonPrdEspectros))
            {
                JArray jsonArray = JArray.Parse(strJsonPrdEspectros);
                if (jsonArray.Count > 0)
                {
                    foreach (var objPrdEspectro in jsonArray.Children())
                    {
                        try
                        {
                            dynamic objArrEspectro = JObject.Parse(objPrdEspectro.ToString());
                            int intIdPrdAccesr;

                            lstPrdEspectros.Add(new CotizarService.ProductoEspectro()
                            {
                                idproducto_espectro = (int.TryParse(objArrEspectro.id.ToString(), out intIdPrdAccesr) ? intIdPrdAccesr : new Nullable<int>()),
                                producto_idproducto = objArrEspectro.idProducto,
                                pantone_idpantone = objArrEspectro.idPanton,
                                porcentajecubrimiento = objArrEspectro.porcentaje,
                                derechoreverso = objArrEspectro.derechoreverso,
                                activo = true
                            });
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }

            return lstPrdEspectros;

        }

        private string GenerarJsonProductosPegues(IEnumerable<CotizarService.ProductoPegue> lstPrdPegue)
        {
            StringBuilder strResultado = new StringBuilder();

            strResultado.Append("[");
            if (lstPrdPegue != null)
            {
                foreach (var item in lstPrdPegue)
                {
                    strResultado.Append("{\"id\":\"" + item.idproducto_pegue.ToString() + "\"," +
                        "\"idProducto\":\"" + item.producto_idproducto.ToString() + "\"," +
                        "\"insumoPegue\":\"" + item.insumo_idinsumo.ToString() + "\"," +
                        "\"maquinarutapegue\":\"" + item.maquinavariprod_idVariacion.ToString() + "\"," +
                        "\"nomPegue\":\"" + item.insumo_descinsumo + "\"," +
                        "\"nomMaquina\":\"" + item.maquinavariprod_descvariacion + "\"," +
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
                            dynamic objArrPegue = JObject.Parse(objPrdPegue.ToString());
                            int intIdPrdPegue;
                            int idProducto;

                            lstPrdPegues.Add(new CotizarService.ProductoPegue()
                            {
                                idproducto_pegue = (int.TryParse(objArrPegue.id.ToString(), out intIdPrdPegue) ? intIdPrdPegue : new Nullable<int>()),
                                producto_idproducto = (int.TryParse(objArrPegue.idProducto.ToString(), out idProducto) ? idProducto : new Nullable<int>()),
                                maquinavariprod_idVariacion = objArrPegue.maquinarutapegue,
                                largo = objArrPegue.largoPegue,
                                ancho = (Convert.ToString(objArrPegue.anchoPegue).Length > 0) ? objArrPegue.anchoPegue : 0,
                                insumo_idinsumo = objArrPegue.insumoPegue
                            });
                        }
                        catch (Exception ex)
                        {
                            throw ex;
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
                        insumo_idinsumo_colaminadopegante = objProducto.insumo_idinsumo_colaminadopegante,
                        colaminadoancho = objProducto.colaminadoancho,
                        colaminadoalargo = objProducto.colaminadoalargo,
                        colaminadocabidalargo = objProducto.colaminadocabidalargo,
                        colaminadocabidaancho = objProducto.colaminadocabidaancho,
                        insumo_idinsumo_reempaque = objProducto.insumo_idinsumo_reempaque,
                        factorrendimientoreempaque = objProducto.factorrendimientoreempaque,
                        maquinavariprod_idVariacion_rutaconversion = objProducto.maquinavariprod_idVariacion_rutaconversion,
                        maquinavariprod_idVariacion_rutaguillotinado = objProducto.maquinavariprod_idVariacion_rutaguillotinado,
                        maquinavariprod_idVariacion_rutalitografia = objProducto.maquinavariprod_idVariacion_rutalitografia,
                        maquinavariprod_idVariacion_rutaacabadoderecho = objProducto.maquinavariprod_idVariacion_rutaacabadoderecho,
                        maquinavariprod_idVariacion_rutaacabadoreverso = objProducto.maquinavariprod_idVariacion_rutaacabadoreverso,
                        maquinavariprod_idVariacion_rutacolaminado = objProducto.maquinavariprod_idVariacion_rutacolaminado,
                        maquinavariprod_idVariacion_rutatroquelado = objProducto.maquinavariprod_idVariacion_rutatroquelado,
                        hdfAccesorios = this.GenerarJsonProductosAccesorios(objProducto.accesorios),
                        hdfEspectro = this.GenerarJsonProductosEspectro(objProducto.espectro),
                        hdfPegues = this.GenerarJsonProductosPegues(objProducto.pegues),
                        imagenartegrafico = objProducto.imagenartegrafico,
                        nuevo = objProducto.nuevo,
                        activo = objProducto.activo,
                        fechacreacion = objProducto.fechacreacion,
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
                    insumo_idinsumo_colaminadopegante = obj.insumo_idinsumo_colaminadopegante,
                    colaminadoancho = obj.colaminadoancho,
                    colaminadoalargo = obj.colaminadoalargo,
                    colaminadocabidalargo = obj.colaminadocabidalargo,
                    colaminadocabidaancho = obj.colaminadocabidaancho,
                    insumo_idinsumo_reempaque = obj.insumo_idinsumo_reempaque,
                    factorrendimientoreempaque = obj.factorrendimientoreempaque,
                    maquinavariprod_idVariacion_rutaconversion = obj.maquinavariprod_idVariacion_rutaconversion,
                    maquinavariprod_idVariacion_rutaguillotinado = obj.maquinavariprod_idVariacion_rutaguillotinado,
                    maquinavariprod_idVariacion_rutalitografia = obj.maquinavariprod_idVariacion_rutalitografia,
                    maquinavariprod_idVariacion_rutaacabadoderecho = obj.maquinavariprod_idVariacion_rutaacabadoderecho,
                    maquinavariprod_idVariacion_rutaacabadoreverso = obj.maquinavariprod_idVariacion_rutaacabadoreverso,
                    maquinavariprod_idVariacion_rutacolaminado = obj.maquinavariprod_idVariacion_rutacolaminado,
                    maquinavariprod_idVariacion_rutatroquelado = obj.maquinavariprod_idVariacion_rutatroquelado,
                    accesorios = CargarPrdAccesorios(obj.hdfAccesorios).ToList(),
                    espectro = CargarPrdEspectros(obj.hdfEspectro).ToList(),
                    pegues = CargarPrdPegues(obj.hdfPegues).ToList(),
                    nuevo = obj.nuevo,
                    activo = obj.activo,
                };
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Producto_Actualizar(objProducto))
                {
                    base.RegistrarNotificación("Se ha actualizado el producto.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("CrearCotizacion", "Comercial", new { id = obj.cliente_idcliente });
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

        public ActionResult EliminarProducto(int idProducto, int idCliente)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Producto_Eliminar(new CotizarService.Producto() { idproducto = idProducto }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el producto.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El producto no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaProductos", "Produccion", new { id = idCliente });
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
                    FileName = ImgFile.FileName.Substring(0, 40).ToString() + '.' + ImgFile.FileName.Split('.')[ImgFile.FileName.Split('.').Length - 1];
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

        public JsonResult anchoMaterial(int id)
        {
            CotizarService.Insumo insumo = SAL.Insumos.RecuperarXId(id, base.SesionActual.empresa.idempresa);

            return Json(insumo, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult BuscarTroqueles(string criterio)
        {
            IEnumerable<CotizarService.Troquel> lst = SAL.Troqueles.RecuperarFiltrados(new CotizarService.Troquel()
            {
                empresa_idempresa = base.SesionActual.empresa.idempresa,
                descripcion = criterio
            }).ToList();

            return Json(lst.Select(ee => new SelectListItem() { Value = ee.idtroquel.ToString(), Text = ee.descripcion }).ToList());
        }

        [HttpPost]
        public JsonResult BuscarInsumosXTipo(string criterio, int tipo)
        {
            IEnumerable<CotizarService.Insumo> lst = SAL.Insumos.RecuperarFiltrados(new CotizarService.Insumo()
            {
                empresa_idempresa = base.SesionActual.empresa.idempresa,
                nombre = criterio,
                itemlista_iditemlista_tipo = tipo
            }).ToList();

            return Json(lst.Select(ee => new SelectListItem() { Value = ee.idinsumo.ToString(), Text = ee.nombre }).ToList());
        }

        [HttpPost]
        public JsonResult BuscarClientes(string criterio)
        {
            IEnumerable<CotizarService.Cliente> lst = SAL.Clientes.RecuperarFiltrados(new CotizarService.Cliente()
            {
                empresa_idempresa = base.SesionActual.empresa.idempresa,
                nombre = criterio
            }).ToList();

            return Json(lst.Select(ee => new SelectListItem() { Value = ee.idcliente.ToString(), Text = ee.nombre }).ToList());
        }

        public ActionResult ClonarProducto(int id)
        {
            CotizarService.Producto objProducto = SAL.Productos.RecuperarXId(id);
            if (objProducto != null)
            {
                CotizarService.ProductoModel objClonar = new CotizarService.ProductoModel()
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
                    insumo_idinsumo_colaminadopegante = objProducto.insumo_idinsumo_colaminadopegante,
                    colaminadoancho = objProducto.colaminadoancho,
                    colaminadoalargo = objProducto.colaminadoalargo,
                    colaminadocabidalargo = objProducto.colaminadocabidalargo,
                    colaminadocabidaancho = objProducto.colaminadocabidaancho,
                    insumo_idinsumo_reempaque = objProducto.insumo_idinsumo_reempaque,
                    factorrendimientoreempaque = objProducto.factorrendimientoreempaque,
                    maquinavariprod_idVariacion_rutaconversion = objProducto.maquinavariprod_idVariacion_rutaconversion,
                    maquinavariprod_idVariacion_rutaguillotinado = objProducto.maquinavariprod_idVariacion_rutaguillotinado,
                    maquinavariprod_idVariacion_rutalitografia = objProducto.maquinavariprod_idVariacion_rutalitografia,
                    maquinavariprod_idVariacion_rutaacabadoderecho = objProducto.maquinavariprod_idVariacion_rutaacabadoderecho,
                    maquinavariprod_idVariacion_rutaacabadoreverso = objProducto.maquinavariprod_idVariacion_rutaacabadoreverso,
                    maquinavariprod_idVariacion_rutacolaminado = objProducto.maquinavariprod_idVariacion_rutacolaminado,
                    maquinavariprod_idVariacion_rutatroquelado = objProducto.maquinavariprod_idVariacion_rutatroquelado,
                    hdfAccesorios = this.GenerarJsonProductosAccesorios(objProducto.accesorios),
                    hdfEspectro = this.GenerarJsonProductosEspectro(objProducto.espectro),
                    hdfPegues = this.GenerarJsonProductosPegues(objProducto.pegues),
                    imagenartegrafico = objProducto.imagenartegrafico,
                    // nuevo = objProducto.nuevo,
                    activo = objProducto.activo,
                    // fechacreacion = objProducto.fechacreacion,
                };

                ViewBag.urlImgProducto = Url.Content(ConfigurationManager.AppSettings["RutaImagenes"].ToString() + "Productos\\" + objProducto.imagenartegrafico);
                this.CargarListasProductoClonar(objClonar);
                return View(objClonar);
            }
            else
            {
                base.RegistrarNotificación("No se ha suministrado un identificador válido.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }
        }
    }
}
