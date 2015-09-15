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
            var intph = $("#txtPH").val();
            var intphun = $("#ddlPHUm").val();
            var strphunnomb = $("#ddlPHUm option:selected").text();

            var intta = $("#txtTA").val();
            var inttaun = $("#ddlTAUm").val();
            var strtaunnomb = $("#ddlTAUm option:selected").text();

            if ($("#dataproduccion").val()) {
                var objXmlCfg = $.parseXML($("#dataproduccion").val());
                var indice = $(objXmlCfg).find("root").length + 1;

                $(objXmlCfg).find("root").append(
                    '<variacion id="' + String(indice) + '">'
                    + '<ph>' + intph + '</ph>'
                    + '<phum>' + intphun + '</phum>'
                    + '<phumnomb>' + strphunnomb + '</phumnomb>'
                    + '<ta>' + intta + '</ta>'
                    + '<taum>' + inttaun + '</taum>'
                    + '<taumnomb>' + strtaunnomb + '</taumnomb>'
                    + '</variacion>'
                );

                $("#dataproduccion").val('<root>' + $(objXmlCfg).find('root').html() + '</root>')

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });
            }
            else {
                var xmldata = '<root><variacion id="1">'
                    + '<ph>' + intph + '</ph>'
                    + '<phum>' + intphun + '</phum>'
                    + '<phumnomb>' + strphunnomb + '</phumnomb>'
                    + '<ta>' + intta + '</ta>'
                    + '<taum>' + inttaun + '</taum>'
                    + '<taumnomb>' + strtaunnomb + '</taumnomb>'
                    + '</variacion></root>';

                $("#dataproduccion").val(xmldata)

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado la configuración.',
                    type: 'success'
                });

            }

            produccion.RestablecerControlesCfgProduccion();
        }
    },
    CargarTablaProduccion: function () {
        $("#divDatosProduccion").empty();

        var objXmlCfg = $.parseXML($("#dataproduccion").val());
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


        $(objXmlCfg).find("variacion").each(function () {
            strtabla = strtabla + '<tr>';
            strtabla = strtabla + '<td></td>';
            strtabla = strtabla + '<td>' + $(this).find("ph").first().text() + '</td>';
            strtabla = strtabla + '<td>' + $(this).find("phumnomb").first().text() + '</td>';

            strtabla = strtabla + '<td>' + $(this).find("ta").first().text() + '</td>';
            strtabla = strtabla + '<td>' + $(this).find("taumnomb").first().text() + '</td>';

            strtabla = strtabla + '</tr>';
        })

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