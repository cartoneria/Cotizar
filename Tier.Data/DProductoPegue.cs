using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DProductoPegue : ParentData<Dto.ProductoPegue>
    {
        #region [Constructores]
        public DProductoPegue()
            : base()
        {

        }

        public DProductoPegue(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ProductoPegue obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] { 
                    new MySql.Data.MySqlClient.MySqlParameter("intidproducto_pegue", obj.idproducto_pegue),
                    new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                    new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                    new MySql.Data.MySqlClient.MySqlParameter("intproducto_idproducto", obj.producto_idproducto),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo", obj.insumo_idinsumo),
                    new MySql.Data.MySqlClient.MySqlParameter("intlargo", obj.largo),
                    new MySql.Data.MySqlClient.MySqlParameter("intancho", obj.ancho),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion", obj.maquinavariprod_idVariacion),
            });
        }

        public override IEnumerable<Dto.ProductoPegue> RecuperarFiltrados(Dto.ProductoPegue obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProducto_Pegue";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.ProductoPegue>(reader);
                }
            }
        }

        public override bool Insertar(Dto.ProductoPegue obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.ProductoPegue obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProducto_Pegue";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idproducto_pegue = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idproducto_pegue > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.ProductoPegue> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            if (obj != null && obj.Count() > 0)
            {
                foreach (Dto.ProductoPegue item in obj)
                {
                    if (item.idproducto_pegue == null)
                    {
                        this.Insertar(item, objTrans);
                    }
                    else
                    {
                        this.Actualizar(item, objTrans);
                    }
                } 
            }
        }

        public override bool Actualizar(Dto.ProductoPegue obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ProductoPegue obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProducto_Pegue";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProductoPegue obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProducto_Pegue";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.ProductoPegue obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProducto_Pegue";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
