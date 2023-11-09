using System;

class LargestOfThreeNumbers
{
        static void Main()
        {

            //Write a C# program to find out largest number among three numbers, using "if".
            int num1 = 120;
            int num2 = 115;
            int num3 = 123;
       
            if(num1 >= num2 && num1 >= num3)
            {
                Console.WriteLine("Num1 is the biggest");

            }

            if (num2 >= num1 && num2 >= num3) {

                Console.WriteLine("Num2 is the biggest");
            }

            if (num3 >= num1 && num3 >= num2)
            {
                Console.WriteLine("Num3 is the biggest");
            }
          
        }

        static void SolutionNested()
        {
            //inputs
            int num1 = 60, num2 = 45, num3 = 123;

            int biggest;
            if (num1 > num2)  //"num1 is greater than num2"
                if (num1 > num3)  //"num1 is greater than num2" and "num1 is greater than num3"
                    biggest = num1;
                else  //"num1 is greater than num2" and "num3 is greater than num1"
                    biggest = num3;
            else  //"num2 is greater than num1"
                if (num2 > num3)  //"num2 is greater than num1" and "num2 is greater than num3"
                biggest = num2;
            else  //"num2 is greater than num1" and "num3 is greater than num2"
                biggest = num3;
            System.Console.WriteLine(biggest);
            System.Console.ReadKey();
        }
}
