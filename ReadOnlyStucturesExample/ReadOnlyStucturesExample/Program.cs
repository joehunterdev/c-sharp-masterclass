using System;

class Program
{
        static void Main()
        {
            // create structure instance
            Marvel m = new Marvel("Thanos"); 
            Console.WriteLine(m.CharacterName); //property
            m.PrintCharacterName(); //method
        }
}