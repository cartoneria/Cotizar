using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DPantone : ParentData<Dto.Pantone>
    {
        #region [Constructores]
        public DPantone()
            : base()
        {

        }

        public DPantone(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Pantone obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidpantone", obj.idpantone),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("strhex", obj.hex),
                new MySql.Data.MySqlClient.MySqlParameter("intr", obj.r),
                new MySql.Data.MySqlClient.MySqlParameter("intg", obj.g),
                new MySql.Data.MySqlClient.MySqlParameter("intb", obj.b),
            });
        }

        public override IEnumerable<Dto.Pantone> RecuperarFiltrados(Dto.Pantone obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionPantones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Pantone>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Pantone obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionPantones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idpantone = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idpantone > 0;
            }
        }

        public override bool Insertar(Dto.Pantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Pantone obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionPantones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Actualizar(Dto.Pantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Pantone obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionPantones";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Pantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
