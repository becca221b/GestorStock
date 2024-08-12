using DataEF.Repository;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UsuarioBusinnes
    {
        private readonly UserRepository _userRepository;

        public UsuarioBusinnes(UserRepository userRepository)
        {
            _userRepository = userRepository;

        }

        public bool Register(string name, string password)
        {
            return _userRepository.Register(name, password);
        }

        public Usuario Login(string username, string enteredPassword)
        {
            return _userRepository.Login(username, enteredPassword);

        }
    }
}
