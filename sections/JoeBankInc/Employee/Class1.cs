public class Employee
{
    //fields
    //EmpID, EmpName, SalaryPerHour, NoOfWorkingHours and NetSalary. 
    public int EmpID;
    public string EmpName;
    public int SalaryPerHour;
    public int NoOfWorkingHours;
    public int NetSalary;
 
    public static string OrganizationName;
    public const string  TypeOfEmployee = "Contract Based";
    public readonly string DepartmentName;

    //constructor
    public Employee()
    {
        DepartmentName = "Finance Department";
    }
}
