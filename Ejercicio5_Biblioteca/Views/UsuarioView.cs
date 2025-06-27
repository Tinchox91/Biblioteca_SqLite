using BasicPack;
using Modelos;

namespace Views
{
   public static class UsuarioView
    {
    public static string MenuUsuario()
        {
            Colors.Blue("*** Menú de Usuarios ***", true);
            Colors.DarkGray(new string('-', 100), true);
            Colors.Blue("1. Crear Usuario");
            Colors.Blue("2. Eliminar Usuario");
            Colors.Blue("3. Actualizar Usuario");
            Colors.Blue("4. Buscar Usuario por ID");
            Colors.Blue("5. Mostrar Todos los Usuarios");
            Colors.Blue("6. Salir");
            Colors.White("Seleccione una opción: ");
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
            Colors.Magenta("Nuevo nombre del usuario: ");
            string name = Valid.IsString();
            Colors.Magenta("Nuevo email del usuario: ");
            string mail = Valid.IsMail();
            usuario.Name = name;
            usuario.Mail = mail;
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
    }
}
