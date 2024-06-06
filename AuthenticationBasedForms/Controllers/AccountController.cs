using AuthenticationBasedForms.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace AuthenticationBasedForms.Controllers
{
    public class AccountController : Controller
    {

        // Static list Users example
        private static List<User> users = new List<User>()
        { 
            new User { Username = "admin", Password = "password" },
            new User { Username = "user", Password = "password" }
        };

        // GET for default
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null) 
            {
                FormsAuthentication.SetAuthCookie(username, false);
                return RedirectToAction("Index", "Home");
            }
            else 
            {
                ModelState.AddModelError("", "Invalid username or password");
                return View(); 
            }
        }

        // GET for default
        public ActionResult Logout() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        
    }
}