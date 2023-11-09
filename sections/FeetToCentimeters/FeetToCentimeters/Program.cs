class FeetToCentimeters
{
    static void Main()
    {
        //1 foot = 30.48 cm  
        double feet = 5.3; 
        double cmFootUnit = 30.48; 
        double heightInCentimeters = feet * cmFootUnit;  //Inches is a unit of feet so this can be simplified

        System.Console.WriteLine(heightInCentimeters);

    }
}