using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interfaces
{
    public interface IUserRL
    {
        bool RegisterUser(RegistationModel registrationModel);
        bool LoginUser(LoginModel loginModel);
    }
}
