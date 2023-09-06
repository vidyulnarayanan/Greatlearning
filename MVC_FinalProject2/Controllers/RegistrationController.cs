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
        /// <summary>
        /// METHOD TO SELECT DATA FROM REGISTRATION FORM TO SQL
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// METHOD TO INSERT DATA INTO SQL TABLE
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
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

        /// <summary>
        /// METHOD TO EDIT DETAILS
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// METHOD TO DELETE DETAILS
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
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