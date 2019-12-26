using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    class Program
    {
        static List<Employee> Populate()
        {
            var employeeDetails = new List<Employee>()
            {
                new Employee() {Id=1,Name="Raju",Location="Nagpur"},
                new Employee() {Id=2,Name="Shyam",Location="Noida"},
                new Employee() {Id=3,Name="Babu",Location="Nagpur"},
                new Employee() {Id=4,Name="Hero",Location="Nagpur"}
            };
            return employeeDetails;
        }

        static void SearchEmployee()
        {
            List<Employee> employeeDetails = Populate();

            Console.WriteLine("Enter Location :");
            var searchLocation = Console.ReadLine();

            foreach (Employee employee in employeeDetails)
            {
                if (employee.Location.Equals(searchLocation))
                {
                    Console.WriteLine(employee.Id + " " + employee.Name);
                }
            }
        }
        static void Main(string[] args)
        {
            SearchEmployee();

        }
    }
}