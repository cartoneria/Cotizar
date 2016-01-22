using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DParametro : ParentData<Dto.Parametro>
    {
        #region [Constructores]
        public DParametro()
            : base()
        {

        }

        public DParametro(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Parametro obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidparametro", obj.idparametro),
                new MySql.Data.MySqlClient.MySqlParameter("intperiodo_idPeriodo", obj.periodo_idPeriodo),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("inttipo", obj.tipo),
                new MySql.Data.MySqlClient.MySqlParameter("strvalortexto", obj.valortexto),
                new MySql.Data.MySqlClient.MySqlParameter("intvalornumero", obj.valornumero),
                new MySql.Data.MySqlClient.MySqlParameter("datvalorfecha", obj.valorfecha),
                new MySql.Data.MySqlClient.MySqlParameter("blnvalorboleano", obj.valorboleano),
            });

        }

        public override IEnumerable<Dto.Parametro> RecuperarFiltrados(Dto.Parametro obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionParametros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Parametro>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Parametro obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Parametro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionParametros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idparametro = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idparametro > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.Parametro> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            foreach (Dto.Parametro item in obj)
            {
                if (item.idparametro == null)
                {
                    this.Insertar(item, objTrans);
                }
                else
                {
                    this.Actualizar(item, objTrans);
                }
            }
        }

        public override bool Actualizar(Dto.Parametro obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Parametro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionParametros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Parametro obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionParametros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Parametro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionParametros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
