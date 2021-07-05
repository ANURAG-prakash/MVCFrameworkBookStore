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
    public class WishlistRL : IWishlistRL
    {
       
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=bookstore;Integrated Security=True");

       

        public List<GetWishlist> WishlistBooks()
        {
            List<GetWishlist> BookList = new List<GetWishlist>();

            try
            {
                using (Connection)
                {
                    string query = @"select * from [dbo].[WishlistModel]";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BookList.Add(new GetWishlist
                            {
                                BookId = Convert.ToInt32(dr["BookId"]),
                                Price = Convert.ToInt32(dr["Price"]),
                                WishlistId = Convert.ToInt32(dr["id"]),
                                UserId = Convert.ToInt32(dr["UserId"]),
                                Quantity= Convert.ToInt32(dr["Quantity"]),
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
    }
}
