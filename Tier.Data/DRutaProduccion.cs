using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DRutaProduccion : ParentData<Dto.RutaProduccion>
    {
        #region [Constructores]
        public DRutaProduccion()
            : base()
        {

        }

        public DRutaProduccion(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.RutaProduccion obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidvariacion", obj.idvariacion),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("intidtipomaquina", obj.idtipomaquina),
                new MySql.Data.MySqlClient.MySqlParameter("intidempresa", obj.idempresa),
            });
        }

        public override IEnumerable<Dto.RutaProduccion> RecuperarFiltrados(Dto.RutaProduccion obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionRutaProduccion";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.RutaProduccion>(reader);
                }
            }
        }

        public override bool Insertar(Dto.RutaProduccion obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.RutaProduccion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.RutaProduccion obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.RutaProduccion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.RutaProduccion obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.RutaProduccion obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
