using System;

namespace ClassLibrary1
{
    //delegate type
    public delegate void MyDelegateType(int a, int b);

    //publisher
    public class Publisher
    {
        //c# compiler automatically creates private delegate field

        //step 1: create event
        public event MyDelegateType myEvent;

        //c# compiler automatically create the code for add and remove accessors
        public void RaiseEvent(int a, int b)
        {
            //step 2: raise event
            if (this.myEvent != null) // then just call my event itself rather than the private delegate
            {
                this.myEvent(a, b);
            }
        }
    }
}
