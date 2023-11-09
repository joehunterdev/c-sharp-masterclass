/*
 Create a class called 'Number' with an instance field called 'value' that stores an integer value.
 This class should contain the following methods to manipulate the number that is stored in the 'value' field.
 */
using System.Collections.Generic;
using System.Linq;
class Number {


    private int value; //field
     public void SetValue(int value)
    {
        this.value = value;
    }
    public double GetValue()
    {
        return this.value;
    }

     //remember bools default value is false
    public bool IsZero()
    {
        if(this.value == 0){return true;} else {return false;}
    }
    public bool IsPositive()
    {
        // 0 is niether positive nor negative
        if (this.value > 0) { return true; } else { return false; }
    }

    public bool IsNegative()
    {
        if (!this.IsPositive()) { return true; } else { return false; }
    }
    public bool IsOdd() { 
        if (this.value % 2 != 0) { return true; } else { return false; } 
    }
    public bool IsEven()
    {
        if (!IsOdd()) { return true; } else { return false; }
    }
 
    public bool IsPrime()
    {
        if (this.value <= 1) return false;
        if (this.value == 2) return true;
        if (this.value % 2 == 0) return false;

        var boundary = (int)System.Math.Floor(System.Math.Sqrt(this.value));

        for (int i = 3; i <= boundary; i += 2)
            if (this.value % i == 0)
                return false;

        return true;
    }
    //public static int Power(int baseNumber, int exponent, bool recursive = false);
     public int GetCountOfDigits()
    {
        return this.value.ToString().Length; 
    }
    public int GetSumOfDigits()
    {

        int n = this.value;
        int sum = 0;
        while (n != 0)
        {
            sum += n % 10;
            n /= 10;
        }
        return sum;
    }
    public int GetReverse()
    {
        int Reverse = 0;
        int Number = this.value;  

        while (Number > 0)
        {
            int remainder = Number % 10;
            Reverse = (Reverse * 10) + remainder;
            Number = Number / 10;
        }
        return Reverse;
    }

    public string ToWords()
    {
 

        // return numbers.ToArray(); 
        string result = this.value.ToString();
        var intList = result.Select(digit => int.Parse(digit.ToString()));
        string[] digitNames = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        string words = "";

        foreach (var item in intList)
        {
 
            words += digitNames[item]+" "; 

        }
        return words;
    }

    public bool IsArmstrong()
    {

        int n, r, sum = 0, temp;

        n = this.value;
        temp = n;
        while (n > 0)
        {
            r = n % 10;
            sum = sum + (r * r * r);
            n = n / 10;
        }
        if (temp == sum) { return true; } else { return false; }


    }

    public string GetFibonacci()
    {
        int n1 = 0, n2 = 1, n3, i, number;
       // Console.Write("Enter the number of elements: ");
        number = this.value;
        string fibonacci = "";

        // Console.Write(n1 + " " + n2 + " "); //printing 0 and 1    
        for (i = 2; i < number; ++i) //loop starts from 2 because 0 and 1 are already printed    
        {
            n3 = n1 + n2;
            fibonacci += n3 + " ";
            //Console.Write(n3 + " ");

            n1 = n2;
            n2 = n3;
        }
        return fibonacci;
    }
    public bool isPalindrome()
    {
        int n, r, sum = 0, temp;
        n =  this.value;
        temp = n;
        while (n > 0)
        {
            r = n % 10;
            sum = (sum * 10) + r;
            n = n / 10;
        }
        if (temp == sum)
            return true;
        else
        {
            return false;
        }
    }

    static void Main()
    {
        Number number = new Number();
        number.SetValue(371); //you can set any integer value
        System.Console.WriteLine("Value: " + number.GetValue()); //Output: 371
        System.Console.WriteLine("IsZero: " + number.IsZero()); //Output: False
        System.Console.WriteLine("IsPositive: " + number.IsPositive()); //Output: True
        System.Console.WriteLine("IsNegative: " + number.IsNegative()); //Output: False
        System.Console.WriteLine("IsOdd: " + number.IsOdd()); //Output: True
        System.Console.WriteLine("IsEven: " + number.IsEven()); //Output: False
        System.Console.WriteLine("IsPrime: " + number.IsPrime()); //Output: False
        System.Console.WriteLine("GetCountOfDigits: " + number.GetCountOfDigits()); //Output: 3
        System.Console.WriteLine("GetSumOfDigits: " + number.GetSumOfDigits()); //Output: 11
        System.Console.WriteLine("GetReverse: " + number.GetReverse()); //Output: 173
        System.Console.WriteLine("ToWords: " + number.ToWords()); //Output: Three Seven One
        System.Console.WriteLine("IsArmstrong: " + number.IsArmstrong()); //Output: True
        System.Console.WriteLine("GetFibonacci: " + number.GetFibonacci()); //Output: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233
        System.Console.WriteLine("isPalindrome: " + number.isPalindrome()); //Output: False
        System.Console.ReadKey();
    }
}