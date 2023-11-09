using System;
using ClassLibrary1;

namespace PatternMatchingExample
{
    class Program
    {
        static void Main()
        {



            object greeting = "Hello, World!";
            if (greeting is string message)
            {
                Console.WriteLine(message.ToLower());  // output: hello, world!
            }


            //reference variable of parent class
            ParentClass pc;

            //object of child class
            pc = new ChildClass() { x = 10, y = 20 };

            //access parent class's members
            if (pc is ChildClass cc)
            {
                Console.WriteLine(cc.x);
                Console.WriteLine(cc.y);

            }

            Console.ReadKey();
        }
    }
}
