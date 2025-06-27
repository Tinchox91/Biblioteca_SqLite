using BasicPack;
using Contexto;
using Modelos;
using Views;

namespace Controllers
{
    public class PrestamoController
    {
        private readonly AppDbContext _context;
        public PrestamoController(AppDbContext context)
        {
            _context = context;
        }
        public List<Prestamo> TraerTodos() => _context.Prestamos.ToList();
        public void AddPrestamo()
        {
            try
            {
                _context.Prestamos.Add(PrestamoView.CrearPrestamo());
                _context.SaveChanges();
                Colors.Green("Prestamo Creado Exitosamente!");
            }
            catch (Exception e)
            {
                Colors.Red($"Error al crear el Prestamo: {e.Message}");
            }
        }
        public void GetPrestamos() => PrestamoView.MostrarPrestamos(TraerTodos());

        public Prestamo GetPrestamoById(int id)
        {
            return _context.Prestamos.FirstOrDefault(p => p.Id == id);
        }
        public void UpdatePrestamo(Prestamo prestamo)
        {
            var existingPrestamo = _context.Prestamos.FirstOrDefault(p => p.Id == prestamo.Id);
            if (existingPrestamo != null)
            {
                existingPrestamo.Libro = prestamo.Libro;
                existingPrestamo.Usuario = prestamo.Usuario;
                existingPrestamo.FechaPrestamo = prestamo.FechaPrestamo;
                _context.SaveChanges();
            }
        }
        public void DeletePrestamo(int id)
        {
            var prestamo = _context.Prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
                _context.Prestamos.Remove(prestamo);
                _context.SaveChanges();
            }
        }
        public List<Prestamo> SearchPrestamos(string search)
        {
            return _context.Prestamos
                .Where(p => p.Libro.Titulo.Contains(search) || p.Usuario.Name.Contains(search))
                .ToList();
        }
        public List<Prestamo> GetPrestamosByLibro(int isbn)
        {
            return _context.Prestamos
                .Where(p => p.Libro.Isbn == isbn)
                .ToList();
        }
        public List<Prestamo> GetPrestamosByUsuario(int usuarioId)
        {
            //aca se aplica codigo linq para filtrar los prestamos por usuario
            return _context.Prestamos
                .Where(p => p.Usuario.Id == usuarioId)
                .ToList();
        }
    }
}
