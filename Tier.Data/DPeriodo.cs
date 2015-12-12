using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DPeriodo : ParentData<Dto.Periodo>
    {
        #region [Constructores]
        public DPeriodo()
            : base()
        {

        }

        public DPeriodo(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Periodo obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidPeriodo", obj.idPeriodo),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("datfechainicio", obj.fechainicio),
                new MySql.Data.MySqlClient.MySqlParameter("datfechafin", obj.fechafin),
                new MySql.Data.MySqlClient.MySqlParameter("blnvigente", obj.vigente),
                new MySql.Data.MySqlClient.MySqlParameter("intempresa_idempresa", obj.empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("intimpuestoicacree", obj.impuestoicacree),
                new MySql.Data.MySqlClient.MySqlParameter("intporcenfinanciacion", obj.porcenfinanciacion),
                new MySql.Data.MySqlClient.MySqlParameter("intporcenalzageneral", obj.porcenalzageneral),
                new MySql.Data.MySqlClient.MySqlParameter("intgasto", obj.gasto),            
                new MySql.Data.MySqlClient.MySqlParameter("intutilidad", obj.utilidad),
            });
        }

        public override IEnumerable<Dto.Periodo> RecuperarFiltrados(Dto.Periodo obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionPeriodos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Periodo>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Periodo obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "seguridad.uspGestionPeriodos";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                        this.CargarParametros(cmd, obj);

                        obj.idPeriodo = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd, trans));

                        if (obj.idPeriodo > 0)
                        {
                            foreach (var item in obj.centros)
                            {
                                item.periodo_idPeriodo = obj.idPeriodo;
                            }

                            foreach (var item in obj.parametros)
                            {
                                item.periodo_idPeriodo = obj.idPeriodo;
                            }

                            //Guardamos los datos periodicos de las maquinas
                            DMaquinaDatosPeriodicos objDALDatPeriodicos = new DMaquinaDatosPeriodicos();
                            objDALDatPeriodicos.Insertar(obj.centros, trans);

                            //Guardamos los parametros
                            DParametro objDALParametros = new DParametro();
                            objDALParametros.Insertar(obj.parametros, trans);

                            trans.Commit();
                        }

                        return obj.idPeriodo > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Insertar(Dto.Periodo obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Periodo obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "seguridad.uspGestionPeriodos";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        if (intRegistrosAfectados > 0)
                        {
                            foreach (var item in obj.centros)
                            {
                                item.periodo_idPeriodo = obj.idPeriodo;
                            }

                            foreach (var item in obj.parametros)
                            {
                                item.periodo_idPeriodo = obj.idPeriodo;
                            }

                            //Guardamos los datos periodicos de las maquinas
                            DMaquinaDatosPeriodicos objDALDatPeriodicos = new DMaquinaDatosPeriodicos();
                            objDALDatPeriodicos.Insertar(obj.centros, trans);

                            //Guardamos los parametros
                            DParametro objDALParametros = new DParametro();
                            objDALParametros.Insertar(obj.parametros, trans);

                            trans.Commit();
                        }

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

        public override bool Actualizar(Dto.Periodo obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Periodo obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionPeriodos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Periodo obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionPeriodos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
