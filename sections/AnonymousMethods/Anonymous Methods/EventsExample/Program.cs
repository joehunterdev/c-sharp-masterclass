﻿using System;
using ClassLibrary1;

namespace EventsExample
{
    class Program // this has now become the Subscriber class
    {
        static void Main()
        {
  
            //create obj of Publisher class
            Publisher publisher = new Publisher();

            //handle the event (or) subscribe to event
            publisher.myEvent += delegate(int a, int b) => { // anonymous method
                int c = a + b;
                Console.WriteLine(c);
            };
            
            //invoke the event
            publisher.RaiseEvent(10, 20);
            publisher.RaiseEvent(5, 80);
            publisher.RaiseEvent(14, 22);

            Console.ReadKey();
        }
    }
}
