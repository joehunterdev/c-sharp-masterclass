/*
Create a C# program with a class called DebitCard with a property called "Pin" with validations in the set accessor.
The Pin should be exactly 4 digits or 6 digits.
If the supplied pin is invalid, it shows error message.

Examples:
Pin = "1234"     -->  valid
Pin = "1234ef"     -->  invalid
Pin = "123456"     -->  valid
Pin = "0"     -->  invalid
Pin = "a4"     -->  invalid
*/
class DebitCard
{
    //private field
    private string _pin;

    //PIN should be either 4 digit or 6 digit number
    public string PIN
    {
        set
        {
            if (value != null && value != "") //if the value is not null or not empty string
            {
                if (value.Length == 4 || value.Length == 6) //if the number of characters value is either 4 or 6
                {
                    bool isValid = true;
                    for (int i = 0; i < value.Length; i++) //loop through each character in the value
                    {
                        if (value[i] < 48 || value[i] > 57) //ASCII codes 48 to 57 are equal to digits (0 to 9)  Refer: https://www.asciitable.com/
                            isValid = false; //if the character is not a digit, make isValid as false
                    }
                    if (isValid)
                        _pin = value; //PIN is valid
                    else
                        System.Console.WriteLine("PIN contains one or more non-digit characters.");
                }
                else
                    System.Console.WriteLine("PIN should contain either 4 digits or 6 digits");
            }
            else
                System.Console.WriteLine("PIN value can't be blank");
        }
        get
        {
            return _pin;
        }
    }
}
class AssignmentPINValidation
{
    static void Main()
    {
        DebitCard debitCard = new DebitCard();
        debitCard.PIN = "12345D"; //Output: PIN contains one or more non-digit characters.
        System.Console.WriteLine(debitCard.PIN); //Output: null (shown as blank)
        System.Console.ReadKey();
    }
}

