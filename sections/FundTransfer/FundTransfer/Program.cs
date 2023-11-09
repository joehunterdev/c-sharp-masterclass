using System;
using System.Collections.Generic;
using System.Linq;

namespace Transfers
{
    class Accounts { 


        private string _holder;
        private double _balance;
        List<Transfer> _transfers; //List of transfers

        public string Holder  
        {
            get { return _holder; }
            set { this._holder = value; }
        }


        public double Balance 
        {
            set { this._balance = value; }
            get {

                if (_transfers == null) {

                    return this._balance;

                } else
                {
                    
                    return Transfers.Sum(t => t.Amount) + this._balance;

                }

            }

        }


        public List<Transfer> Transfers 
        {
            get { return _transfers; }
            set { this._transfers = value; }
        }

    }

    class Transfer
    {
        //Like an entity
        private double _amount;
        private DateTime _date;


        public double Amount
        {
            get { return _amount; }
            set { this._amount = value; }

        }

        public DateTime Date
        {
            get { return DateTime.Now; }
            set { this._date = value; }

        }


    }


    class Program
    {
        //Create two classes and work with list object with one class that takes two properties and performs a calculation or running history (like static class)
        static void Main()
        {
            Transfer t1 = new Transfer() { Amount = 200 };
            Transfer t2 = new Transfer() { Amount = 340 };

            //Init from start
            //Accounts ac1 = new Accounts() { Holder = "Joe", Balance = 100.4, Transfers = new List<Transfer> { t1, t2 } };
           
            Accounts ac1 = new Accounts() { Holder = "Joe", Balance = 100.4};
            Console.WriteLine("Hi " + ac1.Holder + " your current balance is: " + ac1.Balance);

            ac1.Transfers = new List<Transfer> { t1, t2 };

            //Adding to collection
            ac1.Transfers.Add(new Transfer() { Amount = 540 });


            Console.WriteLine(String.Format("{0}Transfer statement{0}", new String('-', 10) ));


            foreach (Transfer transfer in ac1.Transfers)
            {
                Console.WriteLine("Transfer:" + transfer.Date.ToString("MM/dd/yyyy HH:mm") + " - "+ transfer.Amount);
            }

            Console.WriteLine("Balance: " + ac1.Balance.ToString());

        }
    }
}
