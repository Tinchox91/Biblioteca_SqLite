using BasicPack;
using Modelos;
namespace Views
{
   public static class LibroView
    {
        private static string x = new string('-', 30);
        public static string MenuLibro()
        {
            Colors.DarkGray(x, true);
            Colors.Blue("*** Menú de Libros ***", true);
            Colors.Magenta("1. ");
            Colors.White("Agregar Libro", true);
            Colors.Magenta("2. ");
            Colors.White("Eliminar Libro", true);
            Colors.Magenta("3. ");
            Colors.White("Actualizar Libro", true);
            Colors.Magenta("4. ");
            Colors.White("Buscar Libro por Autor", true);
            Colors.Magenta("5. ");
            Colors.White("Buscar Libro por ISBN", true);
            Colors.Magenta("6. ");
            Colors.White("Mostrar Todos los Libros", true);
            Colors.Magenta("7. ");
            Colors.White("Salir", true);
            Colors.DarkGray(x, true);

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
            Colors.Magenta("*** Actualizar Libro ***", true);
            Colors.DarkGray(new string('-', 30), true);
            Colors.DarkGray($"Titulo original: ");
            Colors.White($"{libro.Titulo}", true);
            Colors.DarkGray($"Autor original: ");
            Colors.White($"{libro.Autor}", true);
            bool isValid;
            // Validación para actualizar el título
            do
            {
                isValid = false;
                string op = opcion("Actualizar el Titulo");
               
                switch (op)
                {
                    case "1":
                        Colors.Cyan("Manteniendo el Titulo original.");
                        break;
                    case "2":
                        Colors.Cyan("Ingrese el nuevo Titulo: ");
                        libro.Titulo = Valid.IsString();
                        break;
                    default:
                        Colors.Red("Opción no válida, manteniendo el Titulo original.", true);
                        isValid = true;
                        break;
                }
            } while (isValid);
            // Validación para actualizar el autor
            do
            {
                isValid = false;
                string op = opcion("Actualizar el Autor");

                switch (op)
                {
                    case "1":
                        Colors.Cyan("Manteniendo el Autor original.");
                        break;
                    case "2":
                        Colors.Cyan("Ingrese el nuevo Autor: ");
                        libro.Autor = Valid.IsString();
                        break;
                    default:
                        Colors.Red("Opción no válida, manteniendo el Titulo original.", true);
                        isValid = true;
                        break;
                }
            } while (isValid);

           
            Colors.Cyan("Ingrese la nueva Disponibilidad (Disponible/No Disponible): ");
            string disponibilidad = Valid.IsString();
            if (disponibilidad != "Disponible" && disponibilidad != "No Disponible")
            {
                Colors.Red("Disponibilidad debe ser 'Disponible' o 'No Disponible'.", true);
                return null; // Indica que la disponibilidad es inválida
            }
            libro.Disponibilidad = disponibilidad;
           
           
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
        public static List<Libro> DevolverLibrosDisponibles(List<Libro> libros)
        {
            var librosDisponibles = libros.Where(l => l.Disponibilidad.Equals("Disponible", StringComparison.OrdinalIgnoreCase)).ToList();
            if (librosDisponibles.Count == 0)
            {
                Colors.Red("No hay libros disponibles.", true);
                return null; // Indica que no hay libros disponibles
            }
         
            return librosDisponibles; // Retorna la lista de libros disponibles
        }
        public static Libro DevolverLibroIsbn(List<Libro> libros)
        {
            Colors.Cyan("Ingrese el ISBN del libro a buscar: ");
            int isbn = Valid.IsNumber();
            Libro libro = libros.FirstOrDefault(l => l.Isbn == isbn);
            if (libro == null)
            {
                Colors.Red("El libro no existe.", true);
               return null; // Indica que no se encontró el libro
            }
           return libro;
        }
        public static string opcion(string titulo)
        {
            Colors.Cyan($"¿Desea {titulo} ?: ",true);
            Colors.Magenta($"1. Para dejar el registro original ",true);
            Colors.White("2. Para cambiar el registro ", true);
           string dv= Valid.IsNumberString();
            return dv;  

        }
    }
}
