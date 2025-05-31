using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RayonGuinda.Migrations
{
    /// <inheritdoc />
    public partial class CambiarTipoCodigoAGrupo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archivo",
                columns: table => new
                {
                    Archivo_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alumno_Responsable = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Peso_Archivo = table.Column<int>(type: "int", nullable: false),
                    Fecha_Publicacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Archivo__E5AC051F0605F552", x => x.Archivo_ID);
                });

            migrationBuilder.CreateTable(
                name: "Calificacion",
                columns: table => new
                {
                    Calificacion_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Alumno_Calificacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Calificacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Califica__146BB23EC50181B5", x => x.Calificacion_ID);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Chat_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Other_user = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Chat__9783B1FE4453F6A4", x => x.Chat_ID);
                });

            migrationBuilder.CreateTable(
                name: "Foro",
                columns: table => new
                {
                    Foro_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Administrador = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Nombre_Foro = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Num_Integrantes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Foro__FB62CCA3355C49F8", x => x.Foro_ID);
                });

            migrationBuilder.CreateTable(
                name: "Grupo",
                columns: table => new
                {
                    Grupo_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdminID = table.Column<int>(type: "int", unicode: false, maxLength: 255, nullable: false),
                    Nombre_Grupo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Clave_Acceso = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Num_Integrantes = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Grupo__BE194F08DB4A143C", x => x.Grupo_ID);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    Index_user = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Completo = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Rol = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Particip__0838B1DF216C7E01", x => x.Index_user);
                });

            migrationBuilder.CreateTable(
                name: "Publicacion",
                columns: table => new
                {
                    Publicacion_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor_Publicacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Contenido_Publicacion = table.Column<string>(type: "text", nullable: false),
                    Fecha_Publicacion = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Publicac__E3FEC052ECCCA370", x => x.Publicacion_ID);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    Tarea_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor_Publicacion = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Contenido_Publicacion = table.Column<string>(type: "text", nullable: false),
                    Fecha_Publicacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Calificar = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tarea__327AB98A18E2ABB1", x => x.Tarea_ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Apellido_Paterno = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Apellido_Materno = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Nombres = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    Num_Boleta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Correo_Institucional = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Contraseña = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario__206D9190B281C9D9", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Comentario_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Autor_Comentario = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    Contenido_Comentario = table.Column<string>(type: "text", nullable: false),
                    Publicacion_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Comentar__6551412944FA7B88", x => x.Comentario_ID);
                    table.ForeignKey(
                        name: "FK__Comentari__Publi__534D60F1",
                        column: x => x.Publicacion_ID,
                        principalTable: "Publicacion",
                        principalColumn: "Publicacion_ID");
                });

            migrationBuilder.CreateTable(
                name: "Publicacion_Foro",
                columns: table => new
                {
                    Publicacion_ID = table.Column<int>(type: "int", nullable: false),
                    Foro_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Publicac__CC48EC988C53B95B", x => new { x.Publicacion_ID, x.Foro_ID });
                    table.ForeignKey(
                        name: "FK__Publicaci__Foro___628FA481",
                        column: x => x.Foro_ID,
                        principalTable: "Foro",
                        principalColumn: "Foro_ID");
                    table.ForeignKey(
                        name: "FK__Publicaci__Publi__619B8048",
                        column: x => x.Publicacion_ID,
                        principalTable: "Publicacion",
                        principalColumn: "Publicacion_ID");
                });

            migrationBuilder.CreateTable(
                name: "Archivo_Tarea",
                columns: table => new
                {
                    Calificacion_ID = table.Column<int>(type: "int", nullable: false),
                    Tarea_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Archivo___A74C19A604536A11", x => new { x.Calificacion_ID, x.Tarea_ID });
                    table.ForeignKey(
                        name: "FK__Archivo_T__Calif__6D0D32F4",
                        column: x => x.Calificacion_ID,
                        principalTable: "Calificacion",
                        principalColumn: "Calificacion_ID");
                    table.ForeignKey(
                        name: "FK__Archivo_T__Tarea__6E01572D",
                        column: x => x.Tarea_ID,
                        principalTable: "Tarea",
                        principalColumn: "Tarea_ID");
                });

            migrationBuilder.CreateTable(
                name: "Calificacion_Tarea",
                columns: table => new
                {
                    Calificacion_ID = table.Column<int>(type: "int", nullable: false),
                    Tarea_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Califica__A74C19A6C244FCF0", x => new { x.Calificacion_ID, x.Tarea_ID });
                    table.ForeignKey(
                        name: "FK__Calificac__Calif__70DDC3D8",
                        column: x => x.Calificacion_ID,
                        principalTable: "Calificacion",
                        principalColumn: "Calificacion_ID");
                    table.ForeignKey(
                        name: "FK__Calificac__Tarea__71D1E811",
                        column: x => x.Tarea_ID,
                        principalTable: "Tarea",
                        principalColumn: "Tarea_ID");
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Chat",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Chat_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario___D915AA8FDF95BA20", x => new { x.User_ID, x.Chat_ID });
                    table.ForeignKey(
                        name: "FK__Usuario_C__Chat___6A30C649",
                        column: x => x.Chat_ID,
                        principalTable: "Chat",
                        principalColumn: "Chat_ID");
                    table.ForeignKey(
                        name: "FK__Usuario_C__User___693CA210",
                        column: x => x.User_ID,
                        principalTable: "Usuario",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Foro",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Foro_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario___0FDBBD5AF8733CB7", x => new { x.User_ID, x.Foro_ID });
                    table.ForeignKey(
                        name: "FK__Usuario_F__Foro___5EBF139D",
                        column: x => x.Foro_ID,
                        principalTable: "Foro",
                        principalColumn: "Foro_ID");
                    table.ForeignKey(
                        name: "FK__Usuario_F__User___5DCAEF64",
                        column: x => x.User_ID,
                        principalTable: "Usuario",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Grupo",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false),
                    Grupo_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Usuario___BB8C056025A0417F", x => new { x.User_ID, x.Grupo_ID });
                    table.ForeignKey(
                        name: "FK__Usuario_G__Grupo__66603565",
                        column: x => x.Grupo_ID,
                        principalTable: "Grupo",
                        principalColumn: "Grupo_ID");
                    table.ForeignKey(
                        name: "FK__Usuario_G__User___656C112C",
                        column: x => x.User_ID,
                        principalTable: "Usuario",
                        principalColumn: "User_ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Archivo_Tarea_Tarea_ID",
                table: "Archivo_Tarea",
                column: "Tarea_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Calificacion_Tarea_Tarea_ID",
                table: "Calificacion_Tarea",
                column: "Tarea_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentario_Publicacion_ID",
                table: "Comentario",
                column: "Publicacion_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacion_Foro_Foro_ID",
                table: "Publicacion_Foro",
                column: "Foro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Chat_Chat_ID",
                table: "Usuario_Chat",
                column: "Chat_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Foro_Foro_ID",
                table: "Usuario_Foro",
                column: "Foro_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Grupo_Grupo_ID",
                table: "Usuario_Grupo",
                column: "Grupo_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archivo");

            migrationBuilder.DropTable(
                name: "Archivo_Tarea");

            migrationBuilder.DropTable(
                name: "Calificacion_Tarea");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Participantes");

            migrationBuilder.DropTable(
                name: "Publicacion_Foro");

            migrationBuilder.DropTable(
                name: "Usuario_Chat");

            migrationBuilder.DropTable(
                name: "Usuario_Foro");

            migrationBuilder.DropTable(
                name: "Usuario_Grupo");

            migrationBuilder.DropTable(
                name: "Calificacion");

            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Publicacion");

            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "Foro");

            migrationBuilder.DropTable(
                name: "Grupo");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
