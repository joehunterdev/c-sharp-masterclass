using System;
using JoeBank.Entities.Contracts;
using JoeBank.Exceptions;

namespace JoeBank.Entities
{
    /// <summary>
    /// Represents custom of a the bank
    /// public and implements ICustomer, ICloneable ()
    /// Errors should be caught here 
    /// </summary>

    public class Transfer : ITransfer, ICloneable
    {
        #region Private fields
        private Guid _transferID;
        private double _transferAmount;
        private DateTime _transferDate;
        private Account _fromAccount;
        private Account _toAccount;
        private long _fromAccountNumber;
        private long _toAccountNumber;

        #endregion

        #region Constructor

        #endregion

        #region Public Properties

        public Guid TransferID { get => _transferID; set => _transferID = value; }//note use of expression syntax =>


        /// <summary>
        /// Unique Guid of customer 
        /// </summary>
        /// 
        public double TransferAmount
        {
            get => _transferAmount; set => _transferAmount = value;
        }

        //public DateTime TransferDate
        //{
        //    get { return DateTime.Now; }
        //    set { this._transferDate = value; }
        //}


        public DateTime TransferDate { get => _transferDate; set => _transferDate = value; }
        public Account FromAccount { get => _fromAccount; set => _fromAccount = value; }

        public Account ToAccount { get => _toAccount; set => _toAccount = value; }

        public long FromAccountNumber { get => _fromAccountNumber; set => _fromAccountNumber = value; }

        public long ToAccountNumber { get => _toAccountNumber; set => _toAccountNumber = value; }

        #endregion
        /// <summary>
        /// Creates a new object that is a copy of the current instance. 
        /// </summary>
        /// <returns>Object of customer class</returns>
        #region Methods
        public object Clone()
        {
            return new Transfer() { FromAccount = this.FromAccount,  ToAccount = this.ToAccount, ToAccountNumber = this.ToAccountNumber, FromAccountNumber = this.FromAccountNumber, TransferAmount = this.TransferAmount }; //copy all values of current instance
        }
        //TODO: Swap type
        #endregion

    }
}
