using System;
using System.Collections.Generic;
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
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.EspectroPantone obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.EspectroPantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.EspectroPantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
