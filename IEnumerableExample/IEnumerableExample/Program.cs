using System;
using System.Collections.Generic;
using System.Linq;

namespace IEnumerableExample
{
    class Program
    {
        static void Main()
        {
            //create a collection
            IEnumerable<string> messages; // Storing ref from parents will give you flexibility › It is the parent interface of all types of collections.
            messages = new List<string>() { "How are you", "Have a great day", "Thanks for meeting" }; // benefit you can store not just the ref of list but also stack etc!

            //foreach 
            Console.WriteLine("IEnumerable:"); // something multiple somthing plural -  this process is same as messages.GetEnumerator below. but implemented automatically (its good to know whats going on behind scenes)
            foreach (string item in messages)
            {
                Console.WriteLine(item);
            }

            //IEnumerator this is made for reading through multiple  (makes the foreach loop work)
            Console.WriteLine("\nIEnumerator:"); 
            IEnumerator<string> enumerator = messages.GetEnumerator(); //this assigns into the IEnumerator we dont need to implement this(it happens automatically)
            enumerator.Reset();
            while (enumerator.MoveNext()) // bool val 
            {
                Console.WriteLine(enumerator.Current); //How are you
            }

            Console.ReadKey();
        }
    }
}
