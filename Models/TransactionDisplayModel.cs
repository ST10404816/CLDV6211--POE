using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace CloudDevelopment.Models
{
    public class TransactionDisplayModel
    {
        //Getters and setters
        public int ProductID { get; set; }

        public int UserID { get; set; }

        public int TransactionID { get; set; }

        public string TransactionDate { get; set; }

        public string TransactionStatus { get; set; }

        public string ProductName { get; set; }

        public Double ProductPrice { get; set; }
        //(Mrzyglod, 2022).

        //Constructor
        public TransactionDisplayModel() { }
        //(Mrzyglod, 2022).

        //Parameterized Constructor
        public TransactionDisplayModel(int uID, int pID, int tID, string tDate, string status) 
        {
            ProductID = uID;
            UserID = pID;
            TransactionID = tID;
            TransactionDate = tDate;
            TransactionStatus = status;
        }
        //(Mrzyglod, 2022).

        //Method to display transactions
        public static List<TransactionDisplayModel> SelectTransaction()
        {
            List<TransactionDisplayModel> transactions = new List<TransactionDisplayModel>();

            string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT ProductID, UserID, TransactionID, TransactionDate, TransactionStatus FROM transactionTable";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    TransactionDisplayModel transaction = new TransactionDisplayModel();
                    transaction.ProductID = Convert.ToInt32(reader["ProductID"]);
                    transaction.UserID = Convert.ToInt32(reader["UserID"]);
                    transaction.TransactionID = Convert.ToInt32(reader["TransactionID"]);
                    transaction.TransactionDate = Convert.ToString(reader["TransactionDate"]);
                    transaction.TransactionStatus = Convert.ToString(reader["TransactionStatus"]);
                    transactions.Add(transaction);
                }
                reader.Close();
            }
            return transactions;
        }
        //(Mrzyglod, 2022).

        //Method to display transactions
        public static List<TransactionDisplayModel> SelectUser(int u)
        {
            List<TransactionDisplayModel> transactions = new List<TransactionDisplayModel>();

            string con_string = "Integrated Security=SSPI;Persist Security Info=False;User ID=\"\";Initial Catalog=test;Data Source=labVMH8OX\\SQLEXPRESS";
            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productTable.productName, productTable.productPrice, CAST(transactionTable.transactionDate as DATE) as transactionDate, transactionTable.transactionStatus FROM transactionTable INNER JOIN productTable ON transactionTable.productID = productTable.productID WHERE transactionTable.userID = @UserID";
                SqlCommand cmd = new SqlCommand(sql, con);
                //SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@UserID", u);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    
                    TransactionDisplayModel transaction = new TransactionDisplayModel();
                    
                    transaction.ProductName = Convert.ToString(reader["ProductName"]);
                    transaction.ProductPrice = Convert.ToDouble(reader["ProductPrice"]);
                    transaction.TransactionDate = Convert.ToString(reader["TransactionDate"]);
                    transaction.TransactionStatus = Convert.ToString(reader["TransactionStatus"]);
                    transactions.Add(transaction);
                }
                reader.Close();
            }
            return transactions;
        }
    }
    //(Mrzyglod, 2022).
}
