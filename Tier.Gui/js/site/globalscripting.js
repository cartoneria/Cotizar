var General = {
    GenerarGuid: function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
          s4() + '-' + s4() + s4() + s4();
    }
}

var Seguridad = {
    RestablecerControlesLogin: function () {
        $("#txtUsuarioIniciar").val(null);
        $("#txtClaveIniciar").val(null);
        $("#ddlEmpresaIngresar").val(null);
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

        if ($("#permisosseleccionados").val()) {
            arrPermisos = JSON.parse($("#permisosseleccionados").val());

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

        $("#permisosseleccionados").val(JSON.stringify(arrPermisos));
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
    CerrarFormularioCreaItem: function () {
        $("#btnResetForm").click();
        $('#divlistasmain').show();
        $('#divlistasform').hide();
    },
    EstablecerGrupoListaitems: function (idGrupo) {
        $("#grupo").val(idGrupo)
    }
}

var produccion = {
    RestablecerControlesCfgProduccion: function () {
        $("#hfdIdCfgProduccion").val(null);

        $("#txtPH").val(null);
        $("#ddlPHUm").val(null);

        $("#txtTA").val(null);
        $("#ddlTAUm").val(null);
    },
    AgregarConfiguracion: function () {
        if ($('#frmCfgProduccion').valid()) {
            var arrVariacaciones;

            var strid = $("#hfdIdCfgProduccion").val();

            var intph = $("#txtPH").val();
            var intphun = $("#ddlPHUm").val();
            var strphunnomb = $("#ddlPHUm option:selected").text();

            var intta = $("#txtTA").val();
            var inttaun = $("#ddlTAUm").val();
            var strtaunnomb = $("#ddlTAUm option:selected").text();

            var objCfg = {
                id: strid, ph: intph, phun: intphun, phunnomb: strphunnomb, ta: intta, taun: inttaun, taunnomb: strtaunnomb
            };

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

            produccion.RestablecerControlesCfgProduccion();
        }
    },
    CargarTablaProduccion: function () {
        $("#divDatosProduccion").empty();
        var strContenido;

        if ($("#hfdCfgProduccion").val()) {
            var arrVariacaciones = JSON.parse($("#hfdCfgProduccion").val());
            strContenido = '<table id="tblDatosProduccion">';

            strContenido = strContenido
                + '<thead>'
                + '<tr>'
                + '<th></th>'
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
                strContenido = strContenido + '<li><a href="#"><i class="fa fa-minus"></i></a></li>';
                strContenido = strContenido + '<li><a href="#" onclick="produccion.CargarModalCfgProduccion(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';

                strContenido = strContenido + '<td>' + this.ph + '</td>';
                strContenido = strContenido + '<td>' + this.phunnomb + '</td>';
                strContenido = strContenido + '<td>' + this.ta + '</td>';
                strContenido = strContenido + '<td>' + this.taunnomb + '</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $("#divDatosProduccion").html(strContenido);
            $("#tblDatosProduccion").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han configurado variaciones de produción</span></div>';
            $("#divDatosProduccion").html(strContenido);
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
        $("#ddlTAUm").val(objCfg.taun);

        $(".bs-example-modal-sm1").modal("show");
    },

    RestablecerControlesDatosPeriodicos: function () {
        $("#hfdIdDatosPeriodicos").val(null);

        $("#ddlPeriodo").val(null);
        $("#txtAvaluo").val(null);
        $("#txtPresupuesto").val(null);
        $("#txtTM").val(null);
        $("#ddlTMUm").val(null);
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
            var inttmum = $("#ddlTMUm").val();
            var strtmumnomb = $("#ddlTMUm option:selected").text();

            var objDatoPeriodico = {
                id: strid, periodo: intperiodo, periodonomb: strperiodonomb,
                avaluo: intavaluo, presupuesto: intpresupuesto, tm: inttm,
                tmum: inttmum, mumnomb: strtmumnomb
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

            produccion.RestablecerControlesDatosPeriodicos();
        }
    },
    CargarTablaDatosPeriodicos: function () {
        $("#divDatosPeriodicos").empty();
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
                strContenido = strContenido + '<li><a href="#"><i class="fa fa-minus"></i></a></li>';
                strContenido = strContenido + '<li><a href="#" onclick="produccion.CargarModalDatosPeriodicos(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';

                strContenido = strContenido + '<td style="text-align: center;">' + this.periodonomb + '</td>';
                strContenido = strContenido + '<td style="text-align: right;">' + this.avaluo + '</td>';
                strContenido = strContenido + '<td style="text-align: right;">' + this.presupuesto + '</td>';
                strContenido = strContenido + '<td>' + this.tm + '</td>';
                strContenido = strContenido + '<td>' + this.mumnomb + '</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $("#divDatosPeriodicos").html(strContenido);
            $("#tblDatosPeriodicos").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han agregado datos periódicos</span></div>';
            $("#tblDatosPeriodicos").html(strContenido);
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
        $("#ddlTMUm").val(objDatoPeriodo.tmum);

        $(".bs-example-modal-sm2").modal("show");
    }
}