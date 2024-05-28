using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CloudDevelopment.Models
{
    public class ProductDisplayModel
    {
        //Getters and setter
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
        public string ProductAvailability { get; set; }
        public int ProductQuantity { get; set; }
        //(Mrzyglod, 2022).

        //Constructor
        public ProductDisplayModel() { }
        //(Mrzyglod, 2022).

        //Parameterized Constructor: This constructor takes five parameters (id, name, price, category, availability) and initializes the corresponding properties of ProductDisplayModel with the provided values.
        public ProductDisplayModel(int id, string name, decimal price, string category, string availability, int quantity)
        {
            ProductID = id;
            ProductName = name;
            ProductPrice = price;
            ProductCategory = category;
            ProductAvailability = availability;
            ProductQuantity = quantity;
        }
        //(Mrzyglod, 2022).

        //Method to display products
        public static List<ProductDisplayModel> SelectProducts()
        {
            List<ProductDisplayModel> products = new List<ProductDisplayModel>();

            string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, ProductName, ProductPrice, ProductCategory, ProductAvailability, ProductQuantity FROM productTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ProductDisplayModel product = new ProductDisplayModel();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = Convert.ToString(reader["ProductName"]);
                    product.ProductPrice = Convert.ToDecimal(reader["ProductPrice"]);
                    product.ProductCategory = Convert.ToString(reader["ProductCategory"]);
                    product.ProductAvailability = Convert.ToString(reader["ProductAvailability"]);
                    product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"]);
                    products.Add(product);
                }
                reader.Close();
            }
            return products;
        }
        //(Mrzyglod, 2022).
    }
    //(Mrzyglod, 2022).
}
