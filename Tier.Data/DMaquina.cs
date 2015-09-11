﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DMaquina : ParentData<Dto.Maquina>
    {
        #region [Constructores]
        public DMaquina()
            : base()
        {

        }

        public DMaquina(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Maquina obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidmaquina", obj.idmaquina),
                new MySql.Data.MySqlClient.MySqlParameter("strcodigo", obj.codigo),
                new MySql.Data.MySqlClient.MySqlParameter("intempresa_idempresa", obj.empresa_idempresa),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlistas_tipo", obj.itemlista_iditemlistas_tipo),
                new MySql.Data.MySqlClient.MySqlParameter("strnombre", obj.nombre),
                new MySql.Data.MySqlClient.MySqlParameter("intavaluocomercial", obj.avaluocomercial),
                new MySql.Data.MySqlClient.MySqlParameter("intareaancho", obj.areaancho),
                new MySql.Data.MySqlClient.MySqlParameter("intarealargo", obj.arealargo),
                new MySql.Data.MySqlClient.MySqlParameter("intpresupuesto", obj.presupuesto),
                new MySql.Data.MySqlClient.MySqlParameter("intproduccionhora", obj.produccionhora),
                new MySql.Data.MySqlClient.MySqlParameter("intitemlista_iditemlista_unimed", obj.itemlista_iditemlista_unimed),
                new MySql.Data.MySqlClient.MySqlParameter("inttiempoalistamiento", obj.tiempoalistamiento),
                new MySql.Data.MySqlClient.MySqlParameter("intturnos", obj.turnos),
                new MySql.Data.MySqlClient.MySqlParameter("intconsumonominal", obj.consumonominal),
                new MySql.Data.MySqlClient.MySqlParameter("intlargomaxmp", obj.largomax),
                new MySql.Data.MySqlClient.MySqlParameter("intlargominmp", obj.largomin),
                new MySql.Data.MySqlClient.MySqlParameter("intanchomaxmp", obj.anchomax),
                new MySql.Data.MySqlClient.MySqlParameter("intanchominmp", obj.anchomin),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo)
            });
        }

        public override IEnumerable<Dto.Maquina> RecuperarFiltrados(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Maquina>(reader);
                }
            }
        }

        public override bool Insertar(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idmaquina = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return obj.idmaquina > 0;
            }
        }

        public override bool Insertar(Dto.Maquina obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Actualizar(Dto.Maquina obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Maquina obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "produccion.uspGestionMaquinas";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Maquina obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }
    }
}
