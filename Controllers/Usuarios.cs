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
    public class Usuarios : Controller
    {
          DtBusinessContext Dbx;

          public Usuarios(DtBusinessContext _Dbx)
          {
                Dbx = _Dbx;
          }

            public ActionResult Index()
            {
                    return View();
            }

        [HttpGet]
        public JsonResult ListarUsuarios()
        {
            using(Dbx)
            {
                var Lista = Dbx.Usuarios.Include(x => x.IdTipoUsuarioNavigation ).Include(e=> e.IdEstatusUsuarioNavigation). 
                            Where(p => p.IdEstatusUsuario.Equals(1))
                    .Select(x=> new
                    {
                        x.IdUsuario,
                        x.Email,
                        x.Nombre,
                        x.Fecha,
                        Estatus= x.IdEstatusUsuarioNavigation.Nombre  ,
                        TipoUsuario= x.IdTipoUsuarioNavigation.Nombre,
                         }).ToList();
                    
                    return Json(Lista);


            }
        }

     public JsonResult ListarTipos()
        {
            using(Dbx)
            {
                var Lista = Dbx.CatalagoTipoUsuarios.Where(p => p.Estatus.Equals(true))
                    .Select(x=> new
                    {
                      iid=  x.IdTipoUsuario,
                        x.Nombre
                         }).ToList();
                    
                    return Json(Lista);
            }
        }

 public JsonResult ListarEstatus()
        {
            using(Dbx)
            {
                var Lista = Dbx.Estatuses
                    .Select(x=> new
                    {
                      iid=  x.IdEstatusUsuario,
                        x.Nombre
                         }).ToList();
                    
                    return Json(Lista);
            }
        }

        [BindProperty]
        public Usuario Usuario { get; set; }
        public int guardarDatos(Usuario oUsuario)
        {
            int nregistrosAfectados = 0;
            using (Dbx)
            {
                var _Usuario = Dbx.Usuarios.Where(c => c.IdUsuario == oUsuario.IdUsuario).SingleOrDefault();
                try
                {
                    
                    if (oUsuario.IdUsuario == 0)
                    {
                        Usuario.Email = oUsuario .Email;
                        Usuario.Nombre = oUsuario.Nombre ;                      
                        Usuario.Fecha = System.DateTime.Now;
                        Usuario.IdEstatusUsuario = oUsuario.IdEstatusUsuario  ;     
                        Usuario.IdTipoUsuario = oUsuario.IdTipoUsuario ;     
                       
                        var hash =  hasHelper.Hash(oUsuario.Pass);
                        Usuario.Pass =hash.Password;
                        Usuario.Salt = hash.Salt;
                        
                        Dbx.Usuarios.Add(Usuario);
                        nregistrosAfectados = 1;
                        Dbx.SaveChanges();
                    }
                    //editar
                    else
                    {
                        _Usuario.Nombre = Usuario.Nombre;
                        _Usuario.Email = Usuario.Email;
                        _Usuario.IdEstatusUsuario = Usuario.IdEstatusUsuario;
                        _Usuario.IdTipoUsuario = Usuario.IdTipoUsuario;
                        _Usuario.Fecha = System.DateTime.Now;
                        Dbx.SaveChanges();
                        nregistrosAfectados = 1;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    nregistrosAfectados = 0;
                }
            }

            return nregistrosAfectados;
        }

       public JsonResult recuperarDatos(int IdUsuario)
        {
            using (Dbx)
            {
                var oUsuarios = Dbx.Usuarios.
                                     Where(p => p.IdEstatusUsuario.Equals(1) && p.IdUsuario == IdUsuario)

                 .Select(x => new
                 {
                     llaveId = x.IdUsuario,
                     Nombre = x.Nombre,
                     x.Email,
                     IdEstatus = x.IdEstatusUsuario ,
                     IdTipoUsuario =x.IdTipoUsuario

                 }).First();

                return Json(oUsuarios);

            }
        }

    }
}