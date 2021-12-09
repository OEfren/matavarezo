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
    public class HomeController : Controller
    {

         DtBusinessContext Dbx;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DtBusinessContext _Dbx)
        {
            _logger = logger;
             Dbx = _Dbx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

         public JsonResult ListarTareas(int IdUsuario)
            {        
                    using(Dbx)
                    {
                            var Lista = Dbx.Tareas.Where(x=> x.IdUsuario == IdUsuario && x.IdStatus == 1).
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
                    
            }

  public JsonResult ListarTareasTerminadas(int IdUsuario)
            {        
                    using(Dbx)
                    {
                            /* var Lista = Dbx.Tareas.Include(x=> x.IdCategoriaNavigation)
                            . GroupBy(y=> y.IdCategoriaNavigation.Nombre  ).
                                Select(x=> new{
                                    
                                        NombreCategoria = x.IdCategoriaNavigation.Nombre , 
                                        Cantidad = x.IdCategoriaNavigation.Nombre.Count()
                                        
                                       
                                })
                                .ToList();  */ 

                                var Lista = from r in Dbx.Tareas
                                         join c in Dbx.CategoriaTareas 
                                            on r.IdCategoria equals c.IdCategoria 
                                             where (r.IdUsuario == IdUsuario)
                                       select new { c.Nombre , c.IdCategoria } into x
                                        group x by new { x.Nombre } into g
                                        select new
                                        {
                                        NombreCategoria = g.Key.Nombre ,
                                        idTarea = g.Count()
                                        };
                        
                        return Json(Lista.ToList());  
                    }                   
                    
            }

 public JsonResult ListarTareasPorEstatus(int IdUsuario)
            {        
                    using(Dbx)
                    {
                            /* var Lista = Dbx.Tareas.Include(x=> x.IdCategoriaNavigation)
                            . GroupBy(y=> y.IdCategoriaNavigation.Nombre  ).
                                Select(x=> new{
                                    
                                        NombreCategoria = x.IdCategoriaNavigation.Nombre , 
                                        Cantidad = x.IdCategoriaNavigation.Nombre.Count()
                                        
                                       
                                })
                                .ToList();  */ 

                                var Lista = from r in Dbx.Tareas
                                         join c in Dbx.CatalagoEstatuses 
                                            on r.IdStatus equals c.IdEstatus 
                                              where (r.IdUsuario == IdUsuario)
                                       select new { c.Nombre , c.IdEstatus } into x
                                        group x by new { x.Nombre } into g
                                        select new
                                        {
                                        NombreEstatus = g.Key.Nombre ,
                                        idstatus = g.Count()
                                        };
                        
                        return Json(Lista.ToList());  
                    }                   
                    
            }           

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
