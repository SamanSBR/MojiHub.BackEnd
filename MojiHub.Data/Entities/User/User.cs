using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Entities.User
{
    public class User
    {
        public User()
        {

        }
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public  bool IsActive { get; set; }

        public string ActiveCode { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public ICollection<Offer.Offer> Offers { get; set; } // Offers created by this user

    }
}
