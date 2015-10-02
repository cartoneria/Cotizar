using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tier.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CotizarService" in both code and config file together.
    public class CotizarService : ICotizarService
    {
        #region [Gestión Empresas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Empresa> Empresa_RecuperarFiltrado(Dto.Empresa objFiltros)
        {
            return new Business.BEmpresa().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idEmpresa"></param>
        /// <returns></returns>
        public bool Empresa_Insertar(Dto.Empresa obj, out byte? idEmpresa)
        {
            bool blnRespuesta = new Business.BEmpresa().Crear(obj);

            if (blnRespuesta)
                idEmpresa = obj.idempresa;
            else
                idEmpresa = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Empresa_Actualizar(Dto.Empresa obj)
        {
            return new Business.BEmpresa().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Empresa_Eliminar(Dto.Empresa obj)
        {
            return new Business.BEmpresa().Eliminar(obj);
        }
        #endregion

        #region [Gestión Roles]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Rol> Rol_RecuperarFiltros(Dto.Rol objFiltros)
        {
            return new Business.BRol().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idrol"></param>
        /// <returns></returns>
        public bool Rol_Insertar(Dto.Rol obj, out short? idrol)
        {
            bool blnRespuesta = new Business.BRol().Crear(obj);

            if (blnRespuesta)
                idrol = obj.idrol;
            else
                idrol = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Rol_Actualizar(Dto.Rol obj)
        {
            return new Business.BRol().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Rol_Eliminar(Dto.Rol obj)
        {
            return new Business.BRol().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Rol_ValidaNombre(Dto.Rol obj)
        {
            return new Business.BRol().ValidaNombre(obj);
        }
        #endregion

        #region [Gestión Listas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.ItemLista> ItemLista_RecuperarFiltros(Dto.ItemLista objFiltros)
        {
            return new Business.BItemsLista().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="iditemlista"></param>
        /// <returns></returns>
        public bool ItemLista_Insertar(Dto.ItemLista obj, out int? iditemlista)
        {
            bool blnRespuesta = new Business.BItemsLista().Crear(obj);

            if (blnRespuesta)
                iditemlista = obj.iditemlista;
            else
                iditemlista = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ItemLista_Actualizar(Dto.ItemLista obj)
        {
            return new Business.BItemsLista().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ItemLista_Eliminar(Dto.ItemLista obj)
        {
            return new Business.BItemsLista().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool ItemLista_ValidaNombre(Dto.ItemLista obj)
        {
            return new Business.BItemsLista().ValidaNombre(obj);
        }
        #endregion

        #region [Gestión Usuarios]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Usuario> Usuario_RecuperarFiltros(Dto.Usuario objFiltros)
        {
            return new Business.BUsuario().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idusuario"></param>
        /// <returns></returns>
        public bool Usuario_Insertar(Dto.Usuario obj, out short? idusuario)
        {
            bool blnRespuesta = new Business.BUsuario().Crear(obj);

            if (blnRespuesta)
                idusuario = obj.idusuario;
            else
                idusuario = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_Actualizar(Dto.Usuario obj)
        {
            return new Business.BUsuario().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_Eliminar(Dto.Usuario obj)
        {
            return new Business.BUsuario().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_RestablecerClave(Dto.Usuario obj)
        {
            return new Business.BUsuario().RestablecerClave(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_CambiarClave(Dto.Usuario obj)
        {
            return new Business.BUsuario().CambiarClave(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Usuario_ValidaNombreUsuario(Dto.Usuario obj)
        {
            return new Business.BUsuario().ValidaNombreUsuario(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public Dto.Sesion Usuario_IniciarSesion(Dto.Usuario obj)
        {
            return new Business.BUsuario().IniciarSesion(obj);
        }
        #endregion

        #region [Gestión Maquinas]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Maquina> Maquina_RecuperarFiltros(Dto.Maquina objFiltros)
        {
            return new Business.BMaquina().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idmaquina"></param>
        /// <returns></returns>
        public bool Maquina_Insertar(Dto.Maquina obj, out short? idmaquina)
        {
            bool blnRespuesta = new Business.BMaquina().Crear(obj);

            if (blnRespuesta)
                idmaquina = obj.idmaquina;
            else
                idmaquina = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_Actualizar(Dto.Maquina obj)
        {
            return new Business.BMaquina().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_Eliminar(Dto.Maquina obj)
        {
            return new Business.BMaquina().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Maquina_ValidaCodigo(Dto.Maquina obj)
        {
            return new Business.BMaquina().ValidaCodigo(obj);
        }
        #endregion

        #region [Gestión Asesores]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Asesor> Asesor_RecuperarFiltros(Dto.Asesor objFiltros)
        {
            return new Business.BAsesor().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idasesor"></param>
        /// <returns></returns>
        public bool Asesor_Insertar(Dto.Asesor obj, out byte? idasesor)
        {
            bool blnRespuesta = new Business.BAsesor().Crear(obj);

            if (blnRespuesta)
                idasesor = obj.idasesor;
            else
                idasesor = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_Actualizar(Dto.Asesor obj)
        {
            return new Business.BAsesor().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_Eliminar(Dto.Asesor obj)
        {
            return new Business.BAsesor().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Asesor_ValidaCodigo(Dto.Asesor obj)
        {
            return new Business.BAsesor().ValidaCodigo(obj);
        }
        #endregion

        #region [Funcionalidad]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Funcionalidad> Funcionalidad_RecuperarFiltros(Dto.Funcionalidad objFiltros)
        {
            return new Business.BFuncionalidad().RecuperarFiltrado(objFiltros);
        }

        #endregion

        #region [Periodos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Periodo> Periodo_RecuperarFiltros(Dto.Periodo objFiltros)
        {
            return new Business.BPeriodo().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idperiodo"></param>
        /// <returns></returns>
        public bool Periodo_Insertar(Dto.Periodo obj, out int? idperiodo)
        {
            bool blnRespuesta = new Business.BPeriodo().Crear(obj);

            if (blnRespuesta)
                idperiodo = obj.idPeriodo;
            else
                idperiodo = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Periodo_Actualizar(Dto.Periodo obj)
        {
            return new Business.BPeriodo().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Periodo_Eliminar(Dto.Periodo obj)
        {
            return new Business.BPeriodo().Eliminar(obj);
        }
        #endregion

        #region [Clientes]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Cliente> Cliente_RecuperarFiltros(Dto.Cliente objFiltros)
        {
            return new Business.BCliente().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idcliente"></param>
        /// <returns></returns>
        public bool Cliente_Insertar(Dto.Cliente obj, out int? idcliente)
        {
            bool blnRespuesta = new Business.BCliente().Crear(obj);

            if (blnRespuesta)
                idcliente = obj.idcliente;
            else
                idcliente = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cliente_Actualizar(Dto.Cliente obj)
        {
            return new Business.BCliente().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cliente_Eliminar(Dto.Cliente obj)
        {
            return new Business.BCliente().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Cliente_ValidaNombre(Dto.Cliente obj)
        {
            return new Business.BCliente().ValidaNombre(obj);
        }
        #endregion

        #region [Espectros]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Espectro> Espectro_RecuperarFiltros(Dto.Espectro objFiltros)
        {
            return new Business.BEspectro().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idespectro"></param>
        /// <returns></returns>
        public bool Espectro_Insertar(Dto.Espectro obj, out int? idespectro)
        {
            bool blnRespuesta = new Business.BEspectro().Crear(obj);

            if (blnRespuesta)
                idespectro = obj.idespectro;
            else
                idespectro = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Espectro_Actualizar(Dto.Espectro obj)
        {
            return new Business.BEspectro().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Espectro_Eliminar(Dto.Espectro obj)
        {
            return new Business.BEspectro().Eliminar(obj);
        }
        #endregion

        #region [Pantones]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Pantone> Pantone_RecuperarFiltros(Dto.Pantone objFiltros)
        {
            return new Business.BPantone().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idpantone"></param>
        /// <returns></returns>
        public bool Pantone_Insertar(Dto.Pantone obj, out int? idpantone)
        {
            bool blnRespuesta = new Business.BPantone().Crear(obj);

            if (blnRespuesta)
                idpantone = obj.idpantone;
            else
                idpantone = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_Actualizar(Dto.Pantone obj)
        {
            return new Business.BPantone().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_Eliminar(Dto.Pantone obj)
        {
            return new Business.BPantone().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_ValidaColor(Dto.Pantone obj)
        {
            return new Business.BPantone().ValidaColor(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Pantone_ValidaNombre(Dto.Pantone obj)
        {
            return new Business.BPantone().ValidaNombre(obj);
        }
        #endregion

        #region [Troqueles]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Troquel> Troquel_RecuperarFiltros(Dto.Troquel objFiltros)
        {
            return new Business.BTroquel().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="idtroquel"></param>
        /// <returns></returns>
        public bool Troquel_Insertar(Dto.Troquel obj, out int? idtroquel)
        {
            bool blnRespuesta = new Business.BTroquel().Crear(obj);

            if (blnRespuesta)
                idtroquel = obj.idtroquel;
            else
                idtroquel = null;

            return blnRespuesta;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Troquel_Actualizar(Dto.Troquel obj)
        {
            return new Business.BTroquel().Actualizar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Troquel_Eliminar(Dto.Troquel obj)
        {
            return new Business.BTroquel().Eliminar(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Troquel_ValidaCodigo(Dto.Troquel obj)
        {
            return new Business.BTroquel().ValidaCodigo(obj);
        }
        #endregion

        #region [Municipios]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Municipio> Municipio_RecuperarFiltros(Dto.Municipio objFiltros)
        {
            return new Business.BMunicipio().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Municipio_Insertar(Dto.Municipio obj)
        {
            return new Business.BMunicipio().Crear(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Municipio_ValidaId(Dto.Municipio obj)
        {
            return new Business.BMunicipio().ValidaId(obj);
        }
        #endregion

        #region [Departamentos]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objFiltros"></param>
        /// <returns></returns>
        public IEnumerable<Dto.Departamento> Departamento_RecuperarFiltros(Dto.Departamento objFiltros)
        {
            return new Business.BDepartamento().RecuperarFiltrado(objFiltros);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Departamento_Insertar(Dto.Departamento obj)
        {
            return new Business.BDepartamento().Crear(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Departamento_ValidaId(Dto.Departamento obj)
        {
            return new Business.BDepartamento().ValidaId(obj);
        }
        #endregion

    }
}
