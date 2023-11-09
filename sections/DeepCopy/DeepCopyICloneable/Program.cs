using System;

namespace CopyAndClone
{
    //model class
    class Employee : ICloneable
    {
        public string EmployeeName { get; set; }
        public string Role { get; set; }
 
        public object Clone()
        {
            //this will refer to first object if we employees[0].CreateNewEmployee and copy all the data
            Employee new_one = new Employee() { EmployeeName = this.EmployeeName, Role = this.Role };
            return new_one;

        }
    }
    class Program
    {
        static void Main()
        {
            Employee[] employees = new Employee[]
            {
                new Employee() { EmployeeName = "Joseph", Role = "Developer" },
                new Employee() { EmployeeName = "Jack", Role = "Designer" },
                new Employee() { EmployeeName = "Alexa", Role = "Analyst" }
            };

            Employee[] employees_deep_copy = new Employee[employees.Length];


            for(int i = 0; i<employees.Length;i++)
            {
                //Console.WriteLine(employees[i].EmployeeName);
                var result = (Employee)employees[i].Clone(); //creating new object with the same data as we are using icloneable interface and only specified as object we need to further typecast as Employee
                employees_deep_copy[i] = result; // manual implementation of deepcopy
            }

            //print deep copy
            Console.WriteLine("Deep Copy:  \n");
            // if we were now to make changes to employees array it would not be affected in employees_deep_copy
            employees[1].EmployeeName = "Bill";

            foreach (Employee emp in employees_deep_copy)
            {
                if (!(emp is null))
                {
                    Console.WriteLine(emp.EmployeeName + ", " + emp.Role);
                }
                else
                {
                    Console.WriteLine("null object");
                }
            }


            //new array
            Employee[] highlyPaidEmployees = new Employee[5];
            //CopyTo
            employees.CopyTo(highlyPaidEmployees, 2);
            employees[0].Role = "Changed";

            //print destination array
            Console.WriteLine("\nCopyTo:");
            foreach (Employee emp in highlyPaidEmployees)
            {
                if (!(emp is null))
                {
                    Console.WriteLine(emp.EmployeeName + ", " + emp.Role);
                }
                else
                {
                    Console.WriteLine("null object");
                }
            }

            //Clone
            Employee[] highlyPaidEmployees2 = (Employee[])employees.Clone();  //createss a  new array & copies from source array to that new array
            Console.WriteLine("\nClone:");
            foreach (Employee emp in highlyPaidEmployees2)
            {
                if (!(emp is null))
                {
                    Console.WriteLine(emp.EmployeeName + ", " + emp.Role);
                }
                else
                {
                    Console.WriteLine("null object");
                }
            }

            Console.ReadKey();
        }
    }
}
