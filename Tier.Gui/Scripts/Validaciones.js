var ValAdministracion = {

}

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
    }
}

var ValComercial = {
    CrearEditarCliente: function() {
        if ($("#identificacion").val().length > 0 || $("#itemlista_iditemlista_tipoidenti").val().length > 0) {
            $("#identificacion").rules("add", {
                required: true,
                messages: { required: "Debe ingresar la identificación." }
            });
            $("#itemlista_iditemlista_tipoidenti").rules("add", {
                required: true,
                messages: { required: "Debe seleccionar un tipo de documento." }
            });
        }
        else {
            $("#identificacion").rules("remove");
            $("#itemlista_iditemlista_tipoidenti").rules("remove");
            $('#frmCrearCliente').validate();
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
        }
    }
}