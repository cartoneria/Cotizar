using System;
using System.Collections.Generic;
using System.Data;
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
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMunicipios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Municipio>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Municipio obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "comercial.uspGestionMunicipios";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                base.CurrentDatabase.ExecuteNonQuery(cmd);

                return true;
            }
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
