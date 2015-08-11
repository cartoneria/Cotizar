﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DMaquina : ParentData<Dto.Maquina>
    {
        #region [Constructores]
        public DMaquina()
            : base()
        {

        }

        public DMaquina(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Maquina obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidmaquina", obj.idmaquina),
                new MySql.Data.MySqlClient.MySqlParameter("strcodigo", obj.codigo),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("strdescripcion", obj.descripcion),
                new MySql.Data.MySqlClient.MySqlParameter("intlargomax", obj.largomax),
                new MySql.Data.MySqlClient.MySqlParameter("intlargomin", obj.largomin),
                new MySql.Data.MySqlClient.MySqlParameter("intanchomax", obj.anchomax),
                new MySql.Data.MySqlClient.MySqlParameter("intanchomin", obj.anchomin),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("intempresa_idempresa", obj.empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlistas_tipo", obj.itemlista_iditemlistas_tipo),
            });
        }

        public override IEnumerable<Dto.Maquina> RecuperarFiltrados(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        yield return new Dto.Maquina()
                        {
                            activo = reader.GetBoolean(reader.GetOrdinal("activo")),
                            anchomax = reader[reader.GetOrdinal("anchomax")] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("anchomax")) : new Nullable<decimal>(),
                            anchomin = reader[reader.GetOrdinal("anchomin")] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("anchomin")) : new Nullable<decimal>(),
                            codigo = reader.GetString(reader.GetOrdinal("codigo")),
                            descripcion = reader[reader.GetOrdinal("descripcion")] != DBNull.Value ? reader.GetString(reader.GetOrdinal("descripcion")) : null,
                            empresa_idempresa = reader.GetByte(reader.GetOrdinal("empresa_idempresa")),
                            fechacreacion = reader.GetDateTime(reader.GetOrdinal("fechacreacion")),
                            idmaquina = reader.GetInt16(reader.GetOrdinal("idmaquina")),
                            itemlista_iditemlistas_tipo = reader.GetInt32(reader.GetOrdinal("itemlista_iditemlistas_tipo")),
                            largomax = reader[reader.GetOrdinal("largomax")] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("largomax")) : new Nullable<decimal>(),
                            largomin = reader[reader.GetOrdinal("largomin")] != DBNull.Value ? reader.GetDecimal(reader.GetOrdinal("largomin")) : new Nullable<decimal>(),
                            nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        };
                    }
                }
            }
        }

        public override bool Insertar(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idmaquina = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idmaquina > 0;
            }
        }

        public override bool Insertar(Dto.Maquina obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Actualizar(Dto.Maquina obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Maquina obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
