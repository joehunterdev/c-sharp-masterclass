
//Step 1. Declare a delegate with the signature of the encapsulated method
public delegate void MyDelegate(string input);

//Step 2. Define methods that match with the signature of delegate declaration
class Class1 {
     
    public void delegateMethod1(string input)
    {

        Console.WriteLine("Hi im delegate method 1 with input "+ input);

    }

    public void delegateMethod2(string input)
    {

        Console.WriteLine("Hi im delegate method 2 with input " + input);

    }

}

//Step 3. Create delegate object and plug in the methods
class Class2
{

    public MyDelegate createDelegate()
    {
        Class1 c2 = new Class1();

        MyDelegate d1 = new MyDelegate(c2.delegateMethod1);
        MyDelegate d2 = new MyDelegate(c2.delegateMethod2);
        MyDelegate d3 = d1 + d2;
        return d3;
    }


}

//Step 4. Call the encapsulated methods through the delegate
class Class3
{
    public void callDelegate(MyDelegate d, string input)
    {
        d(input);
    }
}


class Driver
{


    static void Main()
    {


        Class2 c3 = new Class2();
        MyDelegate d = c3.createDelegate();
        Class3 c4 = new Class3();
        c4.callDelegate(d, " Calling the delegate");

    }

}