using CloudDevelopment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace CloudDevelopment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor; // Add IHttpContextAccessor

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor; // Initialize IHttpContextAccessor
        }

        public IActionResult Index()
        {
            // Retrieve all products from the database
            List<productTable> products = productTable.GetAllProducts();
            List<transactionTable> transactions = transactionTable.GetAllTransactions();

            // Retrieve userID from session
            int? userID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
            String? userType = _httpContextAccessor.HttpContext.Session.GetString("UserType");

            // Pass products and userID to the view
            ViewData["Products"] = products;
            ViewData["UserID"] = userID;
            ViewData["UserType"] = userType;
            ViewData["Transactions"] = transactions;

            return View();
        }

        public IActionResult Profile()
        {
    
            List<transactionTable> t = transactionTable.GetAllTransactions();
            int? userrID = _httpContextAccessor.HttpContext.Session.GetInt32("UserID");
           String? userType = _httpContextAccessor.HttpContext.Session.GetString("UserType");
            ViewData["Transactions"] = t;
            ViewData["UserType"] = userType;
            

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("/Views/User/About.cshtml");
        }

        public IActionResult MyWork()
        {
            return View();
        }

        public IActionResult LandingPage()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
