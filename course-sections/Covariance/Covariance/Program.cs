using System;
using System.Collections.Generic;

namespace Covariance
{

    class LivingThing {
        public int NumberOfLegs { get; set; }

    }

    class Parrot: LivingThing
    {


    }
    class Dog: LivingThing
    {

    }
    //out: for covariance says use this generic type t only as a return type cant be argument
    //in for contravariance
    interface IMover<out T> {


        T Move();

    }

    // can call only methods of the same interface but not of child classes
    public class Mover<T>:IMover<T>{

        //   T Method1(); // we can use this t as written type only but not as a parameter type

        public T thing { get; set; }
        public T Move()
        {
            return thing;
        }

        //T Method1(T x); //Invalid variance: The type parameter 'T' must be contravariantly valid on 'IMover<T>.Method1(T)'.
    }
    class Sample
    {
        public void PrintValues(IEnumerable<object> values) // IEnumerable<out T> 
        {
            //List<object>values will not work is not covariance compliance T 
            foreach (var item in values)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LivingThing livingThing = new Parrot(); // not covariance
            Parrot parrot = new Parrot(){ NumberOfLegs = 4}; //normal

            //IMover<Parrot> mover = new Mover<Parrot>;
            //Cannot implicitly convert type 'type1' to 'type2'. An explicit conversion exists (are you missing a cast?)
            //IMover<LivingThing> mover = new Mover<Parrot>(); //this is not allowed in generic type parameters

            //covariance = supply the child type name where the parent is expected
            IMover<LivingThing> mover = new Mover<Parrot>(){ thing = parrot}; // here we can pass the parrot child object (this is required for geneirc)

            //mover.Move(); //returns parrot objectg

            Console.WriteLine("Moving with " + mover.Move().NumberOfLegs + " legs"); //"LivingThing" vs "Parrot"; supplying the child type (Parrot), where the parent type (LivingThing) is expected

            //Covariance in real life
            Sample s = new Sample();
            s.PrintValues(new List<string>() { "hello", "world" });

            Console.ReadKey();

         }
    }
}
