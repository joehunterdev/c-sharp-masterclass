using System;
using System.Collections.Generic;

namespace IComparer
{

    class Player 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
 
    }

    public enum SortBy
    {
        Name,Id,Rank
    }

    class PlayerRank : IComparer<Player>
    {
        // public SortBy SortTypes { get; set; }
        public SortBy sortTypes { get; set; }

        public int Compare(Player x, Player y) //returns int implements IComparer
        {
 
            int result = 0;

            switch (this.sortTypes)
            {
                case SortBy.Rank:

                    result = x.Rank - y.Rank;

               break;

                case SortBy.Name:

                    result = (x.Name !=null) ? x.Name.CompareTo(y.Name) : 0; // Implement IComparable CompareTo method - provide default sort order.


                    break;

                case SortBy.Id:

                    result = x.Rank - y.Rank;
               
                    break;
            }



            return result;
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
             new Player(){Id=6,Name="hacker",Rank=650}

            };

            //PlayerRank ranker = new PlayerRank();

            Console.WriteLine("Comparing Player Ranks: ");

            players.Reverse();
            players.ForEach(player => Console.WriteLine(player.Name + " Ranks: " + player.Rank));

            Console.WriteLine("---------------------------");
    
            PlayerRank ranker = new PlayerRank();
            ranker.sortTypes = SortBy.Name;
            players.Sort(ranker);  // Issue was that we needed to implement ! ArgumentException: At least one object must implement IComparable.

            players.ForEach(player => Console.WriteLine(player.Name + " Ranks: " + player.Rank));

            Console.WriteLine("---------------------------");


        }
    }
}
