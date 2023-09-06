using MVC_FinaLProject2.Models;
using MVC_FinaLProject2.Repository;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using System;

public class CourseController : Controller
{
    private SqlConnection connection;

    private void Connection()
    {
        string constr = ConfigurationManager.ConnectionStrings["GetDatabaseConnection2"].ToString();
        connection = new SqlConnection(constr);
    }

    public ActionResult CourseHomePage()
    {
        List<CourseModel> courses = GetCourses();

        return View(courses);
    }

    public ActionResult AddCourse()
    {
        if (CurrentUserRepository.CurrentUser != null && CurrentUserRepository.CurrentUser.Role == "Admin")
        {
            return View();
        }
        else
        {
            return RedirectToAction("UnauthorizedAccess");
        }
    }

    [HttpPost]
    public ActionResult AddCourse(CourseModel course)
    {
        if (CurrentUserRepository.CurrentUser != null && CurrentUserRepository.CurrentUser.Role == "Admin")
        {
            if (ModelState.IsValid)
            {
                Connection(); // Establish the database connection

                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPI_Courses", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Title", course.Title);
                    command.Parameters.AddWithValue("@Description", course.Description);
                    command.Parameters.AddWithValue("@Link", course.Link);
                    command.ExecuteNonQuery();
                }
                finally
                {
                    connection.Close();
                }

                List<CourseModel> updatedCourses = GetCourses();

                return View("CourseHomePage", updatedCourses);
            }

            return View(course);
        }
        else
        {
            return RedirectToAction("UnauthorizedAccess");
        }
    }

    public ActionResult EditCourse(int id)
    {
        if (CurrentUserRepository.CurrentUser != null && CurrentUserRepository.CurrentUser.Role == "Admin")
        {
            CourseModel course = GetCourseById(id);

            if (course != null)
            {
                return View(course);
            }
            else
            {
                return HttpNotFound();
            }
        }
        else
        {
            return RedirectToAction("UnauthorizedAccess");
        }
    }

    [HttpPost]
    public ActionResult EditCourse(CourseModel course)
    {
        if (CurrentUserRepository.CurrentUser != null && CurrentUserRepository.CurrentUser.Role == "Admin")
        {
            if (ModelState.IsValid)
            {
                UpdateCourse(course);

                List<CourseModel> updatedCourses = GetCourses();

                return View("CourseHomePage", updatedCourses);
            }

            return View(course);
        }
        else
        {
            return RedirectToAction("UnauthorizedAccess");
        }
    }

    public ActionResult DeleteCourse(int Id)
    {
        if (CurrentUserRepository.CurrentUser != null && CurrentUserRepository.CurrentUser.Role == "Admin")
        {
            Connection(); // Establish the database connection

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SPD_Courses", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }

            List<CourseModel> updatedCourses = GetCourses();

            return View("CourseHomePage", updatedCourses);
        }
        else
        {
            return RedirectToAction("UnauthorizedAccess");
        }
    }

    private List<CourseModel> GetCourses()
    {
        Connection();
        List<CourseModel> courses = new List<CourseModel>();

        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SPS_Courses", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                CourseModel course = new CourseModel
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Description = reader["Description"].ToString(),
                    Link = reader["Link"].ToString()
                };
                courses.Add(course);
            }
        }
        finally
        {
            connection.Close();
        }

        return courses;
    }

    private CourseModel GetCourseById(int Id) { 
    
        Connection();
        CourseModel course = null;

        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT Id, Title, Description, Link FROM Table_Courses WHERE Id = @Id", connection);
            command.Parameters.AddWithValue("@Id", Id);

            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    course = new CourseModel
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Title = reader["Title"].ToString(),
                        Description = reader["Description"].ToString(),
                        Link = reader["Link"].ToString()
                    };
                }
            }
        }
        finally
        {
            connection.Close();
        }

        return course;
    }

    private void UpdateCourse(CourseModel course)
    {
        Connection();

        try
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SPU_Courses", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", course.Id);
            command.Parameters.AddWithValue("@Title", course.Title);
            command.Parameters.AddWithValue("@Description", course.Description);
            command.Parameters.AddWithValue("@Link", course.Link);
            command.ExecuteNonQuery();
        }
        finally
        {
            connection.Close();
        }
    }
}
