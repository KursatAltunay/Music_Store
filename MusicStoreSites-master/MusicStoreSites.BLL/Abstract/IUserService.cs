using MusicStoreSites.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreSites.BLL.Abstract
{
    public interface IUserService:IBaseService<User>
    {
        User GetUserByLogin(string userName, string password);
    }
}
