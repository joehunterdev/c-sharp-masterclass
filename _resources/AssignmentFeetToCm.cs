/*
Write a C# program convert a person's height (in feet and inches) to centimeters.
Eg:
feet = 5
inches = 7
output: 170.18 cm

Formula:
1 inch = 2.54 cm
1 feet = 12 inches
*/
class Program
{
    static void Main()
    {
        //inputs
        int feet = 5, inches = 7;

        //process
        //find number of inches based on number of feet
        int total_inches = (feet * 12) + inches;
        //find number of centimeters based on number of inches
        double centimeters = total_inches * 2.54;

        //output
        System.Console.WriteLine(centimeters);
        System.Console.ReadKey();
    }
}
