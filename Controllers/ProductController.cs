using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CloudDevelopment.Controllers
{
    public class ProductController : Controller
    {
        public productTable prodtbl = new productTable();

        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);


        [HttpPost]
        public ActionResult MyWork(productTable products)
        {
            var result2 = prodtbl.insert_product(products);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MyWork()
        {
            return View(prodtbl);
        }
    }
}
