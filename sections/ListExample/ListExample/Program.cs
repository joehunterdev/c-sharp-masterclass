using System;
using System.Collections.Generic;

namespace ManyToOneExample
{

    class Operator
    {

        public string Gender { get; set; }
        public string Name { get; set; }
        public Faction Faction { get; set; }

        public void Print()
        {

            Console.Write("Operator belongs to Faction: " + this.Faction.FactionName + " ");

        }

    }

    class Faction
    {
        public int? FactionId { get; set; }
        public string? FactionName { get; set; }

    }


    class Program
    {
        static void Main()
        {
            //Three operators belonging to one player
            Operator o1 = new Operator() { Gender = "m", Name = "Golem", };
            Operator o2 = new Operator() { Gender = "m", Name = "Ronin", };
            Operator o3 = new Operator() { Gender = "f", Name = "Mara", };

            //create object of Department class
            Faction faction = new Faction() { FactionId = 10, FactionName = "Warcom" };
            o1.Faction = faction;
            o2.Faction = faction;
            o3.Faction = faction;

            Console.WriteLine("FIRST Operator:");
            Console.WriteLine("Operator Gender: " + o1.Gender);
            Console.WriteLine("Operator Name: " + o1.Name);
            Console.WriteLine("Faction ID: " + o1.Faction.FactionId);
            Console.WriteLine("Faction Name: " + o1.Faction.FactionName);

            Console.WriteLine("Second Operator:");
            Console.WriteLine("Operator Gender: " + o2.Gender);
            Console.WriteLine("Operator Name: " + o2.Name);
            Console.WriteLine("Faction ID: " + o2.Faction.FactionId);
            Console.WriteLine("Faction Name: " + o2.Faction.FactionName);

            Console.WriteLine("Third Operator:");
            Console.WriteLine("Operator Gender: " + o3.Gender);
            Console.WriteLine("Operator Name: " + o3.Name);
            Console.WriteLine("Faction ID: " + o3.Faction.FactionId);
            Console.WriteLine("Faction Name: " + o3.Faction.FactionName);



        }
    }
}
