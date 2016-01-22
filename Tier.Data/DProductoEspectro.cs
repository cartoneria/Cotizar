using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DProductoEspectro : ParentData<Dto.ProductoEspectro>
    {
        #region [Constructores]
        public DProductoEspectro()
            : base()
        {

        }

        public DProductoEspectro(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ProductoEspectro obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidproducto_espectro", obj.idproducto_espectro),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("intproducto_idproducto", obj.producto_idproducto),
                new MySql.Data.MySqlClient.MySqlParameter("intpantone_idpantone", obj.pantone_idpantone),
                new MySql.Data.MySqlClient.MySqlParameter("intporcentajecubrimiento", obj.porcentajecubrimiento),
            });
        }

        public override IEnumerable<Dto.ProductoEspectro> RecuperarFiltrados(Dto.ProductoEspectro obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Espectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.ProductoEspectro>(reader);
                }
            }
        }

        public override bool Insertar(Dto.ProductoEspectro obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.ProductoEspectro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Espectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idproducto_espectro = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idproducto_espectro > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.ProductoEspectro> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            foreach (Dto.ProductoEspectro item in obj)
            {
                if (item.idproducto_espectro == null)
                {
                    this.Insertar(item, objTrans);
                }
                else
                {
                    this.Actualizar(item, objTrans);
                }
            }
        }

        public override bool Actualizar(Dto.ProductoEspectro obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ProductoEspectro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Espectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProductoEspectro obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Espectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProductoEspectro obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionProducto_Espectros";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
