using System;
using System.Collections.Generic;

class JoeBankInc
{
    static void Main()
    {

        var employees = new List<Employee>();
        Employee.OrganizationName = "JoeBankInc"; //Static

        Console.Write("How many persons you want to add?: ");

        //max 10
        int newCount = int.Parse(Console.ReadLine());

        if(newCount > 10)
        {
            Console.Write("You cant have more than 10");
           
        }  else
        {
            for (int i = 0; i < newCount; i++)
            {
                // Here you can give each person a custom name based on a number
                Console.Write("Currently adding employee id "+ i + '\n');

                Console.Write("Write name: ");
                string newEmpName = Console.ReadLine();
                Console.Write("Write hourly salary: ");
                int newSalaryPerHour = int.Parse(Console.ReadLine());
                Console.Write("Write Working hours: ");
                int newNoOfWorkingHours = int.Parse(Console.ReadLine());
                int newNetSalary = newSalaryPerHour * newNoOfWorkingHours;
                Console.WriteLine("The Salary Net:" + newNetSalary);
                employees.Add(new Employee{EmpID = i, EmpName = newEmpName, SalaryPerHour = newSalaryPerHour, NoOfWorkingHours = newNoOfWorkingHours, NetSalary = newNetSalary });

                if(i < newCount)
                {
                    Console.Write("Do you want to continue to next employee (yes/no) ?:");

                    string continueToNextEmployee = Console.ReadLine();

                    if (continueToNextEmployee != "yes")
                    {
                        break;
                    }
                }

       

            }

            Console.WriteLine("Currently Displaying: " + Employee.TypeOfEmployee+" - "+ employees[0].DepartmentName+" employees of "+ Employee.OrganizationName+ "\n");
            Console.WriteLine("\tEmpID \tName \tSalary \tHours \tNetSalary");

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine("\t" + employees[i].EmpID + "\t" + employees[i].EmpName + "\t" + employees[i].SalaryPerHour + "\t" + employees[i].NoOfWorkingHours + "\t" + employees[i].NetSalary);

            }
        }

   
    }
}

