using BasicPack;
using Contexto;
using Microsoft.EntityFrameworkCore;
using Modelos;
using Views;

public class LibroController
{
    private readonly AppDbContext _context;

    public LibroController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Libro>> TraerTodosAsync() => await _context.Libros.ToListAsync();

    public async Task AddLibroAsync()
    {
        try
        {
            _context.Libros.Add(LibroView.CrearLibro());
            Colors.White("Guardando Libro...");
            await _context.SaveChangesAsync();
            Colors.White("\r");
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
       Colors.White("Cargando libros...");
        var libros = await _context.Libros.ToListAsync();
        Colors.White("\r");
        LibroView.MostrarLibros(libros);
    }

    public async Task GetLibroByIsbnAsync()
    {
        Colors.White("Cargando libros...");
        var libros = await TraerTodosAsync();
        Colors.White("\r");
        LibroView.BuscarLibroIsbn(libros);
    }

    public async Task UpdateLibroAsync()
    {
        var libros = await TraerTodosAsync();
        Libro libro = LibroView.ActualizarLibro(libros);
        var existingLibro = await _context.Libros.FirstOrDefaultAsync(l => l.Isbn == libro.Isbn);
        try
        {
            if (existingLibro != null)
            {
                existingLibro.Titulo = libro.Titulo;
                existingLibro.Autor = libro.Autor;
                existingLibro.Disponibilidad = libro.Disponibilidad;
                Colors.White("Actualizando Libro...");
                await _context.SaveChangesAsync();
                Colors.White("\r");
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

    public async Task DeleteLibroAsync()
    {
        var libros = await TraerTodosAsync();
        int isbn = LibroView.EliminarLibro(libros);
        var libro = await _context.Libros.FirstOrDefaultAsync(l => l.Isbn == isbn);
        if (libro != null)
        {
            _context.Libros.Remove(libro);
            Colors.White("Eliminando Libro...");
            await _context.SaveChangesAsync();
            Colors.White("\r");
            Colors.Green("Libro eliminado correctamente.");
        }
        else
        {
            Colors.Red("El libro no existe.");
        }
    }

    public async Task SearchLibrosAutorAsync()
    {
        Colors.White("Cargando libros...");
        var libros = await TraerTodosAsync();
        Colors.White("\r");
        LibroView.BuscarLibroAutor(libros);
    }

    public async Task GetLibrosDisponiblesAsync()
    {
        Colors.White("Cargando libros disponibles...");
        var disponibles = await _context.Libros
            .Where(l => l.Disponibilidad == "Disponible")
            .ToListAsync();
        Colors.White("\r     ");
        if (disponibles.Count == 0)
        {
            Colors.Red("No hay libros disponibles.", true);
            return;
        }
        LibroView.MostrarLibros(disponibles);
    }
}