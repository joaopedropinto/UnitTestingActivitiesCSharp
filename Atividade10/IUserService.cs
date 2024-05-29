using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atividade10
{
    public interface IUserService
    {
        User GetUserInfo(int userId);
    }
}
