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
    public class UserRL : IUserRL
    {
        private SqlConnection Connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BookStore;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public bool Register(Register register)
        {
            try
            {
                using (Connection)
                {
                    string password = Encryptdata(register.Password);
                    SqlCommand command = new SqlCommand("RegisterUser", Connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@email", register.Email);
                    command.Parameters.AddWithValue("@password", password);

                    Connection.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr["email"].ToString() == register.Email && dr["password"].ToString() == password )
                            {
                                return true;
                            }
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

            }
            return false;
        }
        public bool Login(Login login)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

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
                            dict.Add(dr["email"].ToString(), dr["password"].ToString());
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
            foreach (KeyValuePair<string, string> kvp in dict)
            {
                string password = Encryptdata(login.Password);
                if (kvp.Key == login.Email && kvp.Value == password)
                {   
                    return true;
                }
            }

            return false;
        }

        public static string Encryptdata(string password)
        {
            string strmsg = string.Empty;
            byte[] encode = new byte[password.Length];
            encode = Encoding.UTF8.GetBytes(password);
            strmsg = Convert.ToBase64String(encode);
            return strmsg;
        }
        public static string Decryptdata(string encryptpwd)
        {
            string decryptpwd = string.Empty;
            UTF8Encoding encodepwd = new UTF8Encoding();
            Decoder Decode = encodepwd.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encryptpwd);
            int charCount = Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            decryptpwd = new String(decoded_char);
            return decryptpwd;
        }
    }
}
