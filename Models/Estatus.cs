using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TareasApp.Models
{
    [Table("Estatus")]
    public partial class Estatus
    {
        public Estatus()
        {
            Usuarios = new HashSet<Usuario>();
        }

        [Key]
        public int IdEstatusUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [InverseProperty(nameof(Usuario.IdEstatusUsuarioNavigation))]
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
