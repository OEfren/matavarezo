using System.ComponentModel.DataAnnotations;

namespace TareasApp.Models.ViewModel
{
    public class UsuarioVM
    {
        [Required(ErrorMessage = "Escriba el Nombre del Usuario")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Escriba su contraseña")]
        public string Password {get; set;}


    }
}