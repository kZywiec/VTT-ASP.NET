using NuGet.ContentModel;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTT.Models.Entities;
using VTT.Services.Repositories;

namespace VTT.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IRepositoryBase<User> _repositoryBase;

        public User? LoggedUser { get; set; }


        public UserService(IRepositoryBase<User> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task<bool> LoginAsync(User user)
        {
            var usersFound = await _repositoryBase.FindAsync(u => u.login == user.login && u.password == user.password);
            bool userExists = usersFound.Any();

            if (!userExists)
                throw new Exception("Błędne dane logowania!");

            LoggedUser = usersFound.First();
            return userExists;
        }

        public async Task RegisterAsync(string login, string password)
        {
            bool userAlreadyExist = await UserExists(login);

            var users = _repositoryBase.FindAsync(u => u.login == login);

            if (userAlreadyExist)
                throw new Exception("Podany Login już istnieje w bazie danych!");
            else
            {
                User newUser = new User
                {
                    login = login,
                    password = password,
                    isAdmin = false,
                };

                LoggedUser = newUser;

                await _repositoryBase.AddAsync(newUser);
            }
        }

        public async Task<User> GetUsersById(int id)
        {
            var users = await _repositoryBase.FindAsync(u => u.id == id);
            return users.First();
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var users = await _repositoryBase.GetAllAsync();
            return users;
        }

        public async Task<bool> UserExists(string login)
        {
            var userFound = await _repositoryBase.FindAsync(u => u.login == login);

            bool userAlreadyExist = userFound.Any();

            return userAlreadyExist;
        }

        public void Logout()
            => LoggedUser = null;

        public bool IsUserLogged()
        {
            if (LoggedUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
