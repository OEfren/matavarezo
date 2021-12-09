listar();

function listar() {

    $.get("Usuarios/listarUsuarios", function (data) {
        crearListado(["Id Usuario", "Email","Nombre","Fecha", 
                      "Estatus","Tipo Usuario"], data);
    })

    $.get("Usuarios/ListarTipos", function (data) {
        ListarCombox(data);  
    })

    $.get("Usuarios/ListarEstatus", function (data) {
        ListarEstatus(data);  
    })

}

function ListarEstatus(data) {
    LLenarCombo(data, document.getElementById("cboEstatus"), true) 
}

function ListarCombox(data) {
    LLenarCombo(data, document.getElementById("cboTipoUsuario"), true)
   
}

function LLenarCombo(data, Control, primerElemento) {
    var contenido = "";
    if (primerElemento == true) {
        // contenido += "<option value=''>--Seleccione--</option>";
    }
   
    for (var i = 0; i < data.length; i++) {

        contenido += "<option value='" + data[i].iid + "'>";
        contenido += data[i].nombre;
        contenido += "</option>";
    }
       Control.innerHTML = contenido;
}

function crearListado(arraycolumnas, data) {
    var contenido = "";
    contenido += "<table id='example1' class='table table-bordered table-responsive table-condensed'>";
    contenido += "<thead>";
    contenido += "<tr>";

    for (var i = 0; i < arraycolumnas.length; i++) {
        contenido += "<td>"
        contenido += arraycolumnas[i];
        contenido += "</td>"
    }

    //añadir columna
    contenido += "<td>operaciones</td>";

    contenido += "</tr>";
    contenido += "</thead>";
    var llaves = Object.keys(data[0]);
    contenido += "<tbody>";

    for (var i = 0; i < data.length; i++) {
        contenido += "<tr>";
        for (var j = 0; j < llaves.length; j++) {
            var valorLLaves = llaves[j];
            contenido += "<td>";
            contenido += data[i][valorLLaves];
            contenido += "</td>";
        }

        var llaveId = llaves[0];
        contenido += "<td>";
        contenido += "<button class='btn btn-block btn-warning btn-xs' onclick='abrirModal(" + data[i][llaveId] + ")' data-toggle='modal' data-target='#myModal'><i class='fas fa-edit'></i>  </button>  ";
        // contenido += "<button class='btn btn-block btn-danger btn-xs' onclick='eliminar(" + data[i][llaveId] + ")' ><i class='far fa-trash-alt'></i></button>";
        contenido += "</td>";
        contenido += "</tr>";
    }


    contenido += "</tbody>";
    contenido += "<tfoot>";
    contenido += "<tr>";

    for (var i = 0; i < arraycolumnas.length; i++) {
        contenido += "<td>"
        contenido += arraycolumnas[i];
        contenido += "</td>"
    }

    contenido += "<td>operaciones</td>";

    contenido += "</tr>";
    contenido += "</tfoot>";
    contenido += "</table>";

    document.getElementById("tabla").innerHTML = contenido;
    $("#tablas").dataTable(
        {
            searching: false
        }
    );

}

function abrirModal(id) {
    var controlesObligatorios = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorios.length;

    for (i = 0; i < ncontroles; i++) {
        controlesObligatorios[i].parentNode.classList.remove("error");
    }

    if (id == 0) {
        borrarDatos();
        document.getElementById("titleModal").innerText = "Agregar nuevo Usuario";   
    }
    //Boton Editar
    else {
        document.getElementById('txtPassword').value = "0";
        document.getElementById('idPassword').style.display = 'none';    
        document.getElementById("titleModal").innerText = "Actualizar Usuario";
           
        $.get("Usuarios/recuperarDatos/?IdUsuario=" + id, function(data) 
        {
           
            console.log(data);

            document.getElementById("TxtIdUsuario").value = data.llaveId;
            document.getElementById("txtEmail").value = data.email;
            document.getElementById("txtNombre").value = data.nombre;
          /*   document.getElementById("CboEstatus").value = data.idEstatus;
            document.getElementById("cboTipoUsuario").value = data.idTipoUsuario; */
     
        });

    }
}

    function Agregar() {
        if (datosobligatorios() == true) {
            var frm = new FormData();
            var IdUsuario = document.getElementById("TxtIdUsuario").value;
            var Nombre = document.getElementById("txtNombre").value;
            var Email = document.getElementById("txtEmail").value;
            var IdEstatusUsuario = document.getElementById("cboEstatus").value;
            var IdTipoUsuario = document.getElementById("cboTipoUsuario").value;
            var Pass = document.getElementById("txtPassword").value;
           
    
            frm.append("IdUsuario", IdUsuario);
            frm.append("Email", Email);
            frm.append("Nombre", Nombre)
            frm.append("IdEstatusUsuario", IdEstatusUsuario);
            frm.append("IdTipoUsuario", IdTipoUsuario);
            frm.append("Pass", Pass);

                $.ajax({
                    type: "POST",
                    url: "Usuarios/guardarDatos",
                    data: frm,
                    contentType: false,
                    processData: false,
                    success: function (data) {
                        if (data != 0) {
                           
                            var Toast = Swal.mixin({
                                toast: true,
                                position: 'top-end',
                                showConfirmButton: false,
                                timer: 3000
                              });
                              
                            if  (IdUsuario == 0)
                               {       
                                                   
                            Toast.fire({
                                icon: 'success',
                                title: 'Registro agregado correctamente.'
                             
                            });
                                 }
                                  else
                                     {
                                        Toast.fire({
                                            icon: 'success',
                                            title: 'Registro Actualizado correctamente.'
                                         
                                        });
                                     }
    
                            document.getElementById("btnCancelar").click();
                            listar();
    
                        }
                        else {
                            alert("Ocurrion un error;");
                        }
    
                    }
                });
    
            }
    }

    function datosobligatorios() {
        var exito = true;
        var controlesObligatorios = document.getElementsByClassName("obligatorio");
        var ncontroles = controlesObligatorios.length;
        for (var i = 0; i < ncontroles; i++) {
            if (controlesObligatorios[i].value == "") {
                exito = false;
                controlesObligatorios[i].parentNode.classList.add("error");
            }
            else {
                controlesObligatorios[i].parentNode.classList.remove("error");
            }
        }
        return exito;
    }


    function borrarDatos() {
        var controles = document.getElementsByClassName("borrar");
        var ncontroles = controles.length;
        for (var i = 0; i < ncontroles; i++) {
            controles[i].value = ""
        }
    }
