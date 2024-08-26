using Configuration;
using Entities;
using Microsoft.Data.SqlClient;
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
        //private readonly Config _config;
        
        private readonly GestionStockContext _context;


        public UserRepository(GestionStockContext context)
        {
            //_config = config;
            _context = context;
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

                _context.Add(user);

                _context.SaveChanges();
                
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
            try {
                var usuario = _context.Usuario.SingleOrDefault(x => x.Nombre == username);

                if (usuario != null)
                {
                    if (!SecurityHelper.VerificarPasswordHash(password, usuario.Hash, usuario.Salt))
                        usuario = null;
                }

                return usuario;
            }
            catch (Exception ex) {
                // Console.WriteLine($"General Error: {ex.Message}");
                return null;
            }
            

        }
    }
}
