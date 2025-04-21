using MojiHub.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MojiHub.Data.Services.Interfaces
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}
