using System;
using ClassLibrary1;

namespace MultiCastDelegatesExample
{
    class Program
    {
        static void Main()
        {
            //create object of Sample
            Sample s = new Sample(); // need to define our object first 

            //create reference variable of MyDelegateType
            MyDelegateType myDelegate;

            //add ref of first target method
            myDelegate = s.Add; //Notice we dont need to use new MyDelegateType() 

            //add ref of second target method
            myDelegate += s.Multiply; //+= will be attached rather than overwritten

            //invoke both target methods; first Add method; and then Multiply method
            myDelegate.Invoke(40, 10); //Separate methods: same parameters will be applied to both methods

            Console.ReadKey();
        }
    }
}
