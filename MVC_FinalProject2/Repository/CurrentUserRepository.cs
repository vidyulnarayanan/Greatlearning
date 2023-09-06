using MVC_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_FinaLProject2.Repository
{
    /// <summary>
    /// THIS REPOSITORY IS BUILT TO USE FOR LOGIN,LOGOUT SESSION MANAGEMENT
    /// </summary>
    public static class CurrentUserRepository
    {
        public static Registration CurrentUser { get; set; }

        public static bool IsLogin { get; set; }
    }
}