using System;

namespace ImplicitlyTypedVariablesExample
{
    class Program
    {
        static void Main()
        {
            // Using var keyword to shorten a legnthy variable
            var p = new namespace1.namespace2.namespace3.Person() { PersonName = "Harsha" };
            //calling a method on written type
            var p2 = "Harsha".ToUpper(); // datatype is implicit as string
            // You cant do this it must be intialized
            //var p3; 

            Console.WriteLine(p.PersonName);
            Console.WriteLine(p2);
            Console.ReadKey();
        }
    }
}
