using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tier.Gui.SAL
{
    public static class Usuarios
    {
        public static CotizarService.Sesion IniciarSesion(string strUsuario, string strClave, Nullable<byte> intIdEmpresa)
        {
            return new clsUsuarios().IniciarSesion(new CotizarService.Usuario() { usuario = strUsuario, clave = strClave, empresa_idempresa = intIdEmpresa, activo = true });
        }

        public static CotizarService.Usuario RecuperarUsuarioRestablecerClave(string strUsuario, string strEmail, Nullable<byte> intIdEmpresa)
        {
            return new clsUsuarios().RecuperarUsuarioRestablecerClave(new CotizarService.Usuario()
            {
                usuario = strUsuario,
                correoelectronico = strEmail,
                empresa_idempresa = intIdEmpresa
            });
        }

        public static bool RestablecerClave(Nullable<short> intIdUsuario, string strUsuario, string strEmail)
        {
            return new clsUsuarios().RestablecerClave(new CotizarService.Usuario() { usuario = strUsuario, correoelectronico = strEmail, idusuario = intIdUsuario });
        }

        public static IEnumerable<CotizarService.Usuario> RecuperarTodos(Nullable<byte> idEmpresa)
        {
            return new clsUsuarios().RecuperarFiltrados(new CotizarService.Usuario() { empresa_idempresa = idEmpresa });
        }

        public static CotizarService.Usuario RecuperarXId(Nullable<short> intIdUsuario, Nullable<byte> idEmpresa)
        {
            return new clsUsuarios().RecuperarXId(new CotizarService.Usuario() { empresa_idempresa = idEmpresa, idusuario = intIdUsuario });
        }

        public static CotizarService.Sesion ActualizarMenuUsuario(Nullable<short> intIdUsuario, Nullable<byte> intIdEmpresa)
        {
            return new clsUsuarios().ActualizarMenuUsuario(new CotizarService.Usuario() { idusuario = intIdUsuario, empresa_idempresa = intIdEmpresa, activo = true });
        }

        public static IEnumerable<CotizarService.Usuario> RecuperarFiltrados(CotizarService.Usuario obj)
        {
            return new clsUsuarios().RecuperarFiltrados(obj);
        }
    }

    internal class clsUsuarios : BaseServiceAccessParent
    {
        internal CotizarService.Sesion IniciarSesion(CotizarService.Usuario objCredenciales)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_IniciarSesion(objCredenciales);
        }

        internal CotizarService.Usuario RecuperarUsuarioRestablecerClave(CotizarService.Usuario obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_RecuperarFiltros(obj).FirstOrDefault();
        }

        internal bool RestablecerClave(CotizarService.Usuario obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_RestablecerClave(obj);
        }

        internal IEnumerable<CotizarService.Usuario> RecuperarFiltrados(CotizarService.Usuario obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_RecuperarFiltros(obj);
        }

        internal CotizarService.Usuario RecuperarXId(CotizarService.Usuario obj)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_RecuperarFiltros(obj).FirstOrDefault();
        }

        internal CotizarService.Sesion ActualizarMenuUsuario(CotizarService.Usuario objUsuario)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_ActualizarMenuUsuario(objUsuario);
        }
    }
}