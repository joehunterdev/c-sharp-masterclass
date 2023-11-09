class Program
{

    static void Main()
    {

        var operation = 2;

        var result = operation switch
        {
            1 => "Case 1",
            2 => "Case 2",
            3 => "Case 3",
            4 => "Case 4",
        };

        Console.WriteLine(result);

    }

}