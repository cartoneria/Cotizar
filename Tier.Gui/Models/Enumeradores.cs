using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.Models
{
    public static class Enumeradores
    {
        public enum TiposLista : byte
        {
            Areas = 1,
            TiposMaquina = 2,
            UnidadesMedida = 3,
            TiposRegimen = 4,
            TiposIdentificacion = 5,
            FormasPago = 6,
            TiposContacto = 7,
            TiposMaterial = 8,
            TiposInsumo = 9
        }

        public enum TiposNotificaciones : byte
        {
            success,
            info,
            notice,
            error,
            dark
        }
    }
}