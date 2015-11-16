using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DInsumo : ParentData<Dto.Insumo>
    {
        #region [Constructores]
        public DInsumo()
            : base()
        {

        }

        public DInsumo(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Insumo obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidinsumo", obj.idinsumo),
                new MySql.Data.MySqlClient.MySqlParameter("intproveedor_linea_idproveedor_linea", obj.proveedor_linea_idproveedor_linea),
                new MySql.Data.MySqlClient.MySqlParameter("intproveedor_linea_proveedor_idproveedor", obj.proveedor_linea_proveedor_idproveedor),
                new MySql.Data.MySqlClient.MySqlParameter("intancho", obj.ancho),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_tipo", obj.itemlista_iditemlista_tipo),
                new MySql.Data.MySqlClient.MySqlParameter("intcalibre", obj.calibre),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_unimedcomp", obj.itemlista_iditemlista_unimedcomp),
                new MySql.Data.MySqlClient.MySqlParameter("intvalor", obj.valor),
                new MySql.Data.MySqlClient.MySqlParameter("intfactorrendimiento", obj.factorrendimiento),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_unimedrendi", obj.itemlista_iditemlista_unimedrendi),
                new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
            });
        }

        public override IEnumerable<Dto.Insumo> RecuperarFiltrados(Dto.Insumo obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionInsumos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Insumo>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Insumo obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionInsumos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idinsumo = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idinsumo > 0;
            }
        }

        public override bool Insertar(Dto.Insumo obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Insumo obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionInsumos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Actualizar(Dto.Insumo obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Insumo obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionInsumos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Insumo obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionInsumos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
