using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace TareasApp.Models
{
    [Table("CatalagoEstatus")]
    public partial class CatalagoEstatus
    {
        public CatalagoEstatus()
        {
            Tareas = new HashSet<Tarea>();
        }

        [Key]
        public int IdEstatus { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; }
        [Column(TypeName = "date")]
        public DateTime FechaCreacion { get; set; }

        [InverseProperty(nameof(Tarea.IdStatusNavigation))]
        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
