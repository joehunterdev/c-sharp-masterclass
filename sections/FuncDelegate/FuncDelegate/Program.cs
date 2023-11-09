class Program{


 
    static void Main()
    {
        // Func Syntax:  public delegate TResult Func<in T, out TResult>(T arg);
 
        Func<int, int> plusone = number => number + 1;
        Console.WriteLine(plusone(3));

        // Declare a Func variable and assign a lambda expression to the
        // variable. The method takes a string and converts it to uppercase.
        Func<string, string> selector = str => str.ToUpper();

        // Create an array of strings.
        string[] words = { "orange", "apple", "Article", "elephant" };
        // Query the array and select strings according to the selector method.
        IEnumerable<String> aWords = words.Select(selector);

        // Output the results to the console.
        foreach (String word in aWords)
        {
            Console.WriteLine(word);

        }



    }


}