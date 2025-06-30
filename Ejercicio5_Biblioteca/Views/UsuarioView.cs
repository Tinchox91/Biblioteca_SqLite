using BasicPack;
using Modelos;

namespace Views
{
    public static class UsuarioView
    {
        private static string x = new string('-', 30);
        public static string MenuUsuario()
        {
            Colors.DarkGray(x, true);
            Colors.Magenta("*** Menú de Usuarios ***", true);
            Colors.Magenta("1. ");
            Colors.White("Crear Usuario", true);
            Colors.Magenta("2. ");
            Colors.White("Mostrar Usuario", true);
            Colors.Magenta("3. ");
            Colors.White("Mostrar Usuarios", true);
            Colors.Magenta("4. ");
            Colors.White("Actualizar Usuario", true);
            Colors.Magenta("5. ");
            Colors.White("Eliminar Usuario", true);
            Colors.Magenta("6. ");
            Colors.White("Buscar Usuario", true);
            Colors.Magenta("7. ");
            Colors.White("Salir", true);
            Colors.DarkGray(x, true);

            Colors.Cyan("Seleccione una opción: ");
            return Console.ReadLine();
        }
        public static void MostrarUsuario(Usuario usuario)
        {
            string barra = new string('-', 100);
            Colors.Magenta($"Id: {usuario.Id} -- Nombre: {usuario.Name} -- Mail: {usuario.Mail}", true);
            Colors.DarkGray(barra, true);
        }
        public static void MostrarUsuarios(List<Usuario> usuarios)
        {
            string barra = new string('-', 100);
            Colors.Cyan("Lista de Usuarios:", true);
            Colors.DarkGray(barra, true);
            foreach (var usuario in usuarios)
            {
                MostrarUsuario(usuario);
            }
        }
        public static Usuario CrearUsuario()
        {
            Colors.Magenta("Nombre del usuario: ");
            string name = Valid.IsString();
            Colors.Magenta("Email del usuario: ");
            string mail = Valid.IsMail();
            return new Usuario(name, mail);
        }
        public static int EliminarUsuario(List<Usuario> usuarios)
        {
            int id;
            Colors.Magenta("Ingrese el ID del usuario a eliminar: ");
            id = Valid.IsNumber();
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                Colors.Red("El usuario no existe.", true);
                return -1; // Indica que no se encontró el usuario
            }
            return id; // Retorna el ID del usuario a eliminar
        }
        public static Usuario ActualizarUsuario(List<Usuario> usuarios)
        {
            int id;
            Colors.Magenta("Ingrese el ID del usuario a actualizar: ");
            id = Valid.IsNumber();
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                Colors.Red("El usuario no existe.", true);
                return null; // Indica que no se encontró el usuario
            }
            Colors.Magenta("*** Actualizar Usuario ***", true);
            Colors.DarkGray(new string('-', 30), true);
            Colors.DarkGray($"Nombre original: ");
            Colors.White($"{usuario.Name}", true);
            Colors.DarkGray($"Mail original: ");
            Colors.White($"{usuario.Mail}", true);
            bool isValid;
            // Validación para actualizar el Nombre
            do
            {
                isValid = false;
                string op = opcion("Actualizar el Nombre");

                switch (op)
                {
                    case "1":
                        Colors.Cyan("Manteniendo el Nombre original.");
                        break;
                    case "2":
                        Colors.Cyan("Ingrese el nuevo Nombre: ");
                        usuario.Name = Valid.IsString();
                        break;
                    default:
                        Colors.Red("Opción no válida, manteniendo el Titulo original.", true);
                        isValid = true;
                        break;
                }
            } while (isValid);
            // Validación para actualizar el Mail
            do
            {
                isValid = false;
                string op = opcion("Actualizar el Mail");

                switch (op)
                {
                    case "1":
                        Colors.Cyan("Manteniendo el Mail original.");
                        break;
                    case "2":
                        Colors.Cyan("Ingrese el nuevo Mail: ");
                        usuario.Mail = Valid.IsMail();
                        break;
                    default:
                        Colors.Red("Opción no válida, Ingrese de nuevo", true);
                        isValid = true;
                        break;
                }
            } while (isValid);
            return usuario; // Retorna el usuario actualizado
        }
        public static int BuscarUsuario(List<Usuario> usuarios)
        {
            int id;
            Colors.Magenta("Ingrese el ID del usuario a buscar: ");
            id = Valid.IsNumber();
            Usuario usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                Colors.Red("El usuario no existe.", true);
                return -1; // Indica que no se encontró el usuario
            }
            MostrarUsuario(usuario);
            return id; // Retorna el ID del usuario encontrado
        }
        public static string BuscarUsuario()
        {
            Colors.Magenta("Ingrese el nombre o email del usuario a buscar: ");
            string search = Valid.IsString();
            return search; // Retorna el nombre o email del usuario a buscar
        }
        public static string opcion(string titulo)
        {
            Colors.Cyan($"¿Desea {titulo} ?: ", true);
            Colors.Magenta($"1. Para dejar el registro original ", true);
            Colors.White("2. Para cambiar el registro ", true);
            string dv = Valid.IsNumberString();
            return dv;

        }
        public static void MostrarNombresUsuarios(List<Usuario> usuarios)
        {

            foreach (var usuario in usuarios)
            {
              
                Colors.Blue($"Id: ");
                Colors.White($"{usuario.Id}  ",true);               
                Colors.Blue($"Nombre: ");
                Colors.White(usuario.Name,true);
                Colors.DarkGray(x,true);
            }
        }
    }
}
