using System;
using JoeBank.Entities;
using System.Collections.Generic;

namespace JoeBank.DataAccesLayer.DALContracts
{
    public interface ITransfersDataAccessLayer
    {
        #region MethodsToImplement


        Guid AddTransfer(Transfer transfer);

        /// <summary>
        /// Return all Accounts as List<T> 
        /// </summary>
        /// <returns></returns>
        // List<Account>
        List<Transfer> GetTransfers();

        List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate); //condition as predicate lambda expression
 

        #endregion
    }
}

