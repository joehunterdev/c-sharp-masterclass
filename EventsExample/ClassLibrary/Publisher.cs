using System;

namespace ClassLibrary
{
    //delegate type
    public delegate void MyDelegateType(int a, int b); // this represents the parameters and delegate type of event

    //publisher
    public class Publisher
    {
        //private delegate
        private MyDelegateType? myDelegate; //this will store one or more methods

        //step 1: create event
        public event MyDelegateType myEvent //allowing external to subscribe to event
        {
            add
            {
                myDelegate += value; //reference will be added to reference mydelgate above
            }
            remove
            {
                myDelegate -= value;
            }
        }

        public void RaiseEvent(int a, int b) //raise event in same class only
        {
            //step 2: raise event
            if (this.myDelegate != null) //if nobody has subscribed to the event its default is null
            {
                this.myDelegate(a, b); // 2 parameters in delegate type
            }
        }
    }
}
