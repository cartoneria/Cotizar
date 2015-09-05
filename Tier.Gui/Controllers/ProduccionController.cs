﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class ProduccionController : BaseController
    {
        //
        // GET: /Produccion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListaMaquinas()
        {
            return View(SAL.Maquinas.RecuperarTodas());
        }

        public ActionResult CrearMaquina()
        {
            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", 1);
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CrearMaquina(CotizarService.Maquina obj)
        {
            if (ModelState.IsValid)
            {
                short? idMaquina = null;
                CotizarService.Maquina _nMaquina = new CotizarService.Maquina
                {
                    activo = obj.activo,
                    anchomax = obj.anchomax,
                    anchomin = obj.anchomin,
                    codigo = obj.codigo,
                    descripcion = obj.descripcion,
                    fechacreacion = DateTime.Now,
                    largomax = obj.largomax,
                    largomin = obj.largomin,
                    nombre = obj.nombre,
                    empresa_idempresa = obj.empresa_idempresa,
                    itemlista_iditemlistas_tipo = obj.itemlista_iditemlistas_tipo
                };

                CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                if (_Service.Maquina_Insertar(_nMaquina, out idMaquina) && idMaquina != null)
                {
                    base.RegistrarNotificación("Maquina creada con exito.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                    return RedirectToAction("ListaMaquinas", "Produccion");
                }
                else
                {
                    base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                }
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no son validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);
            }

            ViewBag.empresa_idempresa = new SelectList(SAL.Empresas.RecuperarEmpresasActivas(), "idempresa", "razonsocial", 1);
            ViewBag.itemlista_iditemlistas_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TipoMaquina), "iditemlista", "nombre");
            return View();
        }

        public JsonResult ValidaCodigoMaquina(string codigo, byte empresa_idempresa)
        {
            CotizarService.CotizarServiceClient objService = new CotizarService.CotizarServiceClient();

            if (objService.Maquina_ValidaCodigo(new CotizarService.Maquina() { codigo = codigo, empresa_idempresa = empresa_idempresa }))
                return Json(true, JsonRequestBehavior.AllowGet);

            string suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible.", codigo);

            for (int i = 1; i < 100; i++)
            {
                string altCandidate = codigo + i.ToString();
                if (objService.Maquina_ValidaCodigo(new CotizarService.Maquina() { codigo = altCandidate, empresa_idempresa = empresa_idempresa }))
                {
                    suggestedUID = String.Format(CultureInfo.InvariantCulture, "{0} no está disponible. Te sugerimos usar {1}.", codigo, altCandidate);
                    break;
                }
            }

            return Json(suggestedUID, JsonRequestBehavior.AllowGet);
        }
    }
}
