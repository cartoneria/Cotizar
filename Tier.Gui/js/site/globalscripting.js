var dataProd = {
    pantones: [],
    pantSelecDoughnut: []
}

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
    },

    CargarTablaParametros: function (arrParametros) {
        $(".x_content .periparams").empty();
        var strContenido;

        strContenido = '<table id="tblParametrosPeriodo">';

        strContenido = strContenido
            + '<thead>'
            + '<tr>'
            + '<th style="text-align: center;">Nombre</th>'
            + '<th style="text-align: center;">Tipo</th>'
            + '<th style="text-align: center;">Descripción</th>'
            + '<th style="text-align: center;">Valor</th>'
            + '</tr>'
            + '</thead>';

        strContenido = strContenido + '<tbody>';

        $(arrParametros).each(function () {
            strContenido = strContenido + '<tr>';

            strContenido = strContenido + '<td>' + this.nombre + '</td>';
            switch (this.tipo) {
                case 1: //Numérico
                    strContenido = strContenido + '<td>Numérico</td>';
                    break;
                case 2: //Texto
                    strContenido = strContenido + '<td>Texto</td>';
                    break;
                case 3: //Fecha
                    strContenido = strContenido + '<td>Fecha</td>';
                    break;
                case 4: //Boleano
                    strContenido = strContenido + '<td>Boleano</td>';
                    break;
                default:
                    strContenido = strContenido + '<td>N/A</td>';
            }

            strContenido = strContenido + '<td>' + this.descripcion + '</td>';

            switch (this.tipo) {
                case 1: //Numero
                    strContenido = strContenido + '<td>'
                        + '<input type="text" class="form-control" id="txtParam_'
                        + this.nombre + '" name="txtParam_'
                        + this.nombre + '" '
                        + 'value="0" />'
                        + '</td>';
                    break;
                case 2: //Texto
                    strContenido = strContenido + '<td>'
                        + '<input type="text" class="form-control" id="txtParam_'
                        + this.nombre + '" name="txtParam_'
                        + this.nombre + '" value="" />'
                        + '</td>';
                    break;
                case 3: //Fecha
                    strContenido = strContenido + '<td>'
                        + '<input type="text" class="form-control" id="txtParam_'
                        + this.nombre + '" name="txtParam_'
                        + this.nombre + '" value="" />'
                        + '</td>';

                    strContenido = strContenido + '<script>'
                    + '$("#txtParam_' + this.nombre + '").daterangepicker({'
                        + 'singleDatePicker: true,'
                        + 'showDropdowns: true,'
                        + 'calender_style: "picker_2"'
                    + '}, function (start, end, label) {'
                    + '});';
                    strContenido = strContenido + '</script>'

                    break;
                case 4: //Boleano
                    strContenido = strContenido + '<td>'
                        + '<input type="checkbox" id="txtParam_'
                        + this.nombre + '" name="txtParam_'
                        + this.nombre + '" value="" />'
                        + '</td>';
                    break;
                default:
                    strContenido = strContenido + '<td><input type="text" id="txtParam_' + this.nombre + '" name="txtParam_' + this.nombre + '" value="" /></td>';
            }

            strContenido = strContenido + '</tr>';
        });

        strContenido = strContenido + '</tbody>';

        strContenido = strContenido + '</table>';

        $(".x_content .periparams").html(strContenido);
        $("#tblParametrosPeriodo").DataTable();
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

    //Productos Accesorio


    //Productos Pantones-Espectro
    //Para obtern los colores HEX
    ObtenerTodosPantones: function () {
        $.ajax({
            method: "POST",
            url: URIs.ObtenerPantones,
            data: {},
            async: false,
            success: function (data) {
                dataProd.pantones = data;
            },
            error: function (error) {
                alert(error)
            }
        });
    },
    ProductoActualizaColorNuevoPanton: function () {
        $("#newKnob").knob({
            change: function (value) {
                //console.log("change : " + value);
            },
            release: function (value) {
                //console.log(this.$.attr('value'));
                console.log("release : " + value);
            },
            cancel: function () {
                console.log("cancel : ", this);
            }
        });

        // Example of infinite knob, iPod click wheel
        var v, up = 0,
            down = 0,
            i = 0,
            $idir = $("div.idir"),
            $ival = $("div.ival"),
            incr = function () {
                i++;
                $idir.show().html("+").fadeOut();
                $ival.html(i);
            },
            decr = function () {
                i--;
                $idir.show().html("-").fadeOut();
                $ival.html(i);
            };
        $("input.infinite").knob({
            min: 0,
            max: 20,
            stopper: false,
            change: function () {
                if (v > this.cv) {
                    if (up) {
                        decr();
                        up = 0;
                    } else {
                        up = 1;
                        down = 0;
                    }
                } else {
                    if (v < this.cv) {
                        if (down) {
                            incr();
                            down = 0;
                        } else {
                            down = 1;
                            up = 0;
                        }
                    }
                }
                v = this.cv;
            }
        });

    },

    ProductoGeneraKnobTodosPantones: function () {
        //Recorrer pantones adicionados.
        arrayPantones = JSON.parse($("#hdfEspectro").val());

        if (arrayPantones.length < 1) {
            return false;
        }

        //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
        var intIndice = -1;
        doughnutData = [];
        var totalPorcentaje = 0;
        dataProd.pantSelecDoughnut.destroy();
        $("#contPantones").empty();
        $(arrayPantones).each(function (idx, item) {
            totalPorcentaje += parseInt(this.porcentaje);
            var htmlTextPantones = '';
            htmlTextPantones = '<div class="wrapperPantones">' +
            '<div class="contClose"><span>' + dataProd.pantones[this.idPanton - 1].nombre + '</span>' +
                '<i class="fa fa-close" data-idguid="' + this.id + '" onclick="Produccion.ProductoEliminarPanton(this);"></i>' +
            '</div><div>' +
                '<input class="knob" data-width="100" data-height="120" data-angleoffset=90 ' +
                ' data-linecap=round data-fgcolor="#' + dataProd.pantones[this.idPanton - 1].hex + '" value="' + this.porcentaje + '">' +
            '</div></div>';

            $("#contPantones").append(htmlTextPantones);

            doughnutData.push({
                value: this.porcentaje,
                color: "#" + dataProd.pantones[this.idPanton - 1].hex,
                highlight: "#" + dataProd.pantones[this.idPanton - 1].hex,
                label: dataProd.pantones[this.idPanton - 1].nombre
            });
        });

        console.log("Porcentaje" + totalPorcentaje);
        //Si el porcentaje es mayor a 100, error
        if (totalPorcentaje > 100) {
            $("#contPantones>.wrapperPantones").addClass("error");
            new PNotify({
                title: 'Error en los pantones!',
                text: 'Los porcentajes asignados son superiores al 100%. Por favor, reasigne valores.',
                type: 'warning'
            });
        }
        else {
            $("#contPantones>.wrapperPantones").removeClass("error");
        }

        $(".knob").knob({
            change: function (value) {
                //console.log("change : " + value);
            },
            release: function (value) {
                //Arreglo JSON
                var arrayPantones = JSON.parse($("#hdfEspectro").val());

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;

                var newVal = $(this).attr("cv");
                var hexMod = $(this).attr("fgColor");
                console.log("A buscar hex: " + hexMod);
                $(arrayPantones).each(function (idx, item) {
                    console.log("Hex: " + item.hex);
                    if ((item.hex == hexMod)) {
                        arrayPantones[idx].porcentaje = newVal;
                        intIndice = $(arrayPantones).index(this);
                    }
                });
                if (intIndice >= 0) {
                    new PNotify({
                        title: 'Correcto!',
                        text: 'Se ha modificado el panton.',
                        type: 'success'
                    });
                    $("#hdfEspectro").val(JSON.stringify(arrayPantones));
                }
                Produccion.ProductoGeneraKnobTodosPantones();
                Produccion.ProductoActualizarDonaPanton();
            },
            cancel: function () {
                console.log("cancel : ", this);
            },
            /*format : function (value) {
             return value + '%';
             },*/
            draw: function () {

            }
        });

        // Example of infinite knob, iPod click wheel
        var v, up = 0,
            down = 0,
            i = 0,
            $idir = $("div.idir"),
            $ival = $("div.ival"),
            incr = function () {
                i++;
                $idir.show().html("+").fadeOut();
                $ival.html(i);
            },
            decr = function () {
                i--;
                $idir.show().html("-").fadeOut();
                $ival.html(i);
            };
        $("input.infinite").knob({
            min: 0,
            max: 20,
            stopper: false,
            change: function () {
                if (v > this.cv) {
                    if (up) {
                        decr();
                        up = 0;
                    } else {
                        up = 1;
                        down = 0;
                    }
                } else {
                    if (v < this.cv) {
                        if (down) {
                            incr();
                            down = 0;
                        } else {
                            down = 1;
                            up = 0;
                        }
                    }
                }
                v = this.cv;
            }
        });
    },

    ProductoMostarAddPanton: function () {
        $("#contNewPanton").fadeIn();
        $("#contDoughut").fadeOut();
    },

    ProductoOcultarAddPanton: function () {
        $("#contNewPanton").fadeOut();
        $("#contDoughut").fadeIn("fast", function () {
            Produccion.ProductoActualizarDonaPanton();
        });
    },

    ProductoAgregarPanton: function () {
        var arrayPantones;

        var guidPanton = $("#guidPanton").val();
        var idProducto = $("#idproducto").val();
        var idPanton = $("#panton_idpanton").val();
        var porcentajePanton = $("#newKnob").val();
        var hexPanton = "#" + dataProd.pantones[idPanton - 1].hex;
        var objPanton = {
            id: guidPanton, idProducto: idProducto, idPanton: idPanton, porcentaje: porcentajePanton, hex: hexPanton
        };

        if ($("#hdfEspectro").val()) {
            //Arreglo JSON
            arrayPantones = JSON.parse($("#hdfEspectro").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrayPantones).each(function () {
                if ((this.id == objPanton.id)) {
                    intIndice = $(arrayPantones).index(this);
                }
            });
            var textPNt = "";
            if (intIndice >= 0) {
                arrayPantones.splice(intIndice, 1);
                arrayPantones.push(objPanton);
                textPNt = 'Se ha modificado el panton.';
            }
            else {
                objPanton.id = General.GenerarGuid();
                arrayPantones.push(objPanton);
                textPNt = 'Se ha agregado el panton.';
            }
            new PNotify({
                title: 'Correcto!',
                text: textPNt,
                type: 'success'
            });

        }
        else {
            //Manejo arreglo JSON
            arrayPantones = new Array();

            objPanton.id = General.GenerarGuid();
            arrayPantones.push(objPanton);

            new PNotify({
                title: 'Correcto!',
                text: 'Se ha agregado el panton.',
                type: 'success'
            });
        }

        $("#hdfEspectro").val(JSON.stringify(arrayPantones));

        Produccion.ProductoGeneraKnobTodosPantones();
        Produccion.ProductoOcultarAddPanton();
    },

    ProductoEliminarPanton: function (control) {
        var idPanGuid = $(control).data("idguid");

        if ($("#hdfEspectro").val()) {
            var arrayPantones = JSON.parse($("#hdfEspectro").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrayPantones).each(function () {
                if ((this.id == idPanGuid)) {
                    intIndice = $(arrayPantones).index(this);
                }
            });

            if (intIndice >= 0) {
                arrayPantones.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado el panton.',
                    type: 'success'
                });
            }

            $("#hdfEspectro").val(JSON.stringify(arrayPantones));
            Produccion.ProductoGeneraKnobTodosPantones();
            Produccion.ProductoActualizarDonaPanton();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }
    },

    ProductoActualizarDonaPanton: function () {
        if (doughnutData.length <= 0) {
            return false;
        }
        $("#contDoughut>.x_content").empty();
        $("#contDoughut>.x_content").html('<canvas id="canvas_doughnut1"></canvas>');

        dataProd.pantSelecDoughnut = new Chart(document.getElementById("canvas_doughnut1").getContext("2d")).Doughnut(doughnutData, {
            //Boolean - Whether we should show a stroke on each segment
            segmentShowStroke: true,

            //String - The colour of each segment stroke
            segmentStrokeColor: "#fff",

            //Number - The width of each segment stroke
            segmentStrokeWidth: 2,

            //Number - The percentage of the chart that we cut out of the middle
            percentageInnerCutout: 50, // This is 0 for Pie charts

            //Number - Amount of animation steps
            animationSteps: 100,

            //String - Animation easing effect
            animationEasing: "easeOutBounce",

            //Boolean - Whether we animate the rotation of the Doughnut
            animateRotate: true,

            //Boolean - Whether we animate scaling the Doughnut from the centre
            animateScale: false,
            responsive: true,
            legendTemplate: ""
        });

    },

    //Productos Pegante

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

        $("#chkPrincipal").val(null);
        $("#chkPrincipal").prop("checked", false);
    },
    AgregarContacto: function () {
        if ($('#frmGesationContactos').valid()) {
            var arrContactos;

            var strid = $("#hfdIdContacto").val();
            var inttipo = Number($("#ddlTipoContacto").val());
            var strnombre = $("#txtNombre").val();
            var stremail = $("#txtEmail").val();
            var strtelefono = $("#txtTelefono").val();
            var strcelular = $("#txtCelular").val();
            var strdireccion = $("#txtDireccion").val();
            var strprincipal = $("#chkPrincipal").prop("checked");

            var objContacto = {
                id: strid, Tipo: inttipo, Nombre: strnombre, EMail: stremail,
                Telefono: strtelefono, Celular: strcelular, Direccion: strdireccion,
                Principal: strprincipal
            };

            if ($("#contactos").val()) {
                //Manejo arreglo JSON
                arrContactos = JSON.parse($("#contactos").val());

                //Se quita la marca de principal a cualquier 
                //otro contacto parqa que solo este pueda ser principal.
                if (objContacto.Principal) {
                    $(arrContactos).each(function () {
                        this.Principal = false;
                    });
                }
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
            Comercial.CargarContactos();
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
                if (this.Principal) {
                    strContenido = strContenido + '<i class="fa fa-user blue"></i>';
                }
                else {
                    strContenido = strContenido + '<i class="fa fa-user aero"></i>';
                }

                strContenido = strContenido + '</a>';
                strContenido = strContenido + '<div class="media-body">';
                strContenido = strContenido + '<a class="title" href="#" onclick="Comercial.CargarDatosContacto(\'' + this.id + '\')">' + this.Nombre + '</a>';
                strContenido = strContenido + '<p><span class="fa fa-envelope" aria-hidden="true"></span>&nbsp;<small>' + (this.EMail ? this.EMail : 'No registra') + '</small></p>';
                strContenido = strContenido + '<p><span class="fa fa-phone" aria-hidden="true"></span>&nbsp;<small>' + (this.Telefono ? this.Telefono : 'No registra') + '</small>&nbsp&nbsp<span class="fa fa-mobile" aria-hidden="true"></span>&nbsp;<small>' + (this.Celular ? this.Celular : 'No registra') + '</small></p>';
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
            $("#chkPrincipal").prop("checked", objContacto.Principal);

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
                if (this.Principal) {
                    strContenido = strContenido + '<img class="img-circle img-responsive" alt="" src="' + URIs.Imagenes + 'user_main.png")">';
                }
                else {
                    strContenido = strContenido + '<img class="img-circle img-responsive" alt="" src="' + URIs.Imagenes + 'user.png")">';
                }
                strContenido = strContenido + '</div>';

                strContenido = strContenido + '</div>';

                strContenido = strContenido + '<div class="col-xs-12 bottom text-center">';
                strContenido = strContenido + '<div class="col-xs-12 col-sm-6 emphasis pull-right">';
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