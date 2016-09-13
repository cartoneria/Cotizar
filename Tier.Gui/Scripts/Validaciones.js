var ValProduccion = {
    CrearEditarMaquina: function() {
        //Área
        if ($("#areaancho").val().length > 0 || $("#arealargo").val().length > 0) {
            $("#areaancho").rules("add", {
                required: true,
                messages: { required: "Debe ingresar el ancho." }
            });
            $("#arealargo").rules("add", {
                required: true,
                messages: { required: "Debe ingresar el largo." }
            });
        }
        else {
            $("#areaancho").rules("remove");
            $("#arealargo").rules("remove");
            $('#frmCrearMaquina').validate();
        }

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
    CrearEditarProducto: function() {
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
        }
        else {
            $("#anchomaquina_acabadoderecho").rules("remove");
            $("#recorrido_acabadoderecho").rules("remove");
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
        }
        else {
            $("#anchomaquina_acabadoreverso").rules("remove");
            $("#recorrido_acabadoreverso").rules("remove");
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
        $("#insumo_idinsumo_colaminadopegante").attr("readonly", habilitar);
        $("#colaminadoalargo").attr("readonly", habilitar);
        $("#colaminadoancho").attr("readonly", habilitar);
        $("#colaminadocabidalargo").attr("readonly", habilitar);
        $("#colaminadocabidaancho").attr("readonly", habilitar);
        $("#maquinavariprod_idVariacion_rutacolaminado").attr("readonly", habilitar);
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
}

var ValComercial = {
    CrearEditarCliente: function() {
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