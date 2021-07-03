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

        /*  private void Connection()
          {
              string connectionString = ConfigurationManager.ConnectionStrings["UserDbConnection"].ConnectionString;
              connection = new SqlConnection(connectionString);

          }*/

       
        private readonly SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=bookstore;Integrated Security=True");

        public bool LoginUser(LoginModel loginModel)
        {
            try
            {

               

                SqlCommand cmd = new SqlCommand("spLogin", Connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@Email", loginModel.Email);
                cmd.Parameters.AddWithValue("@Password", loginModel.Password);

                Connection.Open();
                int i = cmd.ExecuteNonQuery();
                Connection.Close();
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
                Connection.Close();
            }
        }



        public bool RegisterUser(RegistationModel registrationModel)
        {
            try
            {
                using (Connection)
                {
                   
                    SqlCommand command = new SqlCommand("sp_insertintoregister", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Firstname", registrationModel.FirstName);
                    command.Parameters.AddWithValue("@Lastname", registrationModel.LastName);
                    command.Parameters.AddWithValue("@Email", registrationModel.Email);
                    command.Parameters.AddWithValue("@Password", registrationModel.Password);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr["Email"].ToString() == registrationModel.Email && dr["Password"].ToString() == registrationModel.Password)
                            {
                                return true;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Connection.Close();

            }
            return false;
        }

       
    }
}
