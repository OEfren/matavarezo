using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TareasApp.Models
{
    public partial class Tarea
    {
        [Key]
        public int IdTarea { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int IdUsuario { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaTerminacion { get; set; }
        public int IdStatus { get; set; }
        public int IdCategoria { get; set; }

        [ForeignKey(nameof(IdCategoria))]
        [InverseProperty(nameof(CategoriaTarea.Tareas))]
        public virtual CategoriaTarea IdCategoriaNavigation { get; set; }
        [ForeignKey(nameof(IdStatus))]
        [InverseProperty(nameof(CatalagoEstatus.Tareas))]
        public virtual CatalagoEstatus IdStatusNavigation { get; set; }
        [ForeignKey(nameof(IdUsuario))]
        [InverseProperty(nameof(Usuario.Tareas))]
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
