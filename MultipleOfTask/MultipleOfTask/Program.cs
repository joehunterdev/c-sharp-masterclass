class Program
{
    public static int[] ArrayOfMultiples(int num, int length)
    {
        length = length + 1;
        int[] newArray = new int[length];

        for (int i = 0; i < length; i++)
        {
            newArray[i] = num * i;
        }

        return newArray[1..];
    }

    static void Main()
    {
 
   
        foreach(int item in ArrayOfMultiples(7, 5))
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("\n");

        foreach (int item in ArrayOfMultiples(12, 10))
        {
            Console.WriteLine(item);
        }


    }

}