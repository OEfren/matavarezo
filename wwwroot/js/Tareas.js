$( document ).ready(function() {
    listar();// js goes in here.
});  

function listar() {
     
    $.get("Tareas/ListarTareas", function (data) {
        crearListado(["Id Tareea", "Nombre Tarea","Categoria","Asignado", 
                      "Fecha Creacion","Fecha Terminacion","Estatus"], data);
    })

    $.get("Tareas/ListarCategorias", function (data) {
        ListarCategorias(data);  
    })

    $.get("Tareas/ListarUsuarios", function (data) {
        ListarUsuarios(data);  
    })

    $.get("Tareas/ListarEstatus", function (data) {
        ListarEstatus(data);  
    })

}

function ListarEstatus(data) {
    LLenarCombo(data, document.getElementById("cboEstatusTareas"), true) 
}

function ListarCategorias(data) {
    LLenarCombo(data, document.getElementById("cboCategorias"), true) 
}

function ListarUsuarios(data) {
    LLenarCombo(data, document.getElementById("cboUsuarios"), true) 
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


function abrirModal(id) {
    var controlesObligatorios = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorios.length;


    for (i = 0; i < ncontroles; i++) {
        controlesObligatorios[i].parentNode.classList.remove("error");
    }

    if (id == 0) {
        borrarDatos();
        document.getElementById("titleModal").innerText = "Agregar Nueva Tarea";   
    }
    //Boton Editar
    else {
          
        document.getElementById("titleModal").innerText = "Actualizar Tarea";
           
        $.get("Tareas/recuperarDatos/?IdTarea=" + id, function(data) 
        {
           

            document.getElementById("TxtIdTarea").value = data.llaveId;
            document.getElementById("txtTarea").value = data.nombre;
            $("#cboUsuarios").val(data.idUsuario).trigger("change");
            $("#cboCategorias").val(data.idCategoria).trigger("change");
            $("#cboEstatusTareas").val(data.idStatus).trigger("change");
        
     
        });

    }
}

function Agregar() {
    if (datosobligatorios() == true) {
        var frm = new FormData();
        var IdTarea = document.getElementById("TxtIdTarea").value;
        var Nombre = document.getElementById("txtTarea").value;
        var IdUsuario = document.getElementById("cboUsuarios").value;
        var IdStatus = document.getElementById("cboEstatusTareas").value;
        var IdCategoria = document.getElementById("cboCategorias").value;
        
       

        frm.append("IdTarea", IdTarea);
        frm.append("Nombre", Nombre);
        frm.append("IdUsuario", IdUsuario)
        frm.append("IdStatus", IdStatus);
        frm.append("IdCategoria", IdCategoria);
      
            $.ajax({
                type: "POST",
                url: "Tareas/guardarDatos",
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
                          
                        if  (IdTarea == 0)
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