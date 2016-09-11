using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DTroquel : ParentData<Dto.Troquel>
    {
        #region [Constructores]
        public DTroquel()
            : base()
        {

        }

        public DTroquel(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Troquel obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidtroquel", obj.idtroquel),
                new MySql.Data.MySqlClient.MySqlParameter("strdescripcion", obj.descripcion),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_material", obj.itemlista_iditemlista_material),
                new MySql.Data.MySqlClient.MySqlParameter("strtamanio", obj.tamanio),
                new MySql.Data.MySqlClient.MySqlParameter("intlargo", obj.largo),
                new MySql.Data.MySqlClient.MySqlParameter("intancho", obj.ancho),
                new MySql.Data.MySqlClient.MySqlParameter("intalto", obj.alto),
                new MySql.Data.MySqlClient.MySqlParameter("intfibra", obj.fibra),
                new MySql.Data.MySqlClient.MySqlParameter("intcontrafibra", obj.contrafibra),
                new MySql.Data.MySqlClient.MySqlParameter("intcabidafibra", obj.cabidafibra),
                new MySql.Data.MySqlClient.MySqlParameter("intcabidacontrafibra", obj.cabidacontrafibra),
                new MySql.Data.MySqlClient.MySqlParameter("strubicacion", obj.ubicacion),
                new MySql.Data.MySqlClient.MySqlParameter("strmarca", obj.marca),
                new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("intempresa_idempresa", obj.empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("intestilo_idestilo", obj.estilo_idestilo),
            });
        }

        public override IEnumerable<Dto.Troquel> RecuperarFiltrados(Dto.Troquel obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionTroqueles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Troquel>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Troquel obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "produccion.uspGestionTroqueles";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                        this.CargarParametros(cmd, obj);

                        obj.idtroquel = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, trans));

                        if (obj.idtroquel > 0)
                        {
                            obj.AsignarIdentificador();

                            //Gardamos las ventanas
                            DTroquelVentana objDALVentanas = new DTroquelVentana();
                            objDALVentanas.Insertar(obj.ventanas, trans);

                            trans.Commit();
                        }

                        return obj.idtroquel > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Insertar(Dto.Troquel obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Troquel obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "produccion.uspGestionTroqueles";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        if (intRegistrosAfectados > 0)
                        {
                            obj.AsignarIdentificador();

                            //Gardamos las ventanas
                            DTroquelVentana objDALVentanas = new DTroquelVentana();
                            objDALVentanas.Insertar(obj.ventanas, trans);

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

        public override bool Actualizar(Dto.Troquel obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Troquel obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionTroqueles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Troquel obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionTroqueles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
