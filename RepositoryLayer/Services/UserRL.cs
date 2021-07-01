using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class UserRL : IUserRL
    {
        private SqlConnection connection;

        private void Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
            connection = new SqlConnection(connectionString);

        }

        public bool LoginUser(LoginModel loginModel)
        {
            try
            {

                Connection();

                SqlCommand cmd = new SqlCommand("spLogin", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", loginModel.Email);
                cmd.Parameters.AddWithValue("@Password", loginModel.Password);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i <= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }



        public bool RegisterUser(RegistationModel registrationModel)
        {
            throw new NotImplementedException();
        }

       
    }
}
