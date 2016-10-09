using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DCartera : ParentData<Dto.Cartera>
    {
        #region [Constructores]
        public DCartera()
            : base()
        {

        }

        public DCartera(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Cartera obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intcliente_idcliente", obj.cliente_idcliente),
                new MySql.Data.MySqlClient.MySqlParameter("intasesor_idasesor", obj.asesor_idasesor),
                new MySql.Data.MySqlClient.MySqlParameter("strcuenta", obj.cuenta),
                new MySql.Data.MySqlClient.MySqlParameter("strdocumento", obj.documento),
                new MySql.Data.MySqlClient.MySqlParameter("intconsecutivo", obj.consecutivo),
                new MySql.Data.MySqlClient.MySqlParameter("datfecha", obj.fecha),
                new MySql.Data.MySqlClient.MySqlParameter("datvencimiento", obj.vencimiento),
                new MySql.Data.MySqlClient.MySqlParameter("intvalormora", obj.valormora),
                new MySql.Data.MySqlClient.MySqlParameter("intvalorsaldo", obj.valorsaldo),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacracion", obj.fechacracion),
            });
        }

        public override IEnumerable<Dto.Cartera> RecuperarFiltrados(Dto.Cartera obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCartera";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Cartera>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Cartera obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Cartera obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCartera";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return intRegistrosAfectados > 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public bool ActualizarCarteraLote(IEnumerable<Dto.Cartera> lst)
        {
            bool blnResult = true;

            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "delete from comercial_cartera;";
                        cmd.CommandType = System.Data.CommandType.Text;
                        int intRegistrosAfectados = Convert.ToInt32(base.CurrentDatabase.ExecuteNonQuery(cmd, trans));
                    }

                    foreach (Dto.Cartera item in lst)
                    {
                        blnResult = this.Insertar(item, trans);
                        if (!blnResult)
                        {
                            break;
                        }
                    }

                    if (blnResult)
                    {
                        trans.Commit();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Actualizar(Dto.Cartera obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCartera";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Actualizar(Dto.Cartera obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Cartera obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCartera";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Cartera obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
