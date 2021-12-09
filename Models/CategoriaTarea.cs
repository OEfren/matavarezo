using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TareasApp.Models
{
    public partial class CategoriaTarea
    {
        public CategoriaTarea()
        {
            Tareas = new HashSet<Tarea>();
        }

        [Key]
        public int IdCategoria { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }
        public bool Estatus { get; set; }

        [InverseProperty(nameof(Tarea.IdCategoriaNavigation))]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
