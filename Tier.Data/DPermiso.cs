using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DPermiso : ParentData<Dto.Permiso>
    {
        #region [Constructores]
        public DPermiso()
            : base()
        {

        }

        public DPermiso(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Permiso obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] { 
                    new MySql.Data.MySqlClient.MySqlParameter("introl_idrol", obj.rol_idrol),
                    new MySql.Data.MySqlClient.MySqlParameter("intfuncionalidad_idfuncionalidad", obj.funcionalidad_idfuncionalidad),
                    new MySql.Data.MySqlClient.MySqlParameter("intaccion_idaccion", obj.accion_idaccion)
                });
        }

        public override IEnumerable<Dto.Permiso> RecuperarFiltrados(Dto.Permiso obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionPermisos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        yield return new Dto.Permiso()
                        {
                            accion_idaccion = reader.GetInt16(reader.GetOrdinal("accion_idaccion")),
                            funcionalidad_idfuncionalidad = reader.GetByte(reader.GetOrdinal("funcionalidad_idfuncionalidad")),
                            rol_idrol = reader.GetInt16(reader.GetOrdinal("rol_idrol"))
                        };
                    }
                }
            }
        }

        public override bool Insertar(Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Permiso obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionPermisos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return true;
            }
        }

        public void Insertar(IEnumerable<Dto.Permiso> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            //Se eliminan los permisos asociados actualmente.
            this.Eliminar(obj.FirstOrDefault(), objTrans);

            //Se guardan los nuevos.
            foreach (Dto.Permiso item in obj)
            {
                this.Insertar(item, objTrans);
            }
        }

        public override bool Actualizar(Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Permiso obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Permiso obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionPermisos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                Convert.ToInt16(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return true;
            }
        }
    }
}
