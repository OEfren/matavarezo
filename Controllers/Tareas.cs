using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TareasApp.Models;
using Microsoft.EntityFrameworkCore;
using TareasApp.Helper;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;

namespace TareasApp.Controllers
{
   [Authorize]

   public class Tareas : Controller
   {
       DtBusinessContext Dbx;

        public Tareas(DtBusinessContext _Dbx)
          {
                Dbx = _Dbx;
          }

        public ActionResult Index()
        {
           return View();
        }

         [HttpGet]

         public JsonResult ListarCategorias()
            {
            
                    var Lista = Dbx.CategoriaTareas.
                                    
                        Select(x=> new{
                                iid = x.IdCategoria ,
                                Nombre = x.Nombre                       
                        }).ToList();  
                        return Json(Lista);
                
            }

          public JsonResult ListarEstatus()
            {
                
                    var Lista = Dbx.CatalagoEstatuses.
                                    
                        Select(x=> new{
                            iid = x.IdEstatus ,
                            Nombre = x.Nombre                       
                        }).ToList();  
                        return Json(Lista);
                
            }

           public JsonResult ListarUsuarios()
            {
               
                    var Lista = Dbx.Usuarios.
                                    
                        Select(x=> new{
                            iid = x.IdUsuario ,
                            Nombre = x.Nombre                       
                        }).ToList();  
                        return Json(Lista);
               
            }


            public JsonResult ListarTareas()
            {        
                    
                            var Lista = Dbx.Tareas.
                                Select(x=> new{
                                        x.IdTarea ,
                                        NombreTarea = x.Nombre,
                                        NombreCategoria = x.IdCategoriaNavigation.Nombre , 
                                        Asignado = x.IdUsuarioNavigation .Nombre ,
                                        FechaCreacion = x.FechaCreacion ,
                                        FechaTerminacion  = x.FechaCreacion == null ? x.FechaCreacion.ToString() : "" ,
                                        Estatus = x.IdStatusNavigation.Nombre  
                                }).ToList();  
                        
                        return Json(Lista);  
                                    
                    
            }
        
        [BindProperty]
        public Tarea Tarea { get; set; }
        public int guardarDatos(Tarea oTarea)
        {
            int nregistrosAfectados = 0;
           
                var _Tarea = Dbx.Tareas.Where(c => c.IdTarea == oTarea.IdTarea).SingleOrDefault();
                try
                {
                   
                    if (oTarea.IdTarea == 0)
                    {
                        
                        Tarea.Nombre = oTarea.Nombre ;                      
                        Tarea.FechaCreacion = System.DateTime.Now;
                        Tarea.IdCategoria = oTarea.IdCategoria  ;     
                        Tarea.IdUsuario = oTarea.IdUsuario ;  
                        Tarea.IdStatus = oTarea.IdStatus ;     

                        Dbx.Tareas.Add(Tarea);
                        nregistrosAfectados = 1;
                        Dbx.SaveChanges();
                    }
                    //editar
                    else
                    {
                        _Tarea.Nombre = Tarea.Nombre;
                        _Tarea.IdCategoria = Tarea.IdCategoria;
                        _Tarea.IdUsuario = Tarea.IdUsuario;
                        _Tarea.IdStatus = Tarea.IdStatus;
                        
                        Dbx.SaveChanges();
                        nregistrosAfectados = 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    nregistrosAfectados = 0;
                }
           

            return nregistrosAfectados;
        }

         
        public int actualizaDatos(Tarea oTarea)
        {
            int nregistrosAfectados = 0;
            
                var _Tarea = Dbx.Tareas.Where(c => c.IdTarea == oTarea.IdTarea).SingleOrDefault();
                try
                {
                
                    if (_Tarea.IdTarea != 0)
                    {
                        _Tarea.FechaTerminacion =System.DateTime.Now;
                        _Tarea.IdStatus = 2;
                        
                        Dbx.SaveChanges();
                        nregistrosAfectados = 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    nregistrosAfectados = 0;
                }
           

            return nregistrosAfectados;
        }

   }
}