namespace Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }
        public Libro Libro { get; set; }
        public Usuario Usuario { get; set; }
        public string FechaPrestamo { get; set; }

        public Prestamo(Libro libro, Usuario usuario, string fechaPrestamo)
        {
            Libro = libro ?? throw new ArgumentNullException(nameof(libro));
            Usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
            FechaPrestamo = fechaPrestamo ?? throw new ArgumentNullException(nameof(fechaPrestamo));
        }

        public Prestamo()
        {
        }
    }
}
