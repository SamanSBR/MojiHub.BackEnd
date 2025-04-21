using MojiHub.Data.DTOs;
using MojiHub.Data.Entities.User;

namespace MojiHub.Data.Services.Interfaces
{
    public interface IUserService
    {
        void AddUser(User user);
        void UpdateUser(User user);
        User GetUserByEmail(string email);
        bool IsEmailExist(string email);
        void DeleteUser(int  id);
        User ActiveUser(string ActiveCode);
        User GetUserById(int id);
    }
}
