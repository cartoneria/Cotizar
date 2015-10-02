﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DDepartamento : ParentData<Dto.Departamento>
    {
        #region [Constructores]
        public DDepartamento()
            : base()
        {

        }

        public DDepartamento(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Departamento obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("striddepartamento", obj.iddepartamento),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
            });
        }

        public override IEnumerable<Dto.Departamento> RecuperarFiltrados(Dto.Departamento obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Departamento obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.Departamento obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Departamento obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Departamento obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Departamento obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Departamento obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
