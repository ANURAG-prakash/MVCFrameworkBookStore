using BusinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private readonly IUserRL user;

        public UserBL(IUserRL user)
        {
            this.user = user;
        }

        public bool LoginUser(LoginModel loginModel)
        {
            return this.user.LoginUser(loginModel);
        }

        public bool RegisterUser(RegistationModel registrationModel)
        {
            return this.user.RegisterUser(registrationModel);
        }
    }
}
