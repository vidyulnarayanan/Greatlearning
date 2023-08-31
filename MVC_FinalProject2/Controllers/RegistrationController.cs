using MVC_FinalProject.Models;
using MVC_FinalProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_FinaLProject2.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult GetDetails()
        {
            RegistrationRepository RegRepo = new RegistrationRepository();
            ModelState.Clear();
            return View(RegRepo.GetDetails());
        }

        public ActionResult AddDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDetails(Registration registration)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RegistrationRepository RegRepo = new RegistrationRepository();
                    if (RegRepo.AddDetails(registration))
                    {
                        ViewBag.Message = "User Details Added Succesfully";
                    }
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult EditDetails(int? Id)
        {
            RegistrationRepository RegRepo = new RegistrationRepository();
            return View(RegRepo.GetDetails().Find(registration => registration.Id == Id));
        }

        [HttpPost]
        public ActionResult EditDetails(int? Id, Registration obj)
        {
            try
            {
                RegistrationRepository RegRepo = new RegistrationRepository();
                RegRepo.EditDetails(obj);
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DeleteDetails(int Id, Registration obj)
        {
            try
            {
                RegistrationRepository RegRepo = new RegistrationRepository();
                if (RegRepo.DeleteDetails(Id))
                {
                    ViewBag.Alertmessag("User details succesfully deleted");
                }
                return RedirectToAction("GetDetails");
            }
            catch
            {
                return View();
            }
        }

    }
}