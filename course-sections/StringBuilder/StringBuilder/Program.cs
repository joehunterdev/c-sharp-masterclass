using System;
using System.Text;
namespace StringBuilderExample
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] words = new string[4] { "First", "lets ", "Say", "hello" };


            // Create a StringBuilder object with no text.
            string sentence = ""; // 16 char capacity default 

            foreach (string word in words) {

                sentence = sentence + " " + word;

            }


            Console.WriteLine(sentence);


            //StringBuilder
             StringBuilder builder = new StringBuilder("Hello",20);  // string builder is better for memory
            foreach (string word in words)
            {
                builder.Append(word);
                builder.Append(" ");
                Console.WriteLine(builder.ToString() + ", Legnth: " + builder.Length + ", Capacity: " + builder.Capacity);
               
            }

            //Additional methods
            builder[0] = 'v';
            Console.WriteLine(builder.ToString());
            Console.WriteLine(builder.MaxCapacity);

            Console.WriteLine(builder.Insert(5, "updated"));
            Console.WriteLine(builder.Remove(builder.ToString().IndexOf("q"), 3));
            Console.WriteLine(builder.Replace("a", "r"));
            Console.ReadKey();

   
        }
    }
}
