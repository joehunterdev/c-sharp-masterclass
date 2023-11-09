using System;
using System.Collections.Generic; 
using JoeBank.Entities; //Contains customer
using JoeBank.Exceptions;
using JoeBank.DataAccesLayer.DALContracts; // for extending interface ICustomersDataAccessLayer CRUD

namespace JoeBank.DataAccesLayer
{
    /// <summary>
    /// Represnts DAL for bank Customers
    /// </summary>
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region Private Fields
        private static List<Customer> _customers; //static even tho we will init once the same can be accessed everytime
        #endregion

        #region Constructors
        /// <summary>
        /// init _customers static
        /// </summary>
        static CustomersDataAccessLayer() //static even tho we will init once the same can be accessed everytime
        {
            _customers = new List<Customer>();
        }
        #endregion

        #region Private Properties

        /// <summary>
        /// Create private property Customers
        /// </summary>
        private List<Customer> Customers 
        {
            set => _customers = value;
            get => _customers;
        }


        #endregion

        #region
        //implement methods from interface as List !! heres how its done

        /// <summary>
        /// modify the values in dal clone in (customer) of the actual collection
        /// </summary>
        /// <returns>Customers</returns>
        public List<Customer> GetCustomers()  
        {

            try {
                //create new collection of customers 
                List<Customer> customersList = new List<Customer>();
                Customers.ForEach(item => customersList.Add(item.Clone() as Customer)); //lambda once for each item in collection Clone returns object so we need to typecast "as Customer" (List<T>) 
                return customersList;

            }
            catch (CustomerException) { //get the exception could be important worth separating

                throw;
            }

            catch (Exception) {

                throw;

            }

        }
        /// <summary>
        /// Returns list of customers that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression with condition</param>
        /// <returns>List of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                //create a new customers list
                List<Customer> customersList = new List<Customer>();

                //filter the collection
                List<Customer> filteredCustomers = Customers.FindAll(predicate); //filter from global list

                //copy all customers from the soruce collection into the newCustomers list
                filteredCustomers.ForEach(item => customersList.Add(item.Clone() as Customer));
                return customersList;
            }
            catch (CustomerException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Return 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>type is guid</returns>
        public Guid AddCustomer(Customer customer) {

            try
            {
                customer.CustomerID = Guid.NewGuid(); // Internal method to create ids
                Customers.Add(customer); // hook into proptery init
                return customer.CustomerID;
            }
            catch (Exception)
            {

                throw;
            }

             
        }

        /// <summary>
        /// Return 
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>tpye is guid</returns>
        public bool UpdateCustomer(Customer customer)
        {

            try
            {
                // Find all with filter.
                // List<Customer> customersList = new List<Customer>();

                Customer existingCustomer = Customers.Find(item => item.CustomerID == customer.CustomerID);

                //check if customer exists first 

                if (existingCustomer != null)
                {

                    existingCustomer.CustomerCode = customer.CustomerCode;   //customer is param 
                    existingCustomer.CustomerName = customer.CustomerName;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true; //could return existingCustomer.CustomerID;

                }
                else
                {
                    return false; 
                }
            }
            catch (CustomerException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }


        }
        /// <summary>
        /// Delets customer using remove all
        /// </summary>
        /// <param name="customer">Customer Object</param>
        /// <returns>True</returns>
        public bool DeleteCustomer(Guid customerID)
        {
            try
            {
                //Customers.Remove(customer);
                //takes lambda
                if (Customers.RemoveAll(item => item.CustomerID == customerID) > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        // Explicit predicate delegate.
        //private static bool FindByCustomerName(Customer c, string val)
        //{

        //    if (c.CustomerName != val)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
 
        #endregion
        // Explicit predicate delegate.
        //private static bool FindKeyVal(Customer c, object key, string val)
        //{

        //    if (c.{ key} != val)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

    }
}
