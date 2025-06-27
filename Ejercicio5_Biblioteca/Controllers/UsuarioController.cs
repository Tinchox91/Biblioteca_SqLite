using BasicPack;
using Contexto;
using Modelos;
using Views;


namespace Controllers
{
   public class UsuarioController
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }
        public List<Usuario> TraerTodos() => _context.Usuarios.ToList();
        public void AddUsuario()
        {
            try
            {
                _context.Usuarios.Add(UsuarioView.CrearUsuario());
                _context.SaveChanges();
                Colors.Green("Usuario Creado Exitosamente!");
            }
            catch (Exception e)
            {
                Colors.Red($"Error al crear el usuario: {e.Message}");
            }
           
        }
        public void GetUsuarios() => UsuarioView.MostrarUsuarios(TraerTodos());



        public void GetUsuarioById()
        {
            UsuarioView.BuscarUsuario(TraerTodos());
        }
        public void UpdateUsuario()
        {
            Usuario us = UsuarioView.ActualizarUsuario(TraerTodos());
            var existingUsuario = _context.Usuarios.FirstOrDefault(u => u.Id == us.Id);
            if (existingUsuario != null)
            {
                existingUsuario.Name = us.Name;
                existingUsuario.Mail = us.Mail;
                _context.SaveChanges();
                Colors.Green("Usuario actualizado correctamente.");
            }
            else
            {
                Colors.Red("Usuario no encontrado.");
            }
        }
        public void DeleteUsuario()
        {
            int id = UsuarioView.EliminarUsuario(TraerTodos());
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                _context.SaveChanges();
                Colors.Green("Usuario eliminado correctamente.");
            }
            else {                 Colors.Red("Usuario no encontrado."); }
        }
        public void SearchUsuarios()
        {
            string search=UsuarioView.BuscarUsuario();
            //aca se aplica codigo linq pra buscar usuarios por nombre o mail
          UsuarioView.MostrarUsuarios( _context.Usuarios
                .Where(u => u.Name.Contains(search) || u.Mail.Contains(search))
                .ToList());
        }
      


    }
}
