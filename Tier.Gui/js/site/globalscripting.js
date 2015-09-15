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
        $("#txtPH").val(null);
        $("#ddlPHUm").val(null);

        $("#txtTA").val(null);
        $("#ddlTAUm").val(null);
    },
    AgregarConfiguracion: function () {
        if ($('#frmCfgProduccion').valid()) {
            var arrVariacaciones;

            var intph = $("#txtPH").val();
            var intphun = $("#ddlPHUm").val();
            var strphunnomb = $("#ddlPHUm option:selected").text();

            var intta = $("#txtTA").val();
            var inttaun = $("#ddlTAUm").val();
            var strtaunnomb = $("#ddlTAUm option:selected").text();

            var objCfg = {
                ph: intph,
                phun: intphun,
                phunnomb: strphunnomb,
                ta: intta,
                taun: inttaun,
                taunnomb: strtaunnomb
            };

            if ($("#hfdCfgProduccion").val()) {
                //Manejo arreglo JSON
                arrVariacaciones = JSON.parse($("#hfdCfgProduccion").val());

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;
                $(arrVariacaciones).each(function () {
                    if ((this.ph == objCfg.ph) && (this.phun == objCfg.phun) && (this.ta == objCfg.ta) && (this.taun == objCfg.taun)) {
                        intIndice = $(arrVariacaciones).index(this);
                    }
                });

                if (intIndice >= 0)
                    arrVariacaciones.splice(intIndice, 1);
                else
                    arrVariacaciones.push(objCfg);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });
            }
            else {
                //Manejo arreglo JSON
                arrVariacaciones = new Array();
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

        var arrVariacaciones = JSON.parse($("#hfdCfgProduccion").val());
        var strtabla = '<table id="tblDatosProduccion">';

        strtabla = strtabla
            + '<thead>'
            + '<tr>'
            + '<th></th>'
            + '<th>Cantidad</th>'
            + '<th>Unidad medida</th>'
            + '<th>Tiempo</th>'
            + '<th>Unidad medida</th>'
            + '</tr>'
            + '</thead>';

        strtabla = strtabla + '<tbody>';

        $(arrVariacaciones).each(function () {
            strtabla = strtabla + '<tr>';
            strtabla = strtabla + '<td></td>';
            strtabla = strtabla + '<td>' + this.ph + '</td>';
            strtabla = strtabla + '<td>' + this.phunnomb + '</td>';
            strtabla = strtabla + '<td>' + this.ta + '</td>';
            strtabla = strtabla + '<td>' + this.taunnomb + '</td>';
            strtabla = strtabla + '</tr>';
        });

        strtabla = strtabla + '</tbody>';

        strtabla = strtabla + '</table>';

        $("#divDatosProduccion").html(strtabla);
        $("#tblDatosProduccion").DataTable();
    },

    RestablecerControlesDatosPeriodicos: function () {
        alert("asdf");
    },
    AgregarDatoPeriodico: function () {
        alert("asdf");
    },
    CargarTablaDatosPeriodicos: function () {
        alert("asdf");
    },
}