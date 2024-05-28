using CloudDevelopment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloudDevelopment.Controllers
{
    public class LoginController : Controller
    {

        private readonly LoginModel login;

        public LoginController()
        {
            login = new LoginModel();
        }

        [HttpPost]
        public ActionResult Privacy(string email, string password)
        {
            var loginModel = new LoginModel();
            int userID = loginModel.SelectUser(email, password);
            string userType = loginModel.GetUserType(userID);
            if (userID != -1)
            {
                // Store userID in session
                HttpContext.Session.SetInt32("UserID", userID);
                HttpContext.Session.SetString("UserType", userType);

                // User found, proceed with login logic (e.g., set authentication cookie)
                // For demonstration, redirecting to a dummy page
              
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Error
                TempData["ErrorMessage"] = "Invalid login attempt. Please check your credentials and try again.";
                // (David, S. 2023).

                // Return the same view 
                return View("/Views/Home/Privacy.cshtml");
                // (David, S. 2023).
            }
        }
    }
}
