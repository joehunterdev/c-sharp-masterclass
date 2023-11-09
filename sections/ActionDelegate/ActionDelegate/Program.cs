class Program
{

    static void Main()
    {
        Action doWorkAction = new Action(DoWork); //by default is void
        doWorkAction(); //Print "Hi, I am doing work." 
    }

    public static void DoWork()
    {
        Console.WriteLine("Hi, I am doing work.");
    }

}
