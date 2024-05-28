using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CloudDevelopment.Controllers
{
    public class TransactionController : Controller
    {

        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);
    
    //Method to place order
    [HttpPost]
        public ActionResult PlaceOrder(int userID, int productID)
        {
            try
            {
                // Create a new instance of SqlConnection using the connection string
                using (SqlConnection con = new SqlConnection(productTable.con_string))
                {
                    // Insert transaction into transaction table
                    string sql1 = "INSERT INTO transactionTable (userID, productID, transactionDate, transactionStatus) VALUES (@UserID, @ProductID, GETDATE(), 'NeedsProcessing')";

                    // Update product table
                    string sql2 = "UPDATE productTable SET productQuantity = productQuantity-1 WHERE productID = @ProductID";

                    // Create a new instance of SqlCommand with the SQL query and SqlConnection
                    using (SqlCommand cmd = new SqlCommand(sql1, con))
                    {
                        // Add parameters to the SqlCommand for userID and productID
                        cmd.Parameters.AddWithValue("@UserID", userID);
                        cmd.Parameters.AddWithValue("@ProductID", productID);

                        // Open the SqlConnection
                        con.Open();

                        // Execute the SqlCommand to insert the record into the transactionTable
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // Check if the insert operation was successful
                        if (rowsAffected > 0)
                        {
                            //Second sql command
                            using (SqlCommand cmd2 = new SqlCommand(sql2, con))
                            {
                                // Add parameters to the second SqlCommand for productID
                                cmd2.Parameters.AddWithValue("@ProductID", productID);

                                // Execute the second SqlCommand to update the product quantity
                                int rowsAffected2 = cmd2.ExecuteNonQuery();

                                // Check if the update operation was successful
                                if (rowsAffected2 > 0)
                                {
                                    // Both operations were successful, redirect the user to the home page
                                    return RedirectToAction("Index", "Home");
                                }
                                else
                                {
                                    // Error during the update operation
                                    TempData["ErrorMessage"] = "Internal error. ";
                                    // Return the same view
                                    return RedirectToAction("Index", "Home");
                                }

                                // Close the SqlConnection
                                con.Close();


                                // Redirect the user to the home page after placing the order
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            // Error
                            TempData["ErrorMessage"] = "Failed to purchase product. Please contact us.";
                            // (David, S. 2023).

                            // Return the same view 
                            return RedirectToAction("Index", "Home");
                            // (David, S. 2023).
                            
                        }
                    }
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

        //Method to process order
        [HttpPost]
        public ActionResult ProcessOrder(int tID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(productTable.con_string))
                {
                    string sql = "UPDATE transactionTable SET transactionStatus='OrderProcessed' WHERE trasnactionID = @TransactionID";


               
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {       
                        cmd.Parameters.AddWithValue("@TransactionID", tID);
              
                        con.Open();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        con.Close();

                        if (rowsAffected > 0)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return View("OrderFailed");
                        }
                    }
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

        [HttpPost]
        public ActionResult ViewHistory(int uID)
        {
            List<transactionTable> transactions = transactionTable.GetUserTransactions(uID);
            
            ViewData["Transactions"] = transactions;

            return View("/Views/Transaction/ViewHistory.cshtml");

        }
    }
}
