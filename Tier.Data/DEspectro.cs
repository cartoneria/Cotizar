using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DEspectro : ParentData<Dto.Espectro>
    {
        #region [Constructores]
        public DEspectro()
            : base()
        {

        }

        public DEspectro(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Espectro obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidespectro", obj.idespectro),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
            });
        }

        public override IEnumerable<Dto.Espectro> RecuperarFiltrados(Dto.Espectro obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionEspectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Espectro>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Espectro obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionEspectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idespectro = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idespectro > 0;
            }
        }

        public override bool Insertar(Dto.Espectro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Espectro obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "produccion.uspGestionEspectros";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        //Guardamos las variaciones
                        DEspectroPantone objDALEP = new DEspectroPantone();
                        objDALEP.Insertar(obj.pantones, (int)obj.idespectro, trans);

                        trans.Commit();

                        return intRegistrosAfectados > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Actualizar(Dto.Espectro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Espectro obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionEspectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Espectro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
