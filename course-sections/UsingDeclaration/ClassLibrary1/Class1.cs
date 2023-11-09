using System;

namespace ClassLibrary1
{
    public class Sample : System.IDisposable
    {
        //constructor
        public Sample()
        {
            Console.WriteLine("Database connected.");
        }

        //method
        public void DisplayDataFromDatabase()
        {
            Console.WriteLine("Reading data from database");
        }

        public void DisplayDataFromDatabase2()
        {
            Console.WriteLine("Reading data from database2");
        }

        //Dispose
        public void Dispose()
        {
            Console.WriteLine("Database disconnected");
        }
    }
}
