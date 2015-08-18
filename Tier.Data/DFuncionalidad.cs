using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DFuncionalidad : ParentData<Dto.Funcionalidad>
    {
        #region [Constructores]
        public DFuncionalidad()
            : base()
        {

        }

        public DFuncionalidad(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Funcionalidad obj)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Dto.Funcionalidad> RecuperarFiltrados(Dto.Funcionalidad obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Funcionalidad obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Funcionalidad obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Funcionalidad obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Funcionalidad obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Funcionalidad obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Funcionalidad obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
