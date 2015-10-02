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
                new MySql.Data.MySqlClient.MySqlParameter("strcodigo", obj.codigo),
                new MySql.Data.MySqlClient.MySqlParameter("strreferencia", obj.referencia),
                new MySql.Data.MySqlClient.MySqlParameter("intlargo", obj.largo),
                new MySql.Data.MySqlClient.MySqlParameter("intancho", obj.ancho),
                new MySql.Data.MySqlClient.MySqlParameter("intalto", obj.alto),
                new MySql.Data.MySqlClient.MySqlParameter("intcortea", obj.cortea),
                new MySql.Data.MySqlClient.MySqlParameter("intcorteb", obj.corteb),
                new MySql.Data.MySqlClient.MySqlParameter("intcabida", obj.cabida),
                new MySql.Data.MySqlClient.MySqlParameter("intacetatoa", obj.acetatoa),
                new MySql.Data.MySqlClient.MySqlParameter("intacetatob", obj.acetatob),
                new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
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
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionTroqueles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idtroquel = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idtroquel > 0;
            }
        }

        public override bool Insertar(Dto.Troquel obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Troquel obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionTroqueles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
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
                cmd.CommandText = "comercial.uspGestionTroqueles";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Troquel obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
