﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DPantone : ParentData<Dto.Pantone>
    {
        #region [Constructores]
        public DPantone()
            : base()
        {

        }

        public DPantone(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Pantone obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidpantone", obj.idpantone),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("strhex", obj.hex),
                new MySql.Data.MySqlClient.MySqlParameter("intr", obj.r),
                new MySql.Data.MySqlClient.MySqlParameter("intg", obj.g),
                new MySql.Data.MySqlClient.MySqlParameter("intb", obj.b),
            });
        }

        public override IEnumerable<Dto.Pantone> RecuperarFiltrados(Dto.Pantone obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Pantone obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Pantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Pantone obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Pantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Pantone obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Pantone obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
