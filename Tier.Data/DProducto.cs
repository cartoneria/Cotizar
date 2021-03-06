﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tier.Data
{
    public class DProducto : ParentData<Dto.Producto>
    {
        #region [Constructores]
        public DProducto()
            : base()
        {

        }

        public DProducto(string strCnnStr)
            : base(strCnnStr)
        {

        }
        #endregion

        public override void CargarParametros(MySql.Data.MySqlClient.MySqlCommand cmd, Dto.Producto obj)
        {
            cmd.Parameters.AddRange(new MySql.Data.MySqlClient.MySqlParameter[] { 
                    new MySql.Data.MySqlClient.MySqlParameter("intidproducto", obj.idproducto),
                    new MySql.Data.MySqlClient.MySqlParameter("strreferenciacliente", obj.referenciacliente),
                    new MySql.Data.MySqlClient.MySqlParameter("intcliente_idcliente", obj.cliente_idcliente),
                    new MySql.Data.MySqlClient.MySqlParameter("strobservaciones", obj.observaciones),
                    new MySql.Data.MySqlClient.MySqlParameter("inttroquel_idtroquel", obj.troquel_idtroquel),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_material", obj.insumo_idinsumo_material),
                    new MySql.Data.MySqlClient.MySqlParameter("intlargobobina", obj.largobobina),
                    new MySql.Data.MySqlClient.MySqlParameter("intcabidaancho", obj.cabidaancho),
                    new MySql.Data.MySqlClient.MySqlParameter("intcabidalargo", obj.cabidalargo),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_acetato", obj.insumo_idinsumo_acetato),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_acabadoderecho", obj.insumo_idinsumo_acabadoderecho),
                    new MySql.Data.MySqlClient.MySqlParameter("intanchomaquina_acabadoderecho", obj.anchomaquina_acabadoderecho),
                    new MySql.Data.MySqlClient.MySqlParameter("intrecorrido_acabadoderecho", obj.recorrido_acabadoderecho),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_acabadoreverso", obj.insumo_idinsumo_acabadoreverso),
                    new MySql.Data.MySqlClient.MySqlParameter("intanchomaquina_acabadoreverso", obj.anchomaquina_acabadoreverso),
                    new MySql.Data.MySqlClient.MySqlParameter("intrecorrido_acabadoreverso", obj.recorrido_acabadoreverso),
                    new MySql.Data.MySqlClient.MySqlParameter("strposicionplanchas", obj.posicionplanchas),
                    new MySql.Data.MySqlClient.MySqlParameter("intpasadaslitograficas", obj.pasadaslitograficas),
                    new MySql.Data.MySqlClient.MySqlParameter("strimagenartegrafico", obj.imagenartegrafico),
                    new MySql.Data.MySqlClient.MySqlParameter("intfactorprecio", obj.factorprecio),
                    new MySql.Data.MySqlClient.MySqlParameter("intcatidadpredeterminada", obj.catidadpredeterminada),
                    new MySql.Data.MySqlClient.MySqlParameter("intpreciopredeterminado", obj.preciopredeterminado),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_colaminado", obj.insumo_idinsumo_colaminado),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_colaminadopegante", obj.insumo_idinsumo_colaminadopegante),
                    new MySql.Data.MySqlClient.MySqlParameter("intcolaminadoancho", obj.colaminadoancho),
                    new MySql.Data.MySqlClient.MySqlParameter("intcolaminadoalargo", obj.colaminadoalargo),
                    new MySql.Data.MySqlClient.MySqlParameter("intcolaminadocabidalargo", obj.colaminadocabidalargo),
                    new MySql.Data.MySqlClient.MySqlParameter("intcolaminadocabidaancho", obj.colaminadocabidaancho),
                    new MySql.Data.MySqlClient.MySqlParameter("intinsumo_idinsumo_reempaque", obj.insumo_idinsumo_reempaque),
                    new MySql.Data.MySqlClient.MySqlParameter("intfactorrendimientoreempaque", obj.factorrendimientoreempaque),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion_rutaconversion", obj.maquinavariprod_idVariacion_rutaconversion),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion_rutaguillotinado", obj.maquinavariprod_idVariacion_rutaguillotinado),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion_rutalitografia", obj.maquinavariprod_idVariacion_rutalitografia),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion_rutaacabadoderecho", obj.maquinavariprod_idVariacion_rutaacabadoderecho),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion_rutaacabadoreverso", obj.maquinavariprod_idVariacion_rutaacabadoreverso),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion_rutacolaminado", obj.maquinavariprod_idVariacion_rutacolaminado),
                    new MySql.Data.MySqlClient.MySqlParameter("intmaquinavariprod_idVariacion_rutatroquelado", obj.maquinavariprod_idVariacion_rutatroquelado),
                    new MySql.Data.MySqlClient.MySqlParameter("blnnuevo", obj.nuevo),
                    new MySql.Data.MySqlClient.MySqlParameter("blnactivo", obj.activo),
                    new MySql.Data.MySqlClient.MySqlParameter("datfechacreacion", obj.fechacreacion),
                    new MySql.Data.MySqlClient.MySqlParameter("intanchobobina", obj.anchobobina),
                    new MySql.Data.MySqlClient.MySqlParameter("blnpinzalitografica", obj.pinzalitografica),
                    new MySql.Data.MySqlClient.MySqlParameter("intcostotroquel", obj.costotroquel),
                    new MySql.Data.MySqlClient.MySqlParameter("intpliegosdesperdicio", obj.pliegosdesperdicio),                    
                });
        }

        public override IEnumerable<Dto.Producto> RecuperarFiltrados(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarFiltrado));
                this.CargarParametros(cmd, obj);

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.Producto>(reader);
                }

            }
        }

        public override bool Insertar(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "uspGestionProductos";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Insertar));
                        this.CargarParametros(cmd, obj);

                        obj.idproducto = Convert.ToInt32(base.CurrentDatabase.ExecuteScalar(cmd, trans));

                        if (obj.idproducto > 0)
                        {
                            obj.AsignarIdentificador();

                            //Guardamos el espectro
                            DProductoEspectro objDALEspectro = new DProductoEspectro();
                            objDALEspectro.Insertar(obj.espectro, trans);

                            //Guardamos los accesorios
                            DProductoAccesorio objDALAccesorios = new DProductoAccesorio();
                            objDALAccesorios.Insertar(obj.accesorios, trans);

                            //Guardamos los pegues
                            DProductoPegue objDALPegues = new DProductoPegue();
                            objDALPegues.Insertar(obj.pegues, trans);

                            trans.Commit();
                        }

                        return obj.idproducto > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Insertar(Dto.Producto obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Actualizar(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlConnection cnn = new MySql.Data.MySqlClient.MySqlConnection(base.CurrentConnectionString.ConnectionString))
            {
                cnn.Open();

                MySql.Data.MySqlClient.MySqlTransaction trans = cnn.BeginTransaction();

                try
                {
                    using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
                    {
                        cmd.CommandText = "uspGestionProductos";
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Actualizar));
                        this.CargarParametros(cmd, obj);

                        int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, trans);

                        if (intRegistrosAfectados > 0)
                        {
                            obj.AsignarIdentificador();

                            //Guardamos el espectro
                            DProductoEspectro objDALEspectro = new DProductoEspectro();
                            IList<Dto.ProductoEspectro> espectroActuales = new List<Dto.ProductoEspectro>();
                            espectroActuales = objDALEspectro.RecuperarFiltrados(new Dto.ProductoEspectro() { producto_idproducto = obj.idproducto }).ToList();
                            foreach (var itemEspectro in obj.espectro)
                            {
                                if (itemEspectro.idproducto_espectro == null)
                                {
                                    objDALEspectro.Insertar(itemEspectro, trans);
                                }
                                else
                                {
                                    //espectroActuales.RemoveAt(espectroActuales.IndexOf(espectroActuales.Where(c=> c.idproducto_espectro == itemEspectro.idproducto_espectro).FirstOrDefault()));
                                    espectroActuales.Remove(espectroActuales.Where(c => c.idproducto_espectro == itemEspectro.idproducto_espectro).FirstOrDefault());
                                    objDALEspectro.Actualizar(itemEspectro, trans);
                                }
                            }
                            //Eliminar espectros que se removieron en editar
                            foreach (var itemEspectro in espectroActuales)
                            {
                                objDALEspectro.Eliminar(itemEspectro);
                            }

                            //Guardamos los accesorios
                            DProductoAccesorio objDALAccesorios = new DProductoAccesorio();
                            IList<Dto.ProductoAccesorio> accesoriosActuales = objDALAccesorios.RecuperarFiltrados(new Dto.ProductoAccesorio() { producto_idproducto = obj.idproducto }).ToList();
                            foreach (var itemAccesorios in obj.accesorios)
                            {
                                if (itemAccesorios.idproducto_accesorio == null)
                                {
                                    objDALAccesorios.Insertar(itemAccesorios, trans);
                                }
                                else
                                {
                                    //accesoriosActuales.RemoveAt(accesoriosActuales.IndexOf(accesoriosActuales.Where(c => c.idproducto_accesorio == itemAccesorios.idproducto_accesorio).FirstOrDefault()));
                                    accesoriosActuales.Remove(accesoriosActuales.Where(c => c.idproducto_accesorio == itemAccesorios.idproducto_accesorio).FirstOrDefault());
                                    objDALAccesorios.Actualizar(itemAccesorios, trans);
                                }
                            }
                            //Eliminar accesorios que se removieron en editar
                            foreach (var itemAccesorios in accesoriosActuales)
                            {
                                objDALAccesorios.Eliminar(itemAccesorios);
                            }

                            //Guardamos y actualizamos los pegues
                            DProductoPegue objDALPegues = new DProductoPegue();
                            IList<Dto.ProductoPegue> peguesActuales = objDALPegues.RecuperarFiltrados(new Dto.ProductoPegue() { producto_idproducto = obj.idproducto }).ToList();
                            foreach (var itemPegues in obj.pegues)
                            {

                                if (itemPegues.idproducto_pegue == null)
                                {
                                    objDALPegues.Insertar(itemPegues, trans);
                                }
                                else
                                {
                                    peguesActuales.Remove(peguesActuales.Where(c => c.idproducto_pegue == itemPegues.idproducto_pegue).FirstOrDefault());
                                    objDALPegues.Actualizar(itemPegues, trans);
                                }
                            }
                            //Eliminar pegues que se removieron en editar
                            foreach (var itemPegues in peguesActuales)
                            {
                                objDALPegues.Eliminar(itemPegues);
                            }

                            trans.Commit();
                        }

                        return intRegistrosAfectados > 0;
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }

        public override bool Actualizar(Dto.Producto obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar(Dto.Producto obj)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                byte intRegistrosAfectados = Convert.ToByte(base.CurrentDatabase.ExecuteScalar(cmd));

                return intRegistrosAfectados > 0;
            }
        }

        public override bool Eliminar(Dto.Producto obj, MySql.Data.MySqlClient.MySqlTransaction objTrans)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.Eliminar));
                this.CargarParametros(cmd, obj);

                int intRegistrosAfectados = base.CurrentDatabase.ExecuteNonQuery(cmd, objTrans);

                return intRegistrosAfectados > 0;
            }
        }

        public Dto.ReporteFichaTecnicaProducto RecuperarDatosReporteFichaTecnica(int idProducto)
        {
            using (MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand())
            {
                cmd.CommandText = "uspGestionProductos";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySql.Data.MySqlClient.MySqlParameter("intAccion", uspAcciones.RecuperarDatosReporteFichaTecnicaProducto));
                this.CargarParametros(cmd, new Dto.Producto() { idproducto = idProducto });

                using (IDataReader reader = base.CurrentDatabase.ExecuteReader(cmd))
                {
                    return CastObjetos.IDataReaderToList<Dto.ReporteFichaTecnicaProducto>(reader).FirstOrDefault();
                }
            }
        }
    }
}
