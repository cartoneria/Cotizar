using Newtonsoft.Json.Linq;
using System;
using System.Text;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ProduccionController : BaseController
    {
        public ActionResult ListaInsumos()
        {
            ViewBag.lstTipoInsumo = SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo);
            return View(SAL.Insimos.RecuperarTodos());
        }

        public ActionResult CrearInsumo()
        {
            //Proveedores
            ViewBag.proveedores_idproveedor = new SelectList(SAL.Proveedores.RecuperarProveedoresActivas(), "idproveedor", "nombre");

            //ProveedoresLineas
            ViewBag.proveedoreslinea_idproveedorlinea = new SelectList(new List<CotizarService.ProveedorLinea>(), "idlinea", "nombre");

            //ItemLista Tipo
            ViewBag.itemlista_iditemlista_tipo = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.TiposInsumo), "iditemlista", "nombre");

            //ItemLista UnidadMedida
            ViewBag.itemlista_iditemlista_unimedcomp = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");

            //ItemLista UnidadRendimiento
            ViewBag.itemlista_iditemlista_unimedrendi = new SelectList(SAL.ItemsListas.RecuperarActivosGrupo((byte)Models.Enumeradores.TiposLista.UnidadesMedida), "iditemlista", "nombre");

            return View();
        }

        [HttpPost]
        public ActionResult CrearInsumo(CotizarService.Insumo obj)
        {
            return View();
        }


        public ActionResult EditarInsumo(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditarInsumo(CotizarService.Insumo obj)
        {
            return View();
        }

        [HttpPost]
        public JsonResult RecuperarLineasProveedor(int idProveedor)
        {
            return Json(SAL.Proveedores.RecuperarXId(idProveedor).lineas, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EliminarInsumo(int id)
        {
            return View();
        }

    }
}