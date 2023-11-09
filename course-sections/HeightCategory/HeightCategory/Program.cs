using System;

class HeightCategory
{
  static void Main()
    {

        //Height is less than 150 cm = "Dwarf"
        //Height is between 150 cm and 165 cm = "Average height"
        //Height is between 165 cm and 195 cm = "Tall"
        //Height is above 195 cm = "Abnormal height"
      
        double personHeightCm = 15 * 2.54;

        Console.WriteLine(personHeightCm);

        if (personHeightCm < 150)
        {
            Console.WriteLine("Dwarf");

        } else if (personHeightCm < 165)
        {
            Console.WriteLine("Average height");

        }
        else if (personHeightCm < 195)
        {
            Console.WriteLine("Tall");
        }
        else
        {
            Console.WriteLine("Average height");
        }

    }
}

