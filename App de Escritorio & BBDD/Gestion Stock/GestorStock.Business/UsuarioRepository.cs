using System.Linq;
using GestorStock.DataEF;
using GestorStock.Entities;
using GestorStock.Seguridad;

namespace GestorStock.Business
{
    public class UsuarioRepository
    {
        private readonly GestorStockContext _context;

        public UsuarioRepository(GestorStockContext context)
        {
            _context = context;
        }

        public void Registrar(string nombre, string password)
        {
            byte[] passwordHash, passwordSalt;
            SeguridadHelper.CrearPasswordHash(password, out passwordHash, out passwordSalt);

            var usuario = new Usuario
            {
                Nombre = nombre,
                Hash = passwordHash,
                Salt = passwordSalt
            };

            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario Autenticar(string nombre, string password)
        {
            var usuario = _context.Usuario.SingleOrDefault(x => x.Nombre == nombre);

            if (usuario == null)
                return null;

            if (!SeguridadHelper.VerificarPasswordHash(password, usuario.Hash, usuario.Salt))
                return null;

            return usuario;
        }
    }
}
