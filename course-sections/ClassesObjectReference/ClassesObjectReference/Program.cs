public class Sample
{
    //referenceVariables: (all local by default)
    Customer c1, c2;

    //Objects: Contain whatever properties we have defined in Customer
    new c1 = Customer(); //All these objects get stored in the heap only
    new c2 = Customer(); //2nd object
                         // Note these new objects are nameless. For this we need the reference variable
    static void Main()
    {



    }

}
~~~