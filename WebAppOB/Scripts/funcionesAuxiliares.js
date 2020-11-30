// F01 - INGRESO DE USUARIOS---------------------------------------------------------------------

// F01.TOMA DE DATOS
function tomarDatosUsuario() {
    let nombre = $("#txtNombreU").val();
    let contraseña = $("#txtContraseña").val();
    let tipoUsuario = $("#slcUsuario").val();

    verificarUsuarioLogueado(nombre, tipoUsuario, contraseña);

}
// F01.VERIFICACION DE DATOS
function verificarUsuarioLogueado(nombreUsuario, tipoUsuario, contraseña) {
    $("#pErrorUsuarioOContraseña").empty();
    $("#pErrorSelectorU").empty();
    $("#pIngresoUsuario").empty();
    $("#pdeshabilitado").empty();
    if (tipoUsuario === "admin") {
        let nombreChef = ChefAdministrador.nombre;
        let contraseñaChef = ChefAdministrador.contraseña;
        if (nombreUsuario === nombreChef && contraseña === contraseñaChef) {
            usuarioLogueado = ChefAdministrador;
            tipo = "admin";
            mostrarBotones(tipo);
            $("#pIngresoUsuario").html(`${nombreChef} ingreso con exito`);
        } else {
            $("#pErrorUsuarioOContraseña").html("Usuario o contraseña incorrectos");
        }
    } else if (tipoUsuario === "colaborador") {
        let usuarioHabilitado = true;
        for (let i = 0; i < listaColaboradores.length; i++) {
            nombreColaborador = listaColaboradores[i].nombre;
            contraseñaColaborador = listaColaboradores[i].contraseña;
            if (nombreUsuario === nombreColaborador && contraseña === contraseñaColaborador) {
                if (listaColaboradores[i].estado === "habilitado") {
                    usuarioLogueado = listaColaboradores[i];
                    tipo = "colaborador";
                    mostrarBotones(tipo);
                    $("#pIngresoUsuario").html(`${nombreColaborador} ingreso con exito`);
                    $("#pErrorUsuarioOContraseña").empty();
                    break;
                } else {
                    usuarioHabilitado = false;
                    break;
                }
            } else {
                $("#pErrorUsuarioOContraseña").html("Usuario o contraseña incorrectos");
            }
        }

        if (!usuarioHabilitado) {
            $("#pdeshabilitado").html("Usuario deshabilitado.");
        }
    } else {
        $("#pErrorSelectorU").html("Seleccione un tipo de usuario");
    }
}



// F02 - REGISTRO DE COLABORADORES--------------------------------------------------------

// F02.TOMA DE DATOS 
function tomarDatosColaborador() {
    let nombre = $("#txtNombre").val();
    let apellido = $("#txtApellido").val();
    $("#pNombreC").empty();
    $("#pApellidoC").empty();
    if (estaVacio(nombre)) {
        $("#pNombreC").html("Campo vacio, ingrese un nombre")
    } else if (estaVacio(apellido)) {
        $("#pApellidoC").html("Campo vacio, ingrese un apellido")
    }
    else {
        registrarColaborador(nombre, apellido);
        $("#pIngresoC").html(`Colaborador registrado correctamente`)
    }
}

// F02.REGISTRO COLABORADOR 
function registrarColaborador(nombre, apellido) {

    let nombreMin = nombre.toLowerCase();
    let primerLetraNM = nombreMin.charAt(0);
    let apellidMin = apellido.toLowerCase();
    let nombreUsuario = primerLetraNM + apellidMin;
    let estaRepetido;
    let contraseña;
    let contador = 0;
    do {
        for (let i = 0; i < listaColaboradores.length; i++) {

            if (listaColaboradores[i].nombre.indexOf(nombreUsuario) !== -1) {
                estaRepetido = true;
                contador++;
                nombreUsuario = primerLetraNM + apellidMin;
                nombreUsuario = nombreUsuario + contador;

            } else {
                estaRepetido = false;
            }
        }
    } while (estaRepetido)

    contraseña = `${nombreUsuario.charAt(0)}-${nombreUsuario.substr(1)}`;
    let nuevoColaborador = new Colaborador(nombreUsuario, contraseña);
    listaColaboradores.push(nuevoColaborador);

    // ARMO COMBO
    armarCombo();
}


// F03 - ADMINISTRAR COLABORADORES------------------------------------------------------

// F03.ARMADO DE TABLA CON DATOS DE COLABORADORES 
function armarCombo() {
    $("#pGestionColaboradores").empty();
    $("#thead").html("");
    $("#thead").html(`<tr>
    <td>Nombre Usuario</td>
    <td>Cantidad de recetas</td>
    <td>Estado</td>
    </tr>`);


    $("#tbody").html("");
    for (let i = 0; i < listaColaboradores.length; i++) {
        let colaborador = listaColaboradores[i];
        let nombre = colaborador.nombre;
        let recetas = colaborador.recetas;
        let estado = colaborador.estado;
        let otroEstado;

        if (estado === "habilitado") {
            otroEstado = "deshabilitado";
        } else {
            otroEstado = "habilitado";
        }

        $("#tbody").append(`<tr>
        <td>${nombre}</td>
        <td>${recetas}</td>
        <td>    <select id="slc${nombre}">
                    <option value="${estado}">${estado}</option>
                    <option value="${otroEstado}">${otroEstado}</option>
                </select>
        </td>
        </tr>`);
    }

    //  F03 - AMINISTRAR COLABORADORES
    $("#btnGuardar").click(administrarColaboradores);




}

// F03.ADMINISTRACION DE ESTADOS DE COLABORADORES
function administrarColaboradores() {
    $("#pGestionColaboradores").html("Cambios guardados");
    for (let i = 0; i < listaColaboradores.length; i++) {
        let nombre = listaColaboradores[i].nombre;
        let nuevoEstado = $(`#slc${nombre}`).val();

        listaColaboradores[i].estado = nuevoEstado;
    }
    listaRHabilitadas();
    mostrarRecetas(listaRecetas, "seccionRecetas");
}


// F04 - PUBLICAR RECETA-----------------------------------------------

function agregarReceta() {
    $("#pPublicarReceta").empty();
    let autor = usuarioLogueado.nombre;
    let titulo = $("#txtTitulo").val();
    let foto = $("#fileFoto").val(); // "C:\fakepath\Pastel_Limon.jpg"
    let extension = foto.substr(foto.lastIndexOf("."));
    let nombreFoto = foto.substr(foto.lastIndexOf("\\") + 1);
    let tiempoTexto = $("#txtTiempo").val();
    let tiempo = Number(tiempoTexto);
    let elaboracion = $("#txtElaboracion").val();

    let existe = false;

    for (let i = 0; i < listaRecetasTotales.length; i++) {
        if (listaRecetasTotales[i].titulo === titulo) {
            existe = true;
            break
        }
    }

    $("#pErrorTituloR").empty();
    $("#pErrorFotoR").empty();
    $("#pErrorTiempoR").empty();
    $("#pErrorElaboracionR").empty();
    $("#pPublicarReceta").empty();
    if (estaVacio(titulo)) {
        $("#pErrorTituloR").html("Ingrese un titulo.");
    } else if (existe) {
        $("#pErrorTituloR").html("Titulo repetido, ingrese un nuevo titulo.");
    } else if (estaVacio(foto)) {
        $("#pErrorFotoR").html("Seleccione una imagen.");
    } else if (extension !== ".jpg") {
        $("#pErrorFotoR").html("Seleccione una imagen con formato jpg.");
    } else if (estaVacio(tiempoTexto) || isNaN(tiempoTexto)) {
        $("#pErrorTiempoR").html("Ingrese un tiempo.");
    } else if (estaVacio(elaboracion)) {
        $("#pErrorElaboracionR").html("Ingrese elaboración.");
    } else if (elaboracion.length > 150) {
        $("#pErrorElaboracionR").html("La elaboración no puede superar los 150 caracteres.");
    } else {

        if (!existe) {
            idGlobal++;
            // sumo una receta al colaborador que la ingreso
            if (autor !== "chef") {
                colaborador = buscarElemento(listaColaboradores, "nombre", autor);
                colaborador.recetas++;
            }
            let nuevaReceta = new Receta(idGlobal, autor, titulo, nombreFoto, tiempo, elaboracion);
            listaRecetasTotales.push(nuevaReceta);

            $("#pPublicarReceta").html("Receta ingresada con exito.");
            crearTablaIDyUsuario();
            listaRHabilitadas();
            mostrarRecetas(listaRecetas, "seccionRecetas");
            $("#txtTitulo").val("");
            $("#fileFoto").val("");
            $("#txtTiempo").val("");
            $("#txtElaboracion").val("");
        }
    }

}


// F05 - FILTRADO DE RECETAS---------------------------------------------------------------------

// F05A - FILTRAR RECETAS POR TIEMPO
$("#btnBuscarTiempo").click(tomarDatosBuscadosPorTiempo);

function tomarDatosBuscadosPorTiempo() {
    $("#pFiltradorDuracion").empty();
    let criterio = $("#txtDuracion").val()
    let criterioBuscado = Number(criterio);
    if (estaVacio(criterio) || isNaN(criterio)) {
        $("#pFiltradorDuracion").html("Ingrese un numero.")
    } else {
        let contadorMayores = 0;
        let contadorMenores = 0;
        for (let i = 0; i < listaRecetas.length; i++) {
            if (listaRecetas[i].tiempoPreparacion > criterioBuscado) {
                contadorMayores++;
            } else {
                contadorMenores++;
            }
        }

        $("#seccionRecetasBuscadas").empty();


        $("#seccionRecetasBuscadas").append(`<table>
        <thead>
        <tr><th>Menores a ${criterioBuscado}</th>
        <th>Mayores a ${criterioBuscado}</th>
        </tr>
        </thead>
        <tbody>
        <tr>
        <td>${contadorMenores}</td>
        <td>${contadorMayores}</td>
        </tr>
        </tbody>
        </table>
        `)
    }
}

// // F05B - FILTRAR RECETAS MAYOR DURACION

$("#btnMostrarRecetasMD").click(tomarDatosBuscados2);

function tomarDatosBuscados2() {
    listaRecetasMayores = []
    let mayorTiempo = Number.NEGATIVE_INFINITY;


    for (let i = 0; i < listaRecetas.length; i++) {
        if (listaRecetas[i].tiempoPreparacion > mayorTiempo) {
            mayorTiempo = listaRecetas[i].tiempoPreparacion;
        }
    }
    for (let j = 0; j < listaRecetas.length; j++) {
        if (listaRecetas[j].tiempoPreparacion === mayorTiempo) {
            listaRecetasMayores.push(listaRecetas[j]);
        }

    }
    $("#seccionRecetasMayorDuracion").empty();
    listaRHabilitadas();
    mostrarRecetas(listaRecetasMayores, "seccionRecetasMayorDuracion");
}

// // F05C - FILTRAR RECETAS mayor RENDIMIENTO

$("#btnMostrarRecetasMR").click(buscarRecetasMR);

function buscarRecetasMR() {
    listaRecetasMR = [];
    let mayorRendimiento = Number.NEGATIVE_INFINITY;


    for (let i = 0; i < listaRecetas.length; i++) {
        let meGusta = listaRecetas[i].meGusta;
        let noMeGusta = listaRecetas[i].noMeGusta;
        let totalEvaluaciones = meGusta + noMeGusta;
        let rendimiento = meGusta * 100 / totalEvaluaciones;
        if (rendimiento > mayorRendimiento) {
            mayorRendimiento = rendimiento;
        }
    }
    for (let j = 0; j < listaRecetas.length; j++) {
        let meGusta = listaRecetas[j].meGusta;
        let noMeGusta = listaRecetas[j].noMeGusta;
        let totalEvaluaciones = meGusta + noMeGusta;
        let rendimiento = meGusta * 100 / totalEvaluaciones;
        if (rendimiento === mayorRendimiento) {
            listaRecetasMR.push(listaRecetas[j]);
        }

    }
    $("#seccionRecetasMR").empty();
    listaRHabilitadas();
    mostrarRecetas(listaRecetasMR, "seccionRecetasMayorRendimiento");
}

// F07 - BUSCAR RECETAS POR PALABRA CLAVE
$("#btnBuscarR").click(buscarRecetaPorPalabra);

function buscarRecetaPorPalabra() {
    let criterioBuscado = $("#txtBuscar").val();
    $("#pNoHayRecetas").empty();
    if (estaVacio(criterioBuscado)) {
        $("#pNoHayRecetas").html("Campo vacio, ingrese palabra buscada.");
    } else {
        criterioBuscado = criterioBuscado.toLowerCase();
        //ELIMINAR ESPACION EN BLANCO
        criterioBuscado = eliminarEspacio(criterioBuscado);


        //ELIMINAR TILDES
        let tildes = "áéíóú";
        let sinTilde = "aeiou";
        for (let j = 0; j < tildes.length; j++) {
            criterioBuscado = sustituirCaracter(criterioBuscado, tildes.charAt(j), sinTilde.charAt(j));
        }

        listaElementos = buscarReceta(listaRecetas, "titulo", criterioBuscado);
        if (listaElementos.length === 0) {
            listaElementos = buscarReceta(listaRecetas, "elaboracion", criterioBuscado);
        }
        if (listaElementos.length === 0) {
            $("#pNoHayRecetas").html("No hay recetas que contengan la palabra buscada.");
        }

        $("#listadoRecetas").empty();
        listaRHabilitadas();
        mostrarRecetas(listaElementos, "listadoRecetas");
    }
}


// F08 - DAR MEGUSTA Y NOMEGUSTA

// F08.MEGUSTA
function darMeGusta() {
    let idReceta = Number($(this).attr("id"));
    let pos = buscarElemento(listaRecetas, "id", idReceta);
    pos.meGusta = pos.meGusta + 1;
    listaRHabilitadas();
    mostrarRecetas(listaRecetas, "seccionRecetas");
    mostrarRecetas(listaRecetasMR, "seccionRecetasMayorRendimiento");
    mostrarRecetas(listaRecetasMayores, "seccionRecetasMayorDuracion");
    mostrarRecetas(listaElementos, "listadoRecetas");
}
// F08.NOMEGUSTA
function darNoMeGusta() {
    let idReceta = Number($(this).attr("id"));
    let pos = buscarElemento(listaRecetas, "id", idReceta);
    pos.noMeGusta = pos.noMeGusta + 1;
    listaRHabilitadas();
    mostrarRecetas(listaRecetas, "seccionRecetas");
    mostrarRecetas(listaRecetasMR, "seccionRecetasMayorRendimiento");
    mostrarRecetas(listaRecetasMayores, "seccionRecetasMayorDuracion");
    mostrarRecetas(listaElementos, "listadoRecetas");
}