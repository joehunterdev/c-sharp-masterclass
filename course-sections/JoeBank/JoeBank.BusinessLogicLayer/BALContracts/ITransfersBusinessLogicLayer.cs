using System;
using System.Collections.Generic; //needed for List<T>
using JoeBank.Entities;

namespace JoeBank.BusinessLogicLayer.BALContracts
{
    /// <summary>
    /// Interface that represents accounts business logic
    /// </summary>
    public interface ITransfersBusinessLogicLayer
    {
        #region MethodsToImplement
         
        Guid AddTransfer(Transfer transfer);
        List<Transfer> GetTransfersByCondition(Predicate<Transfer> predicate); //condition as predicate lambda expression
                                                                               //Transfer GetTransferByCondition(Predicate<Transfer> predicate); //condition as predicate lambda expression
        bool ProcessTransfer(Transfer transfer);

    }
    #endregion MethodsToImplement

}
