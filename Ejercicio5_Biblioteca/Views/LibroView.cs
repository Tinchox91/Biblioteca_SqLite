using BasicPack;
using Modelos;
namespace Views
{
   public static class LibroView
    {
        public static string MenuLibro()
        {
            Colors.Magenta("1. Crear Libro", true);
            Colors.Magenta("2. Eliminar Libro", true);
            Colors.Magenta("3. Actualizar Libro", true);
            Colors.Magenta("4. Buscar Libro por Autor", true);
            Colors.Magenta("5. Mostrar Libros", true);
            Colors.Magenta("6. Salir", true);
            Colors.Cyan("Seleccione una opción: ");
            return Console.ReadLine();
        }
        public static void MostrarLibros(List<Libro> libros)
        {
            if (libros == null || libros.Count == 0)
            {
                Colors.Red("No hay libros disponibles.", true);
                return;
            }
            Colors.Magenta("*** Lista de Libros ***", true);
            foreach (var lib in libros)
            {
                MostrarLibro(lib);
            }
        }
        public static void MostrarLibro(Libro libro)
        {
            if (libro == null)
            {
                Colors.Red("El libro no existe.", true);
                return;
            }
            Colors.Magenta("*** Detalles del Libro ***", true);
            string st = new string('-', 100);
            Colors.DarkGray(st, true);
            Colors.Cyan("ISBN: ");
            Colors.White($"{libro.Isbn}", true);         
            Colors.Cyan("Titulo: ");
            Colors.White($"{libro.Titulo}", true);
            Colors.Cyan("Autor: ");
            Colors.White($"{libro.Autor}", true);
            Colors.Cyan("Disponibilidad: ");
            if (libro.Disponibilidad == "Disponible")
                Colors.Green($"{libro.Disponibilidad}", true);
            else
            {
                Colors.Red($"{libro.Disponibilidad}", true);
            }
               
        }
        public static Libro CrearLibro()
        {
            Libro libro = new Libro();
            Colors.Cyan("Ingrese el Titulo: ");
            string titulo =Valid.IsString();
            Colors.Cyan("Ingrese el Autor: ");
            string autor = Valid.IsString();
           string dis= "Disponible";
            libro.Titulo = titulo;
            libro.Autor = autor;
            libro.Disponibilidad = dis;
            return libro;



        }
        public static int EliminarLibro(List<Libro> libros)
        {
          int isbn;
            Colors.Cyan("Ingrese el ISBN del libro a eliminar: ");
            isbn= Valid.IsNumber();
            Libro libro = libros.FirstOrDefault(l => l.Isbn == isbn);
            if (libro == null)
            {
                Colors.Red("El libro no existe.", true);
                return -1; // Indica que no se encontró el libro
            } 
            return isbn; // Retorna el ISBN del libro a eliminar

        }
        public static Libro ActualizarLibro(List<Libro> libros)
        {
            int isbn;
            Colors.Cyan("Ingrese el ISBN del libro a actualizar: ");
            isbn = Valid.IsNumber();
            Libro libro = libros.FirstOrDefault(l => l.Isbn == isbn);
            if (libro == null)
            {
                Colors.Red("El libro no existe.", true);
                return null; // Indica que no se encontró el libro
            }
            Colors.Cyan("Ingrese el nuevo Titulo: ");
            string titulo = Valid.IsString();
            Colors.Cyan("Ingrese el nuevo Autor: ");
            string autor = Valid.IsString();
            Colors.Cyan("Ingrese la nueva Disponibilidad (Disponible/No Disponible): ");
            string disponibilidad = Valid.IsString();
            if (disponibilidad != "Disponible" && disponibilidad != "No Disponible")
            {
                Colors.Red("Disponibilidad debe ser 'Disponible' o 'No Disponible'.", true);
                return null; // Indica que la disponibilidad es inválida
            }
            libro.Disponibilidad = disponibilidad;
            libro.Titulo = titulo;
            libro.Autor = autor;
            return libro; // Retorna el libro actualizado
        }
        public static string BuscarLibroAutor(List<Libro> libros)
        {
            Colors.Cyan("Ingrese el nombre del autor a buscar: ");
            string autor = Valid.IsString();
            var librosEncontrados = libros.Where(l => l.Autor.Contains(autor, StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosEncontrados.Count == 0)
            {
                Colors.Red("No se encontraron libros del autor especificado.", true);
                return null; // Indica que no se encontraron libros
            }
            MostrarLibros(librosEncontrados);
            return autor; // Retorna el nombre del autor buscado

        }
        public static void BuscarLibroIsbn(List<Libro> libros)
        {
            Colors.Cyan("Ingrese el ISBN del libro a buscar: ");
            int isbn = Valid.IsNumber();
            Libro libro = libros.FirstOrDefault(l => l.Isbn == isbn);
            if (libro == null)
            {
                Colors.Red("El libro no existe.", true);
                return;
            }
            MostrarLibro(libro);
        }
    }
}
