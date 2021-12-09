using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TareasApp.Migrations
{
    public partial class TareasV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CatalagoEstatus",
                columns: table => new
                {
                    IdEstatus = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalagoEstatus", x => x.IdEstatus);
                });

            migrationBuilder.CreateTable(
                name: "CatalagoTipoUsuarios",
                columns: table => new
                {
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalagoTipoUsuarios", x => x.IdTipoUsuario);
                });

            migrationBuilder.CreateTable(
                name: "CategoriaTareas",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    Estatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaTareas", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Estatus",
                columns: table => new
                {
                    IdEstatusUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estatus", x => x.IdEstatusUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    IdEstatusUsuario = table.Column<int>(type: "int", nullable: false),
                    IdTipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Pass = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_CatalagoTipoUsuarios",
                        column: x => x.IdTipoUsuario,
                        principalTable: "CatalagoTipoUsuarios",
                        principalColumn: "IdTipoUsuario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Estatus",
                        column: x => x.IdEstatusUsuario,
                        principalTable: "Estatus",
                        principalColumn: "IdEstatusUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    IdTarea = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "date", nullable: false),
                    FechaTerminacion = table.Column<DateTime>(type: "date", nullable: false),
                    IdStatus = table.Column<int>(type: "int", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.IdTarea);
                    table.ForeignKey(
                        name: "FK_Tareas_CatalagoEstatus",
                        column: x => x.IdStatus,
                        principalTable: "CatalagoEstatus",
                        principalColumn: "IdEstatus",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tareas_CategoriaTareas",
                        column: x => x.IdCategoria,
                        principalTable: "CategoriaTareas",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tareas_Usuarios",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdCategoria",
                table: "Tareas",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdStatus",
                table: "Tareas",
                column: "IdStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Tareas_IdUsuario",
                table: "Tareas",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdEstatusUsuario",
                table: "Usuarios",
                column: "IdEstatusUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_IdTipoUsuario",
                table: "Usuarios",
                column: "IdTipoUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tareas");

            migrationBuilder.DropTable(
                name: "CatalagoEstatus");

            migrationBuilder.DropTable(
                name: "CategoriaTareas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CatalagoTipoUsuarios");

            migrationBuilder.DropTable(
                name: "Estatus");
        }
    }
}
