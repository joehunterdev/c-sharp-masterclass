using System;
using System.Collections.Generic;
using JoeBank.BusinessLogicLayer.BALContracts;
using JoeBank.DataAccesLayer;
using JoeBank.DataAccesLayer.DALContracts;
using JoeBank.Entities;
using JoeBank.Exceptions;
namespace JoeBank.BusinessLogicLayer
{
    public class CustomersBusinessLogicLayer: ICustomersBusinessLogicLayer
    {

        //implement ICustomers
        #region Private Fields

        private ICustomersDataAccessLayer _customersDataAccessLayer; //using this we can  access all the data of the customers data access layer 

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that initializes CustomersDataAccessLayer
        /// </summary>
        public CustomersBusinessLogicLayer() {

            _customersDataAccessLayer = new CustomersDataAccessLayer();
        
        }
        #endregion

        #region Properties
        /// <summary>
        /// Private property that represents the reference of CustomersDataAccessLayer
        /// </summary>
        private ICustomersDataAccessLayer CustomersDataAccessLayer {

            set => _customersDataAccessLayer = value;
            get => _customersDataAccessLayer;

        }

        #endregion

        #region Methods
        // <summary>
        /// Returns all existing customers
        /// </summary>
        /// <returns>List of customers</returns>
        public List<Customer> GetCustomers() {

            try
            {   //dont access data directly invoke dal
               
              return  CustomersDataAccessLayer.GetCustomers(); // calling dal method from bll

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
        /// Returns a set of customers that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check</param>
        /// <returns>The list of matching customers</returns>
        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate) {

            //invoke dal
            try
            {
                return CustomersDataAccessLayer.GetCustomersByCondition(predicate);
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
        ///  Business logic Adds a new customer to the existing customers list
        /// </summary>
        /// <param name="customer">The customer object to add</param>
        /// <returns>Returns true, that indicates the customer is added successfully
        /// </returns>
        public Guid AddCustomer(Customer customer) {

            try
            {
                //We should check if customer name is generated or not

                //Get all customers
                List<Customer> allCustomers = CustomersDataAccessLayer.GetCustomers();

                CustomersDataAccessLayer.GetCustomers(); 

                long maxCustNo = 0;
     
                foreach (var item in allCustomers) { 

                    if(item.CustomerCode > maxCustNo){ // we need highest num

                        maxCustNo = item.CustomerCode;

                    }
                
                }
                //generate new customer no
                if (allCustomers.Count >= 1) // if one customer exists
                {

                    customer.CustomerCode = maxCustNo + 1;

                }
                else { // empty collection

                    customer.CustomerCode = Configuration.Settings.BaseCustomerNo + 1; //Generate new customer num

                }

                return CustomersDataAccessLayer.AddCustomer(customer); // returns guid

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
        /// Updates an existing customer
        /// </summary>
        /// <param name="customer">Customer object that contains customer details to update</param>
        /// <returns>Returns true, that indicates the customer is updated successfully</returns>
        public bool UpdateCustomer(Customer customer) {

            try
            {
                //invoke dal
                return CustomersDataAccessLayer.UpdateCustomer(customer);

            }
            catch (CustomerException) {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Deletes an existing customer
        /// </summary>
        /// <param name="customerID">CustomerID to delete</param>
        /// <returns>Returns true, that indicates the customer is deleted successfully</returns>
        public bool DeleteCustomer(Guid customerID) {

            try
            {
                //invoke dal
                return CustomersDataAccessLayer.DeleteCustomer(customerID);

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
        #endregion;
    }
}
