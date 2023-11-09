
using System;
using ClassLibrary;

namespace EventsExample
{
 
   class Program
    {
        static void Main()
        {
            //Create object of subscriber
            Subscriber subscriber = new Subscriber();

            //Create object of publisher
            Publisher publisher = new Publisher();

            //handle or subscribe to the event
            publisher.myEvent += subscriber.Add; // store/subscrive reference of add method in myevent

            //invoke the event
            publisher.RaiseEvent(13, 12);

            Console.WriteLine();

        }
    }

}
