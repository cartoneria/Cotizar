using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DProductoAccesorio : ParentData<Dto.ProductoAccesorio>
    {
        #region [Constructores]
        public DProductoAccesorio()
            : base()
        {

        }

        public DProductoAccesorio(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ProductoAccesorio obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidproducto_accesorio", obj.idproducto_accesorio),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("intaccesorio_idaccesorio", obj.accesorio_idaccesorio),
                new MySql.Data.MySqlClient.MySqlParameter("intproducto_idproducto", obj.producto_idproducto),
                new MySql.Data.MySqlClient.MySqlParameter("intcantidad", obj.cantidad),
            });
        }

        public override IEnumerable<Dto.ProductoAccesorio> RecuperarFiltrados(Dto.ProductoAccesorio obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Accesorio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.ProductoAccesorio>(reader);
                }
            }
        }

        public override bool Insertar(Dto.ProductoAccesorio obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.ProductoAccesorio obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Accesorio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idproducto_accesorio = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idproducto_accesorio > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.ProductoAccesorio> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            foreach (Dto.ProductoAccesorio item in obj)
            {
                if (item.idproducto_accesorio == null)
                {
                    this.Insertar(item, objTrans);
                }
                else
                {
                    this.Actualizar(item, objTrans);
                }
            }
        }

        public override bool Actualizar(Dto.ProductoAccesorio obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ProductoAccesorio obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Accesorio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProductoAccesorio obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Accesorio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProductoAccesorio obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Accesorio";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
