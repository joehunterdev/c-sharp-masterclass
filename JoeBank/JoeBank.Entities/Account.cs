using System;
using System.Linq;
using JoeBank.Entities.Contracts;
using JoeBank.Exceptions;
using System.Collections.Generic;

namespace JoeBank.Entities
{

    /// <summary>
    /// Represents custom of a the bank
    /// public and implements ICustomer, ICloneable ()
    /// Errors should be caught here 
    /// </summary>
    public class Account : IAccount , ICloneable
    {

        string[] accountTypes = { "credit","debit","savings" }; //TODO: As enum specified in IAccount

        //public enum AccountTypes {credit,debit,savings };

        #region Private fields
        private Guid _accountID ;
        private long _accountNumber;
        private string  _accountType;
        private string _accountOwnerName ;
        private int _accountPin;
        private double _accountBalance;

        private List<Transfer> _transfers;


        #endregion

        #region Public Properties
        /// <summary>
        /// Unique Guid of account 
        /// </summary>
        public Guid AccountID { get => _accountID; set => _accountID = value; }//note use of expression syntax =>


        public long AccountNumber
        {
            get => _accountNumber;
            set
            {
                _accountNumber = value;
             }
        }

        /// <summary>
        /// This is the account holders name
        /// </summary>
        public string AccountOwnerName { get => _accountOwnerName; set => _accountOwnerName = value; }//note use of expression syntax =>


        /// <summary>
        /// This the type of account
        /// </summary>
        //public string AccountType { get => _accountType; set => _accountType = value; }//note use of expression syntax =>
        public string AccountType
        {
            get => _accountType;
            set
            {

                if (accountTypes.Contains(value)){
                    _accountType = value;
                }
                else
                {

                    throw new AccountException("Account Type should be one of the following: "+ string.Join(",", accountTypes.ToArray()));
                }

            }
        }


        public int AccountPin
        {
            get => _accountPin;
            set
            {
                if (value.ToString().Length >= 4 && value.ToString().Length <= 6) //value == (int)value && 
                {
                    _accountPin = value;
                }
                else
                {
                    throw new AccountException("Pin should be a number between 4 and 6 in lenght");
                }
            }
        }

        public double AccountBalance
        {
            get => _accountBalance;
            set
            {
                _accountBalance = value;
            }
        }

        //JoeBank.Entities.Account.Transfers.get returned null.

        /// <summary>
        /// List of transfer objects
        /// </summary>
        public List<Transfer> Transfers { get => _transfers; set => _transfers = value; }

        //public bool SubmitTransfer(Transfer transfer)
        //{
        //    try
        //    {
        //       // this._transfers.Add(transfer);

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //}

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new object that is a copy of the current instance. 
        /// </summary>
        /// <returns>Object of customer class</returns>
        public object Clone()
        {
            return new Account() { AccountID = this.AccountID, AccountNumber = this.AccountNumber, AccountType = this.AccountType, AccountOwnerName = this.AccountOwnerName, AccountBalance = this.AccountBalance, Transfers = this.Transfers }; //coppy all values of current instance
        }
        #endregion

    }
}
