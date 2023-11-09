public class Employee
{
       public void DisplayName(string name) => Console.WriteLine(name);
}
class Program
{
    static void Main()
    {
     Employee employee = new Employee();
     employee.DisplayName("Joey");

    }
}