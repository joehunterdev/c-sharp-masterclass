using System;
using System.Collections.Generic;
using JoeBank.Entities;
using JoeBank.Exceptions;
using JoeBank.BusinessLogicLayer;
using JoeBank.BusinessLogicLayer.BALContracts;
namespace JoeBank.Presentation
{
    static class AccountsPresentation // make static to be easier to use in switch
    {
        //create an object of account
        internal static void AddAccount()
        {

            try
            {
                Account account = new Account();

                //read all details from the user
                Console.WriteLine("\n********ADD ACCOUNT*************");
                Console.Write("Account Holder Name:"); //should do a check here against existing names
                account.AccountOwnerName = Console.ReadLine();
                Console.Write("Account Pin Number:");
                account.AccountPin = Convert.ToInt32(Console.ReadLine());
                Console.Write("Account type: credit, debit, savings ? ");
                account.AccountType = Console.ReadLine();

                //Create BL Object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();
                Guid newGuid = accountsBusinessLogicLayer.AddAccount(account); //returns new guid

                List<Account> matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountID == newGuid);

    

                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("Account Added.\n");
                    Console.WriteLine("New Account Number created: " + matchingAccounts[0].AccountNumber);
                }
                else
                {
                    Console.WriteLine("Account Not added");
                }
                //Console.WriteLine("Account Added with Id: " + accountCode); // will return back to the top

            }
            catch (Exception ex) //have to speciy type of exception
            {
                Console.WriteLine(ex.Message); //caught in bll
                Console.WriteLine(ex.GetType());

             }
   
            //exceptions need to be caugh

        }

        internal static void ViewAccounts()
        {
            try
            {
                // Create BL Object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

                //List of type accounts assign to allAccounts is equal to the Bl Object we created above access method
                List<Account> allAccounts = accountsBusinessLogicLayer.GetAccounts();

                Console.WriteLine("\n**********ALL ACCOUNTS*************");

                foreach (var item in allAccounts)
                {

                    Console.WriteLine("Account Number: " + item.AccountNumber);
                    Console.WriteLine("Account Holder Name: " + item.AccountOwnerName);
                    Console.WriteLine("Account Type: " + item.AccountType);
                    Console.WriteLine("Account Balance: " + item.AccountBalance);

                    if (item.Transfers != null)
                    {
                        Console.WriteLine("Total Transfers: " + item.Transfers.Count);

                        foreach (var item2 in item.Transfers)
                        {
                            Console.WriteLine("Transfer: Amount " + item2.TransferAmount + " Date:" + item2.TransferDate);

                        }
                    }


                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                throw;
            }

            //read all accounts in loop and print the output

        }

        internal static void EditAccount()
        {
            try
            {

                Console.WriteLine("\n**********UPDATE ACCOUNT*************");

                // Create BL Object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

                Console.WriteLine("\n**********Enter a account number*************");

                long accountCode = Convert.ToInt32(Console.ReadLine());

                List<Account> matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == accountCode);
 

                ////Find account 
                if (matchingAccounts.Count >= 1)
                {
                    Console.WriteLine("Account : " + matchingAccounts[0].AccountNumber + " found");
                    Console.WriteLine("Update Details: ");
                    Console.Write("Account Owner Name: ");
                    matchingAccounts[0].AccountOwnerName = Console.ReadLine();
                    Console.Write("Account Type: ");
                    matchingAccounts[0].AccountType = Console.ReadLine();
  
                    if (accountsBusinessLogicLayer.UpdateAccount(matchingAccounts[0])) {

                        Console.WriteLine("Account Updated Successfully");

                    }  


                }
                else {

                    Console.WriteLine("No Account found");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                throw;
            }

        }

        internal static void DeleteAccount()
        {
            try
            {

                Console.WriteLine("\n**********DELETE ACCOUNT AREA*************");


                // Create BL Object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

                Console.WriteLine("\n**********Enter a account code*************");

                long accountCode = Convert.ToInt32(Console.ReadLine());

                List<Account> matchingAccounts = accountsBusinessLogicLayer.GetAccountsByCondition(item => item.AccountNumber == accountCode);


                ////Find account 
                if (matchingAccounts.Count >= 1 && accountsBusinessLogicLayer.DeleteAccount(matchingAccounts[0].AccountID))
                {
                    
                   Console.WriteLine("Account Deleted Successfully");

                }
                else
                {

                    Console.WriteLine("No Account found");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                throw;
            }

        }

        internal static void ViewStatement()
        {
            try
            {

                Console.WriteLine("\n**********ACCOUNT STATEMENT*************");

                // Create BL Object
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();

                Console.WriteLine("\n**********Enter a account number*************");

                long accNumber = Convert.ToInt32(Console.ReadLine());

                var matchingAccount = accountsBusinessLogicLayer.GetAccountByCondition(item => item.AccountNumber == accNumber);


                // Account found 
                if (matchingAccount!= null)
                {
    
                    Console.WriteLine("Account Number: " + matchingAccount.AccountNumber);
                    Console.WriteLine("Account Holder Name: " + matchingAccount.AccountOwnerName);
                    Console.WriteLine("Account Type: " + matchingAccount.AccountType);
                    Console.WriteLine("Account Balance: " + matchingAccount.AccountBalance);

                    if (matchingAccount.Transfers != null)
                    {
                        Console.WriteLine("Total Transfers: " + matchingAccount.Transfers.Count);

                        foreach (var item in matchingAccount.Transfers)
                        {
                           // Console.WriteLine("Transfer: Amount " + item.TransferAmount + " Date:" + item.TransferDate);
                            Console.WriteLine($"Date: {item.TransferDate} - Amount: {item.TransferAmount} - From: {item.FromAccountNumber} - To: {item.ToAccountNumber}");


                        }
                    } else
                    {

                        Console.WriteLine("No Transfers found");
                    }



                }
                else
                {

                    Console.WriteLine("No Account found");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                throw;
            }

        }


    }
}
