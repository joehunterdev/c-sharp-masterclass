class Program
{
    static bool IsUpperCase(string str)
    {
        return str.Equals(str.ToUpper());
    }

    static bool IsPositiveNumber(int num)
    {
      
        if(num < 0) { return false; } else { return true; }
         
     }

    static void Main()
    {

        Predicate<string> isUpper = IsUpperCase;
        bool result = isUpper("hi");
        Console.WriteLine(result);


        Predicate<int> isPos = IsPositiveNumber;
        bool result2 = isPos(-1);
        Console.WriteLine(result2);
        

    }

}