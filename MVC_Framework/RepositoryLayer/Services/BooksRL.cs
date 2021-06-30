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
                            AvailabeBooks = Convert.ToInt32(dr["availableBooks"])
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
