using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DGestionComercial : ParentData<Dto.ReporteGestionComercial>
    {
        #region [Constructores]
        public DGestionComercial()
            : base()
        {

        }

        public DGestionComercial(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.ReporteGestionComercial obj)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Dto.ReporteGestionComercial> RecuperarFiltrados(Dto.ReporteGestionComercial obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.ReporteGestionComercial obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.ReporteGestionComercial obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ReporteGestionComercial obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.ReporteGestionComercial obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.ReporteGestionComercial obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.ReporteGestionComercial obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public Dto.ReporteGestionComercial RecuperarDatosReporteGestionComercial()
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionComercial";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarDatosGestionComercial));

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.ReporteGestionComercial>(reader).FirstOrDefault();
                }
            }
        }
    }
}
