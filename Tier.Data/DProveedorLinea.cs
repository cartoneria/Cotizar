using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DProveedorLinea : ParentData<Dto.ProveedorLinea>
    {
        #region [Constructores]
        public DProveedorLinea()
            : base()
        {

        }

        public DProveedorLinea(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ProveedorLinea obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidproveedor_linea", obj.idproveedor_linea),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("intproveedor_idproveedor", obj.proveedor_idproveedor),
            });
        }

        public override IEnumerable<Dto.ProveedorLinea> RecuperarFiltrados(Dto.ProveedorLinea obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProvedorLienas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.ProveedorLinea>(reader);
                }
            }
        }

        public override bool Insertar(Dto.ProveedorLinea obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.ProveedorLinea obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProvedorLienas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idproveedor_linea = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idproveedor_linea > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.ProveedorLinea> lst, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            foreach (Dto.ProveedorLinea item in lst)
            {
                if (item.idproveedor_linea == null)
                {
                    this.Insertar(item, objTrans);
                }
                else
                {
                    this.Actualizar(item, objTrans);
                }
            }
        }

        public override bool Actualizar(Dto.ProveedorLinea obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ProveedorLinea obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProvedorLienas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProveedorLinea obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProvedorLienas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProveedorLinea obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProvedorLienas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
