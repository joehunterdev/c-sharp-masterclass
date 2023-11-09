using System;

class PatternPrinting
{
 
        static void Main()
        {

        for (int y = 0;  y < 4; y++)
        {
    
            for (int x = 1; x < 11; x++)
            {

                if (x == 5)
                {

                    continue;

                }
                if (x == 6)
                {

                    continue;

                }

                Console.Write(x+ " ");
            }

            Console.WriteLine(" ");

        }

        for (int y = 0; y < 2; y++)
        {
         
            for (int x = 10; x > 0; x--)
            {
              
                Console.Write(x + " ");

            }  

             Console.WriteLine(" ");

        }

        for (int x = 10; x > 2; x--)
        {

            Console.Write(x + " ");

        }

        Console.WriteLine(" ");

        for (int x = 10; x > 0; x--)
        {

            Console.Write(x + " ");

        }

        Console.WriteLine(" ");

        for (int x = 1; x < 11; x++)
        {
 
            if (x == 8)
            {

                continue;

            }

            Console.Write(x + " ");
        }
    }


}
