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
                    new CourseModel
                {
                    Title = "REACT JS",
                    Description = "This framework is an open-source JavaScript framework and library developed by Facebook",
                    LearnMoreLink = "https://www.w3schools.com/REACT/default.asp"
                },
                    new CourseModel
                {
                    Title = "GOLANG",
                    Description = "Go is used for a variety of applications like cloud and server side applications, DevOps, command line tools and much more",
                    LearnMoreLink = "https://www.w3schools.com/go/"
                },
                    new CourseModel
                {
                    Title = "JAVA",
                    Description = "A multi-platform, object-oriented, and network-centric language that can be used as a platform in itself",
                    LearnMoreLink = "https://www.w3schools.com/java/"
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
