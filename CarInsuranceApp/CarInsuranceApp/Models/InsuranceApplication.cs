using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceApp.Models
{
    public class InsuranceApplication
    {
        public int Id { get; set; }
        public string FirtstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? DateofBirth { get; set; }
        public  int CarYear { get; set; }
        public string CarModel { get; set; }
        public string CarMake { get; set; }
        public bool Dui { get; set; }
        public int SpeedingTickets { get; set; }
        public string CoverageType { get; set; }
        public int Quote { get; set; }
    }
}