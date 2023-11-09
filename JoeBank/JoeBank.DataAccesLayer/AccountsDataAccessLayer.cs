using System;
using System.Collections.Generic; 
using JoeBank.Entities; //Contains account
using JoeBank.Exceptions;
using JoeBank.DataAccesLayer.DALContracts; // for extending interface IAccountsDataAccessLayer CRUD

namespace JoeBank.DataAccesLayer
{
    /// <summary>
    /// Represnts DAL for bank Accounts
    /// </summary>
    public class AccountsDataAccessLayer : IAccountsDataAccessLayer
    {
        #region Private Fields
        private static List<Account> _Accounts; //static even tho we will init once the same can be accessed everytime
        #endregion

        #region Constructors
        /// <summary>
        /// init _Accounts static
        /// </summary>
        static AccountsDataAccessLayer() //static even tho we will init once the same can be accessed everytime
        {
            _Accounts = new List<Account>();
        }
        #endregion

        #region Private Properties

        /// <summary>
        /// Create private property Accounts
        /// </summary>
        private List<Account> Accounts 
        {
            set => _Accounts = value;
            get => _Accounts;
        }


        #endregion

        #region Public Methods
        //implement methods from interface as List !! heres how its done

        /// <summary>
        /// modify the values in dal clone in (account) of the actual collection
        /// </summary>
        /// <returns>Accounts</returns>
        /// 
        public List<Account> GetAccounts() {

            try {
                //create new collection of Accounts 
                List<Account> AccountsList = new List<Account>();
                Accounts.ForEach(item => AccountsList.Add(item.Clone() as Account)); //lambda once for each item in collection Clone returns object so we need to typecast "as Account" (List<T>) 
                return AccountsList;

            }
            catch (AccountException) { //get the exception could be important worth separating

                throw;
            }

            catch (Exception) {

                throw;

            }

        }

        /// <summary>
        /// Returns list of Accounts that are matching with specified criteria
        /// </summary>
        /// <param name="predicate">Lambda expression with condition</param>
        /// <returns>List of matching Accounts</returns>
        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                //create a new Accounts list
                List<Account> AccountsList = new List<Account>();

                //filter the collection
                List<Account> filteredAccounts = Accounts.FindAll(predicate); //filter from global list

                //copy all Accounts from the soruce collection into the newAccounts list
                filteredAccounts.ForEach(item => AccountsList.Add(item.Clone() as Account));
                return AccountsList;
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
        /// Return 
        /// </summary>
        /// <param name="account"></param>
        /// <returns>type is guid</returns>
        public Guid AddAccount(Account account) {

            try
            {
                account.AccountID = Guid.NewGuid(); // Internal method to create ids
                Accounts.Add(account); // hook into proptery init
                return account.AccountID;
            }
            catch (Exception)
            {

                throw;
            }

             
        }

        /// <summary>
        /// Return 
        /// </summary>
        /// <param name="account"></param>
        /// <returns>tpye is guid</returns>
        public bool UpdateAccount(Account account)
        {

            try
            {

                Account existingAccount = Accounts.Find(item => item.AccountID == account.AccountID);

                //check if account exists first 
                if (existingAccount != null)
                {

                    existingAccount.AccountID = account.AccountID;   //account is param 
                    existingAccount.AccountOwnerName = account.AccountOwnerName;

                    return true; //could return existingAccount.AccountID;

                }
                else
                {
                    return false; 
                }
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
        /// Delets account using remove all
        /// </summary>
        /// <param name="account">Account Object</param>
        /// <returns>True</returns>
        public bool DeleteAccount(Guid accountID)
        {
            try
            {
                //Accounts.Remove(account);
                //takes lambda
                if (Accounts.RemoveAll(item => item.AccountID == accountID) > 0)
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

        public bool ProcessTransfer(Account account, Transfer transfer)
        {
            try
            {
                //find existing account record with the same AccountID
                var toAccount = Accounts.Find(item => item.AccountNumber == account.AccountNumber);

                //TODO: ValidateTransfer() ( Check account type,  credit can go into negative, debit & savings cannot)

                //add the transaction to the list of transactions associated with the account
                if (toAccount != null)
                {
                    //Update the balance
                    toAccount.AccountBalance += transfer.TransferAmount;

                    //create a new Accounts list
                    List<Transfer> tlist = toAccount.Transfers;

                    if(tlist != null)
                    {
                        tlist.Add(transfer); //tlist was null

                    } else
                    {
                        //tlist = new List<Transfer> { transfer };
                        List<Transfer> tlist2 = new List<Transfer> { transfer };
                        toAccount.Transfers = tlist2;

                    }
  
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (AccountException) { throw; }
            catch (Exception) { throw; }
        }

        //public bool UpdateBalance(Account account, Transfer transfer)
        //{

        //    var toAccount = Accounts.Find(item => item.AccountNumber == account.AccountNumber);

        //    try
        //    {
        //        account.AccountBalance += transfer.TransferAmount;
        //        Console.WriteLine("Balance Updated :"+ account.AccountBalance);

        //        return true;
        //    }
        //    catch (AccountException) { throw; }
        //    catch (Exception) { throw; }

        //}

        public Account GetAccountByCondition(Predicate<Account> predicate)
        {
            try
            {
                var account = _Accounts.Find(predicate);
                return account.Clone() as Account;
            
            } catch(NullReferenceException){

                throw;

            }
            catch (AccountException)
            {
                throw;
            }
        }

        #endregion

    }
}
