using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TareasApp.Models;
using Microsoft.EntityFrameworkCore;
using TareasApp.Models.ViewModel;
using TareasApp.Helper;
using Newtonsoft.Json.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace TareasApp.Controllers
{

    public class Login : Controller
    {

        DtBusinessContext dbx;

        public Login(DtBusinessContext _dbx)
        {
            dbx = _dbx;
        }
        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
                {
                     return Redirect ("/Home");
                }
                    else
                    {
                    return View();
                    }
        }

        [BindProperty]
        public UsuarioVM Usuario { get; set; }
        public async Task<IActionResult> LogIn()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new JObject(){
                  { "StatusCode" , 400 },
                  { "Message" , "Ingrese Usuario y Password"}
              });
            }
            else
            {
                var result = await dbx.Usuarios.Include(x => x.IdTipoUsuarioNavigation ).Where(x => x.Email == Usuario.Email).SingleOrDefaultAsync();

                if (result == null)
                {
                    return NotFound(new JObject() {
                                { "StatusCode", 405 },
                                { "Message", "Usuario no encontrado." }
                             });
                }
                else
                {
                    if (hasHelper.CheckHash(Usuario.Password, result.Pass, result.Salt))
                    {
                        var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme,ClaimTypes.Name,ClaimTypes.Role);
                        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier ,result.IdUsuario.ToString()));
                        identity.AddClaim(new Claim(ClaimTypes.Name, result.Nombre));
                        identity.AddClaim(new Claim(ClaimTypes.Email , result.Email ));
                        identity.AddClaim(new Claim(ClaimTypes.Role , result.IdTipoUsuarioNavigation.Nombre));
                        var principal = new ClaimsPrincipal(identity);     
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, 
                        new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddHours(1), IsPersistent  = true });
                         return Redirect ("/Home");
                    }
                    else
                    {


                        var response = new JObject() {
                                { "StatusCode", 403 },
                                { "Message", "Usuario o Password incorrecto" }
                                     };

                        return StatusCode(403, response);
                    }
                }
            }

        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/LogIn");
        }

    }
}