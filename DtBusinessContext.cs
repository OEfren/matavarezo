using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TareasApp.Models
{
    public partial class DtBusinessContext : DbContext
    {
        public DtBusinessContext()
        {
        }

        public DtBusinessContext(DbContextOptions<DtBusinessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatalagoEstatus> CatalagoEstatuses { get; set; }
        public virtual DbSet<CatalagoTipoUsuario> CatalagoTipoUsuarios { get; set; }
        public virtual DbSet<CategoriaTarea> CategoriaTareas { get; set; }
        public virtual DbSet<Estatus> Estatuses { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<CatalagoEstatus>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<CatalagoTipoUsuario>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<CategoriaTarea>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Estatus>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tareas_CategoriaTareas");

                entity.HasOne(d => d.IdStatusNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tareas_CatalagoEstatus");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tareas_Usuarios");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Pass).IsUnicode(false);

                entity.HasOne(d => d.IdEstatusUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdEstatusUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_Estatus");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Usuarios_CatalagoTipoUsuarios");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
