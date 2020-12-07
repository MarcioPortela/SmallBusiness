using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmallBusiness.Sales.Costumers.Model;

namespace SmallBusiness.Sales.Costumers.DAL
{
    public class RepositoryUserSys
    {
        private readonly string connString;

        public RepositoryUserSys(string connString)
        {
            this.connString = connString;
        }

        public UserSys GetLogin(UserSys userSys)
        {
            string queryString =
                "SELECT * FROM [dbo].[UserSys]"
                + " WHERE [Email] = '@email' AND [Password] = '@password'";

            using (SqlConnection connection =
                new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@email", userSys.Email);
                command.Parameters.AddWithValue("@password", userSys.Password);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    UserSys result = new UserSys();

                    while (reader.Read())
                    {

                        result.Id = Convert.ToInt32(reader[0]);
                        result.Login = reader[1].ToString();
                        result.Email = reader[2].ToString();
                        result.Password = reader[3].ToString();
                        result.UserRoleId = Convert.ToInt32(reader[4]);
                    }

                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
