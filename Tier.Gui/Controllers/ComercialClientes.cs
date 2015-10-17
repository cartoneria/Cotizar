﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ComercialController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        private void CargarListar(CotizarService.Cliente obj)
        {
            if (obj != null)
            {
                ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", obj.empresa_idempresa);
                ViewBag.itemlista_iditemlista_tipoidenti = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposIdentificacion), "iditemlista", "nombre", obj.itemlista_iditemlista_tipoidenti);
                ViewBag.itemlista_iditemlista_regimen = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposRegimen), "iditemlista", "nombre", obj.itemlista_iditemlista_regimen);
                ViewBag.itemlista_iditemlista_formapago = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.FormasPago), "iditemlista", "nombre", obj.itemlista_iditemlista_formapago);
                ViewBag.tiposcliente = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposContacto), "iditemlista", "nombre");
                ViewBag.municipio_departamento_iddepartamento = new SelectList(SAL.Departamentos.RecuperarActivos(), "iddepartamento", "nombre", obj.municipio_departamento_iddepartamento);
                ViewBag.municipio_idmunicipio = new SelectList(SAL.Municipios.RecuperarXDepartamento(obj.municipio_departamento_iddepartamento), "idmunicipio", "nombre", obj.municipio_idmunicipio);
            }
            else
            {
                ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial");
                ViewBag.itemlista_iditemlista_tipoidenti = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposIdentificacion), "iditemlista", "nombre");
                ViewBag.itemlista_iditemlista_regimen = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposRegimen), "iditemlista", "nombre");
                ViewBag.itemlista_iditemlista_formapago = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.FormasPago), "iditemlista", "nombre");
                ViewBag.tiposcliente = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposContacto), "iditemlista", "nombre");
                ViewBag.municipio_departamento_iddepartamento = new SelectList(SAL.Departamentos.RecuperarActivos(), "iddepartamento", "nombre");
                ViewBag.municipio_idmunicipio = new SelectList(new List<CotizarService.Municipio>(), "idmunicipio", "nombre");
            }
        }

        public ActionResult ListaClientes()
        {
            return View(SAL.Clientes.RecuperarTodos());
        }

        public ActionResult CrearCliente()
        {
            this.CargarListar(null);

            return View(new CotizarService.Cliente());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="editando"></param>
        /// <returns></returns>
        public JsonResult ValidaNombreCliente(string nombre, bool editando)
        {
            if (editando)
                return Json(true, JsonRequestBehavior.AllowGet);

            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Cliente_ValidaNombre(new CotizarService.Cliente() { nombre = nombre }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", nombre);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = nombre + i.ToString();
                if (objService.Cliente_ValidaNombre(new CotizarService.Cliente() { nombre = altCandidate }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", nombre, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearCliente(CotizarService.Cliente obj)
        {
            if (ModelState.IsValid)
            {
                int? _idCliente;

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Cliente_Insertar(obj, out _idCliente) && _idCliente != null)
                {
                    base.RegistrarNotificación("Cliente creado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaClientes", "Comercial");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListar(null);

            return View(obj);
        }

        public ActionResult EditarCliente(int id)
        {
            CotizarService.Cliente objCliente = SAL.Clientes.RecuperarXId(id);

            this.CargarListar(objCliente);

            return View(objCliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditarCliente(CotizarService.Cliente obj)
        {
            if (ModelState.IsValid)
            {
                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Cliente_Actualizar(obj))
                {
                    base.RegistrarNotificación("Cliente actualizado con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaClientes", "Comercial");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            this.CargarListar(obj);

            return View(obj);
        }

        public ActionResult ContactosCliente(int id)
        {
            CotizarService.Cliente objCliente = SAL.Clientes.RecuperarXId(id);

            ViewBag.Departamento = SAL.Departamentos.RecuperarXId(objCliente.municipio_departamento_iddepartamento);
            ViewBag.Municipio = SAL.Municipios.RecuperarXId(objCliente.municipio_idmunicipio);

            return View(objCliente);
        }

        public ActionResult EliminarCliente(int id)
        {
            try
            {
                CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();
                if (objService.Cliente_Eliminar(new CotizarService.Cliente() { idcliente = id }))
                    base.RegistrarNotificación("Se ha eliminado/inactivado el cliente.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                else
                    base.RegistrarNotificación("El cliente no pudo ser eliminado. Posiblemente se ha inhabilitado.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }
            catch (Exception ex)
            {
                //Controlar la excepción
                base.RegistrarNotificación("Falla en el servicio de eliminación.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
            }

            return RedirectToAction("ListaClientes", "Comercial");
        }
    }
}