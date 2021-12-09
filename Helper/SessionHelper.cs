using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace TareasApp.Helper
{
    public class SessionHelper
    {
        
       /* public static string GetValue(IPrincipal User , string Property)
        {
            var r  = (( ClaimsIdentity)User.Identity).FindFirst(Property);
            return  r ==  null ?  "" : r.Value;
        }*/

        public static string GetNameIdentifier(IPrincipal User)
        {
            var r  = (( ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.NameIdentifier);
            return  r ==  null ?  "" : r.Value;
        }

        public static string GetName(IPrincipal User)
        {
            var r  = (( ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Name);
            return  r ==  null ?  "" : r.Value;
        }

        public static string GetEmail(IPrincipal User)
        {
            var r  = (( ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Email);
            return  r ==  null ?  "" : r.Value;
        }

             public static string GetIdUser(IPrincipal User)
        {
            var r  = (( ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Sid );
            return  r ==  null ?  "" : r.Value;
        }

              public static string GetTipoUser(IPrincipal User)
        {
            var r  = (( ClaimsIdentity)User.Identity).FindFirst(ClaimTypes.Role);
            return  r ==  null ?  "" : r.Value;
        }

        

    }
}