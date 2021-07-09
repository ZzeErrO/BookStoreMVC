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
    public class CartRL : ICartRL
    {
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public CartRL()
        {

        }

        public List<GetCartBooks> GetAllBooks(string email)
        {
            List<GetCartBooks> BookList = new List<GetCartBooks>();
            try
            {
                using (Connection)
                {
                    SqlCommand command = new SqlCommand("spGetCartBooks", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {

                            BookList.Add(new GetCartBooks
                            {
                                CartId = Convert.ToInt32(dr["cartId"]),
                                BookId = Convert.ToInt32(dr["bookId"]),
                                BookName = Convert.ToString(dr["bookName"]),
                                Authors = Convert.ToString(dr["authors"]),
                                Price = Convert.ToInt32(dr["price"]),
                                Quantity = Convert.ToInt32(dr["quantity"]),
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

        public bool Checkout(string email)
        {
            SqlConnection Connection1 = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            try
            {
                using (Connection1)
                {
                    SqlCommand command = new SqlCommand("spCheckout", Connection1);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", email);

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
