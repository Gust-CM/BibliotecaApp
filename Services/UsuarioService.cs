using BibliotecaApp.Models;

namespace BibliotecaApp.Services
{
    public class UsuarioService
    {
        private List<Usuario> usuarios = new();

        public void RegistrarUsuario(Usuario usuario)
        {
            if (usuarios.Any(u => u.Id == usuario.Id))
            {
                Console.WriteLine("El usuario con este ID ya existe.");
                return;
            }
            usuarios.Add(usuario);
            Console.WriteLine("Usuario registrado correctamente.");
        }

        public List<Usuario> ListarUsuarios() => usuarios;

        public Usuario? BuscarUsuario(string id) =>
            usuarios.FirstOrDefault(u => u.Id == id);
    }
}
