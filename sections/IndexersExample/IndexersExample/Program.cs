using System;


     class Program
    {
        static void Main()
        {
            Car c = new Car();
            Console.WriteLine(c[1]); // get a value

            c[2] = "Jaguar"; //set or overwriting a value in indexer
            Console.WriteLine(c[2]);

            //overloading
            Console.WriteLine(c["first"]);


    }
}
