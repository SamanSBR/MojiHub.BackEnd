using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Entities.User
{
    public class Role
    {
        public Role()
        {

        }

        [Key]
        public int RoleId { get; set; }


        public string RoleTitle { get; set; }




        #region Relations

        public virtual List<UserRole> UserRoles { get; set; }
       



        #endregion
    }
    
}
