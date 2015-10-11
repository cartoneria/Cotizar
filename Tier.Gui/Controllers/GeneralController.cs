using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public class GeneralController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public JsonResult RecupararMunicipiosXDepartamento(string idDepartamento)
        {
            return Json(SAL.Municipios.RecuperarXDepartamento(idDepartamento), JsonRequestBehavior.AllowGet);
        }

    }
}
