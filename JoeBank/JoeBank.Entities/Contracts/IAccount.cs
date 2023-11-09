using System;
using System.Collections.Generic;

namespace JoeBank.Entities.Contracts
{

    //Could use enum here to store account types

    /// <summary>
    /// model class of a account 1 object
    /// create a ref and account number of this
    /// customer can have one account
    /// wise to create interfaces to specify contract other teams can continue coding
    /// should be in subfolder /Contracts/
    /// </summary>
    public interface IAccount
    {

        #region Fields
        Guid AccountID { get; set; }
        long AccountNumber { get; set; }

        string AccountType { get; set; } //credit,debit,savings

        string AccountOwnerName { get; set; }
        int AccountPin { get; set; }
        double AccountBalance { get; set; }
        List<Transfer> Transfers { get; set; }

       // bool SubmitTransfer(Transfer Transfer);

        #endregion

    }
}
