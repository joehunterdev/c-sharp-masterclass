using System;

namespace MathExample
{
    class Program
    {
        static void Main()
        {
            double x = 5.99;
            double y = 8.3;
            double z = -8.3;

            //Methods are all static and take double type
            //Pow:  returns the value of x power y
            Console.WriteLine($"Power of: x {x} and {y} = "+ Math.Pow(x, y));

            //Min: 
            Console.WriteLine($"Min of: x {x} and {y} = " + Math.Min(x, y));

            //Max: 
            Console.WriteLine($"Max of: x {x} and {y} = " + Math.Max(x, y));

            //Floor: 
            Console.WriteLine($"Floor of: x {x} = " + Math.Floor(x));

            //Ceil: 
            Console.WriteLine($"Ceiling of: x {x} = " + Math.Ceiling(x));

            //Round: 
            Console.WriteLine($"Round of: x {x} = " + Math.Round(x)); // takes additional arg for decimal place

            //Sign: 
            Console.WriteLine($"Signature (pos 1 or neg -1 or 0) of: x {x} = " + Math.Sign(x)); // takes additional arg for decimal place

            //Abs: 
            Console.WriteLine($"Abs returns positive of: z {z} = " + Math.Abs(z)); // takes additional arg for decimal place

            //Sqrt: 
            Console.WriteLine($"Square root of: x {x} = " + Math.Sqrt(x)); // takes additional arg for decimal place

            //Div Rem: 
            int rem;
            int quotient = Math.DivRem(10, 3, out rem); //quotient is 3 
            Console.WriteLine($"DivRem returns remainder of:  10 / 3  (3 goes into 10 3 times) and assign result param = " + quotient); // takes additional arg for decimal place
            Console.Write(" Remainder:" + rem); // is 1
         }
    }
}
