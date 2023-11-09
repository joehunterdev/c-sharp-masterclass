namespace ClassLibrary1
{
    //Create a delegate type which we will then hook into our class below
    public delegate void MyDelegateType(int a, int b);

    //publisher class
    public class Publisher
    {
        private MyDelegateType? myDelegate; //events are created based on these delegates
       
        //step 1. create event
        public event MyDelegateType myEvent // similar to creating property except working with a queue
        {
            add
            {
                myDelegate += value;
            }
            remove {

                myDelegate -= value; //works whenever subscriber class cancels subscription we use -=
            }
        }

        //in order to raise the event lets create a new method
        public void RaiseEvent(int a, int b)
        {
            // step 2. raise event/delgate
            if(this.myDelegate != null)
            {
                this.myDelegate(a, b);

            }
        }
    }
}