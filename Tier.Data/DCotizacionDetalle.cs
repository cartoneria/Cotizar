using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DCotizacionDetalle : ParentData<Dto.CotizacionDetalle>
    {
        #region [Constructores]
        public DCotizacionDetalle()
            : base()
        {

        }

        public DCotizacionDetalle(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.CotizacionDetalle obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] {
                new MySql.Data.MySqlClient.MySqlParameter("intidcotizacion_detalle", obj.idcotizacion_detalle),
                new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                new MySql.Data.MySqlClient.MySqlParameter("intcotizacion_idcotizacion", obj.cotizacion_idcotizacion),
                new MySql.Data.MySqlClient.MySqlParameter("intproducto_idproducto", obj.producto_idproducto),
                new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_flete", obj.insumo_idinsumo_flete),
                new MySql.Data.MySqlClient.MySqlParameter("intescala", obj.escala),
                new MySql.Data.MySqlClient.MySqlParameter("intareacartoncaja", obj.areacartoncaja),
                new MySql.Data.MySqlClient.MySqlParameter("intareaacader", obj.areaacader),
                new MySql.Data.MySqlClient.MySqlParameter("intareaacarev", obj.areaacarev),
                new MySql.Data.MySqlClient.MySqlParameter("intcabidaconversion", obj.cabidaconversion),
                new MySql.Data.MySqlClient.MySqlParameter("intcabidatroquel", obj.cabidatroquel),
                new MySql.Data.MySqlClient.MySqlParameter("intcanttintas", obj.canttintas),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoreempaque", obj.costoreempaque),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoaccesorios", obj.costoaccesorios),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoflete", obj.costoflete),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoacetato", obj.costoacetato),
                new MySql.Data.MySqlClient.MySqlParameter("intcostocartoncaja", obj.costocartoncaja),
                new MySql.Data.MySqlClient.MySqlParameter("intcostocartoncolaminado", obj.costocartoncolaminado),
                new MySql.Data.MySqlClient.MySqlParameter("intcostotintas", obj.costotintas),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoacabadoder", obj.costoacabadoder),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoacabadorev", obj.costoacabadorev),
                new MySql.Data.MySqlClient.MySqlParameter("intcostopegante", obj.costopegante),
                new MySql.Data.MySqlClient.MySqlParameter("intcostopliegosdesper", obj.costopliegosdesper),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoprocpegue", obj.costoprocpegue),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoprocacabadoder", obj.costoprocacabadoder),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoprocacabadorev", obj.costoprocacabadorev),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoprocconversion", obj.costoprocconversion),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoproclitografia", obj.costoproclitografia),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoproctroqelado", obj.costoproctroqelado),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoproccolaminado", obj.costoproccolaminado),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoprocguillotinado", obj.costoprocguillotinado),
                new MySql.Data.MySqlClient.MySqlParameter("intcostoaportegastounidad", obj.costoaportegastounidad),
                new MySql.Data.MySqlClient.MySqlParameter("intcostototalmaterialunidad", obj.costototalmaterialunidad),
                new MySql.Data.MySqlClient.MySqlParameter("intcostototalprocesosunidad", obj.costototalprocesosunidad),
                new MySql.Data.MySqlClient.MySqlParameter("intcostototalfabricacion", obj.costototalfabricacion),
                new MySql.Data.MySqlClient.MySqlParameter("intcostodesperdiciocaja", obj.costodesperdiciocaja),
                new MySql.Data.MySqlClient.MySqlParameter("intporcedesperdiciocaja", obj.porcedesperdiciocaja),
                new MySql.Data.MySqlClient.MySqlParameter("intporcealzageneral", obj.porcealzageneral),
                new MySql.Data.MySqlClient.MySqlParameter("intporceicacree", obj.porceicacree),
                new MySql.Data.MySqlClient.MySqlParameter("intporcecomisionasesor", obj.porcecomisionasesor),
                new MySql.Data.MySqlClient.MySqlParameter("intporceadmfinanciacion", obj.porceadmfinanciacion),
                new MySql.Data.MySqlClient.MySqlParameter("intporceprecioproducto", obj.porceprecioproducto),
                new MySql.Data.MySqlClient.MySqlParameter("intcostonetocaja", obj.costonetocaja),
                new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
            });
        }

        public override IEnumerable<Dto.CotizacionDetalle> RecuperarFiltrados(Dto.CotizacionDetalle obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCotizacionDetalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.CotizacionDetalle>(reader);
                }
            }
        }

        public override bool Insertar(Dto.CotizacionDetalle obj)
        {
            throw new NotImplementedException();
        }

        public override bool Insertar(Dto.CotizacionDetalle obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCotizacionDetalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                this.CargarParametros(cmd, obj);

                obj.idcotizacion_detalle = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, objTrans));

                return obj.idcotizacion_detalle > 0;
            }
        }

        public void Insertar(IEnumerable<Dto.CotizacionDetalle> obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            if (obj != null && obj.Count() > 0)
            {
                foreach (Dto.CotizacionDetalle item in obj)
                {
                    if (item.idcotizacion_detalle == null)
                    {
                        this.Insertar(item, objTrans);
                    }
                    else
                    {
                        this.Actualizar(item, objTrans);
                    }
                } 
            }
        }

        public override bool Actualizar(Dto.CotizacionDetalle obj)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.CotizacionDetalle obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCotizacionDetalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.CotizacionDetalle obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCotizacionDetalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd);

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.CotizacionDetalle obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionCotizacionDetalle";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }
    }
}
