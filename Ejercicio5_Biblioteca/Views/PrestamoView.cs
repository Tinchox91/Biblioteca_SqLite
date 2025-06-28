using BasicPack;
using Modelos;

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
            Colors.Magenta($"Id: {pres.Id} -- Usuario: {usuario} -- Libro: {libro} -- Fecha de Préstamo: {pres.FechaPrestamo} ", true);
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
