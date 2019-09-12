using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CarInsurance( string firstName, string lastName, string emailAddress, string dateOfBirth, string carYear, string carMake, string carModel, bool dui, int speedingTickets, string coverageType, int quote)
        {
            if(string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(dateOfBirth) || string.IsNullOrEmpty(carYear) || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel))
            {
                return View ("~/Views/Shared/Error.cshtml");
            }
            else
            {
                //string connectionString = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=CarInsurance;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                string queryString = @"INSERT INTO CarInsurance (FirstName, LastName, EmailAddress, DateOfBirth, CarYear, CarMake, CarModel, Dui, SpeedingTickets, CoverageType, Quote) VALUES
                                            (@FirstName, @LastName, @EmailAddress, @DateOfBirth, @CarYear, @CarMake, @CarModel, @Dui, @SpeedingTickets, @CoverageType, @Quote)";

                using (SqlConnection connection = new SqlConnection())
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Parameters.Add("@FirstName", SqlDbType.VarChar);
                    command.Parameters.Add("@LastName", SqlDbType.VarChar);
                    command.Parameters.Add("@EmailAddress", SqlDbType.VarChar);
                    command.Parameters.Add("@DateOfBirth", SqlDbType.Date);
                    command.Parameters.Add("@CarYear", SqlDbType.Int);
                    command.Parameters.Add("@CarMake", SqlDbType.VarChar);
                    command.Parameters.Add("@CarModel", SqlDbType.VarChar);
                    command.Parameters.Add("@Dui", SqlDbType.Bit);
                    command.Parameters.Add("SpeedingTickets", SqlDbType.Int);
                    command.Parameters.Add("CoverageType", SqlDbType.Bit);
                    command.Parameters.Add("Quote", SqlDbType.Money);

                    command.Parameters["@FirstName"].Value = firstName;
                    command.Parameters["@LastName"].Value = lastName;
                    command.Parameters["@EmailAddress"].Value = emailAddress;
                    command.Parameters["@DateOfBirth"].Value = dateOfBirth;
                    command.Parameters["@CarYear"].Value = carYear;
                    command.Parameters["@CarMake"].Value = carMake;
                    command.Parameters["@CarModel"].Value = carModel;
                    command.Parameters["@Dui"].Value = dui;
                    command.Parameters["@SpeedingTickets"].Value = speedingTickets;
                    command.Parameters["@CoverageType"].Value = coverageType;
                    command.Parameters["@Quote"].Value = quote;


                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return View("Success");
            }
        }
        public ActionResult Admin()
        {
            return View();
        }
       
    }
}