using MojiHub.Data.Context;
using MojiHub.Data.DTOs;
using MojiHub.Data.Entities.User;
using MojiHub.Data.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace MojiHub.Data.Services
{
    public class UserService : IUserService
    {
        private MojiHubContext _context;
        public UserService(MojiHubContext context)
        {
            _context = context;
        }

        public User ActiveUser(string activeCode)
        {
            var user = _context.Users.FirstOrDefault(u => u.ActiveCode == activeCode);    
            if (user != null)
            {
                user.IsActive = true;
                user.ActiveCode=Guid.NewGuid().ToString();
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            return user;

        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public bool IsEmailExist(string email)
        {
            return _context.Users.Any(user => user.Email == email);
        }

        public void DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId==id);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
