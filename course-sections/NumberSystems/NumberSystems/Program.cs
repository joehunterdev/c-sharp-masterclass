using System;

namespace NumberSystems
{
    class Program
    {
        static void Main()
        {
            //Binary number systems
            int dec1 = 13; //Default treated as decimal number system not the same as data type
            //Convert to binary
            string binary1 = Convert.ToString(dec1,2); // to base specify amount as second param toBase(2) 13 / 2 
            Console.WriteLine("Binary :" + binary1);
             
        }
    }
}
