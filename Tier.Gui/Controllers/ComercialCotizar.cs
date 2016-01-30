using System;
using System.Collections.Generic;
using System.Linq;
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
            var insumos = SAL.Insumos.RecuperarTodos(base.SesionActual.empresa.idempresa).ToList();
            var objCliente = SAL.Clientes.RecuperarTodos(base.SesionActual.empresa.idempresa).Where(c => c.idcliente == obj).ToList().FirstOrDefault();
            ViewBag.cliente_idCliente = objCliente.idcliente;
            ViewBag.cliente_nombre = objCliente.nombre;
            ViewBag.Identificacion = objCliente.identificacion;
            ViewBag.Direccion = objCliente.direccion;
            ViewBag.producto_idproducto = new List<SelectListItem> { new SelectListItem { Text = "Producto 1", Value = "1" }, new SelectListItem { Text = "Producto 2", Value = "2" } };
            ViewBag.insumo_idinsumo_flete = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 46).ToList(), "idinsumo", "nombre");
        }

        public ActionResult ListaCotizaciones(Nullable<int> id)
        {
            if (id == null)
            {
                base.RegistrarNotificación("No se ha suministrado un identificador de cliente.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
                return RedirectToAction("ListaClientes", "Comercial");
            }

            this.CargarListasCotizar(id);
            return View();
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
        public ActionResult CrearCotizacion()
        {
            if (ModelState.IsValid)
            {
                int? idCotizacion;
                //CotizarService.Cotizar idCotizacion = new CotizarService.Cotizar{};
                //CotizarService.CotizarServiceClient objCotizar = new CotizarServiceClient();

                //if cotizacion se inserta correctamente.

                //else si no se inserta correctamente.
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son válidos", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            this.CargarListasCotizar(3);
            return View();
        }

    }
}

