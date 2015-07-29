using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DPermiso : ParentData<Dto.Permiso>
    {
        #region [Constructores]
        public DPermiso()
            : base()
        {

        }

        public DPermiso(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Dto.Permiso> RecuperarFiltrados(Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Permiso obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Permiso obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Permiso obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Permiso obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
