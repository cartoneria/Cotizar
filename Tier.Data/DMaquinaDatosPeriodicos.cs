﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DMaquinaDatosPeriodicos : ParentData<Dto.MaquinaDatoPeriodico>
    {
        #region [Constructores]
        public DMaquinaDatosPeriodicos()
            : base()
        {

        }

        public DMaquinaDatosPeriodicos(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.MaquinaDatoPeriodico obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidmaquinadatosperiodos", obj.idmaquinadatosperiodos),
                new MySql.Data.MySqlClient.MySqlParameter("intperiodo_idPeriodo", obj.periodo_idPeriodo),
                new MySql.Data.MySqlClient.MySqlParameter("intavaluocomercial", obj.avaluocomercial),
                new MySql.Data.MySqlClient.MySqlParameter("intpresupuesto", obj.presupuesto),
                new MySql.Data.MySqlClient.MySqlParameter("inttiempomtto", obj.tiempomtto),
                new MySql.Data.MySqlClient.MySqlParameter("intmaquina_idmaquina", obj.maquina_idmaquina),
                new MySql.Data.MySqlClient.MySqlParameter("intmaquina_empresa_idempresa", obj.maquina_empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_tmunimed", obj.itemlista_iditemlista_tmunimed),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
            });
        }

        public override IEnumerable<Dto.MaquinaDatoPeriodico> RecuperarFiltrados(Dto.MaquinaDatoPeriodico obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaqDatosPeriodicos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.MaquinaDatoPeriodico>(reader);
                }
            }
        }

        public override bool Insertar(Dto.MaquinaDatoPeriodico obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.MaquinaDatoPeriodico obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaqDatosPeriodicos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idmaquinadatosperiodos = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idmaquinadatosperiodos > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.MaquinaDatoPeriodico> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            //Se eliminan los permisos asociados actualmente.
            this.EliminarDetalle(obj.FirstOrDefault(), objTrans);

            //Se guardan los nuevos.
            foreach (Dto.MaquinaDatoPeriodico item in obj)
            {
                this.Insertar(item, objTrans);
            }
        }

        public override bool Actualizar(Dto.MaquinaDatoPeriodico obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.MaquinaDatoPeriodico obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.MaquinaDatoPeriodico obj)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.MaquinaDatoPeriodico obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public bool EliminarDetalle(Dto.MaquinaDatoPeriodico obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaqDatosPeriodicos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.EliminarDetalle));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = Convert.ToInt16(base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans));

                return intRegistrosAfectados > 0;
            }
        }
    }
}