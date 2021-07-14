using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelsLayer.Models;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class WishListRL : IWishListRL
    {
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        //private int id;
        public WishListRL()
        {

        }

        public List<GetWishListBooks> GetAllBooks(string email)
        {
            List<GetWishListBooks> BookList = new List<GetWishListBooks>();
            try
            {
                using (Connection)
                {
                    SqlCommand command = new SqlCommand("spGetWishListBooks", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            BookList.Add(new GetWishListBooks
                            {
                                WishListId = Convert.ToInt32(dr["wishlistId"]),
                                BookId = Convert.ToInt32(dr["bookId"]),
                                BookName = Convert.ToString(dr["bookName"]),
                                Authors = Convert.ToString(dr["authors"]),
                                Price = Convert.ToInt32(dr["price"]),
                                ImagePath = Convert.ToString(dr["imagePath"])
                            }
                        );
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

            return BookList;
        }

        public bool DeleteWishBook(int id)
        {
            /*
            try
            {
                using (Connection)
                {
                    SqlCommand command = new SqlCommand("spDeleteWishBook", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", email);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            id = Convert.ToInt32(dr["wishlistId"]);
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
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection.Close();
            }*/

            SqlConnection Connection1 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                using (Connection1)
                {
                    SqlCommand command = new SqlCommand("spDeleteWishBook", Connection1);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);

                    Connection1.Open();
                    int i = command.ExecuteNonQuery();

                    if (i >= 1)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Connection1.Close();
            }
        }
    }
}
