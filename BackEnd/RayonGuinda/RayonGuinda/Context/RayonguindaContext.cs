using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RayonGuinda.Models;

namespace RayonGuinda.Context;

public partial class RayonguindaContext : DbContext
{
    public RayonguindaContext()
    {
    }

    public RayonguindaContext(DbContextOptions<RayonguindaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ArchivoModel> Archivos { get; set; }

    public virtual DbSet<CalificacionModel> Calificacions { get; set; }

    public virtual DbSet<ChatModel> Chats { get; set; }

    public virtual DbSet<ComentarioModel> Comentarios { get; set; }

    public virtual DbSet<ForoModel> Foros { get; set; }

    public virtual DbSet<GrupoModel> Grupos { get; set; }

    public virtual DbSet<ParticipanteModel> Participantes { get; set; }

    public virtual DbSet<PublicacionModel> Publicacions { get; set; }

    public virtual DbSet<TareaModel> Tareas { get; set; }

    public virtual DbSet<UsuarioModel> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DEWKAT\\SQLEXPRESS;Database=RAYONGUINDA;Trust Server Certificate=true;User Id=Admin;Password=admin;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ArchivoModel>(entity =>
        {
            entity.HasKey(e => e.ArchivoId).HasName("PK__Archivo__E5AC051F0605F552");

            entity.ToTable("Archivo");

            entity.Property(e => e.ArchivoId).HasColumnName("Archivo_ID");
            entity.Property(e => e.AlumnoResponsable)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Alumno_Responsable");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Publicacion");
            entity.Property(e => e.PesoArchivo).HasColumnName("Peso_Archivo");
        });

        modelBuilder.Entity<CalificacionModel>(entity =>
        {
            entity.HasKey(e => e.CalificacionId).HasName("PK__Califica__146BB23EC50181B5");

            entity.ToTable("Calificacion");

            entity.Property(e => e.CalificacionId).HasColumnName("Calificacion_ID");
            entity.Property(e => e.AlumnoCalificacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Alumno_Calificacion");
            entity.Property(e => e.Calificacion1).HasColumnName("Calificacion");

            entity.HasMany(d => d.Tareas).WithMany(p => p.Calificacions)
                .UsingEntity<Dictionary<string, object>>(
                    "ArchivoTarea",
                    r => r.HasOne<TareaModel>().WithMany()
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Archivo_T__Tarea__6E01572D"),
                    l => l.HasOne<CalificacionModel>().WithMany()
                        .HasForeignKey("CalificacionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Archivo_T__Calif__6D0D32F4"),
                    j =>
                    {
                        j.HasKey("CalificacionId", "TareaId").HasName("PK__Archivo___A74C19A604536A11");
                        j.ToTable("Archivo_Tarea");
                        j.IndexerProperty<int>("CalificacionId").HasColumnName("Calificacion_ID");
                        j.IndexerProperty<int>("TareaId").HasColumnName("Tarea_ID");
                    });

            entity.HasMany(d => d.TareasNavigation).WithMany(p => p.CalificacionsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "CalificacionTarea",
                    r => r.HasOne<TareaModel>().WithMany()
                        .HasForeignKey("TareaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Calificac__Tarea__71D1E811"),
                    l => l.HasOne<CalificacionModel>().WithMany()
                        .HasForeignKey("CalificacionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Calificac__Calif__70DDC3D8"),
                    j =>
                    {
                        j.HasKey("CalificacionId", "TareaId").HasName("PK__Califica__A74C19A6C244FCF0");
                        j.ToTable("Calificacion_Tarea");
                        j.IndexerProperty<int>("CalificacionId").HasColumnName("Calificacion_ID");
                        j.IndexerProperty<int>("TareaId").HasColumnName("Tarea_ID");
                    });
        });

        modelBuilder.Entity<ChatModel>(entity =>
        {
            entity.HasKey(e => e.ChatId).HasName("PK__Chat__9783B1FE4453F6A4");

            entity.ToTable("Chat");

            entity.Property(e => e.ChatId).HasColumnName("Chat_ID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.OtherUser)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Other_user");
        });

        modelBuilder.Entity<ComentarioModel>(entity =>
        {
            entity.HasKey(e => e.ComentarioId).HasName("PK__Comentar__6551412944FA7B88");

            entity.ToTable("Comentario");

            entity.Property(e => e.ComentarioId).HasColumnName("Comentario_ID");
            entity.Property(e => e.AutorComentario)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Autor_Comentario");
            entity.Property(e => e.ContenidoComentario)
                .HasColumnType("text")
                .HasColumnName("Contenido_Comentario");
            entity.Property(e => e.PublicacionId).HasColumnName("Publicacion_ID");

            entity.HasOne(d => d.Publicacion).WithMany(p => p.Comentarios)
                .HasForeignKey(d => d.PublicacionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comentari__Publi__534D60F1");
        });

        modelBuilder.Entity<ForoModel>(entity =>
        {
            entity.HasKey(e => e.ForoId).HasName("PK__Foro__FB62CCA3355C49F8");

            entity.ToTable("Foro");

            entity.Property(e => e.ForoId).HasColumnName("Foro_ID");
            entity.Property(e => e.Administrador)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NombreForo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_Foro");
            entity.Property(e => e.NumIntegrantes).HasColumnName("Num_Integrantes");
        });

        modelBuilder.Entity<GrupoModel>(entity =>
        {
            entity.HasKey(e => e.GrupoId).HasName("PK__Grupo__BE194F08DB4A143C");

            entity.ToTable("Grupo");

            entity.Property(e => e.GrupoId).HasColumnName("Grupo_ID");
            entity.Property(e => e.Administrador)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ClaveAcceso)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Clave_Acceso");
            entity.Property(e => e.NombreGrupo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_Grupo");
            entity.Property(e => e.NumIntegrantes).HasColumnName("Num_Integrantes");
        });

        modelBuilder.Entity<ParticipanteModel>(entity =>
        {
            entity.HasKey(e => e.IndexUser).HasName("PK__Particip__0838B1DF216C7E01");

            entity.Property(e => e.IndexUser).HasColumnName("Index_user");
            entity.Property(e => e.NombreCompleto)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Nombre_Completo");
            entity.Property(e => e.Rol)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PublicacionModel>(entity =>
        {
            entity.HasKey(e => e.PublicacionId).HasName("PK__Publicac__E3FEC052ECCCA370");

            entity.ToTable("Publicacion");

            entity.Property(e => e.PublicacionId).HasColumnName("Publicacion_ID");
            entity.Property(e => e.AutorPublicacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Autor_Publicacion");
            entity.Property(e => e.ContenidoPublicacion)
                .HasColumnType("text")
                .HasColumnName("Contenido_Publicacion");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Publicacion");

            entity.HasMany(d => d.Foros).WithMany(p => p.Publicacions)
                .UsingEntity<Dictionary<string, object>>(
                    "PublicacionForo",
                    r => r.HasOne<ForoModel>().WithMany()
                        .HasForeignKey("ForoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Publicaci__Foro___628FA481"),
                    l => l.HasOne<PublicacionModel>().WithMany()
                        .HasForeignKey("PublicacionId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Publicaci__Publi__619B8048"),
                    j =>
                    {
                        j.HasKey("PublicacionId", "ForoId").HasName("PK__Publicac__CC48EC988C53B95B");
                        j.ToTable("Publicacion_Foro");
                        j.IndexerProperty<int>("PublicacionId").HasColumnName("Publicacion_ID");
                        j.IndexerProperty<int>("ForoId").HasColumnName("Foro_ID");
                    });
        });

        modelBuilder.Entity<TareaModel>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tarea__327AB98A18E2ABB1");

            entity.ToTable("Tarea");

            entity.Property(e => e.TareaId).HasColumnName("Tarea_ID");
            entity.Property(e => e.AutorPublicacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Autor_Publicacion");
            entity.Property(e => e.ContenidoPublicacion)
                .HasColumnType("text")
                .HasColumnName("Contenido_Publicacion");
            entity.Property(e => e.FechaPublicacion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Publicacion");
        });

        modelBuilder.Entity<UsuarioModel>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Usuario__206D9190B281C9D9");

            entity.ToTable("Usuario");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Apellido_Materno");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Apellido_Paterno");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CorreoInstitucional)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Correo_Institucional");
            entity.Property(e => e.FechaNacimiento).HasColumnName("Fecha_Nacimiento");
            entity.Property(e => e.Nombres)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NumBoleta)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Num_Boleta");

            entity.HasMany(d => d.Chats).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioChat",
                    r => r.HasOne<ChatModel>().WithMany()
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuario_C__Chat___6A30C649"),
                    l => l.HasOne<UsuarioModel>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuario_C__User___693CA210"),
                    j =>
                    {
                        j.HasKey("UserId", "ChatId").HasName("PK__Usuario___D915AA8FDF95BA20");
                        j.ToTable("Usuario_Chat");
                        j.IndexerProperty<int>("UserId").HasColumnName("User_ID");
                        j.IndexerProperty<int>("ChatId").HasColumnName("Chat_ID");
                    });

            entity.HasMany(d => d.Foros).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioForo",
                    r => r.HasOne<ForoModel>().WithMany()
                        .HasForeignKey("ForoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuario_F__Foro___5EBF139D"),
                    l => l.HasOne<UsuarioModel>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuario_F__User___5DCAEF64"),
                    j =>
                    {
                        j.HasKey("UserId", "ForoId").HasName("PK__Usuario___0FDBBD5AF8733CB7");
                        j.ToTable("Usuario_Foro");
                        j.IndexerProperty<int>("UserId").HasColumnName("User_ID");
                        j.IndexerProperty<int>("ForoId").HasColumnName("Foro_ID");
                    });

            entity.HasMany(d => d.Grupos).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UsuarioGrupo",
                    r => r.HasOne<GrupoModel>().WithMany()
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuario_G__Grupo__66603565"),
                    l => l.HasOne<UsuarioModel>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Usuario_G__User___656C112C"),
                    j =>
                    {
                        j.HasKey("UserId", "GrupoId").HasName("PK__Usuario___BB8C056025A0417F");
                        j.ToTable("Usuario_Grupo");
                        j.IndexerProperty<int>("UserId").HasColumnName("User_ID");
                        j.IndexerProperty<int>("GrupoId").HasColumnName("Grupo_ID");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
