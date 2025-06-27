using BasicPack;
using Contexto;
using Microsoft.EntityFrameworkCore;
using Modelos;
using Views;


namespace Controllers
{
    public class LibroController
    {
        private readonly AppDbContext _context;

        public LibroController(AppDbContext context)
        {
            _context = context;
        }
        public List<Libro> TraerTodos() => _context.Libros.ToList();
        public void AddLibro()
        {
            try
            {
                _context.Libros.Add(LibroView.CrearLibro());
                _context.SaveChanges();
                Colors.Green("Libro creado correctamente.");
            }
            catch (Exception e)
            {
                Colors.Red($"Error al crear el libro: {e.Message}");
                if (e.InnerException != null)
                {
                    Colors.Red($"Detalle: {e.InnerException.Message}", true);
                }
            }
            
        }

        public async Task GetLibrosAsync()
        {
            Console.Write("Cargando libros...");

            var libros = await _context.Libros.ToListAsync();

            // \r Sobrescribe la línea anterior 
            Console.Write("\r");

            LibroView.MostrarLibros(libros);
        }

        public void GetLibroByIsbn()
        {
            LibroView.BuscarLibroIsbn(TraerTodos()); 
        }
        public void UpdateLibro()
        {
            Libro libro = LibroView.ActualizarLibro(TraerTodos());
            var existingLibro = _context.Libros.FirstOrDefault(l => l.Isbn == libro.Isbn);
            try
            {
                if (existingLibro != null)
                {
                    existingLibro.Titulo = libro.Titulo;
                    existingLibro.Autor = libro.Autor;
                    existingLibro.Disponibilidad = libro.Disponibilidad;
                    _context.SaveChanges();
                    Colors.Green("Libro actualizado correctamente.");
                }
                else
                {
                    Colors.Red("El libro no existe.");
                }
            }
            catch (Exception e)
            {

                Colors.Red($"Error: {e.Message}");
            }
           
        }
        public void DeleteLibro()
        {
            int isbn= LibroView.EliminarLibro(TraerTodos());
            var libro = _context.Libros.FirstOrDefault(l => l.Isbn == isbn);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
                _context.SaveChanges();
              Colors.Green("Libro eliminado correctamente.");
            }
            else {                 Colors.Red("El libro no existe."); }
        }
        public void SearchLibrosAutor() => LibroView.BuscarLibroAutor(TraerTodos());
        public void GetLibrosDisponibles() =>
                    
            LibroView.MostrarLibros( _context.Libros
                .Where(l => l.Disponibilidad == "Disponible")
                .ToList());

    }
}
