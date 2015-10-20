using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DEspectroPantone : ParentData<Dto.EspectroPantone>
    {
        #region [Constructores]
        public DEspectroPantone()
            : base()
        {

        }

        public DEspectroPantone(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.EspectroPantone obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidespectro_pantone", obj.idespectro_pantone),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("intpantone_idpantone", obj.pantone_idpantone),
                new MySql.Data.MySqlClient.MySqlParameter("intespectro_idespectro", obj.espectro_idespectro),
            });
        }

        public override IEnumerable<Dto.EspectroPantone> RecuperarFiltrados(Dto.EspectroPantone obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionEspecPantone";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.EspectroPantone>(reader);
                }
            }
        }

        public override bool Insertar(Dto.EspectroPantone obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.EspectroPantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionEspecPantone";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idespectro_pantone = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idespectro_pantone > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.EspectroPantone> obj, int intIdEspectro, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            //Se eliminan los Pantones asociados actualmente.
            this.Eliminar(new Dto.EspectroPantone() { espectro_idespectro = intIdEspectro }, objTrans);

            //Se guardan los nuevos.
            if (obj.Count() > 0)
            {
                foreach (Dto.EspectroPantone item in obj)
                {
                    this.Insertar(item, objTrans);
                }
            }
        }

        public override bool Actualizar(Dto.EspectroPantone obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.EspectroPantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.EspectroPantone obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionEspecPantone";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToInt16(base.CurrentDatabase.ExecuteNonQuery(cmd));

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.EspectroPantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionEspecPantone";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToInt16(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return intRegistrosAfectados > 0;
            }
        }
    }
}
