using Microsoft.AspNetCore.Mvc;
using CloudDevelopment.Models;
using System.Data.SqlClient;

namespace CloudDevelopment.Controllers
{
    public class TransactionDisplayController : Controller

    {
        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        private readonly ILogger<UserController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor; // Add IHttpContextAccessor

        public TransactionDisplayController(ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
        }

        [HttpGet]
        public IActionResult ViewHistory()
        {
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            String? userType = _httpContextAccessor.HttpContext.Session.GetString("UserType");
            ViewData["UserID"] = userID;
            ViewData["UserType"] = userType;

            var t = TransactionDisplayModel.SelectUser((int)userID);
            return View(t);
        }
    }
}
