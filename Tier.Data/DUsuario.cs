using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DUsuario : ParentData<Dto.Usuario>
    {
        #region [Constructores]
        public DUsuario()
            : base()
        {

        }

        public DUsuario(string CnnStr)
            : base(CnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Usuario obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[]{
                new MySql.Data.MySqlClient.MySqlParameter("intidusuario", obj.idusuario),
                new MySql.Data.MySqlClient.MySqlParameter("strusuario", obj.usuario),
                new MySql.Data.MySqlClient.MySqlParameter("strclave", obj.clave),
                new MySql.Data.MySqlClient.MySqlParameter("strnombrecompleto", obj.nombrecompleto),
                new MySql.Data.MySqlClient.MySqlParameter("strcorreoelectronico", obj.correoelectronico),
                new MySql.Data.MySqlClient.MySqlParameter("strcelular", obj.celular),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("strcargo", obj.cargo),
                new MySql.Data.MySqlClient.MySqlParameter("introl_idrol", obj   .rol_idrol),
                new MySql.Data.MySqlClient.MySqlParameter("intempresa_idempresa", obj.empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlistas_area", obj.itemlista_iditemlistas_area)
            });
        }

        public override IEnumerable<Dto.Usuario> RecuperarFiltrados(Dto.Usuario obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Usuario>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Usuario obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idusuario = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idusuario > 0;
            }
        }

        public override bool Insertar(Dto.Usuario obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Usuario obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToByte(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Actualizar(Dto.Usuario obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Usuario obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToByte(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Usuario obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToByte(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return intRegistrosAfectados > 0;
            }
        }

        public bool RestablecerClave(Dto.Usuario obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RestablecerClave));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToByte(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return intRegistrosAfectados > 0;
            }
        }

        public bool CambiarClave(Dto.Usuario obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.CambiarClave));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToByte(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return intRegistrosAfectados > 0;
            }
        }

        public Dto.Usuario InicioSesion(Dto.Usuario obj)
        {
            Dto.Usuario objResult = null;

            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionUsuarios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.IniciarSesion));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    objResult = CastObjetos.IDataReaderToList<Dto.Usuario>(reader).FirstOrDefault();
                }
            }

            return objResult;
        }
    }
}
