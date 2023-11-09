using System;
using ClassLibrary;

namespace EventsExample
{

    class Subscriber //The aim of this class is only to listen in for when publisher raises event
    {
        // here we can assign the reference of one or more methods to the event
        //Target method
        public void Add(int a, int b)
        {
            Console.WriteLine(a + b);  
        }
    }

}

