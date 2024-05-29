using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10
{
    internal class UserService : IUserService
    {
        public User GetUserInfo(int userId)
        {
            return new User("name", "email");
        }
    }
}
