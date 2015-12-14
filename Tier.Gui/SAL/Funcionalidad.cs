﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Funcionalidad
    {
        public static IEnumerable<CotizarService.Funcionalidad> RecuperarActivas()
        {
            return new clsFuncionalidad().RecuperarActivas(new CotizarService.Funcionalidad() { activo = true });
        }
    }

    internal class clsFuncionalidad : BaseServiceAccessParent
    {
        internal IEnumerable<CotizarService.Funcionalidad> RecuperarActivas(CotizarService.Funcionalidad obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Funcionalidad_RecuperarFiltros(obj);
        }
    }
}