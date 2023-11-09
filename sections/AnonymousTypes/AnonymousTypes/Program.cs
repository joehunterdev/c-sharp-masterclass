using System;
using CallOfDuty;
namespace AnonymousTypes
{
    class Program
    {
        static void Main()
        {
            //Create object of player class
            Player pl = new Player();

            //calll methods creates anonymous class by c# compiler
            var pAnon = new { Name = pl.GetPlayerName(), Rank = pl.GetPlayerRank() }; //data types assigend automatically (defualt string)
            Console.WriteLine(pAnon.Rank + pAnon.Name);

            var pAnonNested = new { Name = pl.GetPlayerName(), Prop2 = new { Name = pl.GetPlayerName(), Rank = pl.GetPlayerRank() } }; //data types assigend automatically (defualt string)
            Console.WriteLine(pAnonNested.Name + " Anon Nested "+ pAnonNested.Prop2.Name);


            //calll methods creates anonymous class 
            var p = new { Rank = 108, Player = "Friki" };
            // Rest the mouse pointer over v.Amount and v.Message in the following
            // statement to verify that their inferred types are int and string.
            Console.WriteLine(p.Rank + p.Player);

           //Anonymous types typically are used in the select clause of a query expression to return a subset of the properties from each object in the source sequence. For more information about queries, see LINQ in C#.
            var anonArray = new[] { new { Name = "Friki", Rank = 40 }, new { Name = "Vmax", Rank = 100 } }; //all objects must contain same set of properties
            Console.WriteLine(anonArray[1].Name);
        }
    }
}
