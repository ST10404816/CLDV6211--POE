using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Xml.Linq;
using System.Diagnostics;
using System.Security.Cryptography;

namespace CloudDevelopment.Models
{
    public class transactionTable
    {
        //Connection string
        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);
        //(Mrzyglod, 2022).

        //Getter and setter methods
        public int ProductID { get; set; }

        public int UserID { get; set; }

        public int TransactionID { get; set; }

        public string TransactionDate { get; set; }

        public String TransactionStatus { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }
        //(Mrzyglod, 2022).

        //Method to insert data into transactionTable
        public int insert_transaction(transactionTable p)
        {

            try
            {
                string sql = "INSERT INTO transactionTable (productID, userID, transactionDate, transactionStatus) VALUES (@ProductID, @UserID, @TransactionDate, @TransactionStatus)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@ProductID", p.ProductID);
                cmd.Parameters.AddWithValue("@UserID", p.UserID);
                cmd.Parameters.AddWithValue("@TransactionDate", p.TransactionDate);
                cmd.Parameters.AddWithValue("@TransactionStatus", p.TransactionStatus);
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

        //Method to retrieve all transactions from the database
        public static List<transactionTable> GetAllTransactions()
        {
            List<transactionTable> transactions = new List<transactionTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT * FROM transactionTable";
                SqlCommand cmd = new SqlCommand(sql, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    transactionTable transaction = new transactionTable();

                    transaction.TransactionID = Convert.ToInt32(rdr["transactionID"]);
                    transaction.ProductID = Convert.ToInt32(rdr["productID"]);                                      
                    transaction.UserID = Convert.ToInt32(rdr["userID"]);                   
                    transaction.TransactionDate = rdr["transactionDate"].ToString();
                    transaction.TransactionStatus = rdr["transactionStatus"].ToString();

                    transactions.Add(transaction);
                }
            }

            return transactions;
        }
        //(Mrzyglod, 2022).

        //Method to retrieve all user transactions from the database
        public static List<transactionTable> GetUserTransactions(int uID)
        {
            List<transactionTable> transactions = new List<transactionTable>();

            using (SqlConnection con = new SqlConnection(con_string))
            {
                string sql = "SELECT productTable.productName, productTable.productPrice, CAST(transactionTable.transactionDate as DATE) as transactionDate, transactionTable.transactionStatus FROM transactionTable INNER JOIN productTable ON transactionTable.productID = productTable.productID WHERE transactionTable.userID = @UserID";
                SqlCommand cmd = new SqlCommand(sql, con);

                try
                {


                    cmd.Parameters.AddWithValue("@UserID", uID);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        transactionTable t = new transactionTable();

                        t.ProductName = rdr["productName"].ToString();
                        t.ProductPrice = Convert.ToDouble(rdr["productPrice"]);
                        t.TransactionDate = rdr["transactionDate"].ToString();
                        t.TransactionStatus = rdr["transactionStatus"].ToString();

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

            return transactions;
        }
        //(Mrzyglod, 2022).
    }
    //(Mrzyglod, 2022).


    //(Mrzyglod, 2022).


}
