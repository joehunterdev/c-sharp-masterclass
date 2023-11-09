using System;
using System.Collections.Generic;

namespace ContravarianceExample
{
    class LivingThing
    {
        public int NumberOfLegs { get; set; }
    }
    class Parrot : LivingThing
    {
    }
    class Dog : LivingThing
    {
    }
    interface IMover<in T>//use in keyword to pass a parent 
    {
        void Move(T x);
    }
    public class Mover<T> : IMover<T> // child class implements interface Imover
    {
        public void Move(T x) // T is argument data type allowed as paramter
        {
            //Better to check the data type first
            if (x is Parrot)

                Console.WriteLine("Moving with " + (x as Parrot).NumberOfLegs + " legs"); // x as parrot convert data type

            else

                Console.WriteLine("Moving with " + (x as Dog).NumberOfLegs + " legs");
        }
    }
    class Program
    {
        static void Main()
        {
            //create normal object
            Parrot parrot = new Parrot() { NumberOfLegs = 2 };
            Dog dog = new Dog() { NumberOfLegs = 4 };

            // Contravariance = supply the parent type name, where the child type name is expected.
            IMover<Parrot> obj1 = new Mover<Parrot>(); //normal
            IMover<Parrot> obj2 = new Mover<LivingThing>();//supplying parent type
            //"Parrot" vs "LivingThing"; supplying the parent type (LivingThing), where the child type (Parrot) is expected.
            obj2.Move(parrot);

            IMover<Dog> obj3 = new Mover<LivingThing>();
            obj3.Move(dog);

            Console.ReadKey();
        }
    }
}
