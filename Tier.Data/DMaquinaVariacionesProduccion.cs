using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DMaquinaVariacionesProduccion : ParentData<Dto.MaquinaVariacionProduccion>
    {
        #region [Constructores]
        public DMaquinaVariacionesProduccion()
            : base()
        {

        }

        public DMaquinaVariacionesProduccion(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.MaquinaVariacionProduccion obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidVariacion", obj.idVariacion),
                new MySql.Data.MySqlClient.MySqlParameter("intproduccioncant", obj.produccioncant),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_produnimed", obj.itemlista_iditemlista_produnimed),
                new MySql.Data.MySqlClient.MySqlParameter("inttiempoalistamiento", obj.tiempoalistamiento),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_taunimed", obj.itemlista_iditemlista_taunimed),
                new MySql.Data.MySqlClient.MySqlParameter("intmaquina_idmaquina", obj.maquina_idmaquina),
                new MySql.Data.MySqlClient.MySqlParameter("intmaquina_empresa_idempresa", obj.maquina_empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
            });
        }

        public override IEnumerable<Dto.MaquinaVariacionProduccion> RecuperarFiltrados(Dto.MaquinaVariacionProduccion obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaqVariProd";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.MaquinaVariacionProduccion>(reader);
                }
            }
        }

        public override bool Insertar(Dto.MaquinaVariacionProduccion obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.MaquinaVariacionProduccion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaqVariProd";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idVariacion = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idVariacion > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.MaquinaVariacionProduccion> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            foreach (Dto.MaquinaVariacionProduccion item in obj)
            {
                if (item.idVariacion == null)
                {
                    this.Insertar(item, objTrans);
                }
                else
                {
                    this.Actualizar(item, objTrans);
                }
            }
        }

        public override bool Actualizar(Dto.MaquinaVariacionProduccion obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.MaquinaVariacionProduccion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaqVariProd";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.MaquinaVariacionProduccion obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.MaquinaVariacionProduccion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public bool EliminarDetalle(Dto.MaquinaVariacionProduccion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaqVariProd";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.EliminarDetalle));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToInt16(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return intRegistrosAfectados > 0;
            }
        }
    }
}
