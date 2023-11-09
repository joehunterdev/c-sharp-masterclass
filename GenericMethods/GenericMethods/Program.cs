class Program
{
    static void Main()
    {
        Sample sample = new Sample();
        Employee emp = new Employee() { Salary = 1000 };
        Student stu = new Student() { Marks = 10 };

        //sample.PrintData<Student>;
        sample.PrintData<Student>(stu); // this gets passed into obj

    }
}