using System.Web.Mvc;
using System.Windows.Forms;
using MVC_FinalProject.Models;
using MVC_FinaLProject2.Models;
using MVC_FinaLProject2.Repository;

namespace MVC_FinalProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepository loginRepository;

        public LoginController()
        {
            loginRepository = new LoginRepository();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                bool isValidLogin = loginRepository.CheckLogin(model);

                if (isValidLogin)
                {
                    // Authentication successful
                    // You can set authentication cookies or perform other actions here
                    return RedirectToAction("AdminHomePage", "Admin");
                }
                else
                {
                    MessageBox.Show("Invalid login");
                    //ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            // If we reach this point, the login attempt was invalid
            return View(model);
        }
    }
}
