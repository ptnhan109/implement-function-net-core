using EPPlusExportExcel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPPlusExportExcel.Repositories
{
    public class EmployeeRepository
    {
        public static List<Employee> EmployeeData()
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    Name = "Frank",
                    Age = 33,
                    Phone = "+841234567890",
                    Address = "Chicago"
                },
                new Employee()
                {
                    Id = 2,
                    Name = "Fiona",
                    Age = 33,
                    Phone = "+841234567890",
                    Address = "Chicago"
                },
                new Employee()
                {
                    Id = 3,
                    Name = "Lip",
                    Age = 33,
                    Phone = "+841234567890",
                    Address = "Chicago"
                },
                new Employee()
                {
                    Id = 4,
                    Name = "Ian",
                    Age = 33,
                    Phone = "+841234567890",
                    Address = "Chicago"
                },
                new Employee()
                {
                    Id = 5,
                    Name = "Deb",
                    Age = 33,
                    Phone = "+841234567890",
                    Address = "Chicago"
                },
                new Employee()
                {
                    Id = 6,
                    Name = "Carl",
                    Age = 33,
                    Phone = "+841234567890",
                    Address = "Chicago"
                },
            };
            return employees;
        }
    }
}
