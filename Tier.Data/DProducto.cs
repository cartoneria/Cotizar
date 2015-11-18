using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DProducto : ParentData<Dto.Producto>
    {
        #region [Constructores]
        public DProducto()
            : base()
        {

        }

        public DProducto(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Producto obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] { 
                    new MySql.Data.MySqlClient.MySqlParameter("intidproducto", obj.idproducto),
                    new MySql.Data.MySqlClient.MySqlParameter("intcliente_idcliente", obj.cliente_idcliente),
                    new MySql.Data.MySqlClient.MySqlParameter("inttroquel_idtroquel", obj.troquel_idtroquel),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_material", obj.insumo_idinsumo_material),
                    new MySql.Data.MySqlClient.MySqlParameter("intlargobobina", obj.largobobina),
                    new MySql.Data.MySqlClient.MySqlParameter("intcabidaancho", obj.cabidaancho),
                    new MySql.Data.MySqlClient.MySqlParameter("intcabidalargo", obj.cabidalargo),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_acetato", obj.insumo_idinsumo_acetato),
                    new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_acabadoderecho", obj.itemlista_iditemlista_acabadoderecho),
                    new MySql.Data.MySqlClient.MySqlParameter("intanchomaquina_acabadoderecho", obj.anchomaquina_acabadoderecho),
                    new MySql.Data.MySqlClient.MySqlParameter("intrecorrido_acabadoderecho", obj.recorrido_acabadoderecho),
                    new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_acabadoreverso", obj.itemlista_iditemlista_acabadoreverso),
                    new MySql.Data.MySqlClient.MySqlParameter("intanchomaquina_acabadoreverso", obj.anchomaquina_acabadoreverso),
                    new MySql.Data.MySqlClient.MySqlParameter("intrecorrido_acabadoreverso", obj.recorrido_acabadoreverso),
                    new MySql.Data.MySqlClient.MySqlParameter("strposicionplanchas", obj.posicionplanchas),
                    new MySql.Data.MySqlClient.MySqlParameter("intpasadaslitograficas", obj.pasadaslitograficas),
                    new MySql.Data.MySqlClient.MySqlParameter("strreferenciacliente", obj.referenciacliente),
                    new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquina_idmaquina_peque", obj.maquina_idmaquina_peque),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_reempaque", obj.insumo_idinsumo_reempaque),
                    new MySql.Data.MySqlClient.MySqlParameter("intfactorprecio", obj.factorprecio),
                    new MySql.Data.MySqlClient.MySqlParameter("intcatidadpredeterminada", obj.catidadpredeterminada),
                    new MySql.Data.MySqlClient.MySqlParameter("intpreciopredeterminado", obj.preciopredeterminado),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_colaminado", obj.insumo_idinsumo_colaminado),
                    new MySql.Data.MySqlClient.MySqlParameter("intcolaminadoancho", obj.colaminadoancho),
                    new MySql.Data.MySqlClient.MySqlParameter("intcolaminadoalargo", obj.colaminadoalargo),
                    new MySql.Data.MySqlClient.MySqlParameter("intcolaminadocabidalargo", obj.colaminadocabidalargo),
                    new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                    new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                    new MySql.Data.MySqlClient.MySqlParameter("strimagenartegrafico", obj.imagenartegrafico),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_materialpegue", obj.insumo_idinsumo_materialpegue),
                    new MySql.Data.MySqlClient.MySqlParameter("intrecorrigopegue", obj.recorrigopegue),
                });
        }

        public override IEnumerable<Dto.Producto> RecuperarFiltrados(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Producto>(reader);
                }

            }
        }

        public override bool Insertar(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "produccion.uspGestionProductos";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                        this.CargarParametros(cmd, obj);

                        obj.idproducto = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd, trans));

                        if (obj.idproducto > 0)
                        {
                            //Guardamos las pantones
                            //DMaquinaVariacionesProduccion objDALVariaciones = new DMaquinaVariacionesProduccion();
                            //objDALVariaciones.Insertar(obj.VariacionesProduccion, trans);

                            //Guardamos los accesorios
                            //DMaquinaDatosPeriodicos objDALDatPeriodicos = new DMaquinaDatosPeriodicos();
                            //objDALDatPeriodicos.Insertar(obj.DatosPeriodicos, trans);

                            trans.Commit();
                        }

                        return obj.idproducto > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Insertar(Dto.Producto obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "produccion.uspGestionProductos";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        if (intRegistrosAfectados > 0)
                        {
                            //Guardamos las pantones
                            //DMaquinaVariacionesProduccion objDALVariaciones = new DMaquinaVariacionesProduccion();
                            //objDALVariaciones.Insertar(obj.VariacionesProduccion, trans);

                            //Guardamos los accesorios
                            //DMaquinaDatosPeriodicos objDALDatPeriodicos = new DMaquinaDatosPeriodicos();
                            //objDALDatPeriodicos.Insertar(obj.DatosPeriodicos, trans);

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

        public override bool Actualizar(Dto.Producto obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Producto obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
