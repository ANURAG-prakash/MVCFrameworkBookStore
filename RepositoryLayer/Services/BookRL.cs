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
    public class BookRL : IBookRL
    {
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=bookstore;Integrated Security=True");
        public BookRL()
        {

        }
        public List<BookModel> GetAllBooks()
        {
            List<BookModel> BookList = new List<BookModel>();

            try
            {
                using (Connection)
                {
                    string query = @"select * from [dbo].[BookModel]";
                   

                    SqlCommand command = new SqlCommand(query, Connection);
                   
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                   
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BookList.Add(new BookModel
                            {
                                BookId = Convert.ToInt32(dr["id"]),
                                BookName = Convert.ToString(dr["BookName"]),
                                Price = Convert.ToInt32(dr["Price"]),
                                Category = Convert.ToString(dr["Category"]),
                                Authors = Convert.ToString(dr["Authors"]),
                                Arrivals = Convert.ToDateTime(dr["Arrival"]),
                                AvailabeBooks = Convert.ToInt32(dr["Avaliablebook"]),
                                Image= Convert.ToString(dr["Image"]),
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
        public CartModel AddToCart(CartModel cartModel)
        {
            try
            {
                using (Connection)
                {
                    SqlCommand cmd = new SqlCommand("spAddtocart", Connection);
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

        public WishlistModel AddToWishlist(WishlistModel wishlistModel)
        {
            try
            {
                using (Connection)
                {
                    SqlCommand cmd = new SqlCommand("spAddtowishlist", Connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookId", wishlistModel.BookId);
                    cmd.Parameters.AddWithValue("@userId", 1);
                    cmd.Parameters.AddWithValue("@quantity", wishlistModel.Quantity);
                    cmd.Parameters.AddWithValue("@price", 1500);
                    cmd.Parameters.AddWithValue("@email", "Prakash@gmail.com");
                    Connection.Open();
                    int i = cmd.ExecuteNonQuery();

                    if (i >= 1)
                        return wishlistModel;
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
