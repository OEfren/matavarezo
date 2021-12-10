
    $( document ).ready(function() {
        listar();// js goes in here.
      });  

  function listar() {
       var IdUsuario =  document.getElementById("IdUsuario").value
  
      $.get("Home/ListarTareas/?IdUsuario=" + IdUsuario, function (data) {
          crearListado(data);
  
          document.getElementById("sp_1").innerHTML = data.length;                  
      }) 
      
       $.get("Home/ListarTareasTerminadas/?IdUsuario=" + IdUsuario, function (data) {  
           Grafica1(data);
          }) 
      
      $.get("Home/ListarTareasPorEstatus/?IdUsuario=" + IdUsuario, function (data) {  
           Grafica2(data);
           }) 
         
  }
    
    //-------------
      //- DONUT CHART -
      //-------------
      // Get context with jQuery - using jQuery's .get() method.
   function Grafica1(data)
   {
       
      var labels = [], datas = [];
      
      for (var i = 0; i < data.length; i++) {
          labels.push(data[i]["nombreCategoria"]);
          datas.push(data[i]["idTarea"]);
      }
  
          var donutChartCanvas = $('#donutChart').get(0).getContext('2d')
          var donutData        = {
            labels:labels,
            datasets: [
              {
      
                data: datas ,
                backgroundColor : ['#f56954', '#00a65a', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de'],
              }
            ]
          }
          var donutOptions= {
            maintainAspectRatio : false,
            responsive : true,
          }
          //Create pie or douhnut chart
          // You can switch between pie and douhnut using the method below.
          new Chart(donutChartCanvas, {
            type: 'doughnut',
            data: donutData,
            options: donutOptions
          })
        }
        
       //-------------
      //- DONUT CHART -
      //-------------
      function Grafica2(data)
      { 
          
          var labels = [], datas = [];
          
          for (var i = 0; i < data.length; i++) {
              labels.push(data[i]["nombreEstatus"]);
              datas.push(data[i]["idstatus"]);
          }
  
              var donutChartCanvas = $('#donutChart1').get(0).getContext('2d') 
              var donutData= {
              labels:labels,
              datasets: [
                  {
                  data:datas,
                  backgroundColor : ['#f56954', '#00a65a', '#f39c12', '#00c0ef', '#3c8dbc', '#d2d6de'],
                  }
              ]
              }
              var donutOptions     = {
              maintainAspectRatio : false,
              responsive : true,
              }
              //Create pie or douhnut chart
              // You can switch between pie and douhnut using the method below.
              new Chart(donutChartCanvas, {
              type: 'doughnut',
              data: donutData,
              options: donutOptions
              })
       
           
   
      }


function crearListado(data) {
  
    var contenido = "";
    contenido += "<span class='dropdown-item dropdown-header'>";
    contenido += data.length + " Tarea(s) Pendientes</span>";
    contenido += "<div class='dropdown-divider'></div>";
    

    for (var i = 0; i < data.length; i++) {

        
        contenido += "<a href='#' class='dropdown-item'>";
        contenido += "<i class='fas fa-file mr-2'></i> " + data[i]["nombreTarea"] ;
        contenido += "<span class='float-right text-muted text-sm'>Completar ";
        contenido += "<input type='checkbox' onclick='TerminaTarea(" + data[i]["idTarea"] + ")'>" ;
        contenido += "</span>" ;
        } 
        contenido += "<div class='dropdown-divider'></div>";
        contenido += "<a href='#'' class='dropdown-item dropdown-footer'>Ver Todas las Tareas</a>";
    document.getElementById("dItems").innerHTML = contenido;
}

function TerminaTarea(idTarea)
{
    var frm = new FormData();
    var idTarea = idTarea;
   

    frm.append("idTarea", idTarea);

    $.ajax({
        type: "POST",
        url: "Tareas/actualizaDatos",
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
                  
                if  (idTarea == 0)
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

               
                listar();

            }
            else {
                alert("Ocurrion un error;");
            }

        }
    });
}


  
   
