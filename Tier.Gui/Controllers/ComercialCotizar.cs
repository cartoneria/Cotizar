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
            ViewBag.Ciudad = new SelectList(insumos.Where(c => c.itemlista_iditemlista_tipo == 46).ToList(), "idinsumo", "nombre");
            var objCliente = SAL.Clientes.RecuperarTodos(base.SesionActual.empresa.idempresa).Where(c => c.idcliente == obj).ToList().FirstOrDefault();
            ViewBag.cliente_idCliente = objCliente.idcliente;
            ViewBag.cliente_nombre = objCliente.nombre;
            ViewBag.Identificacion = objCliente.identificacion;
            ViewBag.Direccion = objCliente.direccion;
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

    }
}

