using System;
using System.Collections.Generic;

namespace DateTimeExample
{
    class Person
    {
        public string PersonName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
    class Program
    {
        static void Main()
        {
            Person person1 = new Person();
            person1.PersonName = "Miller"; 
            person1.DateOfBirth = DateTime.Parse("2000-12-31 11:59:59.999 am"); // Parse date from string (expects this format to convert)
            Console.WriteLine(person1.DateOfBirth.ToString());

            Console.WriteLine("Day " + person1.DateOfBirth.Day);
            Console.WriteLine("Month " + person1.DateOfBirth.Month);
            Console.WriteLine("Year " + person1.DateOfBirth.Year);
            Console.WriteLine("Hours " + person1.DateOfBirth.Hour);
            Console.WriteLine("Minutes " + person1.DateOfBirth.Minute);
            Console.WriteLine("Seconds " + person1.DateOfBirth.Second);
            Console.WriteLine("Milliseconds " + person1.DateOfBirth.Millisecond);
            Console.WriteLine("Day of week " + person1.DateOfBirth.DayOfWeek);
            Console.WriteLine("Day of week " + (int)person1.DateOfBirth.DayOfWeek);
            Console.WriteLine("Day of year " + person1.DateOfBirth.DayOfYear);

            DateTime dt = DateTime.Now;
            Console.WriteLine(dt.ToString());

            //Formats
            DateTime dtFormat = new DateTime(2020, 12, 31, 23, 59, 59, 999);//constructor
            string str1 = dtFormat.ToString(); //MM/dd/yyyy hh:mm:ss tt
            string str2 = dtFormat.ToShortDateString(); //MM/dd/yyyy
            string str3 = dtFormat.ToLongDateString(); //dd MMMM yyyy
            string str4 = dtFormat.ToShortTimeString(); //hh:mm tt
            string str5 = dtFormat.ToLongTimeString(); //hh:mm:ss tt
            string str6 = dtFormat.ToString("dd-MM-yyyy HH:mm:ss");

            Console.WriteLine(str1);
            Console.WriteLine(str2);
            Console.WriteLine(str3);
            Console.WriteLine(str4);
            Console.WriteLine(str5);
            Console.WriteLine(str6);

            int daysInMonth = DateTime.DaysInMonth(2022, 7);
            Console.WriteLine("There are " + daysInMonth + " in 7th month");


            //Parse exact
            //may have issues if date time is already defined
            // takes 4 args: public static DateTime ParseExact (string s, string format, IFormatProvider? provider); (format takes slashes)
            System.DateTime dtParseExact =  System.DateTime.ParseExact("31/12/2020 23:59:59", "dd/MM/yyyy HH:mm:ss",System.Globalization.CultureInfo.InvariantCulture,System.Globalization.DateTimeStyles.None);
            Console.WriteLine(dtParseExact);


            //Date Subtraction
            DateTime date1 = new DateTime(2022, 7, 1); //yyyy
            Console.WriteLine(date1.ToString());
            DateTime date2 = new DateTime(2022, 7, 4); //yyyy
            TimeSpan subtracted = date1.Subtract(date2);
            Console.WriteLine("Remaining days using subtract: " + subtracted.TotalDays);

            //returns comparison
            int compareTo = date1.CompareTo(date2);

            if (compareTo > 0)

            Console.WriteLine(date1 + " is later than " + date2);


            else if (compareTo == 0)

                Console.WriteLine(date1 + " is the same time as " + date2);

            else

               Console.WriteLine(date1 + " is earlier " + date2);


            //Date Addition

            //we can add a new timespan like so
            TimeSpan timeSpan = new TimeSpan(12, 0, 0, 0);
            DateTime datePlusTimeSpan = date1.Add(timeSpan); //AddDays, AddMonths, AddYears etc
            Console.WriteLine("Date plus timespan: " + datePlusTimeSpan);


            Console.ReadKey();
        }
    }
}
