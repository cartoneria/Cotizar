﻿using System;
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
            string claveBloquoArchivo = Guid.NewGuid().ToString("N");

            System.IO.FileStream file = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            XSSFWorkbook xssfworkbook = new XSSFWorkbook(file);

            this.AsignarPropiedadesReporte(xssfworkbook, Recursos.CreadorReportes, Recursos.ReporteCotizacionDescripcion, Recursos.ReporteCotizacionTitulo, claveBloquoArchivo);

            Dto.ReporteCotizacion objDatosReporte;
            objDatosReporte = new Data.DCotizacion().RecuperarDatosReporteCotizacion(idCotizacion);

            if (objDatosReporte != null)
            {
                this.AsignarDatosReporteCotizacion(xssfworkbook, objDatosReporte);
            }

            // Se bloquean las hojas del libro.
            for (int i = 0; i < xssfworkbook.NumberOfSheets; i++)
            {
                ISheet objHojaProteger = xssfworkbook.GetSheetAt(i);
                this.BloquearHoja(objHojaProteger, xssfworkbook, claveBloquoArchivo);
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

                    strValorCelda = (objProducto.cantVentanas <= 0 ? "-" : objProducto.cantVentanas.ToString());
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
                this.ObtenerDatosContactoCliente(objDatosReporte.clienteContactos, ref correo, ref telefono, ref contacto);
            }

            objHojaBase.GetRow(7).GetCell(10).SetCellValue(correo);
            objHojaBase.GetRow(7).GetCell(15).SetCellValue(telefono);
            objHojaBase.GetRow(9).GetCell(0).SetCellValue(contacto);
        }
        #endregion

        #region [Reporte Orden de Producción]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPedido"></param>
        /// <returns></returns>
        public byte[] GenerarReporteOrdenProduccion(int idPedido)
        {
            string rutaArchivo = Utilidades.RutaPlantillasReportes + "Orden_Produccion.xlsx";
            string claveBloquoArchivo = Guid.NewGuid().ToString("N");

            System.IO.FileStream file = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            XSSFWorkbook xssfworkbook = new XSSFWorkbook(file);

            this.AsignarPropiedadesReporte(xssfworkbook, Recursos.CreadorReportes, Recursos.ReporteCotizacionDescripcion, Recursos.ReporteCotizacionTitulo, claveBloquoArchivo);

            IEnumerable<Dto.ReporteOrdenProduccion> objDatosReporte;
            objDatosReporte = new Data.DPedido().RecuperarDatosReporteOrdenProduccion(idPedido);

            if (objDatosReporte != null)
            {
                this.AsignarDatosReporteOrdenProduccion(xssfworkbook, objDatosReporte);
                this.AsignarDatosReporteOrdenProduccionColaminado(xssfworkbook, objDatosReporte);

                xssfworkbook.RemoveSheetAt(0);
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
        private void AsignarDatosReporteOrdenProduccion(XSSFWorkbook xssfworkbook, IEnumerable<Dto.ReporteOrdenProduccion> objDatosReporte)
        {
            bool blnProdColaminado;
            ISheet hojaRegistro;
            string strValorCelda = string.Empty;

            foreach (var item in objDatosReporte)
            {
                blnProdColaminado = item.productoCorteColaminado.Length > 1;

                hojaRegistro = xssfworkbook.GetSheetAt(0).CopySheet(string.Format("OP Producto {0}", item.productoId));

                hojaRegistro.GetRow(5).GetCell(5).SetCellValue(item.clienteRazonSocial);
                hojaRegistro.GetRow(5).GetCell(22).SetCellValue(item.clienteCalificacion);
                hojaRegistro.GetRow(5).GetCell(29).SetCellValue(item.pedidoIdSIIGO);
                hojaRegistro.GetRow(6).GetCell(5).SetCellValue(item.productoRefCliente);
                hojaRegistro.GetRow(6).GetCell(22).SetCellValue(item.productoId);
                hojaRegistro.GetRow(6).GetCell(29).SetCellValue(item.pedidoCatidad);

                hojaRegistro.GetRow(8).GetCell(7).SetCellValue(item.pedidoFechaCreacion.Day);
                hojaRegistro.GetRow(8).GetCell(9).SetCellValue(item.pedidoFechaCreacion.Month);
                hojaRegistro.GetRow(8).GetCell(11).SetCellValue(item.pedidoFechaCreacion.Year);

                hojaRegistro.GetRow(10).GetCell(5).SetCellValue(item.productoMaterialCaja);
                hojaRegistro.GetRow(10).GetCell(17).SetCellValue(item.productoKilosMaterialCaja);
                hojaRegistro.GetRow(10).GetCell(23).SetCellValue(item.productoLargoBobina);
                hojaRegistro.GetRow(10).GetCell(29).SetCellValue(item.productoCabidaLargo);
                hojaRegistro.GetRow(11).GetCell(5).SetCellValue(item.troquelCorte);
                hojaRegistro.GetRow(11).GetCell(17).SetCellValue(item.productoPinzaLito);
                hojaRegistro.GetRow(12).GetCell(5).SetCellValue(item.productoCorteConversion);

                hojaRegistro.GetRow(12).GetCell(17).SetCellValue(item.productoPliegosConversion);
                hojaRegistro.GetRow(12).GetCell(22).SetCellValue(item.productoAnchoBobina);
                hojaRegistro.GetRow(12).GetCell(28).SetCellValue(item.productoCabidaAncho);

                if (blnProdColaminado)
                {
                    hojaRegistro.GetRow(13).GetCell(14).SetCellValue("PARTE A COLAMINAR");
                }
                else
                {
                    hojaRegistro.GetRow(13).GetCell(14).SetCellValue("SIN COLAMINADO");
                }

                hojaRegistro.GetRow(15).GetCell(9).SetCellValue(item.productoPosicionPlanchas);
                hojaRegistro.GetRow(16).GetCell(6).SetCellValue(item.productoCantTintas);

                if (blnProdColaminado)
                {
                    strValorCelda = string.Format("Tiro: {0} // Retiro: Ver en OP parte colaminado", item.productoPantonesTiro);
                }
                else
                {
                    strValorCelda = string.Format("Tiro: {0} // Retiro: {1}", item.productoPantonesTiro, item.productoPantonesRetiro);
                }

                hojaRegistro.GetRow(16).GetCell(8).SetCellValue(strValorCelda);

                hojaRegistro.GetRow(17).GetCell(6).SetCellValue(item.productoAcabDer);
                hojaRegistro.GetRow(17).GetCell(18).SetCellValue(item.productoKilosAcabDer);

                if (blnProdColaminado)
                {
                    hojaRegistro.GetRow(18).GetCell(6).SetCellValue("Ver en OP parte colaminado");
                    hojaRegistro.GetRow(18).GetCell(18).SetCellValue("-");
                }
                else
                {
                    hojaRegistro.GetRow(18).GetCell(6).SetCellValue(item.productoAcabRev);
                    hojaRegistro.GetRow(18).GetCell(18).SetCellValue(item.productoKilosAcabRev);
                }

                hojaRegistro.GetRow(19).GetCell(8).SetCellValue(item.productoTroquel);
                hojaRegistro.GetRow(19).GetCell(18).SetCellValue(item.troquelUbicacion);

                hojaRegistro.GetRow(21).GetCell(8).SetCellValue(item.productoPegues);
                hojaRegistro.GetRow(22).GetCell(5).SetCellValue(item.productoAcetatoVentanas);
                hojaRegistro.GetRow(22).GetCell(21).SetCellValue(item.productoAccesorios);
                hojaRegistro.GetRow(23).GetCell(5).SetCellValue(item.productoReempaque);

                hojaRegistro.GetRow(29).GetCell(5).SetCellValue(item.clienteObservaciones);
                hojaRegistro.GetRow(30).GetCell(5).SetCellValue(item.productoObservaciones);
                hojaRegistro.GetRow(31).GetCell(5).SetCellValue(item.pedidoObservaciones);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xssfworkbook"></param>
        /// <param name="objDatosReporte"></param>
        private void AsignarDatosReporteOrdenProduccionColaminado(XSSFWorkbook xssfworkbook, IEnumerable<Dto.ReporteOrdenProduccion> objDatosReporte)
        {
            bool blnProdColaminado;
            ISheet hojaRegistro;
            string strValorCelda = string.Empty;

            foreach (var item in objDatosReporte)
            {
                blnProdColaminado = item.productoCorteColaminado.Length > 1;

                if (blnProdColaminado)
                {
                    hojaRegistro = xssfworkbook.GetSheetAt(0).CopySheet(string.Format("OP Colaminado Producto {0}", item.productoId));

                    hojaRegistro.GetRow(5).GetCell(5).SetCellValue(item.clienteRazonSocial);
                    hojaRegistro.GetRow(5).GetCell(22).SetCellValue(item.clienteCalificacion);
                    hojaRegistro.GetRow(5).GetCell(29).SetCellValue(item.pedidoIdSIIGO);
                    hojaRegistro.GetRow(6).GetCell(5).SetCellValue(item.productoRefCliente);
                    hojaRegistro.GetRow(6).GetCell(22).SetCellValue(item.productoId);
                    hojaRegistro.GetRow(6).GetCell(29).SetCellValue(item.pedidoCatidad);

                    hojaRegistro.GetRow(8).GetCell(7).SetCellValue(item.pedidoFechaCreacion.Day);
                    hojaRegistro.GetRow(8).GetCell(9).SetCellValue(item.pedidoFechaCreacion.Month);
                    hojaRegistro.GetRow(8).GetCell(11).SetCellValue(item.pedidoFechaCreacion.Year);

                    hojaRegistro.GetRow(10).GetCell(5).SetCellValue(item.productoColaminado);
                    hojaRegistro.GetRow(10).GetCell(17).SetCellValue(item.productoKilosMaterialColaminado);
                    hojaRegistro.GetRow(10).GetCell(23).SetCellValue(item.productoColaminadoLargo);
                    hojaRegistro.GetRow(10).GetCell(29).SetCellValue(item.productoColaminadoCabidaLargo);
                    hojaRegistro.GetRow(11).GetCell(5).SetCellValue(item.troquelCorte);
                    hojaRegistro.GetRow(11).GetCell(17).SetCellValue(item.productoPinzaLito);
                    hojaRegistro.GetRow(12).GetCell(5).SetCellValue(item.productoCorteColaminado);

                    hojaRegistro.GetRow(12).GetCell(17).SetCellValue(item.productoPliegosConversionColaminado);
                    hojaRegistro.GetRow(12).GetCell(22).SetCellValue(item.productoColaminadoAncho);
                    hojaRegistro.GetRow(12).GetCell(28).SetCellValue(item.productoColaminadoCabidaAncho);

                    hojaRegistro.GetRow(13).GetCell(14).SetCellValue("PARTE COLAMINADO");

                    hojaRegistro.GetRow(15).GetCell(9).SetCellValue(item.productoPosicionPlanchas);
                    hojaRegistro.GetRow(16).GetCell(6).SetCellValue(item.productoCantTintas);

                    strValorCelda = string.Format("Tiro: Ver en OP parte a colaminar // Retiro: {0}", item.productoPantonesRetiro);
                    hojaRegistro.GetRow(16).GetCell(8).SetCellValue(strValorCelda);

                    hojaRegistro.GetRow(17).GetCell(6).SetCellValue("Ver en OP parte a colaminar");
                    hojaRegistro.GetRow(17).GetCell(18).SetCellValue("-");

                    hojaRegistro.GetRow(18).GetCell(6).SetCellValue(item.productoAcabRev);
                    hojaRegistro.GetRow(18).GetCell(18).SetCellValue(item.productoKilosAcabRev);

                    hojaRegistro.GetRow(19).GetCell(8).SetCellValue("-");
                    hojaRegistro.GetRow(19).GetCell(18).SetCellValue("-");

                    hojaRegistro.GetRow(21).GetCell(8).SetCellValue("-");
                    hojaRegistro.GetRow(22).GetCell(5).SetCellValue("-");
                    hojaRegistro.GetRow(22).GetCell(21).SetCellValue("-");
                    hojaRegistro.GetRow(23).GetCell(5).SetCellValue("-");

                    hojaRegistro.GetRow(29).GetCell(5).SetCellValue(item.clienteObservaciones);
                    hojaRegistro.GetRow(30).GetCell(5).SetCellValue(item.productoObservaciones);
                    hojaRegistro.GetRow(31).GetCell(5).SetCellValue(item.pedidoObservaciones);
                }
            }
        }
        #endregion

        #region [Ficha Técnica de Producto]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idProducto"></param>
        /// <returns></returns>
        public byte[] GenerarReporteFichaTecnicaProducto(int idProducto)
        {
            string rutaArchivo = Utilidades.RutaPlantillasReportes + "Ficha_Tecnica.xlsx";
            string claveBloquoArchivo = Guid.NewGuid().ToString("N");

            System.IO.FileStream file = new System.IO.FileStream(rutaArchivo, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            XSSFWorkbook xssfworkbook = new XSSFWorkbook(file);

            this.AsignarPropiedadesReporte(xssfworkbook, Recursos.CreadorReportes, Recursos.ReporteCotizacionDescripcion, Recursos.ReporteCotizacionTitulo, claveBloquoArchivo);

            Dto.ReporteFichaTecnicaProducto objDatosReporte;
            objDatosReporte = new Data.DProducto().RecuperarDatosReporteFichaTecnica(idProducto);

            if (objDatosReporte != null)
            {
                this.AsignarDatosReporteFichaTecnica(xssfworkbook, objDatosReporte);

                xssfworkbook.RemoveSheetAt(0);
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
        private void AsignarDatosReporteFichaTecnica(XSSFWorkbook xssfworkbook, Dto.ReporteFichaTecnicaProducto objDatosReporte)
        {
            ISheet hojaRegistro;
            hojaRegistro = xssfworkbook.GetSheetAt(0).CopySheet(string.Format("OP Producto {0}", objDatosReporte.productoId));

            hojaRegistro.GetRow(5).GetCell(7).SetCellValue(DateTime.Now.Day);
            hojaRegistro.GetRow(5).GetCell(9).SetCellValue(DateTime.Now.Month);
            hojaRegistro.GetRow(5).GetCell(11).SetCellValue(DateTime.Now.Year);
            hojaRegistro.GetRow(5).GetCell(25).SetCellValue(objDatosReporte.productoId);

            hojaRegistro.GetRow(6).GetCell(7).SetCellValue(objDatosReporte.clienteRazonSocial);
            hojaRegistro.GetRow(6).GetCell(25).SetCellValue(objDatosReporte.clienteIdentificacion);
            hojaRegistro.GetRow(7).GetCell(7).SetCellValue(objDatosReporte.clienteDireccion);
            hojaRegistro.GetRow(7).GetCell(25).SetCellValue(objDatosReporte.clienteMunicipio);

            string correo = "-";
            string telefono = "-";
            string contacto = "-";

            if (objDatosReporte.clienteContacto.Length > 1)
            {
                this.ObtenerDatosContactoCliente(objDatosReporte.clienteContacto, ref correo, ref telefono, ref contacto);
            }

            hojaRegistro.GetRow(8).GetCell(7).SetCellValue(contacto);
            hojaRegistro.GetRow(8).GetCell(25).SetCellValue(objDatosReporte.clienteAsesor);
            hojaRegistro.GetRow(9).GetCell(7).SetCellValue(telefono);
            hojaRegistro.GetRow(10).GetCell(7).SetCellValue(objDatosReporte.clienteObservaciones);

            hojaRegistro.GetRow(12).GetCell(25).SetCellValue(objDatosReporte.productoCorte);
            hojaRegistro.GetRow(13).GetCell(7).SetCellValue(objDatosReporte.productoConversion);
            hojaRegistro.GetRow(13).GetCell(25).SetCellValue(objDatosReporte.productoGuillotinado);

            hojaRegistro.GetRow(28).GetCell(5).SetCellValue(objDatosReporte.productoReferencia);
            hojaRegistro.GetRow(28).GetCell(27).SetCellValue(objDatosReporte.productoCantTintas);
            hojaRegistro.GetRow(29).GetCell(5).SetCellValue(objDatosReporte.productoTroquel);
            hojaRegistro.GetRow(29).GetCell(19).SetCellValue(objDatosReporte.productoCabidaTroquel);
            hojaRegistro.GetRow(30).GetCell(5).SetCellValue(objDatosReporte.productoMaterial);
            hojaRegistro.GetRow(30).GetCell(24).SetCellValue(objDatosReporte.productoPantonesTiro);
            hojaRegistro.GetRow(31).GetCell(5).SetCellValue(objDatosReporte.productoPegues);
            hojaRegistro.GetRow(32).GetCell(5).SetCellValue(objDatosReporte.productoAcetatoVentanas);
            hojaRegistro.GetRow(33).GetCell(5).SetCellValue(objDatosReporte.productoAcabadoDer);
            hojaRegistro.GetRow(34).GetCell(5).SetCellValue(objDatosReporte.productoAcabadoRev);
            hojaRegistro.GetRow(34).GetCell(24).SetCellValue(objDatosReporte.productoPantonesRetiro);
            hojaRegistro.GetRow(35).GetCell(5).SetCellValue(objDatosReporte.productoDimenciones);
            hojaRegistro.GetRow(36).GetCell(5).SetCellValue(objDatosReporte.productoAccesorios);
            hojaRegistro.GetRow(37).GetCell(27).SetCellValue(objDatosReporte.productoPlanchas);
            hojaRegistro.GetRow(43).GetCell(0).SetCellValue(objDatosReporte.productoObservaiones);

            this.CargarImagenArteGraficoProducto(xssfworkbook, hojaRegistro, objDatosReporte.productoArchivoArteGrafico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xssfworkbook"></param>
        /// <param name="hojaRegistro"></param>
        /// <param name="nombreArchivo"></param>
        private void CargarImagenArteGraficoProducto(XSSFWorkbook xssfworkbook, ISheet hojaRegistro, string nombreArchivo)
        {
            if (!string.IsNullOrEmpty(nombreArchivo))
            {
                string rutaArchivoArteGrafico = Utilidades.RutaArtesGraficoProductos + nombreArchivo;
                byte[] data = System.IO.File.ReadAllBytes(rutaArchivoArteGrafico);
                int picInd = xssfworkbook.AddPicture(data, XSSFWorkbook.PICTURE_TYPE_JPEG);
                XSSFCreationHelper helper = xssfworkbook.GetCreationHelper() as XSSFCreationHelper;
                XSSFDrawing drawing = hojaRegistro.CreateDrawingPatriarch() as XSSFDrawing;
                XSSFClientAnchor anchor = helper.CreateClientAnchor() as XSSFClientAnchor;
                anchor.Col1 = 1;
                anchor.Row1 = 16;
                XSSFPicture pict = drawing.CreatePicture(anchor, picInd) as XSSFPicture;
                pict.Resize();
            }
        }
        #endregion

        #region [Métodos Comunes]
        /// <summary>
        /// 
        /// </summary>
        /// <param name="objDatosReporte"></param>
        /// <param name="correo"></param>
        /// <param name="telefono"></param>
        /// <param name="contacto"></param>
        private void ObtenerDatosContactoCliente(string clienteContactos, ref string correo, ref string telefono, ref string contacto)
        {
            JArray jsonArray = JArray.Parse(clienteContactos);

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
        private void AsignarPropiedadesReporte(NPOI.XSSF.UserModel.XSSFWorkbook xssfworkbook, string creador, string descripcion, string titulo, string clave)
        {
            NPOI.POIXMLProperties xmlProps = xssfworkbook.GetProperties();
            NPOI.CoreProperties coreprops = xmlProps.CoreProperties;

            coreprops.Created = DateTime.Now;
            coreprops.Creator = creador;
            coreprops.Description = descripcion;
            coreprops.Title = titulo;
            coreprops.Keywords = "ID seguimiento: " + clave;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <param name="workbookx"></param>
        /// <param name="clave"></param>
        private void BloquearHoja(ISheet s, XSSFWorkbook workbookx, string clave)
        {
            // cast the sheet to the appropriate type
            XSSFSheet sheet = ((XSSFSheet)s);

            //protect the sheet with a password
            sheet.ProtectSheet(clave);
            //enable the locking features
            sheet.EnableLocking();

            // fine tune the locking options (in this example we are blocking all operations on the cells: select, edit, etc.)
            sheet.LockSelectLockedCells();
            sheet.LockSelectUnlockedCells();
        }
        #endregion
    }
}
