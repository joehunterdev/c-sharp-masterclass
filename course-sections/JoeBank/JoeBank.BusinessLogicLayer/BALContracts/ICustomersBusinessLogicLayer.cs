using JoeBank.Entities;
using System;
using System.Collections.Generic; //needed for List<T>

namespace JoeBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents customers business logic
    /// </summary>
    public interface ICustomersBusinessLogicLayer
    {
        #region MethodsToImplement

        /// <summary>
        /// Return all Customers as List<T> 
        /// </summary>
        /// <returns></returns>
        List<Customer> GetCustomers();

        /// <summary>
        /// Finds customer based on a condition Lamda
        /// </summary>
        /// <param name="predicate">Lamda expression that contains a condition to check</param>
        /// <returns></returns>
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate); //condition as predicate lambda expression

        /// <summary>
        ///  Add a new customer to list
        /// </summary>
        /// <param name="customer">Customer object with details to update</param>
        /// <returns>returns true</returns>
        Guid AddCustomer(Customer customer);

        /// <summary>
        /// Updates custom values
        /// </summary>
        /// <param name="customer">Customer object with details to update</param>
        /// <returns>Returns true, indicates updated</returns>
        bool UpdateCustomer(Customer customer);

        /// <summary>
        /// Deletes customer based on guid
        /// </summary>
        /// <param name="customerID"></param>
        /// <returns>Returns true, that indicates cusomer deleted</returns>
        bool DeleteCustomer(Guid customerID);


        #endregion
    }

}
