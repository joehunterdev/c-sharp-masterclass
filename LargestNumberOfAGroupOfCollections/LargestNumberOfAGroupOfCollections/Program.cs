using System;
using System.Collections.Generic;

namespace LargestNumberOfAGroupOfCollections
{

    class Program
    {
        //returns list type
        public static List<int> FindLargest(List<List<int>> numbers)
        {

            List<int> newList = new List<int>();

            foreach (List<int> item in numbers)
            {
                item.Sort();

                newList.Add(item[^1]);

            }

            return newList;

        }
        static void Main()
        {


            //List of numbers
            List <List<int>> numbersLists = new List<List<int>>() {
            new List<int>( ) { 67, 100, 23 },
            new List<int>( ) { 80, 99, 750, 99 },
            new List<int>( ) { 888, 333, 9898 } 
            };


            Console.WriteLine("Finding Largest: ");

            foreach (var item in FindLargest(numbersLists)) {
                 
                Console.Write(item + ",");

            }


        }


    }
}
