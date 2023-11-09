using System;

namespace CovarianceContravariance
{
    class Program
    {
        static string GetString() { return "Test me out delegate covariance baby"; } //Im some string returnef from Func<object> 

        static void Main(string[] args)
        {
            //provides implicit reference conversion for Arrays, Delegates and Generic parameter types. 
            //Assignment Compatibility
            String myStringObject = "An Object of a derived class (stringObject) is being assigned to a variable of a base class (anObject)";
            object myObject = myStringObject;
            Console.WriteLine(myObject.GetType() + " = " + myObject);

            //Array Covariance
            object[] objArray = new String[10];
            // objArray[0] = 5; //not safe

            //Delegate Covariance

            Func<object> myStringObject2 = GetString;
           // String myStringObject2 = delegateObject();

            Console.WriteLine(myStringObject2.GetType() + " = " + myStringObject2);

        }
    }
}
