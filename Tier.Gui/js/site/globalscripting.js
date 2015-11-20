var General = {
    GenerarGuid: function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
          s4() + '-' + s4() + s4() + s4();
    },
    CalcularDv: function (control) {
        var vpri, x, y, z, i, nit1, dv1;

        nit1 = $(control).val();

        if (isNaN(nit1)) {
            $(".identificacion-dv").text("X");
        } else {
            vpri = new Array(16);
            x = 0; y = 0; z = nit1.length;
            vpri[1] = 3;
            vpri[2] = 7;
            vpri[3] = 13;
            vpri[4] = 17;
            vpri[5] = 19;
            vpri[6] = 23;
            vpri[7] = 29;
            vpri[8] = 37;
            vpri[9] = 41;
            vpri[10] = 43;
            vpri[11] = 47;
            vpri[12] = 53;
            vpri[13] = 59;
            vpri[14] = 67;
            vpri[15] = 71;
            for (i = 0 ; i < z ; i++) {
                y = (nit1.substr(i, 1));
                //document.write(y+"x"+ vpri[z-i] +":");
                x += (y * vpri[z - i]);
                //document.write(x+"<br>");		
            }
            y = x % 11
            //document.write(y+"<br>");
            if (y > 1) {
                dv1 = 11 - y;
            } else {
                dv1 = y;
            }

            $(".identificacion-dv").text(dv1);
        }
    },
    RecupararMunicipiosXDepartamento: function (ctlOrigen, ctlDestino) {
        var iddepartamento = $('#' + ctlOrigen).val();

        $.ajax({
            method: "GET",
            url: URIs.MunicipiosXDepartamento,
            data: { idDepartamento: iddepartamento },
            async: false,
            success: function (data) {
                var strOpts = "<option value> -- Municipio -- </option>";
                $(data).each(function () {
                    strOpts = strOpts + '<option value="' + this.idmunicipio + '">' + this.nombre + '</option>';
                });

                $('#' + ctlDestino).empty();
                $('#' + ctlDestino).append(strOpts);
            },
            error: function (error) {
                alert(error)
            }
        });
    },
    showReg: function () {
        $("#login1").fadeOut("slow", function () {
            $("#register").fadeIn("slow");
        });
    },
    closeReg: function () {
        $("#register").fadeOut("slow", function () {
            $("#login1").fadeIn("slow");
        });
    },
    showLoad: function () {
        $("#contLoad").fadeIn();
        if (!$("#form0").valid()) {
            $("#contLoad").fadeOut();
        }
    },
    hideLoad: function () {
        $("#contLoad").fadeOut();
    }
}

var Seguridad = {
    RestablecerControlesLogin: function () {
        $("#txtUsuarioIniciar").val(null);
        $("#txtClaveIniciar").val(null);
        $("#ddlEmpresaIngresar").val(null);
        $("#contLoad").fadeOut();
    },
    RestablecerControlesClave: function () {
        $("#txtUsuarioRecuperar").val(null);
        $("#txtEmailRecuperar").val(null);
        $("#ddlEmpresaRecuperar").val(null);
        Seguridad.RestablecerControlesLogin();
    },
    ValidaInicioSesion: function (data) {
        if (data.blnResultado) {
            Seguridad.RestablecerControlesLogin();

            new PNotify({
                title: 'Correcto!',
                text: data.strMensaje,
                type: 'success'
            });

            setTimeout(function () {
                location.href = SiteUris.UriHome;
            }, 1000)
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: data.strMensaje
            });
            $("#contLoad").fadeOut();
            Seguridad.RestablecerControlesLogin();
        }
    },
    ValidaRestablecerClave: function (data) {
        if (data.blnResultado) {
            new PNotify({
                title: 'Correcto!',
                text: data.strMensaje,
                type: 'success'
            });

            Seguridad.RestablecerControlesClave();
            $(".separator .change_link .to_login")[0].click();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: data.strMensaje
            });
        }
    }
}

var Administracion = {
    AgregarPermisoRol: function (control) {
        var arrPermisos;
        var idFunc = $(control).attr("data-func");
        var idAcc = $(control).attr("data-acc");

        var objPermiso = { funcionalidad: idFunc, accion: idAcc };

        if ($("#hfdPermisosSeleccionados").val()) {
            arrPermisos = JSON.parse($("#hfdPermisosSeleccionados").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrPermisos).each(function () {
                if ((this.funcionalidad == idFunc) && (this.accion == idAcc)) {
                    intIndice = $(arrPermisos).index(this);
                }
            });

            if (intIndice >= 0)
                arrPermisos.splice(intIndice, 1);
            else
                arrPermisos.push(objPermiso);
        }
        else {
            arrPermisos = new Array();
            arrPermisos.push(objPermiso);
        }

        $("#hfdPermisosSeleccionados").val(JSON.stringify(arrPermisos));
    },
    AbrirFormularioCreaItem: function () {
        if ($("#grupo").val()) {
            $('#divlistasform').show();
            $('#divlistasmain').hide();
        }
        else {
            new PNotify({
                title: 'Información',
                text: 'No se ha seleccionado una lista.',
                type: 'info'
            });
        }
    },
    AbrirFormularioEditarItemLista: function (iditemlista, grupo) {
        $.ajax({
            method: "GET",
            url: URIs.AdminEditarItemLista,
            data: { iditem: iditemlista, idgrupo: grupo },
            async: false,
            success: function (itemRs) {
                console.log(itemRs);
                $($("#diveditarlistasform").find("#grupo")).val(itemRs[0].grupo);
                if ($($("#diveditarlistasform").find("#grupo")).val()) {
                    $($("#diveditarlistasform").find("#nombre")).val(itemRs[0].nombre);
                    $($("#diveditarlistasform").find("#nombreinicial")).val(itemRs[0].nombre);
                    $($("#diveditarlistasform").find("#iditemlista")).val(itemRs[0].iditemlista);

                    $($("#diveditarlistasform").find("#activo")).prop('checked', itemRs[0].activo);

                    $('#diveditarlistasform').show();
                    $('#divlistasmain').hide();
                }
                else {
                    new PNotify({
                        title: 'Información',
                        text: 'No se ha seleccionado una lista.',
                        type: 'info'
                    });
                }
            },
            error: function (error) {
                alert(error)
            }
        });

    },

    CerrarFormularioCreaItem: function () {
        $("#btnResetForm").click();
        $('#divlistasmain').show();
        $('#divlistasform').hide();
        $('#diveditarlistasform').hide();
    },
    EstablecerGrupoListaitems: function (idGrupo) {
        $("#grupo").val(idGrupo)
    },
    RolSeleccionarCheckbox: function () {
        if ($("#hfdPermisosSeleccionados").val()) {
            arrPermisos = JSON.parse($("#hfdPermisosSeleccionados").val());
            $(arrPermisos).each(function () {
                var strNombreControl = '#chkPermiso_' + this.funcionalidad + '_' + this.accion;
                $(strNombreControl).prop("checked", "checked");
            });
        }
    },
    MarcarTodosPermidos: function () {
        var arrPermisos = new Array();

        $("input[type='checkbox'][id^='chkPermiso_']").each(function () {
            $(this).prop("checked", true);

            var idFunc = $(this).attr("data-func");
            var idAcc = $(this).attr("data-acc");

            var objPermiso = { funcionalidad: idFunc, accion: idAcc };
            arrPermisos.push(objPermiso);
        });

        $("#hfdPermisosSeleccionados").val(JSON.stringify(arrPermisos));
    },
    DesmarcarTodosPermidos: function () {
        $("input[type='checkbox'][id^='chkPermiso_']").each(function () {
            $(this).prop("checked", false);
            //$(this).change();
        });

        $("#hfdPermisosSeleccionados").val("[]");
    }
}

var Produccion = {
    RestablecerControlesCfgProduccion: function () {
        $("#hfdIdCfgProduccion").val(null);

        $("#txtPH").val(null);
        $("#ddlPHUm").val(null);

        $("#txtTA").val(null);
        $("#txtPNombre").val(null);
    },
    AgregarConfiguracion: function () {
        if ($('#frmCfgProduccion').valid()) {
            var arrVariacaciones;

            var strid = $("#hfdIdCfgProduccion").val();

            var intpvnombre = $("#txtPNombre").val();
            var intph = $("#txtPH").val();
            var intphun = $("#ddlPHUm").val();
            var strphunnomb = $("#ddlPHUm option:selected").text();

            var intta = $("#txtTA").val();

            var objCfg = { id: strid, ph: intph, phun: intphun, phunnomb: strphunnomb, ta: intta, pvnombre: intpvnombre };

            if ($("#hfdCfgProduccion").val()) {
                //Manejo arreglo JSON
                arrVariacaciones = JSON.parse($("#hfdCfgProduccion").val());

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;
                $(arrVariacaciones).each(function () {
                    if ((this.id == objCfg.id)) {
                        intIndice = $(arrVariacaciones).index(this);
                    }
                });

                if (intIndice >= 0) {
                    arrVariacaciones.splice(intIndice, 1);
                    arrVariacaciones.push(objCfg);
                }
                else {
                    objCfg.id = General.GenerarGuid();
                    arrVariacaciones.push(objCfg);
                }

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });
            }
            else {
                //Manejo arreglo JSON
                arrVariacaciones = new Array();

                objCfg.id = General.GenerarGuid();
                arrVariacaciones.push(objCfg);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });

            }

            $("#hfdCfgProduccion").val(JSON.stringify(arrVariacaciones));

            Produccion.RestablecerControlesCfgProduccion();
            Produccion.CargarTablaProduccion();
        }
    },
    CargarTablaProduccion: function () {
        $(".x_content .varprod").empty();
        var strContenido;

        if ($("#hfdCfgProduccion").val()) {
            var arrVariacaciones = JSON.parse($("#hfdCfgProduccion").val());
            strContenido = '<table id="tblDatosProduccion">';

            strContenido = strContenido
                + '<thead>'
                + '<tr>'
                + '<th></th>'
                + '<th style="text-align: center;">Nombre</th>'
                + '<th style="text-align: center;">Cantidad</th>'
                + '<th style="text-align: center;">Unidad medida</th>'
                + '<th style="text-align: center;">Tiempo</th>'
                + '<th style="text-align: center;">Unidad medida</th>'
                + '</tr>'
                + '</thead>';

            strContenido = strContenido + '<tbody>';

            $(arrVariacaciones).each(function () {
                strContenido = strContenido + '<tr data-idvp=\"' + this.id + '\">';

                strContenido = strContenido + '<td>';
                strContenido = strContenido + '<ul class="nav navbar-right panel_toolbox">';

                if (isNaN(this.id)) {
                    strContenido = strContenido + '<li><a href="#" onclick="Produccion.EliminarCfgProduccion(this);"><i class="fa fa-minus"></i></a></li>';
                }

                strContenido = strContenido + '<li><a href="#" onclick="Produccion.CargarModalCfgProduccion(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';
                strContenido = strContenido + '<td>' + this.pvnombre + '</td>';
                strContenido = strContenido + '<td>' + this.ph + '</td>';
                strContenido = strContenido + '<td>' + this.phunnomb + '</td>';
                strContenido = strContenido + '<td>' + this.ta + '</td>';
                strContenido = strContenido + '<td>Minutos</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $(".x_content .varprod").html(strContenido);
            $("#tblDatosProduccion").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han configurado variaciones de produción</span></div>';
            $(".x_content .varprod").html(strContenido);
        }
    },
    CargarModalCfgProduccion: function (control) {
        var objFila = $(control).parents("tr");
        var idCfg = $(objFila).data("idvp");

        var arrVariacaciones = JSON.parse($("#hfdCfgProduccion").val());

        var objCfg;
        $(arrVariacaciones).each(function () {
            if (this.id == idCfg) {
                objCfg = this;
            }
        });

        if (!objCfg) {
            new PNotify({
                title: 'Advertencia!',
                text: 'No fue posible recuperar el id del registro.',
                type: 'notice'
            });

            return false;
        }

        $("#hfdIdCfgProduccion").val(objCfg.id);
        $("#txtPH").val(objCfg.ph);
        $("#ddlPHUm").val(objCfg.phun);
        $("#txtTA").val(objCfg.ta);
        $("#txtPNombre").val(objCfg.pvnombre);

        $(".bs-example-modal-sm1").modal("show");
    },
    EliminarCfgProduccion: function (control) {
        var objFila = $(control).parents("tr");
        var idCfg = $(objFila).data("idvp");

        if ($("#hfdCfgProduccion").val()) {
            var arrVariacaciones = JSON.parse($("#hfdCfgProduccion").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrVariacaciones).each(function () {
                if ((this.id == idCfg)) {
                    intIndice = $(arrVariacaciones).index(this);
                }
            });

            if (intIndice >= 0) {
                arrVariacaciones.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado la configuración de producción.',
                    type: 'success'
                });
            }

            $("#hfdCfgProduccion").val(JSON.stringify(arrVariacaciones));
            Produccion.CargarTablaProduccion();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }
    },

    RestablecerControlesDatosPeriodicos: function () {
        $("#hfdIdDatosPeriodicos").val(null);

        $("#ddlPeriodo").val(null);
        $("#txtAvaluo").val(null);
        $("#txtPresupuesto").val(null);
        $("#txtTM").val(null);
    },
    AgregarDatoPeriodico: function () {
        if ($('#frmDatosPeriodicos').valid()) {
            var arrDatosPeriodicos;

            var strid = $("#hfdIdDatosPeriodicos").val();

            var intperiodo = $("#ddlPeriodo").val();
            var strperiodonomb = $("#ddlPeriodo option:selected").text();

            var intavaluo = $("#txtAvaluo").val();
            var intpresupuesto = $("#txtPresupuesto").val();

            var inttm = $("#txtTM").val();

            var objDatoPeriodico = {
                id: strid, periodo: intperiodo, periodonomb: strperiodonomb,
                avaluo: intavaluo, presupuesto: intpresupuesto, tm: inttm
            };

            if ($("#hfdDatosPeriodicos").val()) {
                //Manejo arreglo JSON
                arrDatosPeriodicos = JSON.parse($("#hfdDatosPeriodicos").val());

                //Validar si ya se ha agregado un dato para el periodo seleccionado.
                var blnExisteDatoPeriodo = false;
                //Se valida si se esta editando un dato periodico.
                if (!objDatoPeriodico.id) {
                    $(arrDatosPeriodicos).each(function () {
                        if (this.periodo == objDatoPeriodico.periodo) {
                            blnExisteDatoPeriodo = true;
                        }
                    });
                }

                if (blnExisteDatoPeriodo) {
                    new PNotify({
                        title: 'Advertencia!',
                        text: 'Ya se ha registrado información para el periodos seleccionado.',
                        type: 'error'
                    });

                    return false;
                }

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;
                $(arrDatosPeriodicos).each(function () {
                    if (this.id == objDatoPeriodico.id) {
                        intIndice = $(arrDatosPeriodicos).index(this);
                    }
                });

                if (intIndice >= 0) {
                    arrDatosPeriodicos.splice(intIndice, 1);
                    arrDatosPeriodicos.push(objDatoPeriodico);
                }
                else {
                    objDatoPeriodico.id = General.GenerarGuid();
                    arrDatosPeriodicos.push(objDatoPeriodico);
                }

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado el dato del pereriodo.',
                    type: 'success'
                });
            }
            else {
                //Manejo arreglo JSON
                arrDatosPeriodicos = new Array();

                objDatoPeriodico.id = General.GenerarGuid();
                arrDatosPeriodicos.push(objDatoPeriodico);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado el dato del pereriodo.',
                    type: 'success'
                });

            }

            $("#hfdDatosPeriodicos").val(JSON.stringify(arrDatosPeriodicos));

            Produccion.RestablecerControlesDatosPeriodicos();
            Produccion.CargarTablaDatosPeriodicos();
        }
    },
    CargarTablaDatosPeriodicos: function () {
        $(".x_content .datper").empty();
        var strContenido;

        if ($("#hfdDatosPeriodicos").val()) {
            var arrDatosPeriodicos = JSON.parse($("#hfdDatosPeriodicos").val());
            strContenido = '<table id="tblDatosPeriodicos">';

            strContenido = strContenido
                + '<thead>'
                + '<tr>'
                + '<th></th>'
                + '<th style="text-align: center;">Periodo</th>'
                + '<th style="text-align: center;">Avaluo</th>'
                + '<th style="text-align: center;">Presupuesto</th>'
                + '<th style="text-align: center;">Timepo Mtto</th>'
                + '<th style="text-align: center;">Unidad medida</th>'
                + '</tr>'
                + '</thead>';

            strContenido = strContenido + '<tbody>';

            $(arrDatosPeriodicos).each(function () {
                strContenido = strContenido + '<tr data-iddp=\"' + this.id + '\">';

                strContenido = strContenido + '<td>';
                strContenido = strContenido + '<ul class="nav navbar-right panel_toolbox">';

                if (isNaN(this.id)) {
                    strContenido = strContenido + '<li><a href="#" onclick="Produccion.EliminarDatosPeriodicos(this);"><i class="fa fa-minus"></i></a></li>';
                }

                strContenido = strContenido + '<li><a href="#" onclick="Produccion.CargarModalDatosPeriodicos(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';

                strContenido = strContenido + '<td style="text-align: center;">' + this.periodonomb + '</td>';
                strContenido = strContenido + '<td style="text-align: right;">' + this.avaluo + '</td>';
                strContenido = strContenido + '<td style="text-align: right;">' + this.presupuesto + '</td>';
                strContenido = strContenido + '<td>' + this.tm + '</td>';
                strContenido = strContenido + '<td>Horas</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $(".x_content .datper").html(strContenido);
            $("#tblDatosPeriodicos").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han agregado datos periódicos</span></div>';
            $(".x_content .datper").html(strContenido);
        }
    },
    CargarModalDatosPeriodicos: function (control) {
        var objFila = $(control).parents("tr");
        var idDato = $(objFila).data("iddp");

        var arrDatosPeriodicos = JSON.parse($("#hfdDatosPeriodicos").val());

        //Validar si ya se ha agregado un dato para el periodo seleccionado.
        var objDatoPeriodo;
        $(arrDatosPeriodicos).each(function () {
            if (this.id == idDato) {
                objDatoPeriodo = this;
            }
        });

        if (!objDatoPeriodo) {
            new PNotify({
                title: 'Advertencia!',
                text: 'No fue posible recuperar el id del registro.',
                type: 'notice'
            });

            return false;
        }

        $("#hfdIdDatosPeriodicos").val(objDatoPeriodo.id);
        $("#ddlPeriodo").val(objDatoPeriodo.periodo);
        $("#txtAvaluo").val(objDatoPeriodo.avaluo);
        $("#txtPresupuesto").val(objDatoPeriodo.presupuesto);
        $("#txtTM").val(objDatoPeriodo.tm);

        $(".bs-example-modal-sm2").modal("show");
    },
    EliminarDatosPeriodicos: function (control) {
        var objFila = $(control).parents("tr");
        var iddp = $(objFila).data("iddp");

        if ($("#hfdDatosPeriodicos").val()) {
            var arrDatosPeriodicos = JSON.parse($("#hfdDatosPeriodicos").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrDatosPeriodicos).each(function () {
                if ((this.id == iddp)) {
                    intIndice = $(arrDatosPeriodicos).index(this);
                }
            });

            if (intIndice >= 0) {
                arrDatosPeriodicos.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado el dato periódico.',
                    type: 'success'
                });
            }

            $("#hfdDatosPeriodicos").val(JSON.stringify(arrDatosPeriodicos));
            Produccion.CargarTablaDatosPeriodicos();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }
    },

    AgregarVentana: function () {
        if ($('#frmGesationVentanas').valid()) {
            var arrVentanas;

            var strid = $("#hfdIdVentana").val();
            var strlargo = $("#txtLargo").val();
            var stralto = $("#txtAlto").val();
            var stractivo = $("#hfdActivoVentana").val() ? $("#hfdActivoVentana").val() : null;
            var stridtroquel = $("#hfdIdTroquelVentana").val() ? $("#hfdIdTroquelVentana").val() : null;

            var objVentana = { id: strid, Largo: strlargo, Alto: stralto, Activo: stractivo, Troquel: stridtroquel };

            if ($("#hfdVentanas").val()) {
                //Manejo arreglo JSON
                arrVentanas = JSON.parse($("#hfdVentanas").val());

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;
                $(arrVentanas).each(function () {
                    if ((this.id == objVentana.id)) {
                        intIndice = $(arrVentanas).index(this);
                    }
                });

                if (intIndice >= 0) {
                    arrVentanas.splice(intIndice, 1);
                    arrVentanas.push(objVentana);
                }
                else {
                    objVentana.id = General.GenerarGuid();
                    arrVentanas.push(objVentana);
                }

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });
            }
            else {
                //Manejo arreglo JSON
                arrVentanas = new Array();

                objVentana.id = General.GenerarGuid();
                arrVentanas.push(objVentana);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });

            }

            $("#hfdVentanas").val(JSON.stringify(arrVentanas));

            Produccion.RestablecerControlesVentanas();
        }
    },
    RestablecerControlesVentanas: function () {
        $("#hfdIdVentana").val(null);
        $("#txtLargo").val(null);
        $("#txtAlto").val(null);
        $("#hfdActivoVentana").val(null);
        $("#hfdIdTroquelVentana").val(null);
    },
    CargarTablaVentanas: function () {
        $(".x_content .ventanas").empty();
        var strContenido;

        if ($("#hfdVentanas").val()) {
            var arrVentanas = JSON.parse($("#hfdVentanas").val());
            strContenido = '<table class="center-margin" id="tblVentanas" style="width: 400px;">';

            strContenido = strContenido
                + '<thead>'
                + '<tr>'
                + '<th></th>'
                + '<th style="text-align: center;">Largo</th>'
                + '<th style="text-align: center;">Alto</th>'
                + '</tr>'
                + '</thead>';

            strContenido = strContenido + '<tbody>';

            $(arrVentanas).each(function () {
                strContenido = strContenido + '<tr data-idv=\"' + this.id + '\">';

                strContenido = strContenido + '<td>';
                strContenido = strContenido + '<ul class="nav navbar-right panel_toolbox">';

                if (isNaN(this.id)) {
                    strContenido = strContenido + '<li><a href="#" onclick="Produccion.EliminarVentana(this);"><i class="fa fa-minus"></i></a></li>';
                }

                strContenido = strContenido + '<li><a href="#" onclick="Produccion.CargarModalVentana(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';

                strContenido = strContenido + '<td style="text-align: center;">' + this.Largo + '</td>';
                strContenido = strContenido + '<td style="text-align: center;">' + this.Alto + '</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $(".x_content .ventanas").html(strContenido);
            $("#tblVentanas").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han agregado ventanas</span></div>';
            $(".x_content .ventanas").html(strContenido);
        }
    },
    EliminarVentana: function (control) {
        var objFila = $(control).parents("tr");
        var idv = $(objFila).data("idv");

        if ($("#hfdVentanas").val()) {
            var arrVentanas = JSON.parse($("#hfdVentanas").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrVentanas).each(function () {
                if ((this.id == idv)) {
                    intIndice = $(arrVentanas).index(this);
                }
            });

            if (intIndice >= 0) {
                arrVentanas.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado la ventana.',
                    type: 'success'
                });
            }

            $("#hfdVentanas").val(JSON.stringify(arrVentanas));
            Produccion.CargarTablaVentanas();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }
    },
    CargarModalVentana: function (control) {
        var objFila = $(control).parents("tr");
        var idv = $(objFila).data("idv");

        var arrVentanas = JSON.parse($("#hfdVentanas").val());

        //Validar si ya se ha agregado un dato para el periodo seleccionado.
        var objVentana;
        $(arrVentanas).each(function () {
            if (this.id == idv) {
                objVentana = this;
            }
        });

        if (!objVentana) {
            new PNotify({
                title: 'Advertencia!',
                text: 'No fue posible recuperar el id del registro.',
                type: 'notice'
            });

            return false;
        }

        $("#hfdIdVentana").val(objVentana.id);
        $("#txtLargo").val(objVentana.Largo);
        $("#txtAlto").val(objVentana.Alto);
        $("#hfdActivoVentana").val(objVentana.Activo);
        $("#hfdIdTroquelVentana").val(objVentana.Troquel);

        $(".bs-example-modal-sm1").modal("show");
    },
    AbrirSelectImagen: function () {
        $("#imgFile").click();
    },
    ValidaExtenImg: function (obj) {
        var nameFile = $(obj).val().split('.');
        var extenFile = jQuery.trim(nameFile[nameFile.length - 1]);
        var extenValid = ["png", "jpeg", "jpg", "ico", "tif"];
        var resp = false;
        jQuery.each(extenValid, function (idx, val) {
            if (extenFile == val) {
                resp = true;
                $("#nombreimagen").val($(obj).val().toString().split('\\')[$(obj).val().toString().split('\\').length - 1]);
            }
        });
        if (!resp) {
            $(obj).val("");
            $("#nombreimagen").val("");
        }
    },


    RestablecerControlesProveedores: function () {
        $("#hfdIdCfgProduccion").val(null);

        $("#txtPH").val(null);
        $("#ddlPHUm").val(null);

        $("#txtTA").val(null);
        $("#ddlTAUm").val(null);
        $("#txtPNombre").val(null);
    },
    AbrirModalProveedorLinea: function () {
        Produccion.RestaurarModalProveedorLinea();
        $(".bs-example-modal-sm1").modal("show");
    },
    AgregarProveedorLinea: function () {
        if ($('#frmNwProvLinea').valid()) {

            var arrayProvLinea;

            var idProvLinea = $("#guidProvLinea").val();
            var nombreProvLinea = $("#nombreProvLinea").val();
            var activo = $("#activoLinea").prop('checked');


            var objProvsLineas = {
                id: idProvLinea, nombreLinea: nombreProvLinea, activo: activo
            };

            if ($("#hfdlineas").val()) {
                //Arreglo JSON
                arrayProvLinea = JSON.parse($("#hfdlineas").val());

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;
                $(arrayProvLinea).each(function () {
                    if ((this.id == objProvsLineas.id)) {
                        intIndice = $(arrayProvLinea).index(this);
                    }
                });

                if (intIndice >= 0) {
                    arrayProvLinea.splice(intIndice, 1);
                    arrayProvLinea.push(objProvsLineas);
                }
                else {
                    objProvsLineas.id = General.GenerarGuid();
                    arrayProvLinea.push(objProvsLineas);
                }
                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la linea.',
                    type: 'success'
                });

            }
            else {
                //Manejo arreglo JSON
                arrayProvLinea = new Array();

                objProvsLineas.id = General.GenerarGuid();
                arrayProvLinea.push(objProvsLineas);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la linea.',
                    type: 'success'
                });
            }

            $("#hfdlineas").val(JSON.stringify(arrayProvLinea));
            Produccion.CargarTablaProveedorLinea();
            Produccion.RestaurarModalProveedorLinea();
        }
    },
    EliminarProveedorLinea: function (control) {
        var objFila = $(control).parents("tr");
        var idPrvLn = $(objFila).data("idvp");

        if ($("#hfdlineas").val()) {
            var arrayProvLinea = JSON.parse($("#hfdlineas").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrayProvLinea).each(function () {
                if ((this.id == idPrvLn)) {
                    intIndice = $(arrayProvLinea).index(this);
                }
            });

            if (intIndice >= 0) {
                arrayProvLinea.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado la linea.',
                    type: 'success'
                });
            }

            $("#hfdlineas").val(JSON.stringify(arrayProvLinea));
            Produccion.CargarTablaProveedorLinea();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }
    },
    CargarModalProveedorLinea: function (control) {
        var objFila = $(control).parents("tr");
        var idPrvLn = $(objFila).data("idvp");

        arrayProvLinea = JSON.parse($("#hfdlineas").val());

        var objProvLinea;

        $(arrayProvLinea).each(function () {
            if (this.id == idPrvLn) {
                objProvLinea = this;
            }
        });

        if (!objProvLinea) {
            new PNotify({
                title: 'Advertencia!',
                text: 'No fue posible recuperar el id del registro.',
                type: 'notice'
            });
        }
        else {
            $("#guidProvLinea").val(objProvLinea.id);
            $("#nombreProvLinea").val(objProvLinea.nombreLinea);
            var activo = $("#activoLinea").prop('checked', objProvLinea.activo);
            $(".bs-example-modal-sm1").modal("show");
        }
    },

    CargarTablaProveedorLinea: function () {
        $("#divTblProvLineas").empty();
        var strContenido;

        if ($("#hfdlineas").val().length > 2) {
            var arrayProvLinea = JSON.parse($("#hfdlineas").val());
            strContenido = '<table id="tblProvLineas">';

            strContenido = strContenido
                + '<thead>'
                + '<tr>'
                + '<th></th>'
                + '<th style="text-align: center;">Nombre</th>'
                + '<th style="text-align: center;">Activo</th>'
                + '</tr>'
                + '</thead>';

            strContenido = strContenido + '<tbody>';

            $(arrayProvLinea).each(function () {
                strContenido = strContenido + '<tr data-idvp=\"' + this.id + '\">';

                strContenido = strContenido + '<td>';
                strContenido = strContenido + '<ul class="nav navbar-right panel_toolbox">';

                if (isNaN(this.id)) {
                    strContenido = strContenido + '<li><a href="#" onclick="Produccion.EliminarProveedorLinea(this);"><i class="fa fa-minus"></i></a></li>';
                }

                strContenido = strContenido + '<li><a href="#" onclick="Produccion.CargarModalProveedorLinea(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';

                strContenido = strContenido + '<td>' + this.nombreLinea + '</td>';
                var actv = (this.activo) ? 'checked />' : '/>';
                strContenido = strContenido + '<td> <input type="checkbox" disabled  ' + actv + '</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $("#divTblProvLineas").html(strContenido);
            $("#tblProvLineas").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han ingresado lineas</span></div>';
            $("#divTblProvLineas").html(strContenido);
        }
    },
    RestaurarModalProveedorLinea: function () {
        $("#guidProvLinea").val(null);
        $("#nombreProvLinea").val(null);
        $("#activoLinea").prop('checked', true);
    },
    RecuperarLineasProveedor: function (ctlOrigen, ctlDestino) {
        var idproveedor = $('#' + ctlOrigen).val();

        $.ajax({
            method: "POST",
            url: URIs.LineasProveedor,
            data: { idProveedor: idproveedor },
            async: false,
            success: function (data) {
                var strOpts = "<option value> -- Linea -- </option>";
                $(data).each(function () {
                    strOpts = strOpts + '<option value="' + this.idproveedor_linea + '">' + this.nombre + '</option>';
                });

                $('#' + ctlDestino).empty();
                $('#' + ctlDestino).append(strOpts);
            },
            error: function (error) {
                alert(error)
            }
        });
    },

    //Productos
    AgregarProductoAccesorio: function () {

    },
    EliminaProductoAccesorio: function() {

    },
    CargaTablaListaProductoAccesorio: function() {

    }
}

var Comercial = {
    RestablecerControlesContactos: function () {
        $("#hfdIdContacto").val(null);
        $("#ddlTipoContacto").val(null);
        $("#txtNombre").val(null);
        $("#txtEmail").val(null);
        $("#txtTelefono").val(null);
        $("#txtCelular").val(null);
        $("#txtDireccion").val(null);
    },
    AgregarContacto: function () {
        if ($('#frmGesationContactos').valid()) {
            var arrContactos;

            var strid = $("#hfdIdContacto").val();
            var strtipo = $("#ddlTipoContacto").val();
            var strnombre = $("#txtNombre").val();
            var stremail = $("#txtEmail").val();
            var strtelefono = $("#txtTelefono").val();
            var strcelular = $("#txtCelular").val();
            var strdireccion = $("#txtDireccion").val();

            var objContacto = { id: strid, Tipo: strtipo, Nombre: strnombre, EMail: stremail, Telefono: strtelefono, Celular: strcelular, Direccion: strdireccion };

            if ($("#contactos").val()) {
                //Manejo arreglo JSON
                arrContactos = JSON.parse($("#contactos").val());

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;
                $(arrContactos).each(function () {
                    if ((this.id == objContacto.id)) {
                        intIndice = $(arrContactos).index(this);
                    }
                });

                if (intIndice >= 0) {
                    arrContactos.splice(intIndice, 1);
                    arrContactos.push(objContacto);
                }
                else {
                    objContacto.id = General.GenerarGuid();
                    arrContactos.push(objContacto);
                }

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });
            }
            else {
                //Manejo arreglo JSON
                arrContactos = new Array();

                objContacto.id = General.GenerarGuid();
                arrContactos.push(objContacto);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });

            }

            $("#contactos").val(JSON.stringify(arrContactos));

            Comercial.RestablecerControlesContactos();
        }
    },
    CargarContactos: function () {
        $(".x_content .contactos").empty();
        var strContenido;

        if ($("#contactos").val()) {
            var arrcontactos = JSON.parse($("#contactos").val());
            strContenido = '<ul class="list-unstyled top_profiles scroll-view" style="overflow-x: auto; outline: none; cursor: -webkit-grab;columns: 2; -webkit-columns: 2; -moz-columns: 2;">';
            $(arrcontactos).each(function () {
                strContenido = strContenido + '<li class="media event">';
                strContenido = strContenido + '<a class="pull-right border-aero profile_thumb">';
                strContenido = strContenido + '<i class="fa fa-user blue"></i>';
                strContenido = strContenido + '</a>';
                strContenido = strContenido + '<div class="media-body">';
                strContenido = strContenido + '<a class="title" href="#" onclick="Comercial.CargarDatosContacto(\'' + this.id + '\')">' + this.Nombre + '</a>';
                strContenido = strContenido + '<p><span class="fa fa-envelope" aria-hidden="true"></span>&nbsp;<small>' + (this.EMail ? this.EMail : 'No registra') + '</small></p>';
                strContenido = strContenido + '<p><span class="fa fa-phone" aria-hidden="true"></span>&nbsp;<small>' + (this.Telefono ? this.Telefono : 'No registra') + '</small>&nbsp&nbsp<span class="fa fa-mobile" aria-hidden="true"></span>&nbsp;<small>' + (this.Celular ? this.Celular : 'No registra') + '</small></p>';
                //strContenido = strContenido + '<p></p>';
                strContenido = strContenido + '<p><span class="fa fa-crosshairs" aria-hidden="true"></span>&nbsp;<small>' + (this.Direccion ? this.Direccion : 'No registra') + '</small></p>';
                strContenido = strContenido + '</div>';
                strContenido = strContenido + '</li>';
            });
            strContenido = strContenido + '</ul>';

            $(".x_content .contactos").html(strContenido);
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han agregado contactos</span></div>';
            $(".x_content .contactos").html(strContenido);
        }
    },
    CargarDatosContacto: function (idContacto) {
        if ($("#contactos").val()) {
            //Manejo arreglo JSON
            arrContactos = JSON.parse($("#contactos").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var objContacto;
            $(arrContactos).each(function () {
                if ((this.id == idContacto)) {
                    objContacto = this;
                }
            });

            if (!objContacto) {
                new PNotify({
                    title: 'Advertencia!',
                    text: 'No fue posible recuperar el id del registro.',
                    type: 'notice'
                });

                return false;
            }

            $("#hfdIdContacto").val(objContacto.id);
            $("#ddlTipoContacto").val(objContacto.Tipo);
            $("#txtNombre").val(objContacto.Nombre);
            $("#txtEmail").val(objContacto.EMail);
            $("#txtTelefono").val(objContacto.Telefono);
            $("#txtCelular").val(objContacto.Celular);
            $("#txtDireccion").val(objContacto.Direccion);

            $(".bs-example-modal-sm1").modal("show");
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay contactos registrados.',
                type: 'notice'
            });
        }
    },
    EliminarContacto: function () {
        if ($("#contactos").val()) {
            //Manejo arreglo JSON
            arrContactos = JSON.parse($("#contactos").val());
            var idContacto = $("#hfdIdContacto").val();

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrContactos).each(function () {
                if ((this.id == idContacto)) {
                    intIndice = $(arrContactos).index(this);
                }
            });

            if (intIndice >= 0) {
                arrContactos.splice(intIndice, 1);
                $("#contactos").val(JSON.stringify(arrContactos));

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado el contacto',
                    type: 'success'
                });
            }
            else {
                new PNotify({
                    title: 'Advertencia!',
                    text: 'No se encontro el contacto.',
                    type: 'notice'
                });
            }

            Comercial.RestablecerControlesContactos();
            Comercial.CargarContactos();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay contactos registrados.',
                type: 'notice'
            });
        }
    },
    CargarContactosAgenda: function () {
        $(".x_content .contactos").empty();
        var strContenido = '';

        if ($("#contactos").val()) {
            var arrcontactos = JSON.parse($("#contactos").val());

            $(arrcontactos).each(function () {
                strContenido = strContenido + '<div class="col-md-6 col-sm-6 col-xs-12 animated fadeInDown">';
                strContenido = strContenido + '<div class="well profile_view">';

                strContenido = strContenido + '<div class="col-sm-12">';
                strContenido = strContenido + '<h4 class="brief"><i>[Tipo]</i></h4>';
                strContenido = strContenido + '<div class="left col-xs-7">';
                strContenido = strContenido + '<h2>' + this.Nombre + '</h2>';
                strContenido = strContenido + '<ul class="list-unstyled">';
                strContenido = strContenido + '<li><p><span class="fa fa-envelope" aria-hidden="true"></span>&nbsp;<small>' + (this.EMail ? this.EMail : 'No registra') + '</small></p></li>';
                strContenido = strContenido + '<li><p><span class="fa fa-phone" aria-hidden="true"></span>&nbsp;<small>' + (this.Telefono ? this.Telefono : 'No registra') + '</small>&nbsp;&nbsp;<span class="fa fa-mobile" aria-hidden="true"></span>&nbsp;<small>' + (this.Celular ? this.Celular : 'No registra') + '</small></p></li>';
                strContenido = strContenido + '<li><p><span class="fa fa-crosshairs" aria-hidden="true"></span>&nbsp;<small>' + (this.Direccion ? this.Direccion : 'No registra') + '</small></p></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</div>';

                strContenido = strContenido + '<div class="right col-xs-5 text-center">';
                strContenido = strContenido + '<img class="img-circle img-responsive" alt="" src="' + URIs.Imagenes + 'user.png")">';
                strContenido = strContenido + '</div>';

                strContenido = strContenido + '</div>';

                strContenido = strContenido + '<div class="col-xs-12 bottom text-center">';
                strContenido = strContenido + '<div class="col-xs-12 col-sm-6 emphasis pull-right">';
                //strContenido = strContenido + '<button class="btn btn-primary btn-xs" type="button"><i class="fa fa-pencil"></i>&nbsp;Editar</button>';
                //strContenido = strContenido + '<button class="btn btn-danger btn-xs" type="button"><i class="fa fa-minus"></i>&nbsp;Eliminar</button>';
                strContenido = strContenido + '</div>';
                strContenido = strContenido + '</div>';

                strContenido = strContenido + '</div>';
                strContenido = strContenido + '</div>';
            });

            $(".x_content .contactos").html(strContenido);
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han agregado contactos</span></div>';
            $(".x_content .contactos").html(strContenido);
        }
    }
}