using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DCotizacion : ParentData<Dto.Cotizacion>
    {
        #region [Constructores]
        public DCotizacion()
            : base()
        {

        }

        public DCotizacion(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Cotizacion obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidcotizacion", obj.idcotizacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("intcliente_idcliente", obj.cliente_idcliente),
                new MySql.Data.MySqlClient.MySqlParameter("intperiodo_idPeriodo", obj.periodo_idPeriodo),
                new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
                new MySql.Data.MySqlClient.MySqlParameter("intcostosplancha", obj.costosplancha),
                new MySql.Data.MySqlClient.MySqlParameter("intcostostroqueles", obj.costostroqueles),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_estado", obj.itemlista_iditemlista_estado),
            });
        }

        public override IEnumerable<Dto.Cotizacion> RecuperarFiltrados(Dto.Cotizacion obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionCotizacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Cotizacion>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Cotizacion obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "comercial.uspGestionCotizacion";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                        this.CargarParametros(cmd, obj);

                        obj.idcotizacion = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, trans));

                        if (obj.idcotizacion > 0)
                        {
                            //Guardamos el detalle de la cotizacìón
                            DCotizacionDetalle objDALDetalle = new DCotizacionDetalle();
                            objDALDetalle.Insertar(obj.detalle, trans);

                            trans.Commit();
                        }

                        return obj.idcotizacion > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Insertar(Dto.Cotizacion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Cotizacion obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "comercial.uspGestionCotizacion";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        if (intRegistrosAfectados > 0)
                        {
                            //Guardamos el detalle
                            DCotizacionDetalle objDALDetalle = new DCotizacionDetalle();
                            objDALDetalle.Insertar(obj.detalle, trans);

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

        public override bool Actualizar(Dto.Cotizacion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Cotizacion obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionCotizacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Cotizacion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionCotizacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public Dto.CotizacionDetalle Cotizar(int idproducto, int idperiodo, int escala, int idinsumoflete)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspCotizacionCotizar";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.CotizacionCotizar));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intidproducto", idproducto));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intidperiodo", idperiodo));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intescala", escala));
                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intidinsumoflete", idinsumoflete));

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.CotizacionDetalle>(reader).FirstOrDefault();
                }
            }
        }
    }
}
