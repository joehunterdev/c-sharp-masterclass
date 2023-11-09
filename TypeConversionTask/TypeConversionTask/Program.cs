using System;

class Program
{

    static void Main()
    {
        byte a = 10; //Convert this value into "short" type (assign into another short type of variable)
        int b = 10; //Convert this value into "short" type (assign into another short type of variable)
        string c = "10.34"; //Convert this value into "double" type using Parse  //Also, convert the same value into "decimal" type  using TryParse
        decimal d = 11.56m; //Convert this value into "string" type (assign into another string type of variable)

        //Implicit
        short aOut =  a;

        //Explicit
        short bOut = (short)b;

        //Parse
        double cOutParsed = double.Parse(c);

        //TryParse
        bool cOutBool = decimal.TryParse(c,out decimal cOutDecimal);

        //Conversion Methods
        string dOut = d.ToString();

        Console.WriteLine(aOut);
        Console.WriteLine(bOut);
        Console.WriteLine(cOutParsed);
        Console.WriteLine(cOutDecimal);
        Console.WriteLine(d);

 
    }

}