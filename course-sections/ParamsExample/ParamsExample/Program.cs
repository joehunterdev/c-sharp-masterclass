class Student
{
    public void DisplaySubjects(params string[] subjects)
    {
        System.Console.WriteLine(subjects[1]);
    }
}

class Program
{
     
    static void Main()
    {
        Student s = new Student();
         s.DisplaySubjects("Theory of Computation", "Computer Networks", "Something Else");
    }

} 