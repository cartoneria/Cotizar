using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Tier.Data
{
    public class DRol : ParentData<Dto.Rol>
    {
        #region [Constructores]
        public DRol()
            : base()
        {

        }

        public DRol(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Rol obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] { 
                    new MySql.Data.MySqlClient.MySqlParameter("intidrol", obj.idrol),
                    new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                    new MySql.Data.MySqlClient.MySqlParameter("strdescripcion", obj.descripcion),
                    new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                    new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion)
                });
        }

        public override IEnumerable<Dto.Rol> RecuperarFiltrados(Dto.Rol obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionRoles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Rol>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Rol obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "seguridad.uspGestionRoles";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                        this.CargarParametros(cmd, obj);

                        obj.idrol = Convert.ToInt16(base.CurrentDatabase.ExecuteScalar(cmd, trans));

                        //Guardamos los permisos
                        DPermiso objDALPermisos = new DPermiso();
                        objDALPermisos.Insertar(obj.permisos, trans);

                        trans.Commit();

                        return obj.idrol > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Insertar(Dto.Rol obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Rol obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection())
            {
                cnn.ConnectionString = base.CurrentConnectionString.ConnectionString;
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "seguridad.uspGestionRoles";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        if (intRegistrosAfectados > 0)
                        {
                            //Guardamos los permisos
                            DPermiso objDALPermisos = new DPermiso();
                            objDALPermisos.Insertar(obj.permisos, trans);

                            trans.Commit();

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Actualizar(Dto.Rol obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Rol obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionRoles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Rol obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Dto.Funcionalidad> RecuperarMenu(Dto.Rol obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionRoles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarMenu));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Funcionalidad>(reader);
                }
            }
        }
    }
}
