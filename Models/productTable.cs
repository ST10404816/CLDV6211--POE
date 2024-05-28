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
    public class productTable
    {
        //Connection string
        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);
        //(Mrzyglod, 2022).

        //Getter and setter methods
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Price { get; set; }

        public string Category { get; set; }

        public string Availability { get; set; }

        public int Quantity { get; set; }
        //(Mrzyglod, 2022).

        //Method to insert into productTable
        public int insert_product(productTable p)
        {
            try
            {
                string sql = "INSERT INTO productTable (productName, productPrice, productCategory, productAvailability, productQuantity) VALUES (@Name, @Price, @Category, @Availability, @Quantity)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Name", p.Name);
                cmd.Parameters.AddWithValue("@Price", p.Price);
                cmd.Parameters.AddWithValue("@Category", p.Category);
                cmd.Parameters.AddWithValue("@Availability", p.Availability);
                cmd.Parameters.AddWithValue("@Quantity", p.Quantity);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowsAffected;
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
        //(Mrzyglod, 2022).

        //Method to retrieve all products from the database
        public static List<productTable> GetAllProducts()
        {
            List<productTable> products = new List<productTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    productTable product = new productTable();
                    product.ProductID = Convert.ToInt32(rdr["productID"]);
                    product.Name = rdr["productName"].ToString();
                    product.Price = rdr["productPrice"].ToString();
                    product.Category = rdr["productCategory"].ToString();
                    product.Availability = rdr["productAvailability"].ToString();
                    product.Quantity = Convert.ToInt32(rdr["productQuantity"]);

                    products.Add(product);
                }
            }

            return products;
        }
        //(Mrzyglod, 2022).

    }
    //(Mrzyglod, 2022).
}
