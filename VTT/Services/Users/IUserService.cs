using VTT.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VTT.Services.Users
{
    public interface IUserService
    { 
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUsersById(int id);
        Task<bool> UserExists(string emailAddress);
        Task<bool> LoginAsync(User user);

        Task RegisterAsync(string login, string password);
        bool IsUserLogged();
        public User LoggedUser { get; }
        public void Logout();
    }
}
