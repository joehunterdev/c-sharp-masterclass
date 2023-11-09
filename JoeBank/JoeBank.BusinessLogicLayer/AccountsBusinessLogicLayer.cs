using System;
using System.Collections.Generic;
using JoeBank.BusinessLogicLayer.BALContracts;
using JoeBank.DataAccesLayer;
using JoeBank.DataAccesLayer.DALContracts;
using JoeBank.Entities;
using JoeBank.Exceptions;

namespace JoeBank.BusinessLogicLayer
{
    public class AccountsBusinessLogicLayer: IAccountsBusinessLogicLayer
    {

        //implement IAccounts
        #region Private Fields

        private IAccountsDataAccessLayer _accountsDataAccessLayer; //using this we can  access all the data of the accounts data access layer 
       // private ICustomersDataAccessLayer _customersDataAccessLayer; //using this we can  access all the data of the customers data access layer 

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that initializes AccountsDataAccessLayer
        /// </summary>
        public AccountsBusinessLogicLayer() {

            _accountsDataAccessLayer = new AccountsDataAccessLayer();
        
        }


        #endregion

        #region Properties
        /// <summary>
        /// Private property that represents the reference of AccountsDataAccessLayer
        /// </summary>
        private IAccountsDataAccessLayer AccountsDataAccessLayer {

            set => _accountsDataAccessLayer = value;
            get => _accountsDataAccessLayer;

        }

        //private ICustomersDataAccessLayer CustomersDataAccessLayer
        //{

        //    set => _customersDataAccessLayer = value;
        //    get => _customersDataAccessLayer;

        //}

        #endregion

        #region Methods
        // <summary>
        /// Returns all existing accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        public List<Account> GetAccounts() {

            try
            {   //dont access data directly invoke dal
               
              return  AccountsDataAccessLayer.GetAccounts(); // calling dal method from bll

            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Returns a set of accounts that matches with specified criteria
        /// </summary>
        /// <param name="predicate">Lamdba expression that contains condition to check</param>
        /// <returns>The list of matching accounts</returns>
        public List<Account> GetAccountsByCondition(Predicate<Account> predicate) {

            //invoke dal
            try
            {
                return AccountsDataAccessLayer.GetAccountsByCondition(predicate);
            }
            catch (AccountException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        ///  Business logic Adds a new account to the existing accounts list
        /// </summary>
        /// <param name="account">The account object to add</param>
        /// <returns>Returns true, that indicates the account is added successfully
        /// </returns>
        public Guid AddAccount(Account account) {

            try
            {

                //Get all accounts
                List<Account> allAccounts   = AccountsDataAccessLayer.GetAccounts();
                // List<Customer> allCustomers = CustomersDataAccessLayer.GetAccounts();

                //We should check if account user name exists
                AccountsDataAccessLayer.GetAccounts();

                long maxCustNo = 0;

                foreach (var item in allAccounts)
                {

                    if (item.AccountNumber > maxCustNo)
                    { 
                        
                        // we need highest num
                        maxCustNo = item.AccountNumber;

                    }

                }
                //generate new account no
                if (allAccounts.Count >= 1) // if one account exists
                {

                    account.AccountNumber = maxCustNo + 1;

                }
                else
                {
                    account.AccountNumber = Configuration.Settings.BaseAccountNo + 1; //Generate new customer num

                }
                //account.AccountCode = Configuration.Settings.BaseAccountNo + 1; //Generate new account num

                return AccountsDataAccessLayer.AddAccount(account); // returns guid

            }
            catch (AccountException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }
             
        }

        /// <summary>
        /// Updates an existing account
        /// </summary>
        /// <param name="account">Account object that contains account details to update</param>
        /// <returns>Returns true, that indicates the account is updated successfully</returns>
        public bool UpdateAccount(Account account) {

            try
            {
                //invoke dal
                return AccountsDataAccessLayer.UpdateAccount(account);

            }
            catch (AccountException) {
                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Deletes an existing account
        /// </summary>
        /// <param name="accountID">AccountID to delete</param>
        /// <returns>Returns true, that indicates the account is deleted successfully</returns>
        public bool DeleteAccount(Guid accountID) {

            try
            {
                //invoke dal
                return AccountsDataAccessLayer.DeleteAccount(accountID);

            }
            catch (AccountException)
            {
                throw;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Account GetAccountByCondition(Predicate<Account> predicate)
        {

            //invoke dal
            try
            {
                return AccountsDataAccessLayer.GetAccountByCondition(predicate);
            }
            catch (AccountException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion;
        /// <summary>
        /// Calls Data access layer
        /// </summary>
        /// <param name="account"></param>
        /// <param name="transfer"></param>
        /// <returns></returns>
        public bool ProcessTransfer(Account account, Transfer transfer)
        {
            try
            {
                //Call additional functions to Accounts DAL 
                return AccountsDataAccessLayer.ProcessTransfer(account,transfer);

            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }



    }
}
