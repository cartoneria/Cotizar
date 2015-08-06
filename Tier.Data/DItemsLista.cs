using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DItemsLista : ParentData<Dto.ItemLista>
    {
        #region [Constructores]
        public DItemsLista()
            : base()
        {

        }

        public DItemsLista(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ItemLista obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intiditemlista", obj.iditemlista),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("intgrupo", obj.grupo),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("intidpadre", obj.idpadre)
            });
        }

        public override IEnumerable<Dto.ItemLista> RecuperarFiltrados(Dto.ItemLista obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "general.uspGestionItemsListas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        yield return new Dto.ItemLista()
                        {
                            activo = reader.GetBoolean(reader.GetOrdinal("activo")),
                            grupo = reader.GetByte(reader.GetOrdinal("grupo")),
                            iditemlista = reader.GetInt32(reader.GetOrdinal("iditemlista")),
                            idpadre = reader[reader.GetOrdinal("idpadre")] != DBNull.Value ? reader.GetInt32(reader.GetOrdinal("idpadre")) : new Nullable<int>(),
                            nombre = reader.GetString(reader.GetOrdinal("nombre"))
                        };
                    }
                }
            }
        }

        public override bool Insertar(Dto.ItemLista obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.ItemLista obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ItemLista obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ItemLista obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.ItemLista obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.ItemLista obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
