using System;
using ClassLibrary1;
class Program
{

    static void Main()
    {
        //Arrays

        //Array of int
        //syntax type[ ] arrayReferenceVariableName = new type[ size ];
        int[] a = new int[5];// it is not possible to create array with out specifying the size [5]
        int[] b = new int[5] { 10, 20, 30, 40, 50 };
        string[] c = new string[3] { "one", "two", "three" }; // with initialization

        //Display
        Console.WriteLine(a[0]);
        //Set
        a[1] = 1;
        Console.WriteLine("Printing from index:");

        Console.WriteLine(b[0]);
        Console.WriteLine(b[1]);
        Console.WriteLine(b[2]);
        Console.WriteLine(b[3]);
        Console.WriteLine(b[4]);
        Console.WriteLine();

        Console.WriteLine(c[0]);
        Console.WriteLine(c[1]);
        Console.WriteLine(c[2]);

        Console.WriteLine("Printing for loop:");

        //Iterating arrays with for
        for (int i = 0; i < b.Length; i++) //always use lefnth
        {
            Console.WriteLine(b[i]);
        }

        Console.WriteLine("Printing foreach:");

        //Iterating arrays with foreach
        foreach (int i in b)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();

        Console.WriteLine("Printing for in reverse:");

        //Iterating arrays with for in reverse

        //Iterating arrays with for
        for (int i = b.Length - 1; i >= 0; i--) // Starting number is Legnth -1; i >= is greater than or equal to 0, descend decrement
        {
            Console.WriteLine(b[i]);
        }

        Console.WriteLine("Printing for in reverse using Reverse():");

        // Or 
        Array.Reverse(b);
        for (int i = 0; i < b.Length; i++) //always use lefnth
        {
            Console.WriteLine(b[i]);
        }
        Array.Reverse(b);

        // IndexOf
        Console.WriteLine("Printing index based on value IndexOf");

        double[] d = new double[6] { 10, 20, 30, 40, 50, 30 }; // with initialization

        Console.WriteLine(Array.IndexOf(d, 30)); // this will return first value found
        Console.WriteLine(Array.IndexOf(d, 30, 3)); // this will return first value found from 3rd key
        Console.WriteLine(Array.IndexOf(d, 100)); // returns -1

        Console.WriteLine("Printing index based on value BinarySearch");

        // Binary Search
        double[] e = new double[] { 10, 20, 30, 40, 50, 60, 70, 80, 100 };

        Console.WriteLine("30 is found in first half with index : " + Array.BinarySearch(e, 30)); //searhes only first half of array
        Console.WriteLine("70 is found in second half with index: " + Array.BinarySearch(e, 70)); // this will return first value found


        // Clear method
        Console.WriteLine("Clearing Array Clear()");

        //public static void Clear (Array array, int index, int length);
        int[] f = new int[] { 0, 10, 20, 30, 40, 50, 60, 70, 80, 100 };

        //Array.Clear(f, 0, f.Length); clear all 
        Array.Clear(f, 0, f.Length / 2); //clear half 

        Console.WriteLine(f);

        foreach (var item in f)
        {
            Console.WriteLine(item);
        }


        //Array resize
        Console.WriteLine("Resizing Array ArrayResize()");

        string[] g = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };

        Array.Resize(ref g, g.Length - 3); // Shorten array by 3

        foreach (var item in g)
        {
            Console.WriteLine(item);
        }

        int[] h = new int[] { 0, 10, 20, 30, 40 };
        Array.Resize(ref h, h.Length + 5); // Shorten array by 3

        foreach (var item in h)
        {
            Console.WriteLine(item);
        }

        // Array sort
        string[] j = new string[] { "Mahesh", "David", "Allen", "Joe", "Monica" };

        Array.Sort(j); // sort alhpabetical
        foreach (string item in j)
        {
            Console.WriteLine(item + " ");
        }

        // Array Index From End Operator
        Console.WriteLine("Index From End Operators ^");

        int[] k = new int[] { 0, 10, 20, 30, 40 };

        //index from end operator
        Console.WriteLine(k[^1]); // gets last element
        Console.WriteLine(k[^2]); // gets second to last element

        //range operator^
        Console.WriteLine("Range [2..5] Operators ");

        foreach (int item in k[2..5])
        {
            Console.WriteLine(item);
        }

        //Multi dimensional arrays
        //Two-dimensional array.
        int[,] array2D = new int[,] { { 1, 2 }, { 3, 4 }, { 5, 6 }, { 7, 8 } }; // each , represents a dimension
                                                                                // The same array with dimensions specified.

        int[,] array2Da = new int[4, 2] { //[rows,columns]
            { 1, 2 },
            { 3, 4 },
            { 5, 6 },
            { 7, 8 }
        };

        // A similar array with string elements.
        string[,] array2Db = new string[3, 2] { { "one", "two" }, { "three", "four" },
                                        { "five", "six" } };

        System.Console.WriteLine("2d array element value: " + array2D[1, 0]);

        //jagged arrays
        Console.WriteLine("Jagged Arrays");

        int[][] l = new int[3][];

        l[0] = new int[3] { 1, 2, 3 };
        l[1] = new int[4] { 4, 5, 6, 7 };
        l[2] = new int[2] { 1, 2 };

        for (int i = 0; i < l.Length; i++)
        {
            //Console.WriteLine(l[i]);

            for (int i2 = 0; i2 < l[i].Length; i2++)
            {
                Console.Write(l[i][i2] + " ");

            }
            Console.WriteLine(" ");

        }

        //Array of objects
        Console.WriteLine("Array of objects");

        //Create objects
        Employee emp1 = new Employee() { EmpID = 101, EmpName = "Scott" };
        Employee emp2 = new Employee() { EmpID = 102, EmpName = "Bill" };
        Employee emp3 = new Employee() { EmpID = 103, EmpName = "James" };

        //array of objects 
        Employee[] employees = new Employee[] { emp1, emp2, emp3 }; // you can only store those of type Employee

        foreach (Employee item in employees)
        {
            Console.WriteLine(item.EmpName);
        }

        //CopyTo
        Employee[] employees2 = new Employee[4] {
          new Employee(){ EmpID = 105, EmpName = "Hamid", EmpRole= "Teamlead", Location= "France"},
          new Employee(){ EmpID = 104, EmpName = "Luis",  EmpRole= "Teamlead", Location= "Madrid"},
          new Employee(){ EmpID = 106, EmpName = "Joe",   EmpRole= "Developer",Location= "Malaga"},
          new Employee(){ EmpID = 107, EmpName = "Jacobo",EmpRole= "Developer",Location= "Vigo"}
        };

        // new array
        Console.WriteLine("Copy to: \n");
        Employee[]spainEmployees = new Employee[6]; // this index must match when copying too
        employees2[0].Location = "Venice"; //shallow copy changes made in references as object is NOT copied   

        employees2.CopyTo(spainEmployees,2); // simple copy reference object = array, start index, also expects array to already exist

        foreach (Employee emp in spainEmployees)
        {
          if(!(emp is null))
            {
                Console.WriteLine(emp.Location);

            } else
            {
                Console.WriteLine("null object");
            }
        }

        //Clone
        Console.WriteLine("Clone: \n");
        employees2[0].Location = "Botswana"; // this will work! because both arrays contain references to object (shallow copy)
        // To iterate we need to type cast (Employee[])
        Employee[] spainEmployees2 = (Employee[])spainEmployees.Clone(); // creates an array 6 copys from source to that new array

        foreach(Employee item in spainEmployees2) //employees3 will get you an error because clone method return type is an object
        {
            if (!(item is null))
            {
                Console.WriteLine(item.Location);

            }
            else
            {
                Console.WriteLine("null object");
            }

        }


    }

}