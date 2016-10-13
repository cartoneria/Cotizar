var ValProduccion = {
    CrearEditarMaquina: function () {
        //Max MP
        if ($("#anchominmp").val().length > 0 || $("#largominmp").val().length > 0) {
            $("#anchominmp").rules("add", {
                required: true,
                messages: { required: "Debe ingresar el ancho." }
            });
            $("#largominmp").rules("add", {
                required: true,
                messages: { required: "Debe ingresar el largo." }
            });
        }
        else {
            $("#anchominmp").rules("remove");
            $("#largominmp").rules("remove");
            $('#frmCrearMaquina').validate();
        }

        //Min MP
        if ($("#anchomaxmp").val().length > 0 || $("#largomaxmp").val().length > 0) {
            $("#anchomaxmp").rules("add", {
                required: true,
                messages: { required: "Debe ingresar el ancho." }
            });
            $("#largomaxmp").rules("add", {
                required: true,
                messages: { required: "Debe ingresar el largo." }
            });
        }
        else {
            $("#anchomaxmp").rules("remove");
            $("#largomaxmp").rules("remove");
            $('#frmCrearMaquina').validate();
        }
    },
    CrearEditarProducto: function () {
        if ($("#hdfEspectro").val()) {
            arrayPantones = JSON.parse($("#hdfEspectro").val());

            if (arrayPantones.length > 1) {
                $("#pinzalitografica").rules("add", {
                    required: true,
                    messages: { required: "Requerido" }
                });
                $("#pasadaslitograficas").rules("add", {
                    required: true,
                    messages: { required: "Requerido" }
                });
                $("#maquinavariprod_idVariacion_rutalitografia").rules("add", {
                    required: true,
                    messages: { required: "Requerido" }
                });
            }
            else {
                $("#pinzalitografica").rules("remove");
                $("#pasadaslitograficas").rules("remove");
                $("#maquinavariprod_idVariacion_rutalitografia").rules("remove");
                $('#frmCrearProducto').validate();
                $('#frmEditarProducto').validate();
            }
        }

        if ($("#insumo_idinsumo_acabadoderecho").val().length > 0) {
            $("#anchomaquina_acabadoderecho").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#recorrido_acabadoderecho").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#maquinavariprod_idVariacion_rutaacabadoderecho").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
        }
        else {
            $("#anchomaquina_acabadoderecho").rules("remove");
            $("#recorrido_acabadoderecho").rules("remove");
            $("#maquinavariprod_idVariacion_rutaacabadoderecho").rules("remove");
            $('#frmCrearProducto').validate();
            $('#frmEditarProducto').validate();
        }

        if ($("#insumo_idinsumo_acabadoreverso").val().length > 0) {
            $("#anchomaquina_acabadoreverso").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#recorrido_acabadoreverso").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#maquinavariprod_idVariacion_rutaacabadoreverso").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
        }
        else {
            $("#anchomaquina_acabadoreverso").rules("remove");
            $("#recorrido_acabadoreverso").rules("remove");
            $("#maquinavariprod_idVariacion_rutaacabadoreverso").rules("remove");
            $('#frmCrearProducto').validate();
            $('#frmEditarProducto').validate();
        }

        if ($("#insumo_idinsumo_colaminado").val().length > 0) {
            $("#insumo_idinsumo_colaminadopegante").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#colaminadoalargo").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#colaminadoancho").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#colaminadocabidalargo").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#colaminadocabidaancho").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
            $("#maquinavariprod_idVariacion_rutacolaminado").rules("add", {
                required: true,
                messages: { required: "Requerido" }
            });
        }
        else {
            $("#insumo_idinsumo_colaminadopegante").rules("remove");
            $("#colaminadoalargo").rules("remove");
            $("#colaminadoancho").rules("remove");
            $("#colaminadocabidalargo").rules("remove");
            $("#colaminadocabidaancho").rules("remove");
            $("#maquinavariprod_idVariacion_rutacolaminado").rules("remove");
            $('#frmCrearProducto').validate();
            $('#frmEditarProducto').validate();
        }

        if ($("#insumo_idinsumo_reempaque").val().length > 0 || $("#factorrendimientoreempaque").val().length > 0) {
            $("#insumo_idinsumo_reempaque").rules("add", {
                required: true,
                messages: { required: "Requerido por factor de rendimiento" }
            });
            $("#factorrendimientoreempaque").rules("add", {
                required: true,
                messages: { required: "Requerido por reempaque" }
            });
        }
        else {
            $("#insumo_idinsumo_reempaque").rules("remove");
            $("#factorrendimientoreempaque").rules("remove");
            $('#frmCrearCliente').validate();
            $('#frmEditarCliente').validate();
        }

    },
    HabilitaCamposColaminado: function (habilitar) {
        $("#insumo_idinsumo_colaminadopegante").attr("disabled", habilitar);
        $("#colaminadoalargo").attr("readonly", habilitar);
        $("#colaminadoancho").attr("readonly", habilitar);
        $("#colaminadocabidalargo").attr("readonly", habilitar);
        $("#colaminadocabidaancho").attr("readonly", habilitar);
        $("#maquinavariprod_idVariacion_rutacolaminado").attr("disabled", habilitar);
    },
    ReiniciarControlesColaminado: function () {
        $("#insumo_idinsumo_colaminadopegante").val(null);
        $("#colaminadoalargo").val(null);
        $("#colaminadoancho").val(null);
        $("#colaminadocabidalargo").val(null);
        $("#colaminadocabidaancho").val(null);
        $("#maquinavariprod_idVariacion_rutacolaminado").val(null);
    },
    HabilitaPredeterminadosProducto: function (habilitar) {
        $("#catidadpredeterminada").attr("readonly", habilitar);
        $("#preciopredeterminado").attr("readonly", habilitar);
    },
    ReiniciarControlesPredeterminadosProducto: function () {
        $("#catidadpredeterminada").val(null);
        $("#preciopredeterminado").val(null);
    },
    HabilitaCamposAcabadoDer: function (habilitar) {
        $("#anchomaquina_acabadoderecho").attr("readonly", habilitar);
        $("#recorrido_acabadoderecho").attr("readonly", habilitar);
        $("#maquinavariprod_idVariacion_rutaacabadoderecho").attr("disabled", habilitar);
    },
    ReiniciarControlesAcabadoDer: function () {
        $("#anchomaquina_acabadoderecho").val(null);
        $("#recorrido_acabadoderecho").val(null);
        $("#maquinavariprod_idVariacion_rutaacabadoderecho").val(null);
    },
    HabilitaCamposAcabadoRev: function (habilitar) {
        $("#anchomaquina_acabadoreverso").attr("readonly", habilitar);
        $("#recorrido_acabadoreverso").attr("readonly", habilitar);
        $("#maquinavariprod_idVariacion_rutaacabadoreverso").attr("disabled", habilitar);
    },
    ReiniciarControlesAcabadoRev: function () {
        $("#anchomaquina_acabadoreverso").val(null);
        $("#recorrido_acabadoreverso").val(null);
        $("#maquinavariprod_idVariacion_rutaacabadoreverso").val(null);
    },
    HabilitaCamposReempaque: function (habilitar) {
        $("#factorrendimientoreempaque").attr("readonly", habilitar);
    },
    ReiniciarControlesReempaque: function () {
        $("#factorrendimientoreempaque").val(null);
    },
}

var ValComercial = {
    CrearEditarCliente: function () {
        if ($("#identificacion").val().length > 0 || $("#itemlista_iditemlista_tipoidenti").val().length > 0) {
            $("#identificacion").rules("add", {
                required: true,
                messages: { required: "Debe ingresar la identificación" }
            });
            $("#itemlista_iditemlista_tipoidenti").rules("add", {
                required: true,
                messages: { required: "Debe seleccionar un tipo de documento" }
            });
        }
        else {
            $("#identificacion").rules("remove");
            $("#itemlista_iditemlista_tipoidenti").rules("remove");
            $('#frmCrearCliente').validate();
            $('#frmEditarCliente').validate();
        }
        if ($("#direccion").val().length > 0) {
            $("#municipio_departamento_iddepartamento").rules("add", {
                required: true,
                messages: { required: "Debe seleccionar el departamento." }
            });
            $("#municipio_idmunicipio").rules("add", {
                required: true,
                messages: { required: "Debe seleccionar el municipio." }
            });
        }
        else {
            $("#municipio_departamento_iddepartamento").rules("remove");
            $("#municipio_idmunicipio").rules("remove");
            $('#frmCrearCliente').validate();
            $('#frmEditarCliente').validate();
        }
    }
}