class Program
{
    static void Main()
    {
        //create three objects for Employee

        Employee emp1 = new Employee(); //num of params points to constructor 3 
        emp1.empID = 101;
        emp1.empName = "Boris";

       //display fields
        System.Console.WriteLine("Company Name: ");
        System.Console.WriteLine(Employee.companyName);


        System.Console.WriteLine("\n First employee:");
        System.Console.WriteLine(emp1.empID);
        System.Console.WriteLine(emp1.empName);
        System.Console.WriteLine(emp1.job);
        System.Console.WriteLine();

        System.Console.WriteLine("Second employee:");
        System.Console.WriteLine(emp2.empID);
        System.Console.WriteLine(emp2.empName);
        System.Console.WriteLine(emp2.job);
        System.Console.WriteLine();

        System.Console.WriteLine("Third employee:");
        System.Console.WriteLine(emp3.empID);
        System.Console.WriteLine(emp3.empName);
        System.Console.WriteLine(emp3.job);
        System.Console.WriteLine();

        System.Console.ReadKey();
    }
}