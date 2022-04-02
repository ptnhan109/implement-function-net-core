using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpenXMLSample.Models
{
    public class EmployeeIndex
    {
        public const int Name = 4;

        public const int Email = 6;

        public const int Address = 8;

        public const int DayOfBirth = 10;

        public const int HomePhone = 12;

        public const int CellPhone = 14;

        public const int Intro = 19;

    }

    public static class EmployeeHelper
    {
        public static string GetEmployeeProp(this string input)
        => input.Split(":")[1].Trim();
    }
    public class Employee
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public DateTime DayOfBirth { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public string Intro { get; set; }

        public List<WorkExperience> WorkExperiences { get; set; }
    }

    public class WorkExperience
    {
        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Company { get; set; }

        public string Role { get; set; }

    }

}
