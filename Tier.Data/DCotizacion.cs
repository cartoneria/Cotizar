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
                cmd.CommandText = "uspGestionCotizacion";
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
                        cmd.CommandText = "uspGestionCotizacion";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                        this.CargarParametros(cmd, obj);

                        obj.idcotizacion = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, trans));

                        if (obj.idcotizacion > 0)
                        {
                            obj.AsignarIdentificador();

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
                        cmd.CommandText = "uspGestionCotizacion";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        if (intRegistrosAfectados > 0)
                        {
                            obj.AsignarIdentificador();

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
                cmd.CommandText = "uspGestionCotizacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                byte intRegistrosAfectados = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Cotizacion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCotizacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idproducto"></param>
        /// <param name="idperiodo"></param>
        /// <param name="escala"></param>
        /// <param name="idinsumoflete"></param>
        /// <returns></returns>
        public Dto.CotizacionDetalle Cotizar(int idproducto, int idperiodo, int escala, int idinsumoflete)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspCotizacionCotizar";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCotizacion"></param>
        /// <returns></returns>
        public Dto.ReporteCotizacion RecuperarDatosReporteCotizacion(int idCotizacion)
        {
            Dto.ReporteCotizacion objResultado = new Dto.ReporteCotizacion();

            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCotizacion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarDatosReporteCotizacion));
                this.CargarParametros(cmd, new Dto.Cotizacion() { idcotizacion = idCotizacion });

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    this.ReporteCotinzacionCargarDatosEncabezado(objResultado, reader);
                    reader.NextResult();
                    List<Dto.ReporteCotizacionProductos> lstproductos = new List<Dto.ReporteCotizacionProductos>();
                    this.ReporteCotizacionCargarDatosProductos(reader, lstproductos);
                    reader.NextResult();
                    List<Dto.ReporteCotizacionValores> lstvalores = new List<Dto.ReporteCotizacionValores>();
                    this.ReporteCotizacionCargarDatosEscalaValores(reader, lstvalores);

                    objResultado.productos = lstproductos;
                    objResultado.valores = lstvalores;
                }
            }

            return objResultado;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="lstvalores"></param>
        private void ReporteCotizacionCargarDatosEscalaValores(IDataReader reader, List<Dto.ReporteCotizacionValores> lstvalores)
        {
            while (reader.Read())
            {
                lstvalores.Add(new Dto.ReporteCotizacionValores()
                {
                    escala = reader.GetInt16(reader.GetOrdinal("escala")),
                    costonetocaja = reader.GetFloat(reader.GetOrdinal("costonetocaja")),
                    producto_idproducto = reader.GetInt32(reader.GetOrdinal("producto_idproducto")),
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        /// <param name="lstproductos"></param>
        private void ReporteCotizacionCargarDatosProductos(IDataReader reader, List<Dto.ReporteCotizacionProductos> lstproductos)
        {
            while (reader.Read())
            {
                lstproductos.Add(new Dto.ReporteCotizacionProductos()
                {
                    idProducto = reader.GetInt32(reader.GetOrdinal("idProducto")),
                    referenciaCliente = reader.GetString(reader.GetOrdinal("referenciaCliente")),
                    descMaterialCaja = reader["descMaterialCaja"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("descMaterialCaja")) : string.Empty,
                    codMaterialCaja = reader["codMaterialCaja"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("codMaterialCaja")) : string.Empty,
                    cantTintasDerecho = reader["cantTintasDerecho"] != DBNull.Value ? reader.GetByte(reader.GetOrdinal("cantTintasDerecho")) : (byte)0,
                    cantTintasReverso = reader["cantTintasReverso"] != DBNull.Value ? reader.GetByte(reader.GetOrdinal("cantTintasReverso")) : (byte)0,
                    descPantones = reader["descPantones"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("descPantones")) : string.Empty,
                    largo = reader["largo"] != DBNull.Value ? reader.GetFloat(reader.GetOrdinal("largo")) : new Nullable<Single>(),
                    ancho = reader["ancho"] != DBNull.Value ? reader.GetFloat(reader.GetOrdinal("ancho")) : new Nullable<Single>(),
                    alto = reader["alto"] != DBNull.Value ? reader.GetFloat(reader.GetOrdinal("alto")) : new Nullable<Single>(),
                    cantVentanas = reader.GetByte(reader.GetOrdinal("cantVentanas")),
                    descAcabadoDerecho = reader["descAcabadoDerecho"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("descAcabadoDerecho")) : string.Empty,
                    descAcabadoReverso = reader["descAcabadoReverso"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("descAcabadoReverso")) : string.Empty,
                    descAccesorios = reader["descAccesorios"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("descAccesorios")) : string.Empty,
                    codEstilo = reader["codEstilo"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("codEstilo")) : string.Empty,
                    codTroquel = reader["codTroquel"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("codTroquel")) : string.Empty,
                    productoNuevo = reader.GetBoolean(reader.GetOrdinal("productoNuevo")),
                });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objResultado"></param>
        /// <param name="reader"></param>
        private void ReporteCotinzacionCargarDatosEncabezado(Dto.ReporteCotizacion objResultado, IDataReader reader)
        {
            while (reader.Read())
            {
                objResultado.clienteRazonSocial = reader.GetString(reader.GetOrdinal("clienteRazonSocial"));
                objResultado.fechaCotizacion = reader.GetDateTime(reader.GetOrdinal("fechaCotizacion"));
                objResultado.clienteContactoDireccion = reader["clienteContactoDireccion"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("clienteContactoDireccion")) : string.Empty;
                objResultado.clienteContactoCiudad = reader["clienteContactoCiudad"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("clienteContactoCiudad")) : string.Empty;
                objResultado.observacionesCotizacion = reader["observacionesCotizacion"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("observacionesCotizacion")) : string.Empty;
                objResultado.costosplanchaCotizacion = reader.GetFloat(reader.GetOrdinal("costosplanchaCotizacion"));
                objResultado.costostroquelesCotizacion = reader.GetFloat(reader.GetOrdinal("costostroquelesCotizacion"));
                objResultado.clienteContactos = reader["clienteContactos"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("clienteContactos")) : string.Empty;
                objResultado.idCotizacion = reader.GetInt32(reader.GetOrdinal("idCotizacion"));
            }
        }
    }
}
