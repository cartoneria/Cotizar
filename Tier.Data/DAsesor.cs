using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DAsesor : ParentData<Dto.Asesor>
    {
        #region [Constructores]
        public DAsesor()
            : base()
        {

        }

        public DAsesor(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Asesor obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidasesor", obj.idasesor),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("intcomision", obj.comision),
                new MySql.Data.MySqlClient.MySqlParameter("strtelefono", obj.telefono),
                new MySql.Data.MySqlClient.MySqlParameter("strcorreoelectronico", obj.correoelectronico),
                new MySql.Data.MySqlClient.MySqlParameter("strcodigo", obj.codigo),
                new MySql.Data.MySqlClient.MySqlParameter("intempresa_idempresa", obj.empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
            });
        }

        public override IEnumerable<Dto.Asesor> RecuperarFiltrados(Dto.Asesor obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionAsesores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        yield return new Dto.Asesor()
                        {
                            activo = reader.GetBoolean(reader.GetOrdinal("activo")),
                            codigo = reader.GetString(reader.GetOrdinal("codigo")),
                            comision = reader[reader.GetOrdinal("comision")] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("comision")) : new Nullable<decimal>(),
                            correoelectronico = reader[reader.GetOrdinal("correoelectronico")] != DBNull.Value ? reader.GetString(reader.GetOrdinal("correoelectronico")) : string.Empty,
                            empresa_idempresa = reader.GetByte(reader.GetOrdinal("empresa_idempresa")),
                            fechacreacion = reader.GetDateTime(reader.GetOrdinal("fechacreacion")),
                            idasesor = reader.GetByte(reader.GetOrdinal("idasesor")),
                            nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            telefono = reader[reader.GetOrdinal("telefono")] != DBNull.Value ? reader.GetString(reader.GetOrdinal("telefono")) : string.Empty
                        };
                    }
                }
            }
        }

        public override bool Insertar(Dto.Asesor obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionAsesores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idasesor = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idasesor > 0;
            }
        }

        public override bool Insertar(Dto.Asesor obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Asesor obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionAsesores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Actualizar(Dto.Asesor obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Asesor obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionAsesores";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Asesor obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
