using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CloudDevelopment.Models
{
    public class LoginModel 
    {
        //Connection string
        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //(Mrzyglod, 2022).

        //Checks if user is on the database and logs them in
        public int SelectUser(string email, string password)
        {
            int userId = -1; // Default value if user is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userID FROM userTable WHERE userEmail = @Email AND userPassword = @Password";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userId = Convert.ToInt32(result);
                    }
                }
                catch (SqlException sqlEx)
                {
                    //Log SQL exception
                    Debug.WriteLine($"SQL Error: {sqlEx.Message}");
                    throw new ApplicationException("Database operation failed. See inner exception for details.", sqlEx);
                }
                //(Github, 2024).
                catch (Exception ex)
                {
                    //Log general exception
                    Debug.WriteLine($"Error: {ex.Message}");
                    throw new ApplicationException("An error occurred. See inner exception for details.", ex);
                }
                //(Github, 2024).
            }
            return userId;
        }
        //(Mrzyglod, 2022).

        public string GetUserType(int userID)
        {
            string userType = ""; // Default value if user type is not found
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT userType FROM userTable WHERE userID = @UserID";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                try
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        userType = result.ToString();
                    }
                }
                catch (SqlException sqlEx)
                {
                    // Log SQL exception
                    Debug.WriteLine($"SQL Error: {sqlEx.Message}");
                    throw new ApplicationException("Database operation failed. See inner exception for details.", sqlEx);
                }
                catch (Exception ex)
                {
                    // Log general exception
                    Debug.WriteLine($"Error: {ex.Message}");
                    throw new ApplicationException("An error occurred. See inner exception for details.", ex);
                }
            }
            return userType;
        }

        //(Mrzyglod, 2022).
    }
}
