using Configuration;
using Entities;
using Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEF.Repository
{
    public class UserRepository
    {
        private readonly Config _config;
        private readonly StockDbContext _context;
        public UserRepository(StockDbContext context)
        {
            _context = context;
        }
        public UserRepository(Config config)
        {
           _config = config;
        }

        public bool Register(string name, string password)
        {
            byte[] passwordHash, passwordSalt;
            SecurityHelper.CrearPasswordHash(password, out passwordHash, out passwordSalt);

            var user = new Usuario
            {
                Nombre = name,
                //LastName = lastname,
                //UserName = username,
                Hash = passwordHash,
                Salt = passwordSalt
            };

            bool result;
            try
            {
                using (var db = new StockDbContext())
                {
                    db.Add(user);

                    db.SaveChanges();
                }
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }


        public Usuario Login(string username, string password)
        {
            var usuario = _context.Usuario.SingleOrDefault(x => x.Nombre == username);

            if (usuario == null)
                return null;

            if (!SecurityHelper.VerificarPasswordHash(password, usuario.Hash, usuario.Salt))
                return null;

            return usuario;
        }
    }
}
