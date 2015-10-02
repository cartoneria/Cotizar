using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DMuninipio : ParentData<Dto.Municipio>
    {
        #region [Constructores]
        public DMuninipio()
            : base()
        {

        }

        public DMuninipio(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Municipio obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("stridmunicipio", obj.idmunicipio),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("strdepartamento_iddepartamento", obj.departamento_iddepartamento),
            });
        }

        public override IEnumerable<Dto.Municipio> RecuperarFiltrados(Dto.Municipio obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Municipio obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Municipio obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Municipio obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Municipio obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Municipio obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Municipio obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
