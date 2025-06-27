using BasicPack;
using Modelos;

namespace Views
{
    public static class PrestamoView
    {
        public static string  MenuPrestamo()
        { 
            Colors.Blue("*** Menú de Préstamos ***", true);
            Colors.DarkGray(new string('-', 100), true);   
            
                Colors.Blue("1. Crear Préstamo");
                Colors.Blue("2. Eliminar Préstamo");
                Colors.Blue("3. Actualizar Préstamo");
                Colors.Blue("4. Buscar Préstamo por ID");
                Colors.Blue("5. Buscar Préstamo por Usuario");
                Colors.Blue("6. Mostrar Todos los Préstamos");
                Colors.Blue("7. Salir");
                Colors.White("Seleccione una opción: ");
                return Console.ReadLine();

        }
        public static void MostrarPrestamo(Prestamo pres){ 
            string barra = new string('-', 100);
            Colors.Magenta($"Id: {pres.Id} -- Usuario: {pres.Usuario.Name} -- Libro: {pres.Libro.Titulo} -- Fecha de Préstamo: {pres.FechaPrestamo} ", true);
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
