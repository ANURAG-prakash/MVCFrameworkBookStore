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
                    SqlCommand command = new SqlCommand("spGetWishlist", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@UserId", 1);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BookList.Add(new GetWishlist
                            {
                                BookId = Convert.ToInt32(dr["id"]),
                                Price = Convert.ToInt32(dr["Price"]),
                                WishlistId = Convert.ToInt32(dr["id"]),

                                BookName = Convert.ToString(dr["BookName"]),
                                Image = Convert.ToString(dr["Image"])

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
        public CartModel WishlistToCart(CartModel cartModel, string email)
        {
            try
            {
                using (Connection)
                {
                    SqlCommand cmd = new SqlCommand("WishlistAddtocart", Connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookId", cartModel.BookId);
                    cmd.Parameters.AddWithValue("@userId", 1);
                    cmd.Parameters.AddWithValue("@quantity", cartModel.CartBookQuantity);
                    cmd.Parameters.AddWithValue("@price", 1500);
                    cmd.Parameters.AddWithValue("@email", "Prakash@gmail.com");
                    Connection.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                        return cartModel;
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
