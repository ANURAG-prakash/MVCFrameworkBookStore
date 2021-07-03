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
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=bookstore;Integrated Security=True");

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
    }
}
