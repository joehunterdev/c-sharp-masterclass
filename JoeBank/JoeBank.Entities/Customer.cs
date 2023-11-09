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

    public class Customer : ICustomer , ICloneable
    {
        #region Private fields
        private Guid _customerID ;
        private long _customerCode ;
        private string _customerName ;
        private string _address ;
        private string _landmark ;
        private string _city ;
        private string _country ;
        private string _mobile ;
        #endregion

        #region Public Properties
        /// <summary>
        /// Unique Guid of customer 
        /// </summary>
        public Guid CustomerID { get => _customerID; set => _customerID = value; }//note use of expression syntax =>
        /// <summary>
        /// Auto generated code for custom sequential generated from 1000 != -1
        /// </summary>
        public long CustomerCode { 
            get => _customerCode;
            set {
                if (value > 0)
                {
                    _customerCode = value;
                }
                else {

                    throw new CustomerException("Customer code should only be positive");
                }
            }
        }
        /// <summary>
        /// Name of customer
        /// </summary>
        public string CustomerName { 
            
            get => _customerName;
            
            set {
                if (value.Length < 40 && string.IsNullOrEmpty(value) == false)
                {
                    _customerName = value;

                } else
                {
                    throw new CustomerException("Customer code should longer than 40 and not null");
                }
            }
        
        }

        //TODO: Validation and exceptions
        /// <summary>
        /// Address of customer
        /// </summary>
        public string Address { get => _address; set => _address = value; }
        /// <summary>
        /// Landmark of customers address
        /// </summary>
        public string Landmark { get => _landmark; set => _landmark = value; }
        /// <summary>
        /// City of customer
        /// </summary>
        public string City { get => _city; set => _city = value; }
        /// <summary>
        /// Country of customer
        /// </summary>
        public string Country { get => _country; set => _country = value; }
        /// <summary>
        /// 10 digit Mobile number of customer eg 646444999
        /// </summary>
        public string Mobile
        {
            get => _mobile;
            set
            {
                if (value.Length < 10  && value.Substring(0, 1) == "6")
                {
                    _mobile = value;
                }
                else
                {
                    throw new CustomerException("Mobile should longer than 10, starts with 6");
                }
            }
        }
        #endregion
        /// <summary>
        /// Creates a new object that is a copy of the current instance. 
        /// </summary>
        /// <returns>Object of customer class</returns>
        #region Methods
        public object Clone()
        {
            return new Customer() { CustomerID = this.CustomerID, CustomerName = this.CustomerName, CustomerCode = this.CustomerCode, City = this.City, Address = this.Address, Country = this.Country, Landmark = this.Landmark, Mobile = this.Mobile }; //coppy all values of current instance
        }
        #endregion

    }
}
