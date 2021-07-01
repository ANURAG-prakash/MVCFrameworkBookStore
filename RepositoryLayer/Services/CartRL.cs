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
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=webform_bookstore;Integrated Security=True");

      

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
                                BookId = 1,
                                BookName = "Harry potter",
                                Price = 1500,
                                Authors = "J K Rowlin",
                                CartId = 1,
                                UserId = 1,
                                Quantity = 1

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
