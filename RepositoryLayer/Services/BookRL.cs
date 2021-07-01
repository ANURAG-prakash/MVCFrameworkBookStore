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
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\ProjectsV13;Initial Catalog=webform_bookstore;Integrated Security=True");
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
                                AvailabeBooks = Convert.ToInt32(dr["Avaliablebook"])
                            }
                        );
                        }
                    }
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

            return BookList;
        }
    }
}
