class Program
{
    Expression<Func<Student, bool>> isTeenAgerExpr = s => s.age > 12 && s.age < 20;

    static void Main()
    {


    }
}