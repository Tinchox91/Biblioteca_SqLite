using BasicPack;
using Modelos;
using System.Reflection.Metadata.Ecma335;

namespace Views
{
    public static class PrestamoView
    {
        private static string x = new string('-', 30);
        public static string  MenuPrestamo()
        {
            Colors.DarkGray(x, true);
            Colors.Magenta("*** Menú de Prestamos ***", true);
            Colors.Magenta("1. ");
            Colors.White("Crear Prestamo", true);
            Colors.Magenta("2. ");            
            Colors.White("Mostrar Prestamos", true);
            Colors.Magenta("3. ");
            Colors.White("Actualizar Prestamo", true);
            Colors.Magenta("4. ");
            Colors.White("Eliminar Prestamo", true);
            Colors.Magenta("5. ");
            Colors.White("Buscar Prestamo por Id", true);
            Colors.Magenta("6. ");
            Colors.White("Buscar Prestamo por Usuario ", true);
            Colors.Magenta("7. ");
            Colors.White("Salir", true);
            Colors.DarkGray(x, true);

            Colors.Cyan("Seleccione una opción: ");
            return Console.ReadLine();

        }
        public static void MostrarPrestamo(Prestamo pres)
        {
            string barra = new string('-', 100);
            string usuario = pres.Usuario != null ? pres.Usuario.Name : "N/A";
            string libro = pres.Libro != null ? pres.Libro.Titulo : "N/A";          
            Colors.Magenta("Id: ");
            Colors.White($"{pres.Id}", true);
            Colors.Magenta(" -- Usuario: ");
            Colors.White($"{usuario}", true);
            Colors.Magenta(" -- Libro: ");
            Colors.White($"{libro}", true);
            Colors.Magenta(" -- Fecha de Préstamo: ");
            Colors.White($"{pres.FechaPrestamo}", true);
            Colors.DarkGray(barra, true);
        }

        public static void MostrarPrestamos(List<Prestamo> prestamos)
        {
            if (prestamos == null || prestamos.Count == 0)
            {
                Colors.Red("No hay préstamos disponibles.", true);
                return;
            }
            Colors.Magenta("*** Lista de Préstamos ***", true);
            foreach (var pres in prestamos)
            {
                MostrarPrestamo(pres);
            }
        }
        public static Prestamo CrearPrestamo() { 
            Prestamo pres = new Prestamo();
          pres.Usuario=  UsuarioView.CrearUsuario();
            pres.Libro = LibroView.CrearLibro();
            pres.FechaPrestamo = DateTime.Now.ToString("dd/MM/yyyy");
            return pres;

        }
        public static Prestamo CrearPrestamo(List<Usuario> usuarios, List<Libro> libros)
        {
            Prestamo pres = new Prestamo();
            //Se selecciona el usuario del préstamo
            string op ="1";
            bool salir = false; 
            if (usuarios!=null && libros != null)
            {
                do
                {
                    Colors.Magenta("Ingresa la opcion deseada:", true);
                    Colors.Magenta("1. ");
                    Colors.White("Seleccionar Usuario Existente", true);
                    Colors.Magenta("2. ");
                    Colors.White("Crear Nuevo Usuario", true);
                    op = Console.ReadLine();
                    switch (op)
                    {
                        case "1":
                            Colors.Magenta("Selecciona un usuario por ID: ", true);
                            UsuarioView.MostrarNombresUsuarios(usuarios);
                            int idUsuario = Valid.IsNumber();
                            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == idUsuario);
                            if (usuario != null)
                            {
                                pres.Usuario = usuario;
                                salir = true;
                            }
                            else
                            {
                                Colors.Red("Usuario no encontrado. Por favor, intenta de nuevo.", true);
                                op = "1"; 
                                salir = false;
                            }
                            break;
                            case "2":
                                pres.Usuario = UsuarioView.CrearUsuario();
                            salir = true;
                            break;
                        default: salir = false; break;
                           
                    }
                } while (!salir);
                pres.FechaPrestamo = DateTime.Now.ToString("dd/MM/yyyy");
            }
            //se selecciona el libro del préstamo
            Colors.Magenta("Selecciona el libro a prestar : ",true);
            LibroView.MostrarNombresLibros(libros);
            if (libros == null || libros.Count == 0)
            {
                Colors.Red("No hay libros disponibles para prestar.", true);
                return null; // No se puede crear el préstamo si no hay libros
            }
            do
            {
                libros = LibroView.DevolverLibrosDisponibles(libros);
                pres.Libro = LibroView.DevolverLibroIsbn(libros);
                if (pres.Libro == null)
                {
                    Colors.Red("No se pudo seleccionar un libro válido para el préstamo.", true);

                    // No se puede crear el préstamo si no se selecciona un libro válido

                }
            } while (pres.Libro==null);
          
            pres.Libro.Disponibilidad = "No Disponible"; // Cambia la disponibilidad del libro a no disponible

            return pres;
        }
        public static int EliminarPrestamo(List<Prestamo> prestamos)
        {
            int id;
            Colors.Magenta("Ingrese el ID del préstamo a eliminar: ");
            id = Valid.IsNumber();
            Prestamo pres = prestamos.FirstOrDefault(p => p.Id == id);
            if (pres == null)
            {
                Colors.Red("El préstamo no existe.", true);
                return -1; // Indica que no se encontró el préstamo
            }
            return id; // Retorna el ID del préstamo a eliminar
        }
        public static Prestamo ActualizarPrestamo(List<Prestamo> prestamos)
        {
            int id;
            Colors.Magenta("Ingrese el ID del préstamo a actualizar: ");
            id = Valid.IsNumber();
            Prestamo pres = prestamos.FirstOrDefault(p => p.Id == id);
            if (pres == null)
            {
                Colors.Red("El préstamo no existe.", true);
                return null; // Indica que no se encontró el préstamo
            }
          pres = CrearPrestamo();
            return pres;
        }
        
        public static void BuscarPrestamoId(List<Prestamo> prestamos)
        {
            int id;
            Colors.Magenta("Ingrese el ID del préstamo a buscar: ");
            id = Valid.IsNumber();
            Prestamo pres = prestamos.FirstOrDefault(p => p.Id == id);
            if (pres == null)
            {
                Colors.Red("El préstamo no existe.", true);
            }
            else
            {
                MostrarPrestamo(pres);
            }
        }
        public static Prestamo? BuscarPrestamo(List<Prestamo> prestamos)
        {
            int id;
            Colors.Magenta("Ingrese el ID del préstamo a buscar: ");
            id = Valid.IsNumber();
            Prestamo pres = prestamos.FirstOrDefault(p => p.Id == id);
            if (pres == null)
            {
                Colors.Red("El préstamo no existe.", true);                
            }

            return pres ; 
        }
        public static string BuscarPrestamoUsuario()
        {
            string name;
            Colors.Magenta("Ingrese el nombre del usuario a buscar: ");
            name = Valid.IsString();
            return name;
        }
        public static void BuscarPrestamoUsuario(List<Prestamo> prestamos)
        {
            string name;
            Colors.Magenta("Ingrese el nombre del usuario a buscar: ");
            name = Valid.IsString();
            // Filtrar los préstamos por el nombre del usuario y crea una lista de resultados
            //se utiliza StringComparison.OrdinalIgnoreCase para hacer la comparación sin importar mayúsculas o minúsculas
            // se utiliza expresion lambda para filtrar los préstamos
            //se uiliza codigo linq para filtrar los préstamos
            var resultados = prestamos.Where(p => p.Usuario.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
            if (resultados.Count == 0)
            {
                Colors.Red("No se encontraron préstamos para el usuario especificado.", true);
            }
            else
            {
                Colors.Cyan($"Préstamos encontrados para el usuario {name}:", true);
                foreach (var pres in resultados)
                {
                    MostrarPrestamo(pres);
                }
            }
        }

    }
}
