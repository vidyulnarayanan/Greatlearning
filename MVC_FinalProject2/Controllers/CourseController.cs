using System.Collections.Generic;
using System.Web.Mvc;
using MVC_FinaLProject2.Models;
using static System.Net.WebRequestMethods;

namespace MVC_FinaLProject2.Controllers
{
    public class CourseController : Controller
    {
        private List<CourseModel> GetCourses()
        {
            return new List<CourseModel>
            {
                new CourseModel
                {
                    Title = "JAVASCRIPT",
                    Description = " A lightweight, interpreted, or just-in-time compiled programming language with first-class functions",
                    LearnMoreLink = "https://www.w3schools.com/js/"
                },
                new CourseModel
                {
                    Title = "PHP",
                    Description = "Open-source general-purpose scripting language fit for server-side programming",
                    LearnMoreLink = "https://www.w3schools.com/php/"
                },
                 new CourseModel
                {
                    Title = "C#.NET",
                    Description = "Enables developers to build many types of secure and robust applications that run in .NET",
                    LearnMoreLink = "https://www.w3schools.com/cs/index.php"
                },
                  new CourseModel
                {
                    Title = "SQL",
                    Description = "Standardized programming language used to manage relational databases and perform various operations on the data in them",
                    LearnMoreLink = "https://www.w3schools.com/sql/"
                },
                   new CourseModel
                {
                    Title = "AJAX",
                    Description = "Allows web pages to be updated asynchronously by exchanging small amounts of data with the server behind",
                    LearnMoreLink = "https://www.w3schools.com/js/js_ajax_intro.asp"
                },
                    new CourseModel
                {
                    Title = "PYTHON",
                    Description = "High-level programming language with dynamic semantics developed by Guido van Rossum",
                    LearnMoreLink = "https://www.w3schools.com/python/"
                },
                // Add more courses...
            };
        }

        public ActionResult CourseHomePage()
        {
            List<CourseModel> courses = GetCourses();
            return View(courses);
        }
    }
}
