using MojiHub.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.DTOs
{
    public class UserProfileViewModel
    {
        public User user { get; set; }
        public ChangePasswordViewModel changePasswordViewModel { get; set; }
    }
}
