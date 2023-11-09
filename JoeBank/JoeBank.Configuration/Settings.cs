using System;

namespace JoeBank.Configuration
{
    /// <summary>
    /// Project level configuration settings
    /// </summary>
    public static class Settings
    {
        #region Properties
        /// <summary>
        /// will serve as base number to add to
        /// </summary>
        public static long BaseCustomerNo { get; set; } = 1000;
        public static long BaseAccountNo { get; set; }  = 2000;

        #endregion        
    }
}
