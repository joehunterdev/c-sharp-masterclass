using System;
using System.Collections.Generic;

namespace AssignmentInLargest
{
    class Program
    {
        static void Main()
        {
            //source list of 'list of int'
            List<List<int>> sourceList = new List<List<int>>()
            {
                new List<int>() { 67, 100, 23 },
                new List<int>() { 80, 99, 750, 99 },
                new List<int>() { 888, 333, 9898 }
            };

            List<int> findLargest = FindLargest(sourceList); //calling the method

            //output
            Console.Write("List of largest numbers = (");
            foreach (var item in findLargest)
            Console.Write(item + ", ");
            Console.Write(")");
            Console.ReadKey();
        }

        //method that receives a list of 'list of int' and returns 'list of int' with respective largest numbers
        public static List<int> FindLargest(List<List<int>> numbers)
        {
            List<int> resultsList = new List<int>(); //create an empty 'list of int'
            foreach (var child_list in numbers)
            {
                if (child_list.Count > 0) //check if the child_list has some values
                {
                    child_list.Sort(); //sort the 'list of int' that comes from the 'numbers' list (source list)
                    resultsList.Add(child_list[child_list.Count - 1]); //take the last value after sorting (because we are sorting it in ascending order). So the last number should be the largest.
                                                                       //Alternatively, you can write a loop (nested for loop) here (based on 'child_list') to get the largest value
                }
            }
            return resultsList;
        }
    }
}
