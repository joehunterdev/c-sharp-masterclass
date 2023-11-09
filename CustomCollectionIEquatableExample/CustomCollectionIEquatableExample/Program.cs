using System;
using System.Collections.Generic;
using System.Collections;

namespace CustomCollectionIEquatble
{
    public enum TypeOfPlayer
    {
        RegularPlayer, PayingPlayer
    }

    public class Player : IEquatable<Player> 
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public TypeOfPlayer TypePlayer { get; set; }

        public bool Equals(Player other) // here we implement IEquatable equals returns bool
        {
            return this.Id == other.Id && this.Name == other.Name && this.TypePlayer == other.TypePlayer; //refers to first,second,.. element in the list if atleast one is found it will return true
        }

    }

    //custom collection generic class IList
    class PlayerList :  IList<Player> //Needs to implement all methods in IList
    {
        private List<Player> players = new List<Player>();

        public int Count => players.Count; // count of items present in collection

        public bool IsReadOnly => false; // we want users to be able to modify this collection returns either true or false if found

        public Player this[int index] { get => players[index]; set => players[index] = value; } //indexer with get /set accesor

        //implementing IEnumerable.GetEnumerator()
        //this method will get called first as its the direct implementaion of IEnumerable interface
        //implementing IEnumerable.GetEnumerator()
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        //implementing IEnumerable<T> get enumerator
        public IEnumerator<Player> GetEnumerator() // The problem with this is it doesnt implement defined methods like Add(),Find()
        {
            for (int i = 0; i < players.Count; i++)
            {
                yield return players[i];
            }
        }

        //could manipultate more with Add(), Find(), Remove()
        //lets add a user defined method
        public void Add(Player player)
        {
            //custom Add logic
            if (player.TypePlayer == TypeOfPlayer.PayingPlayer)
            {
                players.Add(player); // simply add to the list
            }
            else
            {
                Console.WriteLine("Sorry only paying players allowed");

            }
        }

        public void Clear()
        {
            // throw new NotImplementedException();
        }

        public bool Contains(Player item)
        {
            return players.Contains(item); //can identify same object but this will cause issue when creating the same object twice
        }

        public void CopyTo(Player[] array, int arrayIndex)
        {
            // throw new NotImplementedException();
            players.CopyTo(array, arrayIndex);

        }

        public bool Remove(Player item)
        {
            return players.Remove(item);

        }

        // can go on to add additional methods
        public Player Find(Predicate<Player> match) // this predicate returns bool value
        {
            return players.Find(match); //invokes the delegate object for each element in the list and returns first matching
        }

        public List<Player> FindAll(Predicate<Player> match) //return type is list of customer
        {
            return players.FindAll(match);
        }

        public int IndexOf(Player item) //meant for searhcing of customer index
        {
            return players.IndexOf(item);
        }

        public void Insert(int index, Player item)
        {
            players.Insert(index, item); // could add custom logic here
        }

        public void RemoveAt(int index)
        {
            if (index < 0)
            {
                Console.WriteLine("Invalid index");
            }
            else
            {
                players.RemoveAt(index);
            }
        }

    }

    class Program
    {
        static void Main()
        {
            PlayerList playerList = new PlayerList();
            playerList.Add(new Player() { Id = "7", Name = "killmr", TypePlayer = TypeOfPlayer.RegularPlayer }); // note the use of our custom method inside custom collection class
            playerList.Add(new Player() { Id = "9", Name = "NOE Grimes", TypePlayer = TypeOfPlayer.PayingPlayer });

            //we now can add lots more dynamically aka object intitializer
            playerList.Add(new Player() { Id = "1", Name = "edcat08", TypePlayer = TypeOfPlayer.PayingPlayer });
            playerList.Add(new Player() { Id = "2", Name = "vmax", TypePlayer = TypeOfPlayer.PayingPlayer });
            playerList.Add(new Player() { Id = "3", Name = "friki", TypePlayer = TypeOfPlayer.PayingPlayer });

            Player new_player = new Player() { Id = "10", Name = "Jacob", TypePlayer = TypeOfPlayer.PayingPlayer };
            Player another_player = new Player() { Id = "10", Name = "Jacob", TypePlayer = TypeOfPlayer.PayingPlayer };

            playerList.Add(new_player);

            //Contains
            Console.WriteLine("Contains: " + playerList.Contains(new_player));
            Console.WriteLine(playerList.Count + " customers found.");

            Console.WriteLine("Contains: " + playerList.Contains(another_player));
            Console.WriteLine(playerList.Count + " customers found.");


            //Remove
            playerList.Remove(new_player);

            foreach (Player player in playerList)
            {
                Console.WriteLine(player.Id + ", " + player.Name + ", " + player.TypePlayer);
            }

            ////Find
            Player matchingPlayer = playerList.Find(x => x.Id == "1");

            if (matchingPlayer != null)
            {
                Console.WriteLine("Matching Player Found: " + matchingPlayer.Name + ", " + matchingPlayer.Id);
            }

            ////FindAll
            List<Player> paying_players = playerList.FindAll(player => player.TypePlayer == TypeOfPlayer.PayingPlayer);
            Console.WriteLine("Paying players:");

            foreach (Player player in paying_players)
            {
                Console.WriteLine(player.Id + ", " + player.Name + ", " + player.TypePlayer);
            }

            //IndexOf
            Console.WriteLine("Index of: " + playerList.IndexOf(new_player));

            //Insert
            playerList.Insert(2, matchingPlayer);
            Console.WriteLine("Inserted: " + playerList[2].Name);

            Console.WriteLine("Now will remove: " + playerList[3].Name);

            playerList.RemoveAt(3);
            //playerList.RemoveAt(4);

            int i = 0;
            foreach (Player item in playerList) // no need to call enumerator as this method is built into 
            {
                Console.WriteLine("Modified playerlist:" + (i++) + " " + item.Name);
            }

            Console.ReadKey();

            playerList.Clear();
        }
    }

}