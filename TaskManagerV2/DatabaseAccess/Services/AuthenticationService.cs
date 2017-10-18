using Common.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.Services
{
    public class AuthenticationService
    {
        public User LoggedUser { get; private set; }
        public void AuthenticateUser(string username, string password)
        {
            UsersRepository usersRepo = new UsersRepository();
            LoggedUser = usersRepo.GetAll(u => u.Username == username && u.Password == password).FirstOrDefault();
        }

    }
}
