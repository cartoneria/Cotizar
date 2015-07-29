using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICMCotizar" in both code and config file together.
    [ServiceContract]
    public interface ICMCotizar
    {
        #region [Gestión Roles]
        [OperationContract]
        Dto.Rol Rol_Insertar(Dto.Rol obj);

        [OperationContract]
        IEnumerable<Dto.Rol> Rol_RecuperarFiltros(Dto.Rol objFiltros);

        [OperationContract]
        Dto.Rol Rol_Actualizar(Dto.Rol obj);

        [OperationContract]
        Dto.Rol Rol_Eliminar(Dto.Rol obj);
        #endregion
    }
}
