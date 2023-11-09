using System;

namespace JoeBank.Entities.Contracts
{
    /// <summary>
    /// modify name space adding .Contracts
    /// model class of a customer 1 object
    /// create a ref and account number of this
    /// customer can have multiple accounts
    /// wise to create interfaces to specify contract other teams can continue coding
    /// should be in subfolder /Contracts/
    /// auto-implement
    /// Global unique identifier good for id of any entity (rand x 10) is a struc you can create this via tools
    /// </summary>
    public interface ITransfer
    {

        #region Fields
        Guid TransferID { get; set; }


        double TransferAmount { get; set; } 
        DateTime TransferDate { get; set; }

        Account FromAccount { get; set; }

        Account ToAccount { get; set; }

        long FromAccountNumber { get; set; }

        long ToAccountNumber { get; set; }

        #endregion

    }
}
