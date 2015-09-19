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
            return new clsUsuarios().RecuperarUsuarioRestablecerClave(strUsuario, strEmail, intIdEmpresa);
        }

        public static bool RestablecerClave(Nullable<short> intIdUsuario, string strUsuario, string strEmail)
        {
            return new clsUsuarios().RestablecerClave(intIdUsuario, strUsuario, strEmail);
        }

        public static IEnumerable<CotizarService.Usuario> RecuperarTodos()
        {
            return new clsUsuarios().RecuperarTodos();
        }
    }

    internal class clsUsuarios : BaseServiceAccessParent
    {
        internal CotizarService.Sesion IniciarSesion(CotizarService.Usuario objCredenciales)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_IniciarSesion(objCredenciales);
        }

        internal CotizarService.Usuario RecuperarUsuarioRestablecerClave(string strUsuario, string strEmail, Nullable<byte> intIdEmpresa)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_RecuperarFiltros(new CotizarService.Usuario() { usuario = strUsuario, correoelectronico = strEmail, empresa_idempresa = intIdEmpresa }).FirstOrDefault();
        }

        internal bool RestablecerClave(Nullable<short> intIdUsuario, string strUsuario, string strEmail)
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_RestablecerClave(new CotizarService.Usuario() { usuario = strUsuario, correoelectronico = strEmail, idusuario = intIdUsuario });
        }

        internal IEnumerable<CotizarService.Usuario> RecuperarTodos()
        {
            objProxy = new CotizarService.CotizarServiceClient();
            return objProxy.Usuario_RecuperarFiltros(new CotizarService.Usuario());
        }
    }
}