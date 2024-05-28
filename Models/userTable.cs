using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Xml.Linq;
using System.Diagnostics;

namespace CloudDevelopment.Models
{
    public class userTable
    {
        //Connection string
        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);
        //(Mrzyglod, 2022).

        //Getter and setter methods
        public string  Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Type { get; set; }
        //(Mrzyglod, 2022).

        //Method to insert data into userTable
        public int insert_User(userTable m)
        {

            try
            {
                string sql = "INSERT INTO userTable (userName, userSurname, userEmail, userPassword, userType) VALUES (@Name, @Surname, @Email, @Password, @Type)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", m.Name);
                cmd.Parameters.AddWithValue("@Surname", m.Surname);
                cmd.Parameters.AddWithValue("@Email", m.Email);
                cmd.Parameters.AddWithValue("@Password", m.Password);
                cmd.Parameters.AddWithValue("@Type", m.Type);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
                //(Mrzyglod, 2022).
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

    }
    //(Mrzyglod, 2022).
}
