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

        #region [Gestión Empresas]
        [OperationContract]
        Dto.Empresa Empresa_Insertar(Dto.Empresa obj);

        [OperationContract]
        IEnumerable<Dto.Empresa> Empresa_RecuperarFiltros(Dto.Empresa objFiltros);

        [OperationContract]
        Dto.Empresa Empresa_Actualizar(Dto.Empresa obj);

        [OperationContract]
        Dto.Empresa Empresa_Eliminar(Dto.Empresa obj);
        #endregion

        #region [Gestión Listas]
        [OperationContract]
        Dto.ItemLista ItemLista_Insertar(Dto.ItemLista obj);

        [OperationContract]
        IEnumerable<Dto.ItemLista> ItemLista_RecuperarFiltros(Dto.ItemLista objFiltros);

        [OperationContract]
        Dto.ItemLista ItemLista_Actualizar(Dto.ItemLista obj);

        [OperationContract]
        Dto.ItemLista ItemLista_Eliminar(Dto.ItemLista obj);
        #endregion

        #region [Gestión Usuarios]
        [OperationContract]
        Dto.Usuario Usuario_Insertar(Dto.Usuario obj);

        [OperationContract]
        IEnumerable<Dto.Usuario> Usuario_RecuperarFiltros(Dto.Usuario objFiltros);

        [OperationContract]
        Dto.Usuario Usuario_Actualizar(Dto.Usuario obj);

        [OperationContract]
        Dto.Usuario Usuario_Eliminar(Dto.Usuario obj);

        [OperationContract]
        Dto.Usuario Usuario_RestablecerClave(Dto.Usuario obj);

        [OperationContract]
        Dto.Usuario Usuario_CambiarClave(Dto.Usuario obj);

        [OperationContract]
        bool Usuario_ValidaNombreUsuario(Dto.Usuario obj);

        [OperationContract]
        Dto.Sesion Usuario_IniciarSesion(Dto.Usuario obj);
        #endregion
    }
}
