using Microsoft.AspNetCore.Mvc;
using CloudDevelopment.Models;
using System.Data.SqlClient;

namespace CloudDevelopment.Controllers
{
    public class UserController : Controller
    {

        public  userTable usrtbl=new userTable();

        public static string con_string = "Server=tcp:st10404816-sql-server.database.windows.net,1433;Initial Catalog=st10404816-sql-database;Persist Security Info=False;User ID=CLDV-ST10404816;Password=L1sha_666;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public static SqlConnection con = new SqlConnection(con_string);

        private readonly ILogger<UserController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor; // Add IHttpContextAccessor

        public UserController(ILogger<UserController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
        }
        [HttpPost]
        public ActionResult About(userTable Users)
        {
            var result = usrtbl.insert_User(Users);

            //Error Checking
            if (result > 0)
            {
                return RedirectToAction("Privacy", "Home");
            }
            else
            {
                // Error Message
                TempData["ErrorMessage"] = "Invalid Sign up attempt. Please check your information and try again.";
                // (David, S. 2023).

                return RedirectToAction("/Views/Home/Privacy.cshtml");
            }

        }

        [HttpGet]
        public ActionResult About()
        {
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            String? userType = _httpContextAccessor.HttpContext.Session.GetString("UserType");
            ViewData["UserID"] = userID;
            ViewData["UserType"] = userType;

            return View(usrtbl);
        }

        // Login and Signup options
        public IActionResult Profile()
        {
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            String? userType = _httpContextAccessor.HttpContext.Session.GetString("UserType");
            ViewData["UserID"] = userID;
            ViewData["UserType"] = userType;
           
            return View();
            
        }
        // (Mrzyglod, 2022).




    }
}
