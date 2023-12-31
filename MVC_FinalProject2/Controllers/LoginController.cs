﻿using System.Web.Mvc;
using System.Windows.Forms;
using MVC_FinalProject.Repository;
using MVC_FinaLProject2.Models;
using MVC_FinaLProject2.Repository;

namespace MVC_FinalProject.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginRepository loginRepository;
        private readonly RegistrationRepository registrationRepository;

        public LoginController()
        {
            loginRepository = new LoginRepository();
            registrationRepository = new RegistrationRepository();
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
                    CurrentUserRepository.CurrentUser = registrationRepository.GetDetails(model.Email);

                    // Check the role and redirect accordingly
                    if (model.Role == "Admin")
                    {
                        return RedirectToAction("AdminHomePage", "Admin");
                    }
                    else if (model.Role == "User")
                    {
                        return RedirectToAction("CourseHomePage", "Course");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Login");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            // Sign the user out and remove the authentication cookie
            CurrentUserRepository.CurrentUser = null;

            // Redirect to the home page or any other appropriate page after signing out
            return RedirectToAction("AdminHomePage", "Admin");
        }
    }
}
