using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        bool RegisterUser(RegistationModel registrationModel);
        bool LoginUser(LoginModel loginModel);
    }
}
