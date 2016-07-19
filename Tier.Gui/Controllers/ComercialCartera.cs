using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tier.Gui.Controllers
{
    public partial class ComercialController : BaseController
    {
        public ActionResult Cartera()
        {
            return View();
        }

        public ActionResult ActualizarCartera()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActualizarCartera(CotizarService.CarteraModel obj)
        {
            if (ModelState.IsValid)
            {
                //Guardado del archivo
                #region [GuardadoArchivo]
                string fullPath, path, extencion, strNombreArchivo;
                fullPath = path = extencion = strNombreArchivo = string.Empty;

                if (obj.DataFileUpload != null)
                {
                    path = Server.MapPath("~/Content/Cartera/");
                    base.AlistarRutaArchivo(path);

                    extencion = obj.DataFileUpload.FileName.Substring(obj.DataFileUpload.FileName.LastIndexOf('.'));

                    strNombreArchivo = string.Format("Cartera_{0}{1}", DateTime.Now.ToString("yyyyMMdd"), extencion);
                    fullPath = Server.MapPath("~/Content/Cartera/") + strNombreArchivo;

                    if (System.IO.File.Exists(fullPath))
                        System.IO.File.Delete(fullPath);

                    obj.DataFileUpload.SaveAs(fullPath);
                }
                else
                {
                    base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);

                    return View();
                }
                #endregion

                List<CotizarService.Cartera> lstNoAsesor = new List<CotizarService.Cartera>();
                List<CotizarService.Cartera> lstNoCliente = new List<CotizarService.Cartera>();
                List<CotizarService.Cartera> lstCartera = new List<CotizarService.Cartera>();

                //Procesamiento del archivo
                if (!string.IsNullOrEmpty(fullPath))
                {
                    try
                    {
                        var dataTable = new System.Data.DataTable();

                        #region [LecturaArchivo]
                        string con = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties='Excel 8.0;HDR=Yes;'", fullPath);
                        using (System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection(con))
                        {
                            connection.Open();

                            System.Data.DataTable objSheetNames = connection.GetSchema("Tables");

                            System.Data.OleDb.OleDbCommand command = new System.Data.OleDb.OleDbCommand(string.Format("select * from [{0}]", objSheetNames.Rows[0][2]), connection);
                            using (System.Data.OleDb.OleDbDataReader dr = command.ExecuteReader())
                            {
                                dataTable.Load(dr);
                            }
                        }
                        #endregion

                        #region [ProcesamientoRegistrosArchivo]
                        foreach (System.Data.DataRow item in dataTable.Rows)
                        {
                            int intIndiceRegistro = dataTable.Rows.IndexOf(item);

                            if (intIndiceRegistro > 5)
                            {
                                CotizarService.Cartera objNew = new CotizarService.Cartera()
                                {
                                    filaarchivo = intIndiceRegistro + 1,
                                    consecutivo = item[14] != DBNull.Value ? Convert.ToByte(item[14]) : new Nullable<byte>(),
                                    cuenta = item[10] != DBNull.Value ? item[10].ToString() : null,
                                    documento = item[13] != DBNull.Value ? item[13].ToString() : null,
                                    fecha = item[15] != DBNull.Value ? Convert.ToDateTime(item[15]) : new Nullable<DateTime>(),
                                    valormora = item[18] != DBNull.Value ? Convert.ToSingle(item[18]) : new Nullable<Single>(),
                                    valorsaldo = item[19] != DBNull.Value ? Convert.ToSingle(item[19]) : new Nullable<Single>(),
                                    vencimiento = item[16] != DBNull.Value ? Convert.ToDateTime(item[16]) : new Nullable<DateTime>(),
                                };

                                //Sin Asesor
                                #region [ValidacionAsesor]
                                if (item[2] == DBNull.Value)
                                {
                                    lstNoAsesor.Add(objNew);
                                    continue;
                                }
                                else
                                {
                                    CotizarService.Asesor objAsesor = new CotizarService.CotizarServiceClient().Asesor_RecuperarFiltros(new CotizarService.Asesor()
                                    {
                                        idasesor = Convert.ToByte(item[2])
                                    }).FirstOrDefault();

                                    if (objAsesor == null)
                                    {
                                        lstNoAsesor.Add(objNew);
                                        continue;
                                    }
                                    else
                                    {
                                        objNew.asesor_idasesor = objAsesor.idasesor;
                                    }
                                }
                                #endregion

                                //Sin cliente
                                #region [ValidacionCliente]
                                if (item[4] == DBNull.Value)
                                {
                                    lstNoCliente.Add(objNew);
                                    continue;
                                }
                                else
                                {
                                    CotizarService.Cliente objCliente = new CotizarService.CotizarServiceClient().Cliente_RecuperarFiltros(new CotizarService.Cliente()
                                    {
                                        identificacion = item[4].ToString()
                                    }).FirstOrDefault();

                                    if (objCliente == null)
                                    {
                                        lstNoCliente.Add(objNew);
                                        continue;
                                    }
                                    else
                                    {
                                        objNew.cliente_idcliente = objCliente.idcliente;
                                    }
                                }
                                #endregion

                                lstCartera.Add(objNew);
                            }
                        }
                        #endregion

                        CotizarService.CotizarServiceClient _Service = new CotizarService.CotizarServiceClient();
                        if (_Service.Cartera_ActualizarCarteraLote(lstCartera))
                        {
                            base.RegistrarNotificación("Se ha actualizado la cartera correctamente.", Models.Enumeradores.TiposNotificaciones.success, Recursos.TituloNotificacionExitoso);
                        }
                        else
                        {
                            base.RegistrarNotificación("Falla en el servicio de inserción.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                        }
                    }
                    catch (Exception ex)
                    {
                        Logs.Error(ex, "Comercial");
                        base.RegistrarNotificación("Se produjo una excepción al procesar el archivo.", Models.Enumeradores.TiposNotificaciones.error, Recursos.TituloNotificacionError);
                        return View();
                    }
                }

                ViewBag.lstCartera = lstCartera;
                ViewBag.lstNoAsesor = lstNoAsesor;
                ViewBag.lstNoCliente = lstNoCliente;

                return View();
            }
            else
            {
                base.RegistrarNotificación("Algunos valores no validos.", Models.Enumeradores.TiposNotificaciones.notice, Recursos.TituloNotificacionAdvertencia);

                return View();
            }
        }
    }
}