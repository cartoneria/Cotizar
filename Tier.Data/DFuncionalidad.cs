using System;
using System.Collections.Generic;
using System.Data;
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
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] { 
                    new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                    new MySql.Data.MySqlClient.MySqlParameter("stricono", obj.icono),
                    new MySql.Data.MySqlClient.MySqlParameter("intidfuncionalidad", obj.idfuncionalidad),
                    new MySql.Data.MySqlClient.MySqlParameter("intidpadre", obj.idpadre),
                    new MySql.Data.MySqlClient.MySqlParameter("strmvcaction", obj.mvcaction),
                    new MySql.Data.MySqlClient.MySqlParameter("strmvccontroller", obj.mvccontroller),
                    new MySql.Data.MySqlClient.MySqlParameter("strtitulo", obj.titulo),
                    new MySql.Data.MySqlClient.MySqlParameter("struri", obj.uri),
                    new MySql.Data.MySqlClient.MySqlParameter("blnvisible", obj.visible)
                });
        }

        public override IEnumerable<Dto.Funcionalidad> RecuperarFiltrados(Dto.Funcionalidad obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionFuncionalidades";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Funcionalidad>(reader);
                }

            }
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

        public IEnumerable<Dto.Accion> RecuperarAccionesFuncionalidad(Dto.Funcionalidad obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "seguridad.uspGestionFuncionalidades";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarAccionesFunc));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Accion>(reader);
                }
            }
        }
    }
}
