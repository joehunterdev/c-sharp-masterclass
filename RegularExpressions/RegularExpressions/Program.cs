using System;
using System.Text.RegularExpressions;

namespace RegularExpressions
{
    class Program
    {
        static void Main()
        {
            Regex digit = new Regex("[0-9]"); // only 1 digit
            Regex digits = new Regex("^[0-9]*$"); //only digits between 0-9 ^start $end
            Regex alpha = new Regex("^[A-Za-z]*$"); //only alpha upper and lower upper only "^[A-Z]*$"
            Regex alphaCase = new Regex("^[a-z]*$"); //alpha lower only "^[a-z]*$"
            Regex specificCharacters = new Regex("[1,2,3]"); //specific chars
            Regex onlyDigits = new Regex("\d"); //only digits
            Regex words = new Regex('\w'); //only words
            Regex whitespace = new Regex("\s"); //whitespace

            Console.WriteLine("Enter some input:");
            string inp = Console.ReadLine();
            bool isDigit = digits.IsMatch(inp); // heres how validate
            Console.WriteLine(isDigit);

        }
    }
}
