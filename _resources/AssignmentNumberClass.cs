//A class that represents a numeric value as a field and provides several methods to manipulate that numeric value.
class Number
{
    //private field to store actual numeric value
    private int value;


    //Set method that receives a numeric value as argument and assigns the same into the 'value' field
    public void SetValue(int value)
    {
        this.value = value;
    }


    //Get method that returns the numeric value of the current instance (object)
    public double GetValue()
    {
        return value;
    }


    //A method that returns a boolean value that indicates whether the current numeric value is equal to zero or not
    public bool IsZero()
    {
        return value == 0;
    }


    //A method that returns a boolean value that indicates whether the current numeric value is a positive number or not
    public bool IsPositive()
    {
        return value > 0; //if the number is greater than zero (0), it is the negative number
    }


    //A method that returns a boolean value that indicates whether the current numeric value is a negative number or not
    public bool IsNegative()
    {
        return value < 0; //if the number is less than zero (0), it is the negative number
    }


    //A method that returns a boolean value that indicates whether the current numeric value is an odd number or not
    public bool IsOdd()
    {
        return value % 2 != 0; //if the number is divisible by 2, with zero (1) as remainder, it is the odd number
    }

    //A method that returns a boolean value that indicates whether the current numeric value is an even number or not
    public bool IsEven()
    {
        return value % 2 == 0; //if the number is divisible by 2, with zero (0) as remainder, it is the even number
    }


    //A method that returns a boolean value that indicates whether the current numeric value is a prime number or not. If the number is not divisible by any other number (except '1' and same number itself) with remainder zero (0), it is a prime number. Eg: 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97 etc., are the prime numbers. Because, for example, the number 7 is divisible by 1 and 7 only - but not by other numbers between, such as 2, 3, 4, 5, 6.
    public bool IsPrime()
    {
        if (IsNegative()) //if the current numeric value is a negative number, it is not a prime number
            return false;
        else
        {
            for (int i = 2; i < value / 2; i++) //loop between '2' and 'numeric value / 2' (half of the number)
            {
                if (value % i == 0) //if the numeric value is divisible by atleast any one number (except '1' and same number itself), it is NOT a prime number
                    return false;
            }
            return true; //hence, the number is NOT divisible by any other number, except '1' and the same number itself; so it's a prime number.
        }
    }


    //A mthod that returns power value of given baseNumber. "baseNumber power exponent". Eg: baseNumber is "2". exponent is "3". So the method should return the value of "2 power 3" (2 * 2 * 2) = 8.
    public static int Power(int baseNumber, int exponent, bool recursive = false)
    {
        if (!recursive) //if not recursive, perform a normal 'for' loop
        {
            int power = baseNumber;
            for (int i = 1; i < exponent; i++) //loop for 'exponent - 1' times
            {
                power *= baseNumber; //multiply the baseNumber itself
            }
            return power;
        }
        else //if recursive
        {
            if (exponent == 0) //if the exponent is reached down to zero (0), then the result is 1.
                return 1;
            else //if the exponent is greater than zero (0), then the result is 'baseNumber * power(basenumber, exponent - 1)'.
                return baseNumber * (Number.Power(baseNumber: baseNumber, exponent: exponent - 1, recursive: true));
        }
    }


    //A method that returns the count of digits in a number. Eg: If the number is "98765", it has "5" digits. So the method returns '5'.
    public int GetCountOfDigits()
    {
        int num = value; //copy the current numeric value into 'num', as we don't want to disturb the actual 'value' field.
        int count = 0;
        while (num > 0) //loop as long as the 'num' is a positive number
        {
            num = num / 10; //removes the last digit. Eg: suppose the num is '371'. Then '371 / 10' (integer division) will be "37". So it removes the last digit i.e "1".
            count++; //increase the count by '1', as we can removed one digit from the number
        }
        return count; //return the final count of digits
    }


    //A method that returns sum of all digits in a number. Eg: If the number is "1234", it should calculate "1+2+3+4". So it's "10".
    public int GetSumOfDigits()
    {
        int num = value; //copy the current numeric value into 'num', as we don't want to disturb the actul 'value field.
        int digit, sum = 0;
        while (num > 0) //loop as long as the 'num' is a positive number
        {
            digit = num % 10; //gets the last digit. Eg: suppose the num is '371'. Then '371 % 10' (remainder) will be "1". So it gets the last digit of the number i.e "1".
            num = num / 10; //removes the last digit. Eg: suppose the num is '371'. Then '371 / 10' (integer division) will be "37". So it removes the last digit i.e "1".
            sum += digit; //add the digit into 'sum'.
        }
        return sum; //returns the final value of 'sum'.
    }


    //A method that returns reverse of the number. Eg: If the number is "1234", its reverse is "4321".
    public int GetReverse()
    {
        int num = value; //copy the current numeric value into 'num', as we don't want to disturb the actul 'value field.
        int digit;
        string reverse = "";
        while (num > 0) //loop as long as the 'num' is a positive number
        {
            digit = num % 10; //gets the last digit. Eg: suppose the num is '371'. Then '371 % 10' (remainder) will be "1". So it gets the last digit of the number i.e "1".
            num = num / 10; //removes the last digit. Eg: suppose the num is '371'. Then '371 / 10' (integer division) will be "37". So it removes the last digit i.e "1".
            reverse += digit; //add the 'digit' into the string called "reverse".
        }
        return int.Parse(reverse); //convert the string 'reverse' into 'int' type.
    }


    //A method that returns all digits of the number, as words. Eg: If the number is "9840", then the same number in words is "Nine Eight Four Zero".
    public string ToWords()
    {
        int num = GetReverse(); //get reverse of the number
        int digit;
        string word, words = "";
        while (num > 0) //loop as long as the 'num' is a positive number
        {
            digit = num % 10; //gets the last digit. Eg: suppose the num is '173'. Then '173 % 10' (remainder) will be "3". So it gets the last digit of the number i.e "3".
            num = num / 10; //removes the last digit. Eg: suppose the num is '173'. Then '173 / 10' (integer division) will be "17". So it removes the last digit i.e "3".
            word = Number.GetWord(digit); //convert the digit into word, using the following GetWord() method
            words += word; //add the word into "words" string
        }
        return words; //return the last & final value of "words" string
    }


    //A method that returns the given number in words. Eg: if the argument value is "1", it returns "One"
    public static string GetWord(int digit)
    {
        switch(digit)
        {
            case 0: return "Zero ";
            case 1: return "One ";
            case 2: return "Two ";
            case 3: return "Three ";
            case 4: return "Four ";
            case 5: return "Five ";
            case 6: return "Six ";
            case 7: return "Seven ";
            case 8: return "Eight ";
            case 9: return "Nine ";
            default: return "";
        }
    }

    /*A method that returns a boolean value that indicates whether the current numeric value is an Armstrong number or not.
    Armstrong number is a number where the sum of its digits raised to the 'n' power is equal to the number itself, where the 'n' is the 'number of digits of the number'.
    Eg: number is '371'. number of digits is "3" because the number has 3 digits.
    371 == (3*3*3) + (7*7*7) + (1*1*1)
    371 == (27) + (343) + (1)
    371 == 371
    */
    public bool IsArmstrong()
    {
        int num = value; //copy the current numeric value into 'num', as we don't want to disturb the actul 'value field.
        int digit, sum = 0;
        int numberOfDigits = GetCountOfDigits(); //get number of digits of current numeric value, by calling GetCountOfDigits() method
        while (num > 0) //loop as long as the 'num' is a positive number
        {
            digit = num % 10; //gets the last digit. Eg: suppose the num is '371'. Then '371 % 10' (remainder) will be "1". So it gets the last digit of the number i.e "1".
            sum += Power(baseNumber: digit, exponent: numberOfDigits, recursive: true); //the power value of "digit power numberOfDigits". Eg: digit is "1" and numberOfDigits is "3". So get the value of "1 power 3" and add its result into 'sum'.
            num = num / 10; //removes the last digit. Eg: suppose the num is '371'. Then '371 / 10' (integer division) will be "37". So it removes the last digit i.e "1".
        }
        return value == sum; //return true, if the current numeric value is equal to the "sum of all digits (raised to the power of 'number of digits' as per above code)"
    }


    //A method that prints fibonacci series from "0" to "current numeric value" i.e "value" field.
    public string GetFibonacci()
    {
        //fibonacci series begins with default "0" and "1"
        int a = 0, b = 1;
        string fibonacci = a + ", " + b + ", ";
        int c = a + b;
        while (c <= value)
        {
            c = a + b;
            if (c > value) //stop if the next numer reaches out the "value" field
                break;

            //add the "c" value into the output string
            fibonacci += c + ", ";

            a = b; //the previous value in the series ("b") should be assigned to "a"
            b = c; //the latest value in the series ("c") should be assigned to "b"
        }
        return fibonacci;
    }

    //A method that returns true, if the number ('value' field) is a palindrome number
    public bool isPalindrome()
    {
        return value == GetReverse(); //if the reverse of a number is equal to the same number, it is a palindrome
    }
}


class AssignmentNumberClass
{
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

