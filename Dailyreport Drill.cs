using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Tech_Academy_Daily_report
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Tech Academy");

            Console.WriteLine("Student Daily Report:");
            Console.WriteLine("What course are you on?");
            string courseOn = Console.ReadLine();


            Console.WriteLine("What page number are you on?");
            string pageNumber = Console.ReadLine();
            int pageNum = Convert.ToInt32(pageNumber);
            int total = pageNum + 0;

            Console.Write("Do you need help with anything? Please answer \"True\" or \"False\"");
            string TrueorFalse = Console.ReadLine();

            Console.WriteLine("Were there any positive eperiences you'd like to share? Please give specifics.");
            string shareSpecifics = Console.ReadLine();

            Console.WriteLine("Is there any other feedback you'd like to provide? Please be specific.");
            string provideSpecific = Console.ReadLine();

            Console.WriteLine("How many hours did you study today?");
            string hoursStudy = Console.ReadLine();

            int hours = Convert.ToInt32(hoursStudy);
            int hour = hours + 0;

            Console.WriteLine("Thank you for your answers. An Instructor will respond to this shortly. Have a great day!");
            Console.ReadLine();



        }
    }
}
