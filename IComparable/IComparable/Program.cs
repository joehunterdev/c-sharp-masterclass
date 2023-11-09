using System;
using System.Collections.Generic;

namespace IComparable
{
    public enum TypeOfPlayer
    {
        RegularPlayer, PayingPlayer
    }

    class Player : IComparable<Player> 
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Rank { get; set; }


        public int CompareTo(Player other)
            {

              // returns int whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
            if (this.Rank < other.Rank)
                {
                    return 1;
                }
                else if (this.Rank > other.Rank)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

    }

    class Program
    {
      
        static void Main()
        {
            var players = new List<Player>
            {
             new Player(){Id=1,Name="friki",Rank=66},
             new Player(){Id=2,Name="vmax",Rank=400},
             new Player(){Id=3,Name="edcat08",Rank=440},
             new Player(){Id=4,Name="Noe GRIMES",Rank=66},
             new Player(){Id=5,Name="killmr",Rank=300},
             new Player(){Id=5,Name="hacker",Rank=650},

            };

            Console.WriteLine("Comparing Player Ranks: ");
            players.Sort();
            players.ForEach(player => Console.WriteLine(player.Name));

            Console.WriteLine("---------------------------");

            players.Reverse();
            players.ForEach(player => Console.WriteLine(player.Name));

        }
    }
}
