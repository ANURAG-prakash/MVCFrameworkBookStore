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

        public List<GetCart> CartBooks()
        {
            List<GetCart> BookList = new List<GetCart>();

            try
            {
                using (Connection)
                {
                    string query = @"select * from [dbo].[CartModel]";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BookList.Add(new GetCart
                            {
                                BookId = Convert.ToInt32(dr["BookId"]),
                                Price = Convert.ToInt32(dr["Price"]),
                                CartId =  Convert.ToInt32(dr["id"]),
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Quantity = Convert.ToInt32(dr["Quantity"]),
                                BookName = Convert.ToString("Source of Dream"),

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
        public bool Placeorder()
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
