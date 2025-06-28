using BasicPack;
using Contexto;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Usuario>> TraerTodos() =>  await _context.Usuarios.ToListAsync();
        public async Task AddUsuario()
        {
            try
            {
                _context.Usuarios.Add(UsuarioView.CrearUsuario());
                Colors.White("Guardando Usuario...");
                await _context.SaveChangesAsync();
                Colors.White("\r");
                Colors.Green("Usuario Creado Exitosamente!");
            }
            catch (Exception e)
            {
                Colors.Red($"Error al crear el usuario: {e.Message}");
            }
           
        }
        public async Task GetUsuarios()
        {
            Colors.White("Cargando Usuarios...");
            var usuarios = await TraerTodos();
           
            Colors.White("\r");
            if (usuarios.Count == 0)
            {
                Colors.Red("No hay usuarios registrados.",true);
                return;
            }
            UsuarioView.MostrarUsuarios(usuarios);
        }
        public async Task GetUsuarioById()
        {
            UsuarioView.BuscarUsuario(await TraerTodos());
        }
        public async Task UpdateUsuario()
        {
            Usuario us = UsuarioView.ActualizarUsuario(await TraerTodos());
            var existingUsuario = _context.Usuarios.FirstOrDefault(u => u.Id == us.Id);
            if (existingUsuario != null)
            {
                existingUsuario.Name = us.Name;
                existingUsuario.Mail = us.Mail;
                Colors.White("Actualizando Usuario...");
                await  _context.SaveChangesAsync();
                Colors.White("\r");
                Colors.Green("Usuario actualizado correctamente.");
            }
            else
            {
                Colors.Red("Usuario no encontrado.");
            }
        }
        public async Task DeleteUsuario()
        {
            int id = UsuarioView.EliminarUsuario(await TraerTodos());
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
                Colors.White("Eliminando Usuario...");
                await _context.SaveChangesAsync();
                Colors.White("\r");
                Colors.Green("Usuario eliminado correctamente.");
            }
            else {                 Colors.Red("Usuario no encontrado."); }
        }
        public async Task SearchUsuarios()
        {
            string search=UsuarioView.BuscarUsuario();
            //aca se aplica codigo linq pra buscar usuarios por nombre o mail
            var usuarios = await _context.Usuarios
                .Where(u => u.Name.Contains(search) || u.Mail.Contains(search))
                .ToListAsync();
            Colors.White("Buscando Usuario...");
            Colors.White("\r");
            if (usuarios.Count == 0)
            {
                Colors.Red("No se encontraron usuarios con ese criterio de búsqueda.",true);
                return;
            }else
            {
                Colors.Green("Usuarios encontrados:");
                Colors.DarkGray(new string('-', 100), true);
                UsuarioView.MostrarUsuarios(usuarios);
            }
           

           

        }
      


    }
}
