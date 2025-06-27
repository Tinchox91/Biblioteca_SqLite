using Microsoft.EntityFrameworkCore;
using Modelos;
namespace Contexto
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("Data Source=biblioteca.db");

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    var dbPath = Path.Combine(AppContext.BaseDirectory, "Data", "biblioteca.db");
        //    Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);
        //    options.UseSqlite($"Data Source={dbPath}");
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Clave primaria y autoincremento para Libro
            modelBuilder.Entity<Libro>()
                .HasKey(l => l.Isbn);
            modelBuilder.Entity<Libro>()
                .Property(l => l.Isbn)
                .ValueGeneratedOnAdd();

            // Clave primaria y autoincremento para Usuario
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.Id);
            modelBuilder.Entity<Usuario>()
                .Property(u => u.Id)
                .ValueGeneratedOnAdd();

            // Clave primaria y autoincremento para Prestamo
            modelBuilder.Entity<Prestamo>()
                .HasKey(p => p.Id);
            modelBuilder.Entity<Prestamo>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            // Relaciones para Prestamo
            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Libro)
                .WithMany()
                .HasForeignKey("LibroId")
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Prestamo>()
                .HasOne(p => p.Usuario)
                .WithMany()
                .HasForeignKey("UsuarioId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
