using System;
using System.Collections.Generic;
using System.Linq; //required

namespace LINQExample
{

    class Employee
    {

        public int EmpID { get; set; }

        public string EmpName { get; set; }
        public string Job { get; set; }

        public string City { get; set; }

        public double Salary { get; set; }


    }

    class Person
    {

      public string PersonName { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //Collection of objects

            List<Employee> employees = new List<Employee>() {  // create new list of type <Employee>
              
                new Employee{ EmpID = 12,EmpName ="Joey",  Job="Developer", City = "Malaga", Salary = 79030  }, //Initialize new objects
                new Employee{ EmpID = 22,EmpName ="Bill",  Job="Analyst", City = "Madrid", Salary = 79031 },
                new Employee{ EmpID = 3,EmpName ="Steve",  Job="Developer", City = "Zaragoza", Salary = 14200 },
                new Employee{ EmpID = 44,EmpName ="Winnie",Job="Designer", City = "London", Salary = 64020 },
                new Employee{ EmpID = 10,EmpName ="Carlos",Job="Manager", City = "Zaragoza", Salary = 40000 }

            };

            //Where
            // var results = employees.Where(emp => emp.Job == "Developer");
            IEnumerable<Employee> results = employees.Where(emp => emp.City == "Zaragoza");

            //where ever there is IEnumerable you can perform a foreach
            foreach (Employee emp in results)
            {
                Console.WriteLine("Results Where: "+ emp.EmpName + ", " + emp.City);

            }

            //Orderby
            IOrderedEnumerable<Employee> orderdByName = employees.OrderBy(emp => emp.EmpName); // Lets use (same as IEnumerable) IOrderedEnumerable its used to add a secondary sort criteria represents well sorted data 
            IOrderedEnumerable<Employee> orderdByNameDescending = employees.OrderByDescending(emp => emp.EmpName); // descending

            IOrderedEnumerable<Employee> orderdByJobThenName = employees.OrderBy(emp => emp.Job).ThenBy(emp => emp.EmpName); // two conditions secondary sorting property using ThenBy() ThenByDescending()


            foreach (Employee emp in orderdByJobThenName)
            {
                Console.WriteLine("Results Ordered by job and name: " + emp.EmpName + ", " + emp.Job + ", " + emp.City);

            }


            //To list
            // IEnumerable<Employee> filteredEmployees = employees.Where(emp => emp.Job == "Developer").FirstOrDefault(); // where returns muliple value
            List<Employee> filteredEmployeesList = employees.Where(emp => emp.Job == "Developer").ToList(); // need to convert using ToList() working with lists where returns IEnumberable
            Console.WriteLine("To List:" + filteredEmployeesList[0].EmpName);


            //First
            Employee filteredEmployeesFirst = employees.First(emp => emp.Job == "Developer"); 
            Console.WriteLine("First:" + filteredEmployeesFirst.EmpName); // no need for indexer

            //First or default
            //When no matching is found using First  emp.Job == "Sweeper"
            Employee filteredEmployeesFirstOrDefault = employees.FirstOrDefault(emp => emp.Job == "Sweeper"); //returns null rather than invalid

            //using null here 
            if (filteredEmployeesFirstOrDefault != null)
            {
                Console.WriteLine("First Or default " + filteredEmployeesFirstOrDefault.EmpName); // no need for indexer
            }
            else {

                Console.WriteLine("No Employee found for query"); // no need for indexer

            }

            //Last
            Employee filteredEmployeesLast = employees.Last(emp => emp.Job == "Developer");
            Console.WriteLine("Last:" + filteredEmployeesLast.EmpName); // no need for indexer

            //Last or default
            //When no matching is found using Last  emp.Job == "Sweeper"
            Employee filteredEmployeesLastOrDefault = employees.LastOrDefault(emp => emp.Job == "Sweeper"); //returns null rather than invalid

            //using null here 
            if (filteredEmployeesLastOrDefault != null)
            {
                Console.WriteLine("Last Or default " + filteredEmployeesLastOrDefault.EmpName); // no need for indexer
            }
            else
            {

                Console.WriteLine("No Employee found for query");

            }


            //ElementAt
            Employee filteredEmployeesElementAt = employees.ElementAt(3);
            Console.WriteLine("ElementAt index:" + filteredEmployeesElementAt.EmpName); 

            //ElementAt or default
            //When no matching is found using ElementAt  emp.Job == "Sweeper"
            Employee filteredEmployeesElementAtOrDefault = employees.ElementAtOrDefault(100); //returns null rather than invalid

            //using null here 
            if (filteredEmployeesElementAtOrDefault != null)
            {
                Console.WriteLine("ElementAt Or default " + filteredEmployeesElementAtOrDefault.EmpName); // no need for indexer
            }
            else
            {

                Console.WriteLine("No Employee found for query"); // no need for indexer

            }



            //Single
            //(Expects only one matching element works well with unique properties)
            //The difference here is that if the result is multiple it returns unhandled exception
            Employee filteredEmployeesSingle = employees.Single(emp => emp.Job == "Designer");  //not IEnumerable 
            Console.WriteLine("Single:" + filteredEmployeesSingle.EmpName); // no need for indexer

            //Single or default
            Employee filteredEmployeesSingleOrDefault = employees.SingleOrDefault(emp => emp.Job == "Analyst");

            //using null here 
            if (filteredEmployeesSingleOrDefault != null)
            {
                Console.WriteLine("Single Or default " + filteredEmployeesSingleOrDefault.EmpName); // no need for indexer
            }
            else
            {

                Console.WriteLine("No Employee found for query"); // no need for indexer

            }



            //Select
            //Selects only a bunch of cols/vals from source
            //need to specify return type to match your value
            //based on the type it will take up the value automatically
            //good for converting types
            IEnumerable<string> filteredEmployeesSelect = employees.Select(emp => emp.EmpName).ToList();  //can use any collection methods on these dictionay etc 
            Console.WriteLine("Select First Combo:" + filteredEmployeesSelect.First());

            foreach (var item in filteredEmployeesSelect)
            {
                Console.WriteLine("Select: " + item); // no need for indexer

            }

            //Using select to object init
            //IEnumerable<Person> filteredEmployeesSelectWithNewObjectInit = employees.Select(emp => new Person() { PersonName = emp.EmpName });  //produce new person object for each item in collection
            
            List<Person> filteredEmployeesSelectWithNewObjectInit = employees.Select(emp => new Person() { PersonName = emp.EmpName }).ToList(); //to list can be usefull to access all of the list extension methods (add,addRange)

            foreach (Person item in filteredEmployeesSelectWithNewObjectInit)
            {
                Console.WriteLine(item.PersonName);

            }


            // Min, Max, Count, Sum, Average
            double maxItem = employees.Max(emp => emp.Salary);
            Console.WriteLine("Max item:" + maxItem);

            double minItem = employees.Min(emp => emp.Salary);
             Console.WriteLine("Min item:" + minItem);

            int count = employees.Count();
            Console.WriteLine("Count:" + count);

            double sum = employees.Sum(emp => emp.Salary);
            Console.WriteLine("Sum of all items:" + sum);

            double avg = employees.Average(emp => emp.Salary);
            Console.WriteLine("Average Salary:" + avg);

        }
    }
}