class Program
{

    static void Main()
    {

        Func<int, int> square = x => x * x; //lambda expressions
        Console.WriteLine(square(5));

        Action<string> greet = name => //lambda statement
        {
            string greeting = $"Hello {name}!";
            Console.WriteLine(greeting);
        };

        greet("World");


    }

}