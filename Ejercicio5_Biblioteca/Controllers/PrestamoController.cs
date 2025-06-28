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
        }
        public async Task<List<Prestamo>> TraerTodos() => await _context.Prestamos.ToListAsync();
        public async Task AddPrestamo()
        {
            try
            {
               _context.Prestamos.Add(PrestamoView.CrearPrestamo());
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
          var prestamos = await TraerTodos();
            Colors.White("Cargando prestamos...");
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
            int id = PrestamoView.EliminarPrestamo(await TraerTodos());

            var prestamo = _context.Prestamos.FirstOrDefault(p => p.Id == id);
            if (prestamo != null)
            {
               
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
