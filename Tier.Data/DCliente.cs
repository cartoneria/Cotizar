using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DCliente : ParentData<Dto.Cliente>
    {
        #region [Constructores]
        public DCliente()
            : base()
        {

        }

        public DCliente(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Cliente obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidcliente", obj.idcliente),
                new MySql.Data.MySqlClient.MySqlParameter("stridentificacion", obj.identificacion),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_tipoidenti", obj.itemlista_iditemlista_tipoidenti),
                new MySql.Data.MySqlClient.MySqlParameter("strdireccion", obj.direccion),
                new MySql.Data.MySqlClient.MySqlParameter("strmunicipio_idmunicipio", obj.municipio_idmunicipio),
                new MySql.Data.MySqlClient.MySqlParameter("strmunicipio_departamento_iddepartamento", obj.municipio_departamento_iddepartamento),
                new MySql.Data.MySqlClient.MySqlParameter("strtelefono", obj.telefono),
                new MySql.Data.MySqlClient.MySqlParameter("stremail", obj.email),
                new MySql.Data.MySqlClient.MySqlParameter("intdiasplazo", obj.diasplazo),
                new MySql.Data.MySqlClient.MySqlParameter("intcupocredito", obj.cupocredito),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_regimen", obj.itemlista_iditemlista_regimen),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_formapago", obj.itemlista_iditemlista_formapago),
                new MySql.Data.MySqlClient.MySqlParameter("strcontactos", obj.contactos),
                new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
            });
        }

        public override IEnumerable<Dto.Cliente> RecuperarFiltrados(Dto.Cliente obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionDepartamentos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Cliente>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Cliente obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Cliente obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Cliente obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Cliente obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Cliente obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Cliente obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
