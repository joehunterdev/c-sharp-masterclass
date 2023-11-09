using System;
using System.Collections.Generic; 
using JoeBank.Entities; //Contains account
using JoeBank.Exceptions;
using JoeBank.DataAccesLayer.DALContracts; // for extending interface ITransfersDataAccessLayer CRUD
using System.Linq;
namespace JoeBank.DataAccesLayer
{
    /// <summary>
    /// Represnts DAL for bank Transfers
    /// </summary>
    public class TransfersDataAccessLayer : ITransfersDataAccessLayer
    {
        #region Private Fields
        private static List<Transfer> _transfers; //static even tho we will init once the same can be accessed everytime
        #endregion

        #region Constructors
        /// <summary>
        /// init _Transfers static
        /// </summary>
        static TransfersDataAccessLayer() //static even tho we will init once the same can be accessed everytime
        {
            _transfers = new List<Transfer>();
        }
        #endregion

        #region Private Properties

        /// <summary>
        /// Create private property Transfers
        /// </summary>
        private List<Transfer> Transfers 
        {
            set => _transfers = value;
            get => _transfers;
        }

        public List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate)
        {
            try
            {
                //create a new transfers list
                List<Transfer> transfersList = new List<Transfer>();

                //filter the collection
                List<Transfer> filteredTransfers = Transfers.FindAll(predicate); //filter from global list

                //copy all transfers from the soruce collection into the newTransfers list
                filteredTransfers.ForEach(item => transfersList.Add(item.Clone() as Transfer));
                return transfersList;
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

        public Guid AddTransfer(Transfer transfer)
        {

            try
            {
                transfer.TransferID = Guid.NewGuid(); // Internal method to create ids
                Transfers.Add(transfer); // hook into proptery init
                return transfer.TransferID;
            }
            catch (Exception)
            {
                throw;
            }


        }

        public List<Transfer> GetTransfers()
        {

            try
            {
                //create new collection of transfers 
                List<Transfer> transfersList = new List<Transfer>();
                Transfers.ForEach(item => transfersList.Add(item.Clone() as Transfer)); //lambda once for each item in collection Clone returns object so we need to typecast "as Transfer" (List<T>) 
                return transfersList;

            }
            catch (TransferException)
            { //get the exception could be important worth separating

                throw;
            }

            catch (Exception)
            {

                throw;

            }

        }


        #endregion

       

    }
}
