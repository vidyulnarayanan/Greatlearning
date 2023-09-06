using MVC_FinalProject.Models;
using MVC_FinaLProject2.Models;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MVC_FinaLProject2.Repository
{
    public class LoginRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["GetDatabaseConnection2"].ToString();
            connection = new SqlConnection(constr);
        }

        /// <summary>
        /// CHECKING LOGIN BY VALIDATING EMAIL ID AND PASSWORD
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool CheckLogin(LoginModel login)
        {
            Connection();
            SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Table_Registration2 WHERE Email=@Email AND Password=@Password AND Role=@Role", connection);
            command.Parameters.AddWithValue("@Email", login.Email);
            command.Parameters.AddWithValue("@Password", login.Password);
            command.Parameters.AddWithValue("@Role", login.Role);

            int rowsAffected = 0;

            try
            {
                connection.Open();
                rowsAffected = (int)command.ExecuteScalar();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return rowsAffected > 0;
        }

    }
}
