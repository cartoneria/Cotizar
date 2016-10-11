using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Newtonsoft.Json.Linq;

namespace Tier.Business
{
    public class BReportes : ParentBusiness
    {
        #region [Reporte Cotización]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCotizacion"></param>
        /// <returns></returns>
        public byte[] GenerarReporteCotizacion(int idCotizacion)
        {
            string rutaArchivo = Utilidades.RutaPlantillasReportes + "Cotizacion.xlsx";

            System.IO.FileStream file = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            XSSFWorkbook xssfworkbook = new XSSFWorkbook(file);

            this.AsignarPropiedadesReporte(xssfworkbook, Recursos.CreadorReportes, Recursos.ReporteCotizacionDescripcion, Recursos.ReporteCotizacionTitulo);

            Dto.ReporteCotizacion objDatosReporte;
            objDatosReporte = new Data.DCotizacion().RecuperarDatosReporteCotizacion(idCotizacion);

            if (objDatosReporte != null)
            {
                this.AsignarDatosReporteCotizacion(xssfworkbook, objDatosReporte);
            }

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                xssfworkbook.Write(ms);
                return ms.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xssfworkbook"></param>
        /// <param name="objDatosReporte"></param>
        private void AsignarDatosReporteCotizacion(XSSFWorkbook xssfworkbook, Dto.ReporteCotizacion objDatosReporte)
        {
            ISheet objHojaBase = xssfworkbook.GetSheetAt(0);

            this.AsignarDatosEncabezadoCotizacion(objDatosReporte, objHojaBase);

            if (objDatosReporte.productos.Count() > 0)
            {
                this.CrearPaginasCotizacion(xssfworkbook, objDatosReporte, objHojaBase);

                int intFilaRegistro = 16;
                int intRegistroConteo = 1;

                foreach (Dto.ReporteCotizacionProductos objProducto in objDatosReporte.productos)
                {
                    int intRegistro = ((List<Dto.ReporteCotizacionProductos>)objDatosReporte.productos).IndexOf(objProducto) + 1;
                    int intHojaRegistro = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(intRegistro / 11)));
                    ISheet hojaRegistro = xssfworkbook.GetSheetAt(intHojaRegistro);

                    string strValorCelda = string.Empty;
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(0).SetCellValue(intRegistroConteo);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(1).SetCellValue(objProducto.referenciaCliente);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.descMaterialCaja) ? "-" : objProducto.descMaterialCaja);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(2).SetCellValue(strValorCelda);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.codMaterialCaja) ? "-" : objProducto.codMaterialCaja);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(3).SetCellValue(strValorCelda);

                    strValorCelda = string.Format("{0}/{1}", objProducto.cantTintasDerecho, objProducto.cantTintasReverso);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(4).SetCellValue(strValorCelda);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.descPantones) ? "-" : objProducto.descPantones);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(5).SetCellValue(strValorCelda);

                    strValorCelda = (objProducto.largo == null ? "-" : objProducto.largo.ToString());
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(6).SetCellValue(strValorCelda);

                    strValorCelda = (objProducto.ancho == null ? "-" : objProducto.ancho.ToString());
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(7).SetCellValue(strValorCelda);

                    strValorCelda = (objProducto.alto == null ? "-" : objProducto.alto.ToString());
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(8).SetCellValue(strValorCelda);

                    strValorCelda = (objProducto.cantVentanas == null ? "-" : objProducto.cantVentanas.ToString());
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(9).SetCellValue(strValorCelda);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.descAcabadoDerecho) ? "-" : objProducto.descAcabadoDerecho);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(10).SetCellValue(strValorCelda);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.descAcabadoReverso) ? "-" : objProducto.descAcabadoReverso);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(11).SetCellValue(strValorCelda);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.descAccesorios) ? "-" : objProducto.descAccesorios);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(12).SetCellValue(strValorCelda);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.codEstilo) ? "-" : objProducto.codEstilo);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(13).SetCellValue(strValorCelda);

                    strValorCelda = (string.IsNullOrEmpty(objProducto.codTroquel) ? "-" : objProducto.codTroquel);
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(14).SetCellValue(strValorCelda);

                    strValorCelda = (objProducto.productoNuevo ? "Si" : "No");
                    hojaRegistro.GetRow(intFilaRegistro).GetCell(15).SetCellValue(strValorCelda);

                    IEnumerable<Dto.ReporteCotizacionValores> lstValores = from ee in objDatosReporte.valores where ee.producto_idproducto == objProducto.idProducto select ee;
                    if (lstValores != null)
                    {
                        int intCeldaConteo = 16;

                        foreach (Dto.ReporteCotizacionValores objEscalaValor in lstValores)
                        {
                            hojaRegistro.GetRow(intFilaRegistro).GetCell(intCeldaConteo).SetCellValue(objEscalaValor.escala);
                            hojaRegistro.GetRow(intFilaRegistro + 1).GetCell(intCeldaConteo).SetCellValue(objEscalaValor.costonetocaja);
                            intCeldaConteo++;
                        }
                    }

                    if (intRegistroConteo < 10)
                    {
                        intFilaRegistro = intFilaRegistro + 2;
                        intRegistroConteo = intRegistroConteo + 1;
                    }
                    else
                    {
                        intFilaRegistro = 16;
                        intRegistroConteo = 1;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xssfworkbook"></param>
        /// <param name="objDatosReporte"></param>
        /// <param name="objHojaBase"></param>
        private void CrearPaginasCotizacion(XSSFWorkbook xssfworkbook, Dto.ReporteCotizacion objDatosReporte, ISheet objHojaBase)
        {
            byte intCantiHojas = Convert.ToByte(Math.Ceiling(objDatosReporte.productos.Count() / 10D));

            if (intCantiHojas > 1)
            {
                for (int i = 1; i <= intCantiHojas - 1; i++)
                {
                    objHojaBase.CopySheet(string.Format("Página {0}", i + 1), true);
                    ISheet nuevaHoja = xssfworkbook.GetSheetAt(i);
                    nuevaHoja.GetRow(11).GetCell(22).SetCellValue(string.Format("Pág {0}", i + 1));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDatosReporte"></param>
        /// <param name="objHojaBase"></param>
        private void AsignarDatosEncabezadoCotizacion(Dto.ReporteCotizacion objDatosReporte, ISheet objHojaBase)
        {
            objHojaBase.GetRow(7).GetCell(0).SetCellValue(objDatosReporte.clienteRazonSocial);
            objHojaBase.GetRow(7).GetCell(20).SetCellValue(objDatosReporte.fechaCotizacion);

            objHojaBase.GetRow(9).GetCell(10).SetCellValue(objDatosReporte.clienteContactoDireccion);
            objHojaBase.GetRow(9).GetCell(20).SetCellValue(objDatosReporte.clienteContactoCiudad);

            objHojaBase.GetRow(11).GetCell(20).SetCellValue(objDatosReporte.idCotizacion);
            objHojaBase.GetRow(11).GetCell(22).SetCellValue(string.Format("Pág {0}", 1));

            objHojaBase.GetRow(38).GetCell(17).SetCellValue(objDatosReporte.costosplanchaCotizacion);
            objHojaBase.GetRow(38).GetCell(20).SetCellValue(objDatosReporte.costostroquelesCotizacion);

            objHojaBase.GetRow(45).GetCell(0).SetCellValue(objDatosReporte.observacionesCotizacion);

            string correo, telefono, contacto;
            correo = telefono = contacto = "N/A";

            if (!string.IsNullOrEmpty(objDatosReporte.clienteContactos))
            {
                this.ObtenerDatosContactoCliente(objDatosReporte, ref correo, ref telefono, ref contacto);
            }

            objHojaBase.GetRow(7).GetCell(10).SetCellValue(correo);
            objHojaBase.GetRow(7).GetCell(15).SetCellValue(telefono);
            objHojaBase.GetRow(9).GetCell(0).SetCellValue(contacto);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDatosReporte"></param>
        /// <param name="correo"></param>
        /// <param name="telefono"></param>
        /// <param name="contacto"></param>
        private void ObtenerDatosContactoCliente(Dto.ReporteCotizacion objDatosReporte, ref string correo, ref string telefono, ref string contacto)
        {
            JArray jsonArray = JArray.Parse(objDatosReporte.clienteContactos);

            if (jsonArray.Count > 0)
            {
                foreach (var objCotProd in jsonArray.Children())
                {
                    try
                    {
                        dynamic objContacto = JObject.Parse(objCotProd.ToString());
                        if (Convert.ToBoolean(objContacto.Principal))
                        {
                            correo = string.IsNullOrEmpty(Convert.ToString(objContacto.EMail)) ? "N/A" : objContacto.EMail;
                            telefono = string.IsNullOrEmpty(Convert.ToString(objContacto.Telefono)) ? "N/A" : objContacto.Telefono;
                            contacto = string.IsNullOrEmpty(Convert.ToString(objContacto.Nombre)) ? "N/A" : objContacto.Nombre;

                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlProps"></param>
        private void AsignarPropiedadesReporte(NPOI.XSSF.UserModel.XSSFWorkbook xssfworkbook, string creador, string descripcion, string titulo)
        {
            NPOI.POIXMLProperties xmlProps = xssfworkbook.GetProperties();
            NPOI.CoreProperties coreprops = xmlProps.CoreProperties;

            coreprops.Created = DateTime.Now;
            coreprops.Creator = creador;
            coreprops.Description = descripcion;
            coreprops.Title = titulo;
        }
        #endregion
    }
}
