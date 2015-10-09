using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DTroqueVentana : ParentData<Dto.TroquelVentana>
    {
        #region [Constructores]
        public DTroqueVentana()
            : base()
        {

        }

        public DTroqueVentana(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.TroquelVentana obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidtroquel_ventana", obj.idtroquel_ventana),
                new MySql.Data.MySqlClient.MySqlParameter("intlargo", obj.largo),
                new MySql.Data.MySqlClient.MySqlParameter("intalto", obj.alto),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("inttroquel_idtroquel", obj.troquel_idtroquel),
            });
        }

        public override IEnumerable<Dto.TroquelVentana> RecuperarFiltrados(Dto.TroquelVentana obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionTroquelVentanas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.TroquelVentana>(reader);
                }
            }
        }

        public override bool Insertar(Dto.TroquelVentana obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.TroquelVentana obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionTroquelVentanas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idtroquel_ventana = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idtroquel_ventana > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.TroquelVentana> obj, int intIdTroquel, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            //Se guardan los nuevos.
            if (obj.Count() > 0)
            {
                foreach (Dto.TroquelVentana item in obj)
                {
                    if (item.idtroquel_ventana == null)
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

        public override bool Actualizar(Dto.TroquelVentana obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.TroquelVentana obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionTroquelVentanas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToInt16(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.TroquelVentana obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.TroquelVentana obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionTroquelVentanas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToInt16(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return intRegistrosAfectados > 0;
            }
        }
    }
}
