/*
Write a C# program to calculate "area of circle" based on the given "radius" value.
The radius value can be assigned to a variable; need not to take the value from the keyboard input.

Formula: PI * radius * radius

PI is a constant value, approximately equal to 3.14159, which is equal to the ratio of the circumference of any circle to its diameter. 
*/
class AssignmentAreaOfCircle
{
    static void Main()
    {
        //inputs
        double pi = 3.14159;  //a constant value
        int radius = 5;

        //process
        double area = pi * radius * radius;

        //output
        System.Console.WriteLine(area);
        System.Console.Read();
    }
}

