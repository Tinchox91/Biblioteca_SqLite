using BasicPack;
using Contexto;
using Microsoft.EntityFrameworkCore;
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
          //  TraerTodos().Wait(); // Cargar los préstamos al iniciar el controlador
        }
     //   public async Task<List<Prestamo>> TraerTodos() => await _context.Prestamos.ToListAsync();
       
        public async Task<List<Prestamo>> TraerTodos()
        {
            return await _context.Prestamos
                .Include(p => p.Libro)
                .Include(p => p.Usuario)
                .ToListAsync();
        }

        public async Task AddPrestamo()
        {
            try
            {
                List<Libro> libros = await _context.Libros.ToListAsync();
                List<Usuario> usuarios = await _context.Usuarios.ToListAsync();
                Prestamo pres = PrestamoView.CrearPrestamo(usuarios,libros);
               Usuario usuario  = _context.Usuarios.FirstOrDefault(u => u.Id == pres.Usuario.Id);
                if (usuario==null)
                {
                   _context.Usuarios.Add(pres.Usuario);
                }
                pres.Libro = _context.Libros.FirstOrDefault(l => l.Isbn == pres.Libro.Isbn);
                
                _context.Prestamos.Add(pres);
                Colors.White("Guardando Prestamo...");
                await   _context.SaveChangesAsync();
                Colors.White("\r");
                Colors.Green("Prestamo Creado Exitosamente!");
            }
            catch (Exception e)
            {
                Colors.Red($"Error al crear el Prestamo: {e.Message}");
            }
        }
        public async Task GetPrestamos()
        {
            Colors.White("Cargando prestamos...");           
            var prestamos = await TraerTodos();          
            Colors.White("\r");
            PrestamoView.MostrarPrestamos(prestamos);
        }

        public async Task GetPrestamoById()
        {
          var  pres = await TraerTodos();
            Colors.White("Cargando prestamos...");
            Colors.White("\r");
            PrestamoView.BuscarPrestamoId(pres);
        }
        public async Task UpdatePrestamo()
        {
            var prestamo = PrestamoView.BuscarPrestamo(await TraerTodos());
            if (prestamo != null) 
            {
                var existingPrestamo = _context.Prestamos.FirstOrDefault(p => p.Id == prestamo.Id);
                if (existingPrestamo != null)
                {
                    existingPrestamo.Libro = prestamo.Libro;
                    existingPrestamo.Usuario = prestamo.Usuario;
                    existingPrestamo.FechaPrestamo = prestamo.FechaPrestamo;
                    Colors.White("Actualizando Prestamo...");
                    await _context.SaveChangesAsync(); 
                    Colors.White("\r");
                    Colors.Green("Prestamo actualizado correctamente.");
                }
            }
        }
        public async Task DeletePrestamo()
        {
            var prestamos = await TraerTodos();
            int id = PrestamoView.EliminarPrestamo(prestamos);

            var prestamo = await _context.Prestamos
                .Include(p => p.Libro)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prestamo != null)
            {
                if (prestamo.Libro != null)
                {
                    prestamo.Libro.Disponibilidad = "Disponible";
                }

                _context.Prestamos.Remove(prestamo);
                Colors.White("Eliminando Prestamo...");
                try
                {
                    await _context.SaveChangesAsync();
                    Colors.White("\r");
                    Colors.Green("Prestamo eliminado correctamente.");
                }
                catch (Exception e)
                {
                    Colors.White("\r");
                    Colors.Red($"Error al eliminar el Prestamo: {e.Message}");
                }
            }
            else
            {
                Colors.Red("No se encontró el préstamo a eliminar.");
            }
        }
        public async Task SearchPrestamos()
        {
            var prestamos = await TraerTodos();
            string search = PrestamoView.BuscarPrestamoUsuario();
            if (prestamos != null)
            {
               var existingPrestamo = prestamos
                .Where(p => p.Libro.Titulo.Contains(search) || p.Usuario.Name.Contains(search))
                .ToList(); ;
                if (existingPrestamo != null)
                {
                  
                   PrestamoView.MostrarPrestamos(existingPrestamo);
                }else
                {
                    Colors.Red("No se encontraron préstamos con ese criterio de búsqueda.");    
                }
            }else
            {
                Colors.Red("No hay préstamos disponibles.");
            }
        }
      
    }
}
