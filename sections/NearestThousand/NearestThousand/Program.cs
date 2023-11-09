class NearestThousand
{
    
    static void Main()
    {
        //Write a C# program to get nearest thousand of given integer numberer. Here, let name the input value as "number".

        //Rounding using Math
        //double y = 499;
        //double rounded = System.Math.Round(y / 1000d, 0) * 1000;


        //Here, let name the input value as "number".

        //If the number's last three digits are greater than or equal to 500; it should "round up" the number.
        //If the number's last three digits are less than 500; it should "round down" the number.
        //If the number is less than 500; it should round up to 1000.

        //Eg:
        //Input: 499  Output: 1000
        //Input: 500  Output: 1000
        //Input: 999  Output: 1000
        //Input: 1000 Output: 1000
        //Input: 1499 Output: 1000
        //Input: 1500 Output: 2000


        //Rounding using arithmetical / ternary
        int x = 29345;

        int result = x % 1000 >= 500 ? x + 1000 - x % 1000 : x - x % 1000;

        System.Console.WriteLine(result);
        System.Console.ReadKey();


    }

}
