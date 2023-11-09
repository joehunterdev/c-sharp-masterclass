class Program
{
    static void Main()
    {
        //create object of generic class
        MarksPrinter<GraduateStudent> mp = new MarksPrinter<GraduateStudent>(); // Must be student or a child class of
        mp.stu = new GraduateStudent() { Marks = 80 };
        mp.PrintMarks();
        System.Console.ReadKey();
    }
}