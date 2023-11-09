using System;
using System.Collections.Generic;
using JoeBank.Entities;
using JoeBank.Exceptions;
using System.Linq;
using JoeBank.BusinessLogicLayer;
using JoeBank.BusinessLogicLayer.BALContracts;
namespace JoeBank.Presentation
{
    static class TransfersPresentation // make static to be easier to use in switch
    {
      
        internal static void AddTransfer()
        {

            try
            {
                //Create BL Object
                ITransfersBusinessLogicLayer transfersBusinessLogicLayer = new TransfersBusinessLogicLayer();
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer   = new AccountsBusinessLogicLayer();

                Transfer transfer = new Transfer();

                //read all details from the user
                Console.WriteLine("\n********ADD TRANSFER*************");

                //TODO: Return To/From Accounts as object 
                Console.Write("From Acc No: ");
                long fromAccNum = long.Parse(Console.ReadLine());

                //Check to see if account exists
                Account fromAcc = accountsBusinessLogicLayer.GetAccountByCondition(a => a.AccountNumber == fromAccNum);

                if (fromAcc != null)
                {
                    transfer.FromAccount = fromAcc;

                    Console.WriteLine("Account Holder found: " + fromAcc.AccountOwnerName);

                    Console.WriteLine("Which account number do you wish to transfer to ?: " );

                    long toAccNum = long.Parse(Console.ReadLine());

                    Account toAcc = accountsBusinessLogicLayer.GetAccountByCondition(a => a.AccountNumber == toAccNum);

                    if (toAcc != null)
                    {
                        transfer.ToAccount = toAcc;
                        transfer.FromAccountNumber = fromAccNum;
                        transfer.ToAccountNumber = toAccNum;

                        Console.WriteLine("To account found: " + toAcc.AccountOwnerName);

                        Console.WriteLine("How much do you want to transfer ? :");

                         transfer.TransferAmount = double.Parse(Console.ReadLine());

                        var processed = transfersBusinessLogicLayer.ProcessTransfer(transfer);

                        if (processed)
                        {

                            Console.WriteLine("Transfer Processed Sucessfully");

                        } else
                        {
                            Console.WriteLine("We couldnt process that transfer");

                        }


                    } else
                    {
                        Console.WriteLine("No To Account found with that Account Number");
                    }


                } else
                {
                  
                     Console.WriteLine("No From Account found with that Account Number");

                }


            }
            catch (Exception ex)  
            {

                Console.WriteLine(ex.Message); //caught in bll
                Console.WriteLine(ex.GetType());

                throw;
            }
             

        }

        internal static void ViewTransfers()
        {
            Console.WriteLine("\n********VIEW TRANSFERS*************");

            //Get date from user start/end
            //Init transfer bll
            //Call GetTransfers by condition (predicate should handle to and from range)
            //Output all transfers

            Console.WriteLine("Enter Start Date (dd/MM/yyyy):");

            string startDate = Console.ReadLine();
            DateTime validStartDate;
            while (!DateTime.TryParseExact(startDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out validStartDate))
            {
                Console.WriteLine("Invalid start date, please retry");
                startDate = Console.ReadLine();
            }

            Console.WriteLine("Enter End Date (dd/MM/yyyy):");

            string endDate = Console.ReadLine();

            DateTime validEndDate;
            while (!DateTime.TryParseExact(endDate, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out validEndDate))
            {
                Console.WriteLine("Invalid end date, please retry");
                endDate = Console.ReadLine();
            }

            try
            {
                ITransfersBusinessLogicLayer transfersBusinessLogicLayer = new TransfersBusinessLogicLayer();
                 List<Transfer> matchingTransfers = transfersBusinessLogicLayer.GetTransfersByCondition(t => t.TransferDate >= validStartDate && t.TransferDate <= validEndDate); //      Where(c => start <= c.end && end >= c.start) i.StartDate <= date && i.EndDate >= date

                if (matchingTransfers != null)
                {
                    int count = matchingTransfers.Count();

                    Console.WriteLine($"Found {count} matching transfers from: {validStartDate} to {validEndDate} ");

                    foreach (var item in matchingTransfers)
                    {
                        //TODO: Fix date format coming out. Figure out why FromAccount and To account not coming out 
                        Console.WriteLine($"Date: {item.TransferDate} - Amount: {item.TransferAmount} - From: {item.FromAccountNumber} - To: {item.ToAccountNumber}");
                        Console.WriteLine("Acc" + item.FromAccount);
                        Console.WriteLine(string.Join(", ", item));

                    }

                } else
                {

                    Console.WriteLine($"No matching transfers from: {validStartDate} to {validEndDate} ");

                }
            }


            catch (Exception ex) //have to speciy type of exception
            {
                Console.WriteLine(ex.Message); //caught in bll
                Console.WriteLine(ex.GetType());
                throw;
            }
        }


    }
}
