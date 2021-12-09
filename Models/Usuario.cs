using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TareasApp.Models
{
  
    public partial class Usuario
    {
        public Usuario()
        {
            Tareas = new HashSet<Tarea>();
        }

        [Key]
        public int IdUsuario { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public int IdEstatusUsuario { get; set; }
        public int IdTipoUsuario { get; set; }
        [Required]
        [StringLength(200)]
        public string Pass { get; set; }
        public string Salt { get; set; }

        [ForeignKey(nameof(IdEstatusUsuario))]
        [InverseProperty(nameof(Estatus.Usuarios))]
        public virtual Estatus IdEstatusUsuarioNavigation { get; set; }
        [ForeignKey(nameof(IdTipoUsuario))]
        [InverseProperty(nameof(CatalagoTipoUsuario.Usuarios))]
        public virtual CatalagoTipoUsuario IdTipoUsuarioNavigation { get; set; }
        [InverseProperty(nameof(Tarea.IdUsuarioNavigation))]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
