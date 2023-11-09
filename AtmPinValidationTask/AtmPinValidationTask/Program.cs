using System;

class DebitCard
{
    private string _pin;
 
    public string Pin {
        set {
            if (4 <= value.Length && value.Length <= 6 && int.TryParse(value, out _)) {
               _pin = value;
            }
        }
        get { return _pin; }
    }

}

class Program
{
    static void Main()
    {
        DebitCard d = new DebitCard();

        Console.Write("Enter your desired pin number: ");

        d.Pin = Console.ReadLine();

 
        if (string.IsNullOrEmpty(d.Pin))
        {
            Console.WriteLine("Invalid Pin");
        }
        else
        {
            Console.WriteLine("Valid Pin");
        }

        Console.ReadKey();
    }
}