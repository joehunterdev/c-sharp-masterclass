using System;
using System.Collections.Generic;
using System.Collections;

namespace CustomIEnumerable
{

    public enum TypeOfPlayer
    {
        RegularPlayer, PayingPlayer
    }

    public class Player
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public TypeOfPlayer TypePlayer { get; set; }

    }
       //custom collection generic class IEnumerable
        class PlayerList:IEnumerable<Player>
        {
        private List<Player> players = new List<Player>();


        //implementing IEnumerable.GetEnumerator()
        //this method will get called first as its the direct implementaion of IEnumerable interface
        IEnumerator IEnumerable.GetEnumerator() // explicit interface implementation by default this has to be private
        {

           return  this.GetEnumerator();//from here we call the below method return type is IEnumerator
        }

        //implementing IEnumerable<T> get enumerator
        public IEnumerator<Player>GetEnumerator() // The problem with this is it doesnt implement defined methods like Add(),Find()
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
                Console.WriteLine("Sorry only regular players allowed");

            }
        }
    }

    class Program
    {
        static void Main()
        {
            PlayerList playerList = new PlayerList();
            playerList.Add(new Player() { Id = "7", Name = "killmr", TypePlayer = TypeOfPlayer.RegularPlayer }); // note the use of our custom method inside custom collection class
            playerList.Add(new Player() { Id = "9", Name = "NOE Grimes", TypePlayer = TypeOfPlayer.RegularPlayer });

            //we now can add lots more dynamically aka object intitializer
            playerList.Add(new Player() { Id = "1", Name = "edcat08", TypePlayer = TypeOfPlayer.PayingPlayer });
            playerList.Add(new Player() { Id = "2", Name = "vmax", TypePlayer = TypeOfPlayer.PayingPlayer });
            playerList.Add(new Player() { Id = "3", Name = "friki", TypePlayer = TypeOfPlayer.RegularPlayer });

            //IEnumerator enumerator = playerList.GetEnumerator(); // note declare of IEnumerator Type
            //MoveNext() implementation is not particularly real world 
            //better to use foreach  (IEnumerator IEnumerable & Enumerator here are working together)
            foreach (Player item in playerList) // no need to call enumerator as this method is built into 
            {
                Console.WriteLine(item.Name);
            }


        }
    }

}