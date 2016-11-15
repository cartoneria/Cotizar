var dataProd = {
    pantones: [],
    pantSelecDoughnut: []
}
var maquinas = [];
var anchoMaterial;
var anchoMaterialColaminado;

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
    //Inicio sesión
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
    //Roles
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

    //Items Listas
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
        });

        $("#hfdPermisosSeleccionados").val("[]");
    },

    //Períodos - Parámetros
    CargarJsonParametros: function (arrParametrosPredefinidos) {
        var arrParametros = new Array();

        if (!$("#hfdparametros").val()) {
            $(arrParametrosPredefinidos).each(function () {
                var objParametro = {
                    idparametro: null, nombre: this.nombre, periodo_idPeriodo: null, tipo: this.tipo,
                    valorboleano: null, valorfecha: null, valornumero: null, valortexto: null
                };

                arrParametros.push(objParametro);
            });

            $("#hfdparametros").val(JSON.stringify(arrParametros));
        }
    },
    CargarTablaParametros: function (arrParametrosPredefinidos) {
        $(".x_content .periparams").empty();
        var strContenido;

        strContenido = '<table id="tblParametrosPeriodo" width="100%">';

        strContenido = strContenido
            + '<thead>'
            + '<tr>'
            + '<th style="text-align: center;">Nombre &nbsp;&nbsp;&nbsp;</th>'
            + '<th style="text-align: center;">Tipo &nbsp;&nbsp;&nbsp;</th>'
            + '<th style="text-align: center;">Descripción &nbsp;&nbsp;&nbsp;</th>'
            + '<th style="text-align: center;">Valor &nbsp;&nbsp;&nbsp;</th>'
            + '</tr>'
            + '</thead>';

        strContenido = strContenido + '<tbody>';

        $(arrParametrosPredefinidos).each(function () {
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
                        + '<input type="text" '
                        + 'class="form-control" '
                        + 'id="txtParam_' + this.nombre + '" '
                        + 'name="txtParam_' + this.nombre + '" '
                        + 'data-tipo-parametro="' + this.tipo + '" '
                        + 'data-nombre-parametro="' + this.nombre + '" '
                        + 'data-val="true" '
                        + 'data-val-required="Dato requerido." '
                        + 'data-val-number="The field ' + this.nombre + ' must be a number." '
                        + 'data-val-range="Monto inválido. Debe estar entre 1 y 1.000.000.000" '
                        + 'data-val-range-min="1" '
                        + 'data-val-range-max="1000000000" '
                        + 'onchange="Administracion.AsignarValorParametros(this)" />';

                    strContenido = strContenido + '<span class="field-validation-valid" '
                        + 'data-valmsg-for="txtParam_' + this.nombre + '" '
                        + 'data-valmsg-replace="true"></span>';

                    strContenido = strContenido + '</td>';

                    break;
                case 2: //Texto
                    strContenido = strContenido + '<td>'
                        + '<input type="text" '
                        + 'class="form-control" '
                        + 'id="txtParam_' + this.nombre + '" '
                        + 'name="txtParam_' + this.nombre + '" '
                        + 'data-tipo-parametro="' + this.tipo + '" '
                        + 'data-nombre-parametro="' + this.nombre + '" '
                        + 'data-val="true" '
                        + 'data-val-required="Dato requerido." '
                        + 'onchange="Administracion.AsignarValorParametros(this)" />';

                    strContenido = strContenido + '<span class="field-validation-valid" '
                        + 'data-valmsg-for="txtParam_' + this.nombre + '" '
                        + 'data-valmsg-replace="true"></span>';

                    strContenido = strContenido + '</td>';

                    break;
                case 3: //Fecha
                    strContenido = strContenido + '<td>'
                        + '<input type="text" '
                        + 'class="form-control" '
                        + 'id="txtParam_' + this.nombre + '" '
                        + 'name="txtParam_' + this.nombre + '" '
                        + 'data-tipo-parametro="' + this.tipo + '" '
                        + 'data-nombre-parametro="' + this.nombre + '" '
                        + 'data-val-date="Formato de fecha inválido" '
                        + 'data-val="true" '
                        + 'data-val-required="Dato requerido." '
                        + 'onchange="Administracion.AsignarValorParametros(this)" />';

                    strContenido = strContenido + '<span class="field-validation-valid" '
                        + 'data-valmsg-for="txtParam_' + this.nombre + '" '
                        + 'data-valmsg-replace="true"></span>';

                    strContenido = strContenido + '<script>'
                    + '$("#txtParam_' + this.nombre + '").daterangepicker({'
                        + 'singleDatePicker: true,'
                        + 'showDropdowns: true,'
                        + 'calender_style: "picker_2"'
                    + '}, function (start, end, label) {$("#txtParam_' + this.nombre + '").change();'
                    + '});</script>';

                    strContenido = strContenido + '</td>';

                    break;
                case 4: //Boleano
                    strContenido = strContenido + '<td>'
                        + '<input type="checkbox" '
                        + 'id="chkParam_' + this.nombre + '" '
                        + 'name="chkParam_' + this.nombre + '" '
                        + 'data-tipo-parametro="' + this.tipo + '" '
                        + 'data-nombre-parametro="' + this.nombre + '" '
                        + 'onchange="Administracion.AsignarValorParametros(this)" />';

                    strContenido = strContenido + '</td>';

                    break;
                default:
                    strContenido = strContenido + '<td>'
                        + '<input type="text" '
                        + 'id="txtParam_' + this.nombre + '" '
                        + 'name="txtParam_' + this.nombre + '" '
                        + 'data-tipo-parametro="' + this.tipo + '" '
                        + 'data-nombre-parametro="' + this.nombre + '" '
                        + 'onchange="Administracion.AsignarValorParametros(this)" />';

                    strContenido = strContenido + '</td>';

                    break;
            }

            strContenido = strContenido + '</tr>';
        });

        strContenido = strContenido + '</tbody>';

        strContenido = strContenido + '</table>';

        //Se activan los validadores agregados dinámicamente.
        strContenido = strContenido + '<script>$("form").data("validator", null); $.validator.unobtrusive.parse($("form"));</script>';

        $(".x_content .periparams").html(strContenido);

        $("#tblParametrosPeriodo").DataTable({
            "paging": false,
            "ordering": false,
            "info": false,
            "searching": false
        });
    },
    AsignarValorCamposParametros: function (arrParametrosPredefinidos) {
        $(arrParametrosPredefinidos).each(function () {
            switch (this.tipo) {
                case 4:
                    $("#chkParam_" + this.nombre).prop("checked", Administracion.ExtraerValorParametro(this));
                    break;
                default:
                    $("#txtParam_" + this.nombre).val(Administracion.ExtraerValorParametro(this));
                    break;
            }
        })
    },
    ExtraerValorParametro: function (objparampredefinido) {
        var arrParametros = JSON.parse($("#hfdparametros").val());
        var valorParametro;
        var nomnbreParametroPredefinido = objparampredefinido.nombre;

        $(arrParametros).each(function () {
            if (this.nombre == nomnbreParametroPredefinido) {
                switch (objparampredefinido.tipo) {
                    case 1:
                        valorParametro = this.valornumero;
                        break;
                    case 2:
                        valorParametro = this.valortexto;
                        break;
                    case 3:
                        valorParametro = this.valorfecha;
                        break;
                    case 4:
                        valorParametro = this.valorboleano;
                        break;
                    default:
                        valorParametro = this.valortexto;
                        break;
                }
            }
        });

        return valorParametro;
    },
    AsignarValorParametros: function (control) {
        var valorParametro;
        var strNombreParametro = $(control).data("nombre-parametro");
        var intTipoParametro = $(control).data("tipo-parametro");

        var arrParametros = JSON.parse($("#hfdparametros").val());

        $(arrParametros).each(function () {
            if (this.nombre == strNombreParametro) {
                switch (this.tipo) {
                    case 1:
                        valorParametro = $(control).val();
                        this.valornumero = valorParametro
                        break
                    case 2:
                        valorParametro = $(control).val();
                        this.valortexto = valorParametro
                        break
                    case 3:
                        valorParametro = $(control).val();
                        this.valorfecha = valorParametro
                        break
                    case 4:
                        valorParametro = $(control).prop("checked");
                        this.valorboleano = valorParametro
                        break
                    default:
                        valorParametro = $(control).val();
                        this.valortexto = valorParametro
                        break
                }
            }
        })

        $("#hfdparametros").val(JSON.stringify(arrParametros));
    },

    //Períodos - Centros máquinas
    CargarJsonCentrosMaquinas: function (arrMaquinasActivas) {
        var arrCentrosMaquinas = new Array();

        if (!$("#hfdcentros").val()) {
            $(arrMaquinasActivas).each(function () {
                var objCentro = {
                    activo: null, avaluocomercial: null, idmaquinadatosperiodos: null, maquina_empresa_idempresa: this.empresa_idempresa,
                    maquina_idmaquina: this.idmaquina, periodo_idPeriodo: null, presupuesto: null, tiempomtto: null
                };

                arrCentrosMaquinas.push(objCentro);
            });

            $("#hfdcentros").val(JSON.stringify(arrCentrosMaquinas));
        }
    },
    CargarTablaCentrosMaquinas: function (arrMaquinasActivas) {
        $(".x_content .pericentros").empty();
        var strContenido;

        strContenido = '<table id="tblCentrosPeriodo" width="100%">';

        strContenido = strContenido
            + '<thead>'
            + '<tr>'
            + '<th style="text-align: center;">Centro/Maquina &nbsp;&nbsp;&nbsp;</th>'
            + '<th style="text-align: center;">Avaluo &nbsp;&nbsp;&nbsp;</th>'
            + '<th style="text-align: center;">Presupuesto &nbsp;&nbsp;&nbsp;</th>'
            + '<th style="text-align: center;">Tiempo Mtto &nbsp;&nbsp;&nbsp;</th>'
            + '</tr>'
            + '</thead>';

        strContenido = strContenido + '<tbody>';

        $(arrMaquinasActivas).each(function () {
            strContenido = strContenido + '<tr>';

            strContenido = strContenido + '<td>' + this.nombre + '</td>';

            //Celda de avaluo comercial
            strContenido = strContenido + '<td>'
                + '<input type="text" '
                + 'class="form-control"'
                + 'id="txtAvaluoMaq_' + this.idmaquina + '" '
                + 'name="txtAvaluoMaq_' + this.idmaquina + '" '
                + 'data-maquina="' + this.idmaquina + '" '
                + 'data-concepto="A" '
                + 'data-val="true" '
                + 'data-val-required="Dato requerido." '
                + 'data-val-number="The field Avaluo ' + this.nombre + ' must be a number." '
                + 'data-val-range="Monto inválido. Debe estar entre 1 y 1.000.000.000" '
                + 'data-val-range-min="0" '
                + 'data-val-range-max="1000000000" '
                + 'value="" '
                + 'placeholder="$" '
                + 'onchange="Administracion.AsignarValoresCentrosMaquinas(this)" />';

            strContenido = strContenido + '<span class="field-validation-valid" '
                + 'data-valmsg-for="txtAvaluoMaq_' + this.idmaquina + '" '
                + 'data-valmsg-replace="true"></span>';

            + '</td>';

            //Celda presupuesto del periodo
            strContenido = strContenido + '<td>'
                + '<input type="text" '
                + 'class="form-control"'
                + 'id="txtPresupestoMaq_' + this.idmaquina + '" '
                + 'name="txtPresupestoMaq_' + this.idmaquina + '" '
                + 'data-maquina="' + this.idmaquina + '" '
                + 'data-concepto="P" '
                + 'data-val="true" '
                + 'data-val-required="Dato requerido." '
                + 'data-val-number="The field Presupuesto ' + this.nombre + ' must be a number." '
                + 'data-val-range="Monto inválido. Debe estar entre 1 y 1.000.000.000" '
                + 'data-val-range-min="0" '
                + 'data-val-range-max="1000000000" '
                + 'value="" '
                + 'placeholder="$" '
                + 'onchange="Administracion.AsignarValoresCentrosMaquinas(this)" />';

            strContenido = strContenido + '<span class="field-validation-valid" '
                + 'data-valmsg-for="txtPresupestoMaq_' + this.idmaquina + '" '
                + 'data-valmsg-replace="true"></span>';

            + '</td>';

            //Celda tiempo mtto del periodo
            strContenido = strContenido + '<td>'
                + '<input type="text" '
                + 'class="form-control"'
                + 'id="txtTMttoMaq_' + this.idmaquina + '" '
                + 'name="txtTMttoMaq_' + this.idmaquina + '" '
                + 'data-maquina="' + this.idmaquina + '" '
                + 'data-concepto="T" '
                + 'data-val="true" '
                + 'data-val-required="Dato requerido." '
                + 'data-val-number="The field Tiempo mtto ' + this.nombre + ' must be a number." '
                + 'data-val-range="Monto inválido. Debe estar entre 1 y 8.760" '
                + 'data-val-range-min="0" '
                + 'data-val-range-max="8760" '
                + 'value="" '
                + 'placeholder="Horas" '
                + 'onchange="Administracion.AsignarValoresCentrosMaquinas(this)" />';

            strContenido = strContenido + '<span class="field-validation-valid" '
                + 'data-valmsg-for="txtTMttoMaq_' + this.idmaquina + '" '
                + 'data-valmsg-replace="true"></span>';

            + '</td>';

            strContenido = strContenido + '</tr>';

        });

        strContenido = strContenido + '</tbody>';

        strContenido = strContenido + '</table>';

        //Se activan los validadores agregados dinámicamente.
        strContenido = strContenido + '<script>$("form").data("validator", null); $.validator.unobtrusive.parse($("form"));</script>'

        $(".x_content .pericentros").html(strContenido);

        $("#tblCentrosPeriodo").DataTable({
            "paging": false,
            "ordering": false,
            "info": false,
            "searching": false
        });
    },
    AsignarValorCamposCentrosMaquinas: function (arrMaquinasActivas) {
        $(arrMaquinasActivas).each(function () {
            $("#txtAvaluoMaq_" + this.idmaquina).val(Administracion.ExtraerValoresCentrosMaquinas(this, "A"));
            $("#txtPresupestoMaq_" + this.idmaquina).val(Administracion.ExtraerValoresCentrosMaquinas(this, "P"));
            $("#txtTMttoMaq_" + this.idmaquina).val(Administracion.ExtraerValoresCentrosMaquinas(this, "T"));
        })
    },
    ExtraerValoresCentrosMaquinas: function (objMaquinaActiva, strConcpto) {
        var arrCentrosMaquinas = JSON.parse($("#hfdcentros").val());
        var valorConcepto;
        var idMaquina = objMaquinaActiva.idmaquina;

        $(arrCentrosMaquinas).each(function () {
            if (this.maquina_idmaquina == idMaquina) {
                if (strConcpto == "A") {
                    valorConcepto = this.avaluocomercial;
                }
                else if (strConcpto == "P") {
                    valorConcepto = this.presupuesto;
                }
                else if (strConcpto == "T") {
                    valorConcepto = this.tiempomtto;
                }
            }
        });

        return valorConcepto;
    },
    AsignarValoresCentrosMaquinas: function (control) {
        var idMaquina = $(control).data("maquina");
        var idConcepto = $(control).data("concepto");
        var valorParametro = $(control).val();

        var arrCentrosMaquinas = JSON.parse($("#hfdcentros").val());

        $(arrCentrosMaquinas).each(function () {
            if (this.maquina_idmaquina == idMaquina) {
                if (idConcepto == "A") {
                    this.avaluocomercial = valorParametro;
                }
                else if (idConcepto == "P") {
                    this.presupuesto = valorParametro;
                }
                else if (idConcepto == "T") {
                    this.tiempomtto = valorParametro;
                }
            }
        })

        $("#hfdcentros").val(JSON.stringify(arrCentrosMaquinas));
    },
}

var Produccion = {
    //Máquinas - Variaciones de producción
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

    //Máquinas - Datos períodicos
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

    //Troqueles - Ventanas
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
        $("#imgPrdto").click();
    },
    ValidaExtenImg: function (obj) {
        var resp = true;
        var imgFileName = "";
        if ($(obj).val() != undefined && $(obj).val() != "") {
            var ext = $(obj).val().split('.').pop().toLowerCase();
            if ($.inArray(ext, ['png', 'jpg', 'jpeg']) == -1) {
                new PNotify({
                    title: 'Error imagen!',
                    text: 'La imagen no es valida.',
                    type: 'warning'
                });
                resp = false;
            }
            imgFileName = $(obj).val().split('/').pop().split('\\').pop();
        }
        else {
            resp = false;
        }
        if (resp) {
            $($(obj).parent()).find('input[type=text]').val(imgFileName);
        }
        return resp;
    },

    //Proveedores
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

    //Proveedores - Lineas
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
        if ($("#hdfEspectro").val() == "") {
            return false;
        }
        arrayPantones = JSON.parse($("#hdfEspectro").val());

        if (arrayPantones.length < 1) {
            $("#contPantones").empty();
            return false;
        }

        //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
        var intIndice = -1;
        doughnutData = [];
        var totalPorcentaje = 0;
        if (dataProd.pantSelecDoughnut.length > 0) {
            dataProd.pantSelecDoughnut.destroy();
        }
        else {
            dataProd.pantSelecDoughnut = [];
        }
        $("#contPantones").empty();
        $(arrayPantones).each(function (idx, item) {
            var objPantonOriginal;

            $.each(dataProd.pantones, function (sidx, sitem) {
                if (sitem.idpantone == item.idPanton) {
                    objPantonOriginal = sitem;
                }
            });

            totalPorcentaje += parseInt(this.porcentaje);
            var htmlTextPantones = '';

            htmlTextPantones =
                '<div class="wrapperPantones">' +
                '<div class="contClose">' +
                '<span>' + objPantonOriginal.nombre + '</span>' +
                '<i class="fa fa-close" data-idguid="' + this.id + '" onclick="Produccion.ProductoEliminarPanton(this);"></i>' +
                '</div>' +
                '<div>' +
                '<input class="knob" data-width="100" data-height="120" data-angleoffset=90 ' +
                ' data-linecap=round data-fgcolor="#' + objPantonOriginal.hex + '" value="' + this.porcentaje + '">' +
                '</div>' +
                '<span>Lado: ' + (Boolean(this.derechoreverso) == true ? 'Derecho' : 'Reverso') + '</span>' +
                '</div>';

            $("#contPantones").append(htmlTextPantones);

            doughnutData.push({
                value: this.porcentaje,
                color: "#" + objPantonOriginal.hex,
                highlight: "#" + objPantonOriginal.hex,
                label: objPantonOriginal.nombre
            });
        });

        //console.log("Porcentaje" + totalPorcentaje);
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
                //console.log("A buscar hex: " + hexMod);
                $(arrayPantones).each(function (idx, item) {
                    //console.log("Hex: " + item.hex);
                    if ((item.hex == hexMod)) {
                        arrayPantones[idx].porcentaje = newVal;
                        intIndice = $(arrayPantones).index(this);
                    }
                });
                if (intIndice >= 0) {
                    $("#hdfEspectro").val(JSON.stringify(arrayPantones));
                }
                Produccion.ProductoGeneraKnobTodosPantones();
                Produccion.ProductoActualizarDonaPanton();
            },
            cancel: function () {
                console.log("cancel : ", this);
            },
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
        var derechoreverso = $("#chkDerechoReverso").prop("checked");

        var hexPanton = "#";
        $.each(dataProd.pantones, function (idx, item) {
            if (idPanton == item.idpantone) {
                hexPanton = "#" + item.hex;
            }
        });

        var objPanton = {
            id: guidPanton, idProducto: idProducto, idPanton: idPanton, porcentaje: porcentajePanton, hex: hexPanton, derechoreverso: derechoreverso
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
            if (arrayPantones.length <= 0) {
                arrayPantones = [];
                doughnutData = [];
                $("#contDoughut>.x_content").empty();
                $("#contPantones").empty();
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
            //$("#contDoughut>.x_content").empty();
            //$("#contPantones").empty();
            $("#pasadaslitograficas").val(0);
            return false;
        }

        Produccion.ProduccionActualizaPasadasLitograficas();

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
    ProductoCargarAnchosInsumoTroquel: function () {
        var idmaterial = $("#insumo_idinsumo_material").val();

        if (idmaterial == "" || idmaterial == undefined) {
            anchoMaterial = null;
        }
        else {
            $.ajax({
                method: "GET",
                url: URIs.ObtAnchosInsumos,
                data: { id: idmaterial },
                async: false,
                success: function (data) {
                    anchoMaterial = data;
                },
                error: function (error) {
                    console.log(error);
                }
            });
        }
    },
    ProductoCargarAnchosInsumoTroquelColaminado: function () {
        var idmaterial = $("#insumo_idinsumo_colaminado").val();
        if (idmaterial == "" || idmaterial == undefined) {
            $("#colaminadoancho").val("");
        }
        else {
            $.ajax({
                method: "GET",
                url: URIs.ObtAnchosInsumos,
                data: { id: idmaterial },
                async: false,
                success: function (data) {
                    anchoMaterialColaminado = data;
                    if (anchoMaterial != undefined) {
                        if (anchoMaterialColaminado.ancho) {
                            $("#colaminadoancho").val(anchoMaterialColaminado.ancho);
                        }
                        else {
                            $("#colaminadoancho").val(1);
                        }
                    }

                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

    },
    ProductoActualizaAncho: function () {
        Produccion.ProductoCargarAnchosInsumoTroquel();

        if (anchoMaterial.ancho) {
            $("#anchobobina").val(anchoMaterial.ancho);
            $("#anchoPegue").val(anchoMaterial.ancho);
            $("#anchoPegue").attr("data-anchoinsumo", anchoMaterial.ancho);
        }
        else {
            $("#anchobobina").val(1);
            $("#anchoPegue").val(1);
            $("#anchoPegue").attr("data-anchoinsumo", 1);
        }
    },
    ProductoActualizaAnchoColaminado: function () {
        Produccion.ProductoCargarAnchosInsumoTroquelColaminado();
    },
    ProduccionActualizaPasadasLitograficas: function () {
        var ok = false;
        var idMaquinaLitografica = $("#maquinavariprod_idVariacion_rutalitografia").val();
        $.each(maquinas, function (idx, item) {
            if (idMaquinaLitografica == item.idMaquinaVariacion) {
                $("#pasadaslitograficas").attr("data-numtintas", item.numeroTintas);
                ok = true;
            }
        });
        if (ok) {
            var PasLit = 0;
            try {
                if (doughnutData == undefined) {
                    PasLit = $("#pasadaslitograficas").attr("data-numtintas");
                }
                else {
                    PasLit = Math.ceil(doughnutData.length / $("#pasadaslitograficas").attr("data-numtintas"));
                }
            } catch (e) {
                PasLit = 0;
                console.log(3);
            }

            $("#pasadaslitograficas").val(PasLit);
        }
        else {
            $("#pasadaslitograficas").val(0);
        }
    },
    ProductoCargarDatosMaquinasVariacion: function () {
        $.ajax({
            method: "GET",
            url: URIs.ObtLstMaquVar,
            data: {}, async: false,
            success: function (data) {
                maquinas = data;
            },
            error: function (error) {
                console.log(error);
            }
        });
    },
    ProductoBuscarTroqueles: function (filtercontrol, selectcontrol) {
        var criterio = $(filtercontrol).val();

        if (criterio.length >= 3) {
            NProgress.start();

            $.ajax({
                method: "POST",
                url: URIs.BuscarTroqueles,
                data: { criterio: criterio },
                async: true,
                success: function (data) {
                    if (data.length > 0) {
                        $("#" + selectcontrol).empty();

                        var options = '<option value> -- Seleccione -- </option>';
                        $(data).each(function () {
                            options = options + '<option value="' + $(this).attr("Value") + '">' + $(this).attr("Text") + '</option>';
                        });

                        $("#" + selectcontrol).html(options);
                    }
                    else {
                        new PNotify({
                            title: 'Advertencia!',
                            text: 'No se encontraron troqueles.',
                            type: 'notice'
                        });
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });

            NProgress.done();
        }
    },
    ProductoBuscarInsumo: function (filtercontrol, selectcontrol) {
        var criterio = $(filtercontrol).val();
        var tipomaterial = $(filtercontrol).attr("tipomaterial");

        if (criterio.length >= 3) {
            NProgress.start();

            $.ajax({
                method: "POST",
                url: URIs.BuscarInsumosXTipo,
                data: { criterio: criterio, tipo: tipomaterial },
                async: true,
                success: function (data) {
                    if (data.length > 0) {
                        $("#" + selectcontrol).empty();

                        var options = '<option value> -- Seleccione -- </option>';
                        $(data).each(function () {
                            options = options + '<option value="' + $(this).attr("Value") + '">' + $(this).attr("Text") + '</option>';
                        });

                        $("#" + selectcontrol).html(options);
                    }
                    else {
                        new PNotify({
                            title: 'Advertencia!',
                            text: 'No se encontraron troqueles.',
                            type: 'notice'
                        });
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });

            NProgress.done();
        }
    },
    ProductoCargarPeguesEstiloTroquel: function (idTroquel) {
        $.get(URIs.ObtTblPeguesEstiloTroquel, { id: idTroquel }, function (data) {
            $("#_ListaPeguesEstilo").empty();
            $("#_ListaPeguesEstilo").html(data);
        });
    },
    ProductoBuscarClientes: function (filtercontrol, selectcontrol) {
        var criterio = $(filtercontrol).val();

        if (criterio.length >= 3) {
            NProgress.start();

            $.ajax({
                method: "POST",
                url: URIs.BuscarClientes,
                data: { criterio: criterio },
                async: true,
                success: function (data) {
                    if (data.length > 0) {
                        $("#" + selectcontrol).empty();

                        var options = '<option value> -- Seleccione -- </option>';
                        $(data).each(function () {
                            options = options + '<option value="' + $(this).attr("Value") + '">' + $(this).attr("Text") + '</option>';
                        });

                        $("#" + selectcontrol).html(options);
                    }
                    else {
                        new PNotify({
                            title: 'Advertencia!',
                            text: 'No se encontraron clientes.',
                            type: 'notice'
                        });
                    }
                },
                error: function (error) {
                    console.log(error);
                }
            });

            NProgress.done();
        }
    },
    ValidarRestriccionAcetaro: function (idTroquel) {
        $.get(URIs.ValidarRestrisccionAcetato, { idTroquel: idTroquel }, function (data) {
            if (data) {
                $("#insumo_idinsumo_acetato").rules("add", {
                    required: true,
                    messages: { required: "Dato requerido" }
                });
                $("#insumo_idinsumo_acetato").attr("disabled", false);
            }
            else {
                $("#insumo_idinsumo_acetato").rules("remove");
                $("#insumo_idinsumo_acetato").attr("disabled", true);
            }
        });
    },

    //Accesorios
    AgregarProductoAccesorio: function () {
        if (Produccion.ValidarFormularioProductoAccesorio()) {
            var arrayAccesorios;

            var strid = $("#guidprodaccsr").val();

            var idProducto = $("#idproducto").val();
            var idAccesorio = $("#accesorio_idaccesorio").val();
            var nombreAccesorio = $("#accesorio_idaccesorio option[value='" + idAccesorio + "']").text();
            var cantidad = $("#cantidadAccesorio").val();
            var activio = $("#activoAccesorio").val();

            var objAccrs = {
                id: strid, idProducto: idProducto, cantAccsr: cantidad,
                idAccesorio: idAccesorio, nomAccr: nombreAccesorio, activo: activio
            };
            console.log(objAccrs);
            if ($("#hdfAccesorios").val()) {
                //Manejo arreglo JSON
                arrayAccesorios = JSON.parse($("#hdfAccesorios").val());

                //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
                var intIndice = -1;
                $(arrayAccesorios).each(function () {
                    if ((this.id == objAccrs.id)) {
                        intIndice = $(arrayAccesorios).index(this);
                    }
                });

                if (intIndice >= 0) {
                    arrayAccesorios.splice(intIndice, 1);
                    arrayAccesorios.push(objAccrs);
                }
                else {
                    objAccrs.id = General.GenerarGuid();
                    arrayAccesorios.push(objAccrs);
                }

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado el accesorio.',
                    type: 'success'
                });
            }
            else {
                //Manejo arreglo JSON
                arrayAccesorios = new Array();

                objAccrs.id = General.GenerarGuid();
                arrayAccesorios.push(objAccrs);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado el accesorio.',
                    type: 'success'
                });

            }

            $("#hdfAccesorios").val(JSON.stringify(arrayAccesorios));

            Produccion.RestaurarModalProductoAccesorio();
            Produccion.CargaTablaListaProductoAccesorio();
        }
    },
    EliminaProductoAccesorio: function (control) {
        var objFila = $(control).parents("tr");
        var strid = $(objFila).data("guidprodaccsr");

        if ($("#hdfAccesorios").val()) {
            var arrayAccesorios = JSON.parse($("#hdfAccesorios").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrayAccesorios).each(function () {
                if ((this.id == strid)) {
                    intIndice = $(arrayAccesorios).index(this);
                }
            });

            if (intIndice >= 0) {
                arrayAccesorios.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado la linea.',
                    type: 'success'
                });
            }

            $("#hdfAccesorios").val(JSON.stringify(arrayAccesorios));
            Produccion.CargaTablaListaProductoAccesorio();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }
    },
    AbrirModalProductoAccesorio: function () {
        Produccion.RestaurarModalProductoAccesorio();

        $(".bs-example-modal-sm2").modal("show");

        $("#accesorio_idaccesorio").select2();
    },
    RestaurarModalProductoAccesorio: function () {
        $("#guidprodaccsr").val(null);
        $("#accesorio_idaccesorio").val("");
        $("#cantidadAccesorio").val(null);
        $("#activoAccesorio").prop('checked', true);
    },
    CargarModalProductoAccesorio: function (control) {
        var objFila = $(control).parents("tr");
        var strid = $(objFila).data("guidprodaccsr");

        arrayAccesorios = JSON.parse($("#hdfAccesorios").val());

        var objAccrs;

        $(arrayAccesorios).each(function () {
            if (this.id == strid) {
                objAccrs = this;
            }
        });

        if (!objAccrs) {
            new PNotify({
                title: 'Advertencia!',
                text: 'No fue posible recuperar el registro.',
                type: 'notice'
            });
        }
        else {
            $("#guidprodaccsr").val(objAccrs.id);
            $("#idProducto").val(objAccrs.idProducto);
            $("#accesorio_idaccesorio").val(objAccrs.idAccesorio);
            $("#nombreAccesorio").val(objAccrs.nomAccr);
            $("#cantidadAccesorio").val(objAccrs.cantAccsr);
            $("#activoAccesorio").prop('checked', objAccrs.activo);
            $(".bs-example-modal-sm2").modal("show");
        }
    },
    CargaTablaListaProductoAccesorio: function () {
        $("#divTblProdAccrs").empty();
        var strContenido;

        if ($("#hdfAccesorios").val().length > 2) {
            var arrayAccesorios = JSON.parse($("#hdfAccesorios").val());
            strContenido = '<table id="tblProdAccrs">';

            strContenido = strContenido
                + '<thead>'
                + '<tr>'
                + '<th></th>'
                + '<th style="text-align: center;">Nombre</th>'
                + '<th style="text-align: center;">Cantidad</th>'
                + '</tr>'
                + '</thead>';

            strContenido = strContenido + '<tbody>';

            $(arrayAccesorios).each(function () {
                strContenido = strContenido + '<tr data-guidprodaccsr=\"' + this.id + '\">';

                strContenido = strContenido + '<td>';
                strContenido = strContenido + '<ul class="nav navbar-right panel_toolbox">';

                if ((this.id) != undefined && (this.id) != null) {
                    strContenido = strContenido + '<li><a href="#" onclick="Produccion.EliminaProductoAccesorio(this);"><i class="fa fa-minus"></i></a></li>';
                }

                strContenido = strContenido + '<li><a href="#" onclick="Produccion.CargarModalProductoAccesorio(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';

                strContenido = strContenido + '<td>' + this.nomAccr + '</td>';
                strContenido = strContenido + '<td>' + this.cantAccsr + '</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $("#divTblProdAccrs").html(strContenido);
            $("#tblProdAccrs").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han ingresado accesorios</span></div>';
            $("#divTblProdAccrs").html(strContenido);
        }
    },
    ValidarFormularioProductoAccesorio: function () {
        var respuesta = true;
        if (!$('#frmNwProdAccrs').valid()) {
            respuesta = false;
        }

        if ($("#accesorio_idaccesorio").val() == undefined || $("#accesorio_idaccesorio").val().toString().length < 1) {
            respuesta = false;
        }

        if (!respuesta) {
            new PNotify({
                title: 'Hay campos no validos!',
                text: 'No puede agregar el accesorio.',
                type: 'warning'
            });
        }
        return respuesta;
    },

    //Estilos troquel
    AgregarEstiloPegue: function () {
        if (Produccion.ValidarFormularioEstiloPegue()) {
            var arrayEstiloPegues;

            var strid = $("#guidestilopegue").val();
            var inttp = $("#maquinavariprod_idVariacion_rutapegue").val();
            var strtpdesc = $("#maquinavariprod_idVariacion_rutapegue option:selected").text();
            var intcant = Number($("#txtCantidad").val());

            var objEP = { id: strid, tp: inttp, tpdesc: strtpdesc, cant: intcant };

            if ($("#hfdpegues").val()) {
                arrayEstiloPegues = JSON.parse($("#hfdpegues").val());

                var intIndice = -1;
                $(arrayEstiloPegues).each(function () {
                    if (this.id == objEP.id) {
                        intIndice = $(arrayEstiloPegues).index(this);
                    }

                    if ((this.tp == objEP.tp) && !(this.id == objEP.id)) {
                        objEP.cant = objEP.cant + this.cant;
                        intIndice = $(arrayEstiloPegues).index(this);
                    }
                });

                if (intIndice >= 0) {
                    objEP.id = isNaN(arrayEstiloPegues[intIndice].id) ? General.GenerarGuid() : arrayEstiloPegues[intIndice].id;
                    arrayEstiloPegues.splice(intIndice, 1);

                    arrayEstiloPegues.push(objEP);
                }
                else {
                    objEP.id = General.GenerarGuid();
                    arrayEstiloPegues.push(objEP);
                }

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado el accesorio.',
                    type: 'success'
                });
            }
            else {
                arrayEstiloPegues = new Array();

                objEP.id = General.GenerarGuid();
                arrayEstiloPegues.push(objEP);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha agregado el accesorio.',
                    type: 'success'
                });

            }

            $("#hfdpegues").val(JSON.stringify(arrayEstiloPegues));

            Produccion.RestaurarModalEstiloPegue();
            Produccion.CargaTablaListaEstiloPegue();
        }
    },
    ValidarFormularioEstiloPegue: function () {
        var respuesta = true;
        if (!$('#frmEstiloPegue').valid()) {
            respuesta = false;
        }

        if (!respuesta) {
            new PNotify({
                title: 'Hay campos no validos!',
                text: 'No puede agregar el accesorio.',
                type: 'warning'
            });
        }

        return respuesta;
    },
    RestaurarModalEstiloPegue: function () {
        $("#guidestilopegue").val("");
        $("#maquinavariprod_idVariacion_rutapegue").val(null);
        $("#txtCantidad").val(null);
    },
    CargaTablaListaEstiloPegue: function () {
        $("#divTblEstiloPegues").empty();
        var strContenido;

        if ($("#hfdpegues").val().length > 2) {
            var arrayAccesorios = JSON.parse($("#hfdpegues").val());
            strContenido = '<table id="tblEstiloPegues">';

            strContenido = strContenido
                + '<thead>'
                + '<tr>'
                + '<th></th>'
                + '<th style="text-align: center;">Tipo</th>'
                + '<th style="text-align: center;">Cantidad</th>'
                + '</tr>'
                + '</thead>';

            strContenido = strContenido + '<tbody>';

            $(arrayAccesorios).each(function () {
                strContenido = strContenido + '<tr data-guidestilipegue=\"' + this.id + '\">';

                strContenido = strContenido + '<td>';
                strContenido = strContenido + '<ul class="nav navbar-right panel_toolbox">';

                if ((this.id != undefined) && (this.id != null) && (isNaN(this.id))) {
                    strContenido = strContenido + '<li><a href="#" onclick="Produccion.EliminaEstiloPegue(this);"><i class="fa fa-minus"></i></a></li>';
                }

                strContenido = strContenido + '<li><a href="#" onclick="Produccion.CargarModalEstiloPegue(this);"><i class="fa fa-pencil"></i></a></li>';
                strContenido = strContenido + '</ul>';
                strContenido = strContenido + '</td>';

                strContenido = strContenido + '<td>' + this.tpdesc + '</td>';
                strContenido = strContenido + '<td>' + this.cant + '</td>';
                strContenido = strContenido + '</tr>';
            });

            strContenido = strContenido + '</tbody>';

            strContenido = strContenido + '</table>';

            $(".divTblEstiloPegues").html(strContenido);
            $("#tblEstiloPegues").DataTable();
        }
        else {
            strContenido = '<div style="width: 80%;text-align:center;margin: 0 auto;font-size: smaller;color: darkorange;"><p><span class="glyphicon glyphicon-alert" aria-hidden="true" style="font-size: 32px;"></span></p><span>No se han configurado pegues</span></div>';
            $(".divTblEstiloPegues").html(strContenido);
        }
    },
    EliminaEstiloPegue: function (control) {
        var objFila = $(control).parents("tr");
        var strid = $(objFila).data("guidestilipegue");

        if ($("#hfdpegues").val()) {
            var arrayEstiloPegues = JSON.parse($("#hfdpegues").val());

            var intIndice = -1;
            $(arrayEstiloPegues).each(function () {
                if ((this.id == strid)) {
                    intIndice = $(arrayEstiloPegues).index(this);
                }
            });

            if (intIndice >= 0) {
                arrayEstiloPegues.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado el pegue.',
                    type: 'success'
                });
            }

            $("#hfdpegues").val(JSON.stringify(arrayEstiloPegues));
            Produccion.CargaTablaListaEstiloPegue();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }
    },
    CargarModalEstiloPegue: function (control) {
        var objFila = $(control).parents("tr");
        var strid = $(objFila).data("guidestilipegue");

        if ($("#hfdpegues").val()) {
            arrayEstiloPegues = JSON.parse($("#hfdpegues").val());

            var objEP;

            $(arrayEstiloPegues).each(function () {
                if (this.id == strid) {
                    objEP = this;
                }
            });

            if (!objEP) {
                new PNotify({
                    title: 'Advertencia!',
                    text: 'No fue posible recuperar el registro.',
                    type: 'notice'
                });
            }
            else {
                $("#guidestilopegue").val(objEP.id);
                $("#maquinavariprod_idVariacion_rutapegue").val(objEP.tp);
                $("#txtCantidad").val(objEP.cant);

                $(".bs-example-modal-sm2").modal("show");
            }
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para editar.',
                type: 'notice'
            });
        }
    },
}

var Comercial = {
    //Clientes
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
            var strtipo = $("#ddlTipoContacto option:selected").text();
            var strnombre = $("#txtNombre").val();
            var stremail = $("#txtEmail").val();
            var strtelefono = $("#txtTelefono").val();
            var strcelular = $("#txtCelular").val();
            var strdireccion = $("#txtDireccion").val();
            var strprincipal = $("#chkPrincipal").prop("checked");

            var objContacto = {
                id: strid, Tipo: inttipo, DescTipo: strtipo, Nombre: strnombre, EMail: stremail,
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
            strContenido = '<ul class="list-unstyled top_profiles scroll-view">';
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
                strContenido = strContenido + '<a class="title" href="#" onclick="Comercial.CargarDatosContacto(\'' + this.id + '\')">' + this.Nombre + ' (<small>' + this.DescTipo + '</small>)' + '</a>';
                strContenido = strContenido + '<p><span class="fa fa-envelope" aria-hidden="true"></span>&nbsp;<small>' + (this.EMail ? this.EMail : 'No registra') + '</small></p>';
                strContenido = strContenido + '<p><span class="fa fa-phone" aria-hidden="true"></span>&nbsp;<small>' + (this.Telefono ? this.Telefono : 'No registra') + '</small>&nbsp&nbsp<span class="fa fa-mobile" aria-hidden="true"></span>&nbsp;<small>' + (this.Celular ? this.Celular : 'No registra') + '</small></p>';
                strContenido = strContenido + '<p><span class="fa fa-crosshairs" aria-hidden="true"></span>&nbsp;<small>' + (this.Direccion ? this.Direccion : 'No registra') + '</small></p>';
                strContenido = strContenido + '</div>';
                strContenido = strContenido + '</li>';
                strContenido = strContenido + '<br style="clear: both;"/>';
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
                strContenido = strContenido + '<h4 class="brief"><i>' + this.DescTipo + '</i></h4>';
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
    },

    //Cotizaciones
    AgregarProdCotizar: function () {
        if (Comercial.ValidarFormularioProdCotizar()) {

            var idProducto = $("#producto_idproducto").val();
            var idPeriodo = $("#periodo_idPeriodo").val();
            var idInsumoFlete = $("#insumo_idinsumo_flete").val();

            if (Comercial.BuscarProducto(idProducto)) {
                new PNotify({
                    title: 'Advertencia!',
                    text: 'El producto ya se ha agregado antes a la cotización',
                    type: 'warning'
                });
            }
            else {
                $.ajax({
                    method: "GET",
                    url: URIs.ObtenerInfoProdCotizar,
                    data: { idProducto: idProducto, idPeriodo: idPeriodo, idFlete: idInsumoFlete, cotizacion_idcotizacion: null },
                    async: false,
                    success: function (data) {
                        var arrayProductos;

                        var strguid = $("#guidCotizarProducto").val();
                        var idProducto = $("#producto_idproducto").val();
                        var idInsumoFlete = $("#insumo_idinsumo_flete").val();
                        var comentarioAdicional = $("#comentarioAdicional").val();
                        var productoData = data.productoData;
                        var nombreInsumoFlete = $("#insumo_idinsumo_flete option:selected").text();
                        var tipoCarton = data.insumo_nombreInsumo;
                        var nombreTroquel = data.troquel_nombreTroquel;
                        var detalleProdCoti = data.lstCotDet;

                        var objProdCotizar = {
                            id: strguid, idProducto: idProducto, productoData: productoData,
                            tipoCarton: tipoCarton, nombreTroquel: nombreTroquel,
                            idInsumoFlete: idInsumoFlete, nombreInsumoFlete: nombreInsumoFlete,
                            comentarioAdicional: comentarioAdicional,
                            detalleProdCoti: detalleProdCoti
                        };

                        if ($("#hdfProdCotizar").val()) {
                            arrayProductos = JSON.parse($("#hdfProdCotizar").val());

                            var intIndice = -1;
                            $(arrayProductos).each(function () {
                                if (this.id == objProdCotizar.id) {
                                    intIndice = $(arrayProductos).index(this);
                                }
                            });

                            if (intIndice >= 0) {
                                arrayProductos.splice(intIndice, 1);
                                arrayProductos.push(objProdCotizar);
                            }
                            else {
                                objProdCotizar.id = General.GenerarGuid();
                                arrayProductos.push(objProdCotizar);
                            }
                            new PNotify({
                                title: 'Correcto!',
                                text: 'Se ha agregado el producto.',
                                type: 'success'
                            });

                        }
                        else {
                            arrayProductos = new Array();

                            objProdCotizar.id = General.GenerarGuid();
                            arrayProductos.push(objProdCotizar);

                            new PNotify({
                                title: 'Correcto!',
                                text: 'Se ha agregado el producto.',
                                type: 'success'
                            });
                        }

                        $("#hdfProdCotizar").val(JSON.stringify(arrayProductos));
                        Comercial.RestaurarModalProdCotizar();
                        Comercial.CargarTablaProductosCotizar();
                        Comercial.CalcularCostoPlanchasTroqueles();
                    },
                    error: function (error) {
                        console.log(error);
                        new PNotify({
                            title: 'Error!',
                            text: "Se produjo un error al intentar cotizar el producto.",
                            type: 'error'
                        });
                    }
                });
            }
        }

    },
    EliminarProdCotizar: function (obj) {
        var idProducto = $(obj).attr("data-idprodcot");
        if ($("#hdfProdCotizar").val()) {
            var arrayProductosCotizar = JSON.parse($("#hdfProdCotizar").val());

            //Se busca si ya se ha agregado antes el permiso y se remueve de la lista.
            var intIndice = -1;
            $(arrayProductosCotizar).each(function () {
                if ((this.idProducto == idProducto)) {
                    intIndice = $(arrayProductosCotizar).index(this);
                }
            });

            if (intIndice >= 0) {
                arrayProductosCotizar.splice(intIndice, 1);

                new PNotify({
                    title: 'Correcto!',
                    text: 'Se ha eliminado el producto de la cotización.',
                    type: 'success'
                });
            }

            $("#hdfProdCotizar").val(JSON.stringify(arrayProductosCotizar));

            Comercial.CargarTablaProductosCotizar();
            Comercial.CalcularCostoPlanchasTroqueles();
        }
        else {
            new PNotify({
                title: 'Advertencia!',
                text: 'No hay registros para eliminar.',
                type: 'notice'
            });
        }

    },
    RestaurarModalProdCotizar: function () {
        $("#producto_idproducto").val(null);
        $("#insumo_idinsumo_flete").val(null);
        $("#comentarioAdicional").val(null);
        $("#imgProdCotizarMdl").attr("src", $("#imgProdCotizarMdl").attr("scrnotfoung"));
    },
    BuscarProducto: function (idProducto) {
        if ($("#hdfProdCotizar").val()) {
            var arrayProductosCotizar = JSON.parse($("#hdfProdCotizar").val());
            var intIdx = -1;
            $(arrayProductosCotizar).each(function () {
                if ((this.idProducto == idProducto)) {
                    intIdx = $(arrayProductosCotizar).index(this);
                }
            });
            return (intIdx > -1);
        }
        return false;
    },
    CargarDetalleProdCotiEscala: function (obj) {
        var idProductoEscala = $(obj).attr("data-idProdEscala").split('|');

        if ($("#hdfProdCotizar").val() && idProductoEscala.length > 1) {
            arrayProductos = JSON.parse($("#hdfProdCotizar").val());

            var objProducto = null;
            $.each(arrayProductos, function (idx, item) {
                if (item.idProducto == idProductoEscala[0]) {
                    objProducto = item;
                }
            });

            if (objProducto != null) {
                $.each(objProducto.detalleProdCoti, function (idx, item) {
                    if (item.escala == idProductoEscala[1]) {
                        $.post(URIs.CargarMdlDetCotProEscala, item, function (data) {
                            $("#trgCotProDetEscala").html(data);
                            $($("#frmDetalleProdCotizacionEscala").find('h4')).html("Detalle " + idProductoEscala[1] + " unidades");
                        });
                    }
                });
            }
            else {
                new PNotify({
                    title: 'Error al detallar la escala',
                    text: "",
                    type: 'error'
                });
            }
        }
    },
    CargarTablaProductosCotizar: function () {
        var strContenido = '';

        if ($("#hdfProdCotizar").val() && $("#hdfProdCotizar").val().length > 2) {
            var arrayProductosCotizar = JSON.parse($("#hdfProdCotizar").val());

            var tmpColumnas = [];
            var strTblHead = '<tr>';
            var strTblBody = '';

            $(arrayProductosCotizar).each(function (idx, item) {
                strTblBody += '<tr style="height:60px;">';

                var fnClk = ($("#idcotizacion").val() == undefined) ? '' : "";
                if ($("#idcotizacion").val() == undefined) {
                    strTblBody += "<td><div onclick='Comercial.EliminarProdCotizar(this);' data-idProdCot='" + item.idProducto + "'><i class='fa fa-minus'></i></div></td>";
                }
                else {
                    strTblBody += '<td></td>'
                }

                strTblBody += "<td><div "
                + "class=\"customlink\" "
                + "data-toggle='modal' "
                + "data-target='.bs-example-modal-sm3'"
                + "onclick=\"Comercial.CargarDetalleProdCoti(this);\" "
                + "data-idProdEscala=\"" + item.idProducto + "\" "
                + "title=\"Clic para detalles\">" + item.productoData.prodNombre + "</div></td>";

                strTblBody += ("<td>" + item.tipoCarton + "</td>");
                strTblBody += ("<td>" + item.nombreTroquel + "</td>");
                strTblBody += ("<td>" + item.nombreInsumoFlete + "</td>");

                if (item.productoData.predeterminado) {
                    //Si el producto tiene un precio y cantidad pactada, no debe mostrar las escalas.
                    var precioPredt = 0, cantidadPredt = 0;
                    strTblBody += ("<td>" + item.productoData.cantidadPredt + "</td>");
                    strTblBody += ("<td>" + item.productoData.precioPredt + "</td>");

                    $.each(item.detalleProdCoti, function (sidx, sitem) {
                        strTblBody += ("<td><div>-</div></td>");
                    });
                }
                else {
                    strTblBody += "<td>-</td>";
                    strTblBody += "<td>-</td>";
                    $.each(item.detalleProdCoti, function (sidx, sitem) {
                        strTblBody += "<td>"
                            + "<div class='customlink text-center' "
                            + "data-toggle='modal' "
                            + "data-target='.bs-example-modal-sm2'"
                            + "onclick='Comercial.CargarDetalleProdCotiEscala(this);' "
                            + "data-idProdEscala='" + item.idProducto + "|" + sitem.escala + "' "
                            + "title='Clic para detalles'>" + sitem.escala + "<br/>$&nbsp;" + sitem.costonetocaja + "</div>";

                        if ((!$("#idcotizacion").val() == undefined || $("#idcotizacion").val()) && (Number($("#itemlista_iditemlista_estado").val()) == CONs.EstadoCotCreacion)) {
                            strTblBody = strTblBody + "<div class=\"tblEscalaPedido text-center\""
                            + "data-idcotizaciondetalle=\"" + sitem.idcotizacion_detalle + "\">"

                            + "<input type=\"radio\" "
                            + "class=\"rbnidcd\" "
                            + "name=\"rbn_idprod_" + item.idProducto + "\" "
                            + "data-idprod=\"" + item.idProducto + "\" "
                            + "data-idcd=\"" + sitem.idcotizacion_detalle + "\" "
                            + "data-escala=\"" + sitem.escala + "\" "
                            + "onchange=\"Comercial.AgregarPedidoDetalle(this);\" ></div>";
                        }
                        strTblBody += '</td>';
                    });
                }

                strTblBody += ("<td>" + item.comentarioAdicional + "</td>");
                strTblBody += '</tr>';

                // -- -- -- -- -- -- --
                //id: strguid, idProducto: idProducto, productoData: productoData,
                //tipoCarton: tipoCarton, nombreTroquel: nombreTroquel,
                //idInsumoFlete: idInsumoFlete, nombreInsumoFlete: nombreInsumoFlete,
                //comentarioAdicional: comentarioAdicional,
                //detalleProdCoti: detalleProdCoti
                // -- -- -- -- -- -- --

                //Solo en la primera iteración para crear las columnas.
                if (idx == 0) {
                    strTblHead += '<th></th>';
                    tmpColumnas.push({ "data": "" });
                    strTblHead += '<th>Referencia</th>';
                    tmpColumnas.push({ "data": "Referencia" });
                    strTblHead += '<th>Carton</th>';
                    tmpColumnas.push({ "data": "Carton" });
                    strTblHead += '<th>Troquel</th>';
                    tmpColumnas.push({ "data": "Troquel" });
                    strTblHead += '<th>Flete</th>';
                    tmpColumnas.push({ "data": "Flete" });
                    strTblHead += '<th>Escala</th>';
                    tmpColumnas.push({ "data": "Escala" });
                    strTblHead += '<th>Precio</th>';
                    tmpColumnas.push({ "data": "Precio" });
                    strTblHead += '<th colspan="' + item.detalleProdCoti.length + '" style="text-align: center;">Escalas</th>';
                    $.each(item.detalleProdCoti, function (sidx, sitem) {
                        tmpColumnas.push({ "data": "Escalas" });
                    });
                    strTblHead += '<th>Observaciones</th>';
                    tmpColumnas.push({ "data": "Observaciones" });

                    strTblHead += '</tr>';
                }
            });

            var table;

            window.strTblHead = strTblHead;
            window.tmpColumnas = tmpColumnas;

            if ($.fn.dataTable.isDataTable('#tblProductosCotizacion')) {
                table = $('#tblProductosCotizacion').DataTable().destroy();
            }

            $($('#tblProductosCotizacion').find('thead')).html(strTblHead);
            $($('#tblProductosCotizacion').find('tbody')).html(strTblBody);

            try {
                $('#tblProductosCotizacion').dataTable({
                    "paging": false,
                    "ordering": false,
                    "info": false,
                    "searching": false
                });
            } catch (e) {
                console.log(e);
            }


            $('#contProductosCotizacion').fadeIn();
            $("#sinProductosMsj").fadeOut();
            $('[data-toggle="tooltip"]').tooltip();
            $("#periodo_idPeriodo").attr("disabled", "disabled");
        }
        else {
            $('#contProductosCotizacion').fadeOut();
            $("#sinProductosMsj").fadeIn();
            try {
                $('#tblProductosCotizacion').DataTable().destroy();
            } catch (e) {
                console.log(e);
            }
            $("#periodo_idPeriodo").removeAttr("disabled", "disabled");
        }
    },
    HabilitaCampos: function (e) {
        if ($("#hdfProdCotizar").val() && $("#hdfProdCotizar").val().length > 2) {
            $("#periodo_idPeriodo").removeAttr("disabled", "disabled");
        }
        else {
            new PNotify({
                title: 'La cotización no tiene productos',
                text: "",
                type: 'warning'
            });
            e.preventDefault();
            return false;
        }


    },
    ValidarFormularioProdCotizar: function () {
        var blnResult = true;

        if (!$("#periodo_idPeriodo").val()) {
            blnResult = false;

            new PNotify({
                title: 'Información',
                text: 'No ha seleccionado un periodo.',
                type: 'info'
            });
        }

        if (!$("#frmNwProdCotizacion").valid()) {
            blnResult = false;
            new PNotify({
                title: 'Campos no válidos',
                text: 'Debe completar los campos PRODUCTO y FLETE.',
                type: 'warning'
            });
        }

        return blnResult;
    },
    ObtenerImagenProducto: function () {
        var idProducto = parseInt($("#producto_idproducto").val());
        $.post(URIs.ImagenProdCotizar, { idProducto: idProducto }, function (result) {
            if (result.estado) {
                $("#imgProdCotizarMdl").attr("src", result.respuesta);
            }
            else {
                if (result.respuesta == "") {
                    $("#imgProdCotizarMdl").attr("src", $("#imgProdCotizarMdl").attr("scrnotfoung"));
                }
                else {
                    console.log(result.respuesta);
                }
            }
        });
    },
    CargarDetalleProdCoti: function (control) {
        var idProducto = $(control).attr("data-idProdEscala");

        if (idProducto) {
            var datos = { id: idProducto };

            $.post(URIs.CargarMdlDetCotPro, datos, function (data) {
                $("#trgCotProDet").html(data);
                var action = $("#btnEditarProd").attr("href");
                action = action.replace("0", idProducto);
                $("#btnEditarProd").attr("href", action);
                $($("#frmDetalleProdCotizacion").find('h4')).html("Detalle de producto");
            });
        }
    },
    CalcularCostoPlanchasTroqueles: function () {
        if ($("#hdfProdCotizar").val() && $("#hdfProdCotizar").val().length > 2) {
            var arrayProductosCotizar = JSON.parse($("#hdfProdCotizar").val());
            var idPeriodo = $("#periodo_idPeriodo").val();

            var arrProds = new Array;
            $(arrayProductosCotizar).each(function () {
                arrProds.push(Number(this.idProducto));
            });

            var datos = { idPeriodo: idPeriodo, arrProductos: arrProds };

            $.ajax({
                url: URIs.CostoPlanTroq,
                data: datos,
                type: 'POST',
                traditional: true,
                success: function (data) {
                    $("#costosplancha").val(data.costoPlachas);
                    $("#costostroqueles").val(data.costoTroqueles);

                    $("#lblcostosplancha").text(Number($("#costosplancha").val()));
                    $("#lblcostostroqueles").text(Number($("#costostroqueles").val()));
                }
            });
        }
        else {
            $("#costosplancha").val(0);
            $("#costostroqueles").val(0);
        }

        $("#lblcostosplancha").text(Number($("#costosplancha").val()));
        $("#lblcostostroqueles").text(Number($("#costostroqueles").val()));
    },
    AgregarPedidoDetalle: function (control) {
        var arrCantidadesPedido;

        var idprod = $(control).data("idprod");
        var idcd = $(control).data("idcd");
        var cantidad = $(control).data("escala");

        var objCantidad = { prod: idprod, cd: idcd, cant: cantidad };

        if ($("#hdfProdPedido").val()) {
            arrCantidadesPedido = JSON.parse($("#hdfProdPedido").val());

            var intIndice = -1;
            $(arrCantidadesPedido).each(function () {
                if ((this.prod == idprod)) {
                    intIndice = $(arrCantidadesPedido).index(this);
                }
            });

            if (intIndice >= 0)
                arrCantidadesPedido.splice(intIndice, 1);

            arrCantidadesPedido.push(objCantidad);
        }
        else {
            arrCantidadesPedido = new Array();
            arrCantidadesPedido.push(objCantidad);
        }

        $("#hdfProdPedido").val(JSON.stringify(arrCantidadesPedido));
    },
    ValidarDatosPedido: function () {
        var cantidadsel = false;

        $(".rbnidcd").each(function () {
            if ($(this).prop("checked")) {
                cantidadsel = true;
            }
        });

        if (!cantidadsel) {
            new PNotify({
                title: 'Advertencia!',
                text: 'Debe seleccionar al menos una cantidad a pedir.',
                type: 'notice'
            });
        }

        return cantidadsel;
    },

    //Pedidos
    CalcularValoresPedido: function () {
        var subtotal = 0;
        var porceImpuesto = 0;
        var impuesto = 0;

        var cantPedido = 0;
        var idProducto = 0;
        var vUnitario = 0;

        var costoPlanchas = ($("#costosplancha").val() ? Number($("#costosplancha").val()) : 0);
        var costoTroqueles = ($("#costostroqueles").val() ? Number($("#costostroqueles").val()) : 0);

        subtotal = subtotal + costoPlanchas;
        subtotal = subtotal + costoTroqueles;

        $(".txtCantProd").each(function (idx, item) {
            cantPedido = Number($(item).val());
            idProducto = Number($(item).data("producto"));
            vUnitario = Number($(item).data("vunitario"));

            var vParcial = cantPedido * vUnitario;
            subtotal = subtotal + vParcial;

            $("span[class='vParcialProd'][data-producto=" + idProducto + "]").text(vParcial.toLocaleString());
        });

        porceImpuesto = ($("#impuestoPedido").val() ? Number($("#impuestoPedido").val()) : 0);
        impuesto = (subtotal * porceImpuesto / 100);

        $("#lblCostosPlanchas").text(costoPlanchas.toLocaleString());
        $("#lblCostosTroqueles").text(costoTroqueles.toLocaleString());
        $("#lblSubtotalPedido").text(subtotal.toLocaleString());
        $("#lblImpuestoPedido").text(impuesto.toLocaleString());

        $("#lblTotalPedido").text((subtotal + impuesto).toLocaleString());
    },
    ValidarRangoCantidad: function (control) {
        var blnResultado;

        var cantPedido = 0;
        var pedMin = 0;
        var pedMax = 0;

        cantPedido = Number($(control).val());
        pedMin = Number($(control).data("pedmin"));
        pedMax = Number($(control).data("pedmax"));

        if (cantPedido < pedMin || cantPedido > pedMax) {
            blnResultado = false;
            $(control).val(pedMin);

            new PNotify({
                title: 'Advertencia!',
                text: 'Cantidad fuera del rango. Cant min: ' + pedMin + ', Cant max: ' + pedMax,
                type: 'notice'
            });
        }
        else {
            var idcd = $(control).data("cd");
            var arrPedidoDetalle = JSON.parse($("#hfddetalle").val());

            $(arrPedidoDetalle).each(function () {
                if ((this.cotizacion_detalle_idcotizacion_detalle == idcd)) {
                    this.cantidad = cantPedido;
                    return false;
                }
            });

            $("#hfddetalle").val(JSON.stringify(arrPedidoDetalle));

            blnResultado = true;
            $(control).change();
        }

        return blnResultado;
    },

    //Gestión Comercial
    RecupararTablaPedidosGestion: function (control) {
        var idAgrupacion = $(control).data("estados");
        var idcontenedor = $(control).attr("href");

        $.get(URIs.ObtTblPedidosGestionAgrupacion, { id: idAgrupacion }, function (data) {
            $(idcontenedor).empty();
            $(idcontenedor).html(data);
        }).fail(function (ex) {
            console.log(ex.responseText);
        });
    },
}