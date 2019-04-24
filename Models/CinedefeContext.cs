using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CinedefeBackend.Models
{
    public partial class CinedefeContext : DbContext
    {
        public CinedefeContext()
        {
        }

        public CinedefeContext(DbContextOptions<CinedefeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Boleto> Boletos { get; set; }
        public virtual DbSet<BoletoTipo> BoletosTipos { get; set; }
        public virtual DbSet<BoletoTipoFuncion> BoletoTipoFuncion { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Funcion> Funciones { get; set; }
        public virtual DbSet<FuncionHorario> FuncionHorarios { get; set; }
        public virtual DbSet<FuncionAsientosReservados> FuncionesAsientosReservados { get; set; }
        public virtual DbSet<Pelicula> Peliculas { get; set; }
        public virtual DbSet<PeliculaClasificacion> PeliculasClasificaciones { get; set; }
        public virtual DbSet<Sala> Salas { get; set; }
        public virtual DbSet<SalaAsientos> SalasAsientos { get; set; }
        public virtual DbSet<SalaTipo> SalasTipos { get; set; }
        public virtual DbSet<Sucursal> Sucursales { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<UsuarioRol> UsuariosRoles { get; set; }

        public virtual DbQuery<UsuariosRolesView> vwUsuariosRoles { get; set; }
        public virtual DbQuery<FuncionDisponibleView> vwFuncionesDisponibles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=TodosPara.1;database=cinedefe");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.1-servicing-10028");

            modelBuilder.Entity<Boleto>(entity =>
            {
                entity.ToTable("boletos", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.AsientoFila)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AsientoNumero).HasColumnType("smallint(6)");

                entity.Property(e => e.ClienteId).HasColumnType("int(11)");

                entity.Property(e => e.FuncionId).HasColumnType("int(11)");

                entity.Property(e => e.Precio).HasColumnType("decimal(11,2)");

                entity.Property(e => e.TipoId).HasColumnType("int(11)");

                entity.Property(e => e.Horario).HasColumnType("datetime");
            });

            modelBuilder.Entity<BoletoTipo>(entity =>
            {
                entity.ToTable("boletostipos", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioActual).HasColumnType("decimal(11,2)");
            });

            modelBuilder.Entity<BoletoTipoFuncion>(entity =>
            {
                entity.HasKey(e => new { e.BoletoTipoId, e.FuncionId });

                entity.ToTable("boletostiposfunciones", "cinedefe");

                entity.Property(e => e.BoletoTipoId).HasColumnType("int(11)");

                entity.Property(e => e.FuncionId).HasColumnType("int(11)");

                entity.Property(e => e.Precio).HasColumnType("decimal(11,2)");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("clientes", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.ToTable("funciones", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.PeliculaId)
                    .HasName("PeliculaId");

                entity.HasIndex(e => e.SalaId)
                    .HasName("SalaId");

                entity.HasIndex(e => new { e.SalaId, e.PeliculaId })
                    .HasName("SalaPelicula")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activa).HasColumnType("tinyint(4)");

                entity.Property(e => e.PeliculaId).HasColumnType("int(11)");

                entity.Property(e => e.SalaId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<FuncionHorario>(entity =>
            {
                entity.HasKey(e => new { e.FuncionId, e.Horario });

                entity.ToTable("funcioneshorarios", "cinedefe");

                entity.Property(e => e.FuncionId).HasColumnType("int(11)");

                entity.Property(e => e.Horario).HasColumnType("datetime");
            });

            modelBuilder.Entity<FuncionAsientosReservados>(entity =>
            {
                entity.HasKey(e => new { e.FuncionId, e.AsientoFila, e.AsientoNumero });

                entity.ToTable("funcionesasientosreservados", "cinedefe");

                entity.Property(e => e.FuncionId).HasColumnType("int(11)");

                entity.Property(e => e.AsientoFila)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.AsientoNumero).HasColumnType("smallint(6)");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.ToTable("peliculas", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Anio).HasColumnType("int(11)");

                entity.Property(e => e.ClasificacionId).HasColumnType("int(11)");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Duracion).HasColumnType("int(11)");

                entity.Property(e => e.Poster).HasColumnType("mediumblob");

                entity.Property(e => e.Sinopsis).IsUnicode(false);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PeliculaClasificacion>(entity =>
            {
                entity.ToTable("peliculasclasificaciones", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Codigo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.ToTable("salas", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.SucursalId)
                    .HasName("Sucursal_idx");

                entity.HasIndex(e => e.TipoId)
                    .HasName("TipoSala_idx");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Activa).HasColumnType("tinyint(4)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.SucursalId).HasColumnType("int(11)");

                entity.Property(e => e.TipoId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<SalaAsientos>(entity =>
            {
                entity.HasKey(e => new { e.SalaId, e.Fila, e.Asientos });

                entity.ToTable("salasasientos", "cinedefe");

                entity.Property(e => e.SalaId).HasColumnType("int(11)");

                entity.Property(e => e.Fila)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Asientos).HasColumnType("int(11)");
            });

            modelBuilder.Entity<SalaTipo>(entity =>
            {
                entity.ToTable("salastipos", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.ToTable("sucursales", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Ciudad)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("usuarios", "cinedefe");

                entity.HasIndex(e => e.Nombre)
                    .HasName("Nombre_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.RolId)
                    .HasName("Roles_idx");

                entity.Property(e => e.Id).HasColumnType("int(10) unsigned");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RolId).HasColumnType("int(11)");
            });

            modelBuilder.Entity<UsuarioRol>(entity =>
            {
                entity.ToTable("usuariosroles", "cinedefe");

                entity.HasIndex(e => e.Id)
                    .HasName("Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Permisos)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
        }
    }
}
