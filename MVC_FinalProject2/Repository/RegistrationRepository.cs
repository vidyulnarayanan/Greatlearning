using MVC_FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Security;

namespace MVC_FinalProject.Repository
{
    public class RegistrationRepository
    {
        private SqlConnection connection;

        private void Connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["GetDatabaseConnection2"].ToString();
            connection = new SqlConnection(constr);
        }

       /// <summary>
       /// ADDING DETAILS OF USERS TO LIST
       /// </summary>
       /// <param name="registration"></param>
       /// <returns></returns>
        public bool AddDetails(Registration registration)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("SPI2_Registration", connection);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@FirstName", registration.FirstName);
                com.Parameters.AddWithValue("@LastName", registration.LastName);
                com.Parameters.AddWithValue("@DateOfBirth", registration.DateOfBirth);
                com.Parameters.AddWithValue("@Gender", registration.Gender);
                com.Parameters.AddWithValue("@PhoneNumber", registration.PhoneNumber);
                com.Parameters.AddWithValue("@Email", registration.Email);
                com.Parameters.AddWithValue("@Address", registration.Address);
                com.Parameters.AddWithValue("@City", registration.City);
                com.Parameters.AddWithValue("@State", registration.State);
                com.Parameters.AddWithValue("@Pincode", registration.Pincode);
                com.Parameters.AddWithValue("@UserName", registration.UserName);
                com.Parameters.AddWithValue("@Role", registration.Role);
                com.Parameters.AddWithValue("@Password", registration.Password);
                com.Parameters.AddWithValue("@ConfirmPassword", registration.ConfirmPassword);
                connection.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        /// <summary>
        /// DISPLAYING INSERTED DATA OF USERS
        /// </summary>
        /// <returns></returns>

        public List<Registration> GetDetails()
        {
            try
            {
                Connection();
                List<Registration> Registrationlist = new List<Registration>();
                SqlCommand com = new SqlCommand("SPS2_Registration", connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                connection.Open();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                    Registrationlist.Add(
                        new Registration()
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstName = Convert.ToString(dr["FirstName"]),
                            LastName = Convert.ToString(dr["LastName"]),
                            DateOfBirth = Convert.ToString(dr["DateOfBirth"]),
                            Gender = Convert.ToString(dr["Gender"]),
                            PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                            Email = Convert.ToString(dr["Email"]),
                            Address = Convert.ToString(dr["Address"]),
                            City = Convert.ToString(dr["City"]),
                            State = Convert.ToString(dr["State"]),
                            Pincode = Convert.ToString(dr["Pincode"]),
                            UserName = Convert.ToString(dr["UserName"]),
                            Role = Convert.ToString(dr["Role"]),
                            Password = Convert.ToString(dr["Password"]),
                            ConfirmPassword = Convert.ToString(dr["ConfirmPassword"]),

                        });
                return Registrationlist;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        /// <summary>
        /// THIS GETDETAILS METHOD IS USED TO LOGIN SESSION MANAGEMENT 
        /// TO DISPLAY LOGGED IN USER DETAIL IN NAVIGATION BAR
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Registration GetDetails(string Email)
        {
            try
            {
                Connection();
          
                SqlCommand com = new SqlCommand("SPS2_Registration", connection);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
           
                connection.Open();
                da.Fill(dt);
                DataRow dr =dt.AsEnumerable()
               .FirstOrDefault(r=> r.Field<string>("Email") == Email);//.Select("@Email = " + Email).FirstOrDefault();
                var retval = new Registration()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    FirstName = Convert.ToString(dr["FirstName"]),
                    LastName = Convert.ToString(dr["LastName"]),
                    DateOfBirth = Convert.ToString(dr["DateOfBirth"]),
                    Gender = Convert.ToString(dr["Gender"]),
                    PhoneNumber = Convert.ToString(dr["PhoneNumber"]),
                    Email = Convert.ToString(dr["Email"]),
                    Address = Convert.ToString(dr["Address"]),
                    City = Convert.ToString(dr["City"]),
                    State = Convert.ToString(dr["State"]),
                    Pincode = Convert.ToString(dr["Pincode"]),
                    UserName = Convert.ToString(dr["UserName"]),
                    Role = Convert.ToString(dr["Role"]),
                    Password = Convert.ToString(dr["Password"]),
                    ConfirmPassword = Convert.ToString(dr["ConfirmPassword"]),
                };
                return retval;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

        }
        /// <summary>
        /// UPDATING ALREADY ISERTED DATA
        /// </summary>
        /// <param name="registration"></param>
        /// <returns></returns>
        public bool EditDetails(Registration registration)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("SPU2_Registration", connection);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@FirstName", registration.FirstName);
                com.Parameters.AddWithValue("@LastName", registration.LastName);
                com.Parameters.AddWithValue("@DateOfBirth", registration.DateOfBirth);
                com.Parameters.AddWithValue("@Gender", registration.Gender);
                com.Parameters.AddWithValue("@PhoneNumber", registration.PhoneNumber);
                com.Parameters.AddWithValue("@Email", registration.Email);
                com.Parameters.AddWithValue("@Address", registration.Address);
                com.Parameters.AddWithValue("@City", registration.City);
                com.Parameters.AddWithValue("@State", registration.State);
                com.Parameters.AddWithValue("@Pincode", registration.Pincode);
                com.Parameters.AddWithValue("@UserName", registration.UserName);
                com.Parameters.AddWithValue("@Role", registration.Role);
                com.Parameters.AddWithValue("@Password", registration.Password);
                com.Parameters.AddWithValue("@ConfirmPassword", registration.ConfirmPassword);
                connection.Open();
                int i = com.ExecuteNonQuery();
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

        }

        /// <summary>
        /// DELETION OPERATION ON INSERTED DATA
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteDetails(int Id)
        {
            try
            {
                Connection();
                SqlCommand com = new SqlCommand("SPD2_Registration", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("Id", Id);
                connection.Open();
                int i = com.ExecuteNonQuery();
               
                if (i >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                connection.Close();
            }

        }



    }
}