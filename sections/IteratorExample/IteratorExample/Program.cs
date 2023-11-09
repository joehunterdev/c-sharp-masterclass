// C# program to illustrate the concept
// of iterator using list collection
using System;
using System.Collections.Generic;
class IteratorExample
{
    static int counter = 1;
    public static IEnumerable<string> GetMyList() //Iterator method
    {
        
        // Creating and adding elements in list
        List<string> playerList = new List<string>() {"edcat08", "noegrimes", "friki", "vmax" };

        counter = 0;

        // Iterating the elements of my_list
        foreach (var items in playerList)
        {
          //  Console.WriteLine("Iterator method executes");
            // Returning the element after every iteration
            yield return items.ToUpper(); //remains of list type
          //  Console.WriteLine("Iterator method continues");

            counter++;
            

        }
    }

    // Main Method
    static public void Main()
    {

        // Storing the elements of GetMyList
        IEnumerable<string> my_slist = GetMyList();

        var enumerator1 = my_slist.GetEnumerator();
        enumerator1.MoveNext();
        Console.WriteLine("Current " + enumerator1.Current);
        enumerator1.MoveNext(); // Here you can use this to break up your operations if you have more things to do with your code
        Console.WriteLine("Lobby Count " + IteratorExample.counter);
        enumerator1.MoveNext();
        Console.WriteLine("Current "+ enumerator1.Current);
        enumerator1.MoveNext();  
        Console.WriteLine("Lobby Count " + IteratorExample.counter);
        Console.WriteLine("Current " + enumerator1.Current);


        //Console.WriteLine("In a loop \n");

        // Display the elements return from iteration
        //foreach (var i in my_slist)
        //{
        //    Console.WriteLine(i);
        //}

        
    }
}