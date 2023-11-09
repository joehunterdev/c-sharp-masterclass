using System;

namespace Tuples
{
    class CallOfDuty{ 
     
       public Tuple<int, string, string> GetPlayerDetails() {  //5 ways of accessign data: separate class, anonymous objects, out tpye param, tuple, value tuple
           
            Tuple<int, string, string> player = new Tuple<int, string, string>(1, "Friki", "Mara"); // not recommended to create more than 7
            return player;
        }

        //value tuple
        //good for returning multiple values at a time
        public (int NumPlayers, string Squad) GetAllSquadDetails()
        {  // change return type to 

            return (20, "Los Techeros");

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            //var referenceVariable = new Tuple<string, int>() {"im a string", 3};
            CallOfDuty cod = new CallOfDuty();
            Tuple<int, string, string> player = cod.GetPlayerDetails();

            Console.WriteLine(player.Item1);// this item property can be confusing
            Console.WriteLine(player.Item2);
            Console.WriteLine(player.Item3);

            //Return value tuples (not readonly)
            (int NumPlayers, string Squad) squad = cod.GetAllSquadDetails();
            Console.WriteLine("Squad Count: "+ squad.NumPlayers + "Squad Name:" + squad.Squad);


            //Deconstruction with Discard
            (int NumPlayers,_) = cod.GetAllSquadDetails(); //note: removed reference var (dont change the order)
            Console.WriteLine("Squad Count: " + NumPlayers + "Squad Name:" );

 


            //Creating new tuple
            var player2 = Tuple.Create(1, "Vmax", "Mara");

            Console.WriteLine(player2.Item1);
            Console.WriteLine(player2.Item2);
            Console.WriteLine(player2.Item3);
             
            // Max of 8
            var ranks = Tuple.Create(1, 2, 3, 4, 5, 6, 7, 8);
            Console.WriteLine(ranks.Item1);


        }
    }
}
