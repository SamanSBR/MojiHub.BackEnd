using Microsoft.EntityFrameworkCore;
using MojiHub.Data.Entities.Offer;
using MojiHub.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Context
{
    public class MojiHubContext : DbContext

    {
        public MojiHubContext(DbContextOptions<MojiHubContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Offer> Offers { get; set; }

    }
}
