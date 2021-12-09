using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TareasApp.Models
{
    public partial class CatalagoTipoUsuario
    {
        public CatalagoTipoUsuario()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }
        public bool Estatus { get; set; }

        [InverseProperty(nameof(Usuario.IdTipoUsuarioNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
