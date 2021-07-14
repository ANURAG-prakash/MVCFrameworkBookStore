using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class CartRL : ICartRL
    {
        private readonly SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=bookstore;Integrated Security=True");

        public CartRL()
        {

        }

        public List<GetCart> CartBooks(string email)
        {
            List<GetCart> BookList = new List<GetCart>();

            try
            {
                using (Connection)
                {
                    SqlCommand command = new SqlCommand("spGetCart", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", 1);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BookList.Add(new GetCart
                            {
                                BookId = Convert.ToInt32(dr["id"]),
                                Price = Convert.ToInt32(dr["Price"]),
                                CartId =  Convert.ToInt32(dr["id"]),
                                
                                BookName = Convert.ToString(dr["BookName"]),
                                Image= Convert.ToString(dr["Image"])

                            }
                        );
                        }
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

            return BookList;
        }
        public bool Placeorder(string email)
        {
           
            try
            {
                using (Connection)
                {
                    SqlCommand command = new SqlCommand("spCheckout", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Email", "Prakash@gmail.com");

                    Connection.Open();
                    int i = command.ExecuteNonQuery();

                    if (i >= 1)
                        return true;
                    else
                        return false;
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

        }
    }
}
