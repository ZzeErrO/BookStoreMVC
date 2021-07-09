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
    public class BooksRL : IBooksRL
    {
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public BooksRL()
        {

        }
        public List<Books> GetAllBooks()
        {
            List<Books> BookList = new List<Books>();

            try
            {
                using (Connection)
                {
                    string query = @"select * from books ";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    //Console.WriteLine("----------TABLE FOR BOOKS----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BookList.Add( new Books

                            {
                            BookId = Convert.ToInt32(dr["bookId"]),
                            BookName = Convert.ToString(dr["bookName"]),
                            Price = Convert.ToInt32(dr["price"]),
                            Category = Convert.ToString(dr["category"]),
                            Authors = Convert.ToString(dr["authors"]),
                            Arrivals = Convert.ToDateTime(dr["arrivals"]),
                            AvailabeBooks = Convert.ToInt32(dr["availableBooks"]),
                            ImagePath = Convert.ToString(dr["imagePath"])
                        
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

        public List<Books> GetSearchBooks(string value)
        {
            List<Books> BookList = new List<Books>();

            try
            {
                using (Connection)
                {
                    SqlCommand cmd = new SqlCommand("spSearch", Connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@value", value);
                    Connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    //Console.WriteLine("----------TABLE FOR BOOKS----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            BookList.Add(new Books

                            {
                                BookId = Convert.ToInt32(dr["bookId"]),
                                BookName = Convert.ToString(dr["bookName"]),
                                Price = Convert.ToInt32(dr["price"]),
                                Category = Convert.ToString(dr["category"]),
                                Authors = Convert.ToString(dr["authors"]),
                                Arrivals = Convert.ToDateTime(dr["arrivals"]),
                                AvailabeBooks = Convert.ToInt32(dr["availableBooks"]),
                                ImagePath = Convert.ToString(dr["imagePath"])

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

        public Cart AddToCart(Cart cartModel, string email)
        {

            try
            {
                using (Connection)
                {
                    string query = @"select * from users ";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    //Console.WriteLine("----------TABLE FOR BOOKS----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (Convert.ToString(dr["email"]) == email)
                            {
                                cartModel.UserId = Convert.ToInt32(dr["userId"]);
                            }
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

            SqlConnection Connection1 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                using (Connection1) 
                {
                    SqlCommand cmd = new SqlCommand("AddToCart", Connection1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookId", cartModel.BookId);
                    cmd.Parameters.AddWithValue("@userId", cartModel.UserId);
                    cmd.Parameters.AddWithValue("@quantity", cartModel.Quantity);
                    cmd.Parameters.AddWithValue("@email", email);
                    Connection1.Open();
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
                Connection1.Close();
            }
        }

        public WishList AddToWishList(WishList wishlistModel, string email)
        {
            try
            {
                using (Connection)
                {
                    string query = @"select * from users ";
                    SqlCommand command = new SqlCommand(query, Connection);
                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    //Console.WriteLine("----------TABLE FOR BOOKS----------");
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (Convert.ToString(dr["email"]) == email)
                            {
                                wishlistModel.UserId = Convert.ToInt32(dr["userId"]);
                            }
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

            SqlConnection Connection1 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            try
            {
                using (Connection1)
                {
                    SqlCommand cmd = new SqlCommand("AddToWishList", Connection1);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookId", wishlistModel.BookId);
                    cmd.Parameters.AddWithValue("@userId", wishlistModel.UserId);
                    cmd.Parameters.AddWithValue("@email", email);
                    Connection1.Open();
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
                Connection1.Close();
            }
        }

        public bool UploadImage(int BookId, string imageUpload)
        {/*
            Connection();
            SqlCommand cmd = new SqlCommand("sp_AddImage", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BookId", BookId);
            // var myAccount = new Account { ApiKey = "371652781151548", ApiSecret = "1aVBjz0E-GdsHlguqwgk_spEyCo", Cloud = "dywhtr8hk" };
            cmd.Parameters.AddWithValue("@Image", imageUpload);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i >= 1)
                return true;

            else*/
                return false;
        }
    }
}
