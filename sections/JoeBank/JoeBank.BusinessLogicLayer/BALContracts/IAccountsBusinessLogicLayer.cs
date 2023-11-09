using System;
using System.Collections.Generic; //needed for List<T>
using JoeBank.Entities;

namespace JoeBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents accounts business logic
    /// </summary>
    public interface IAccountsBusinessLogicLayer
    {
        #region MethodsToImplement

        /// <summary>
        /// Return all Accounts as List<T> 
        /// </summary>
        /// <returns></returns>
        List<Account> GetAccounts();

        /// <summary>
        /// Finds account based on a condition Lamda
        /// </summary>
        /// <param name="predicate">Lamda expression that contains a condition to check</param>
        /// <returns></returns>
        List<Account> GetAccountsByCondition(Predicate<Account> predicate); // ? by Account Code condition as predicate lambda expression

        /// <summary>
        ///  Add a new account to list
        /// </summary>
        /// <param name="account">Account object with details to update</param>
        /// <returns>returns true</returns>
        Guid AddAccount(Account account);


        /// <summary>
        /// Updates custom values
        /// </summary>
        /// <param name="account">Account object with details to update</param>
        /// <returns>Returns true, indicates updated</returns>
        bool UpdateAccount(Account account);

        /// <summary>
        /// Deletes account based on guid
        /// </summary>
        /// <param name="accountID"></param>
        /// <returns>Returns true, that indicates cusomer deleted</returns>
        bool DeleteAccount(Guid accountID);

        /// <summary>
        /// Returns a single object of type account
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        Account GetAccountByCondition(Predicate<Account> predicate);

        /// <summary>
        /// Invoke Accounts dal from Transfer BLL
        /// </summary>
        /// <param name="account"></param>
        /// <param name="transfer"></param>
        /// <returns></returns>
        bool ProcessTransfer(Account account, Transfer transfer);

        /// <summary>
        /// Updates the balance of account
        /// </summary>
        /// <param name="account"></param>
        /// <param name="transfer"></param>
        /// <returns></returns>
        //public bool UpdateBalance(Account account, Transfer transfer);

        #endregion

    }

}
 