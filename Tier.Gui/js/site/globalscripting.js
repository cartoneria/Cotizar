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
    RedirigirInicio: function (data) {
        debugger;
        if (data.blnResultado) {
            new PNotify({
                title: 'Correcto!',
                text: 'En un segundo serás redireccionado a la pagina principal. Feliz dia!',
                type: 'success'
            });

            setTimeout(function () {
                location.href = SiteUris.UriHome;
            }, 2000)
        }
        else {
            new PNotify({
                title: 'Oh No!',
                text: 'Credenciales inválidas',
                type: 'error'
            });
        }
    }
}