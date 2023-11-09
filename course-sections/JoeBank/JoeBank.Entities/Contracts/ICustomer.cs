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
    public interface ICustomer
    {

        #region Fields
        Guid CustomerID { get; set; }
        long CustomerCode { get; set; } // these props must be implemented in corresponding class
        string CustomerName { get; set; }
        string Address { get; set; }
        string Landmark { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Mobile { get; set; }
        #endregion

    }
}
