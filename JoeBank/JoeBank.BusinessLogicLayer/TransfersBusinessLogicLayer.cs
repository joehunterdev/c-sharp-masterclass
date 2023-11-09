using System;
using System.Collections.Generic;
using JoeBank.BusinessLogicLayer.BALContracts;
using JoeBank.DataAccesLayer;
using JoeBank.DataAccesLayer.DALContracts;
using JoeBank.Entities;
using JoeBank.Exceptions;
namespace JoeBank.BusinessLogicLayer
{
    public class TransfersBusinessLogicLayer: ITransfersBusinessLogicLayer
    {

        //implement IFunds
        //using this we can  access all the data of the funds data access layer 
        private ITransfersDataAccessLayer _transfersDataAccessLayer;
    //    private _accountsDataAccessLayer;

        /// <summary>
        /// Constructor that initializes FundTransferDataAccessLayer
        /// </summary>
        public TransfersBusinessLogicLayer()
        {
            _transfersDataAccessLayer = new TransfersDataAccessLayer();

        }

        //public AccountsBusinessLogicLayer()
        //{
        //    _accountsDataAccessLayer = new AccountsDataAccessLayer();

        //}
        /// <summary>
        /// Private property that represents the reference of TransfersDataAccessLayer
        /// </summary>
        private ITransfersDataAccessLayer TransfersDataAccessLayer
        {

            set => _transfersDataAccessLayer = value;
            get => _transfersDataAccessLayer;

        }

        public List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate)
        {

            //invoke dal
            try
            {
                return TransfersDataAccessLayer.GetTransfersByCondition(predicate);
            }
            catch (TransferException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        ///  Business logic Adds a new transfer to the existing transfers list
        /// </summary>
        /// <param name="transfer">The transfer object to add</param>
        /// <returns>Returns true, that indicates the transfer is added successfully
        /// </returns>
        public Guid AddTransfer(Transfer transfer)
        {

            try
            {
                //We should check if transfer name is generated or not

                //Get all transfers
                List<Transfer> allTransfers = TransfersDataAccessLayer.GetTransfers();

                TransfersDataAccessLayer.GetTransfers();

                //Transfer added
                //Update Account
                //AccountsDataAccessLayer.AddTransfer(transfer); // returns guid

                Console.WriteLine(transfer.TransferAmount);
                 
                return TransfersDataAccessLayer.AddTransfer(transfer); // returns guid
 

            }
            catch (TransferException)
            {

                throw;
            }
            catch (Exception)
            {

                throw;
            }

        }
        /// <summary>
        /// Calls accounts bll and updates transfer object that here contains two Accounts and tranfer data
        /// </summary>
        /// <param name="transfer">Combo of Accounts and Transfer Object </param>
        /// <returns></returns>
        public bool ProcessTransfer(Transfer transfer)
        {
            try
            {
                //Validate transfer before application
                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer();


                //Also maintain separate trasnfers entity
                TransfersDataAccessLayer.AddTransfer(new Transfer() { TransferAmount = transfer.TransferAmount, TransferDate = DateTime.Now, ToAccountNumber = transfer.ToAccountNumber, FromAccountNumber = transfer.FromAccountNumber }); // calling dal method from bll


                //Question: might be a bad place to create a new transfer object ?

                //toAccount
                accountsBusinessLogicLayer.ProcessTransfer(transfer.ToAccount, new Transfer() { TransferAmount = transfer.TransferAmount,TransferDate = DateTime.Now, ToAccountNumber = transfer.ToAccountNumber, FromAccountNumber = transfer.FromAccountNumber }); 
              
                //fromAccount
                accountsBusinessLogicLayer.ProcessTransfer(transfer.FromAccount, new Transfer() { TransferAmount = transfer.TransferAmount * -1, TransferDate = DateTime.Now, ToAccountNumber = transfer.ToAccountNumber, FromAccountNumber = transfer.FromAccountNumber });
               
                return true;
            }
            catch (TransferException) { throw; }
            catch (Exception) { throw; }


        }



    }
}
