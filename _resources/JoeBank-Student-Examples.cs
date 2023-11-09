using static HarshaBank.Presentation.AccountsPresentation;
using static HarshaBank.Presentation.CustomersPresentation;
using static HarshaBank.Presentation.FundsTransferPresentation;
using static System.Console;
using static System.Convert;

namespace HarshaBank.Presentation
{
    public class Program
    {
        #region Methods
        public static void Main()
        {
            WriteLine("********** Harsha Bank **********");
            var (userName, password) = LoginPage();
            if (userName == "system" && password == "manager")
                MainMenu();
            WriteLine("Thank you! Visit again");
        }

        private static (string userName, string password) LoginPage()
        {
            try
            {
                WriteLine("\n:::Login page:::");
                Write("User name: ");
                var userName = ReadLine();
                Write("Password: ");
                var password = ReadLine();
                return (userName, password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void MainMenu()
        {
            int menuChoice;
            do
            {
                WriteLine("\n:::Main menu:::");
                WriteLine("1. Customers");
                WriteLine("2. Accounts");
                WriteLine("3. Funds transfer");
                WriteLine("4. Funds transfer statement");
                WriteLine("5. Account statement");
                WriteLine("0. Exit");

                Write("Enter choice: ");
                menuChoice = ToInt32(ReadLine());

                switch (menuChoice)
                {
                    case 1: CustomersMenu(); break;
                    case 2: AccountsMenu(); break;
                    case 3: FundsTransferMenu(); break;
                    case 4: ViewTransfers(); break;
                    case 5: SearchTransfers(); break;
                    case 0: Environment.Exit(0); break;
                    default: throw new InvalidOperationException();
                }
            } while(menuChoice != 0);
        }

        private static void CustomersMenu()
        {
            int menuChoice;
            do
            {
                WriteLine("\n:::Customers menu:::");
                WriteLine("1. Add customer");
                WriteLine("2. Delete customer");
                WriteLine("3. Update customer");
                WriteLine("4. Search customer");
                WriteLine("5. View customers");
                WriteLine("0. Back to main menu");

                Write("Enter choice: ");
                menuChoice = ToInt32(ReadLine());

                switch(menuChoice)
                {
                    case 1: AddCustomer(); break;
                    case 2: DeleteCustomer(); break;
                    case 3: EditCustomer(); break;
                    case 4: SearchCustomer(); break;
                    case 5: ViewCustomers(); break;
                    case 0: return;
                    default: throw new InvalidOperationException();
                }
            } while(menuChoice != 0);
        }

        private static void AccountsMenu()
        {
            int menuChoice;
            do
            {
                WriteLine("\n:::Accounts menu:::");
                WriteLine("1. Add account");
                WriteLine("2. Delete account");
                WriteLine("3. Update account");
                WriteLine("4. Search account");
                WriteLine("5. View accounts");
                WriteLine("0. Back to main menu");

                Write("Enter choice: ");
                menuChoice = ToInt32(ReadLine());

                switch (menuChoice)
                {
                    case 1: AddAccount(); break;
                    case 2: DeleteAccount(); break;
                    case 3: EditAccount(); break;
                    case 4: SearchAccount(); break;
                    case 5: ViewAccounts(); break;
                    case 0: return;
                    default: throw new InvalidOperationException();
                }
            } while (menuChoice != 0);
        }

        private static void FundsTransferMenu()
        {
            int menuChoice;
            do 
            { 
                WriteLine("\n:::Funds transfer menu:::");
                WriteLine("1. Transfer fund");
                WriteLine("2. View transfers");
                WriteLine("3. Search transfers");
                WriteLine("0. Back to main menu");

                Write("Enter choice: ");
                menuChoice = ToInt32(ReadLine());

                switch (menuChoice)
                {
                    case 1: TransferFund(); break;
                    case 2: ViewTransfers(); break;
                    case 3: SearchTransfers(); break;
                    case 0: return;
                    default: throw new InvalidOperationException();
                }
            } while (menuChoice != 0);
        }
        #endregion
    }
}


using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using static System.Console;
using static System.Guid;

namespace HarshaBank.Presentation
{
    internal static class AccountsPresentation
    {
        #region Methods
        internal static void AddAccount()
        {
            try
            {
                WriteLine("\n********** Add account **********");
                var account = new Account();
                InsertAccountInput(account);

                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();
                var accountID = accountsBLL.AddAccount(account);
                if (accountID != Empty)
                    WriteLine($"New account with ID {accountID} is added");
                else
                    WriteLine("Account is not added");
            }
            catch (AccountException)
            {
                throw;
            }
        }

        internal static void ViewAccounts()
        {
            try
            {
                WriteLine("\n********** All accounts **********");
                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();
                var accounts = accountsBLL.GetAccounts();
                foreach (var account in accounts)
                {
                    WriteLine($"ID: {account.ID}");
                    WriteLine($"User name: {account.UserName}");
                    WriteLine($"Password: {account.Password}");
                    WriteLine();
                }
            }
            catch (AccountException)
            {
                throw;
            }
        }

        internal static void SearchAccount()
        {
            try
            {
                WriteLine("\n********** Search account **********");
                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();

                Write("\nEnter user name: ");
                var userName = ReadLine();
                var account = accountsBLL.GetAccountByCondition(a => a.UserName == userName);
                if (account != null)
                {
                    WriteLine($"ID: {account.ID}");
                    WriteLine($"User name: {account.UserName}");
                    WriteLine($"Password: {account.Password}");
                }
                else
                    WriteLine("Account is not found");
            }
            catch (AccountException)
            {

                throw;
            }
        }

        internal static void EditAccount()
        {
            try
            {
                WriteLine("\n********** Edit account **********");
                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();

                Write("\nEnter user name: ");
                var userName = ReadLine();
                var account = accountsBLL.GetAccountByCondition(a => a.UserName == userName);
                if (account != null)
                {
                    InsertAccountInput(account);
                    accountsBLL.UpdateAccount(account);
                    WriteLine($"Account with user name {account.UserName} is edited");
                }
                else
                    WriteLine("Account is not found");
            }
            catch (AccountException)
            {
                throw;
            }
        }

        internal static void DeleteAccount()
        {
            try
            {
                WriteLine("\n********** Delete account **********");
                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();

                Write("\nEnter user name: ");
                var userName = ReadLine();
                var account = accountsBLL.GetAccountByCondition(a => a.UserName == userName);
                if (account != null)
                {
                    accountsBLL.DeleteAccount(account);
                    WriteLine("Account deleted");
                }
                else
                    WriteLine("Account not found");
            }
            catch (AccountException)
            {
                throw;
            }
        }

        private static void InsertAccountInput(Account account)
        {
            Write("User name: ");
            account.UserName = ReadLine();
            Write("Password: ");
            account.Password = ReadLine();
        }
        #endregion
    }
}


using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using static System.Console;
using static System.Convert;
using static System.Guid;

namespace HarshaBank.Presentation
{
    internal static class CustomersPresentation
    {
        #region Methods
        internal static void AddCustomer()
        {
            try
            {
                WriteLine("\n********** Add customer **********");
                Customer customer = new Customer();
                InsertCustomerInput(customer);

                ICustomersBusinessLogicLayer customersBLL = new CustomersBusinessLogicLayer();
                var customerID = customersBLL.AddCustomer(customer);
                if (customerID != Empty)
                    WriteLine($"New customer with ID {customerID} is added");
                else
                    WriteLine("Customer is not added");
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        internal static void ViewCustomers()
        {
            try
            {
                WriteLine("\n********** All customers **********");
                ICustomersBusinessLogicLayer customersBLL = new CustomersBusinessLogicLayer();
                var customers = customersBLL.GetCustomers();
                foreach (var customer in customers)
                {
                    WriteLine($"Code: {customer.Code}");
                    WriteLine($"Name: {customer.Name}");
                    WriteLine($"Address: {customer.Address}");
                    WriteLine($"Landmark: {customer.Landmark}");
                    WriteLine($"City: {customer.City}");
                    WriteLine($"Country: {customer.Country}");
                    WriteLine($"Mobile: {customer.Mobile}");
                    WriteLine();
                }
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        internal static void SearchCustomer()
        {
            try
            {
                WriteLine("\n********** Search customer **********");
                ICustomersBusinessLogicLayer customersBLL = new CustomersBusinessLogicLayer();

                Write("\nEnter customer name: ");
                var customerName = ReadLine();
                var customer = customersBLL.GetCustomerByCondition(c => c.Name == customerName);
                if (customer != null)
                {
                    WriteLine($"Code: {customer.Code}");
                    WriteLine($"Name: {customer.Name}");
                    WriteLine($"Address: {customer.Address}");
                    WriteLine($"Landmark: {customer.Landmark}");
                    WriteLine($"City: {customer.City}");
                    WriteLine($"Country: {customer.Country}");
                    WriteLine($"Mobile: {customer.Mobile}");
                }
                else
                    WriteLine("Customer not found");
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        internal static void EditCustomer()
        {
            try
            {
                WriteLine("\n********** Edit customer **********");
                ICustomersBusinessLogicLayer customersBLL = new CustomersBusinessLogicLayer();

                Write("\nEnter customer code: ");
                var customerCode = ToInt64(ReadLine());
                var customer = customersBLL.GetCustomerByCondition(c => c.Code == customerCode);
                if (customer != null)
                {
                    InsertCustomerInput(customer);
                    customersBLL.UpdateCustomer(customer);
                    WriteLine($"Customer with code {customerCode} is edited");
                }
                else
                    WriteLine("Customer is not found");
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        internal static void DeleteCustomer()
        {
            try
            {
                WriteLine("\n********** Delete customer **********");
                ICustomersBusinessLogicLayer customersBLL = new CustomersBusinessLogicLayer();

                Write("\nEnter customer code: ");
                var customerCode = ToInt64(ReadLine());
                var customer = customersBLL.GetCustomerByCondition(c => c.Code == customerCode);
                if (customer != null && customersBLL.DeleteCustomer(customer))
                    WriteLine("Customer is deleted");
                else
                    WriteLine("Customer is not found");
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        private static void InsertCustomerInput(Customer customer)
        {
            Write("Customer name: ");
            customer.Name = ReadLine();
            Write("Address: ");
            customer.Address = ReadLine();
            Write("Landmark: ");
            customer.Landmark = ReadLine();
            Write("City: ");
            customer.City = ReadLine();
            Write("Country: ");
            customer.Country = ReadLine();
            Write("Mobile: ");
            customer.Mobile = ReadLine();
        }
        #endregion
    }
}


using HarshaBank.BusinessLogicLayer;
using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using static System.Console;
using static System.Convert;
using static System.DateTime;

namespace HarshaBank.Presentation
{
    internal static class FundsTransferPresentation
    {
        #region Methods
        internal static void TransferFund()
        {
            try
            {
                WriteLine("\n********** Transfer fund **********");
                var fundsTransfer = new FundsTransfer();

                Write("Enter account user name to transfer to: ");
                var accountUserName = ReadLine();
                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();
                var account = accountsBLL.GetAccountByCondition(a => a.UserName == accountUserName);

                if (account != null)
                {
                    Write("Enter amount to transfer: ");
                    fundsTransfer.Amount = ToDecimal(ReadLine());

                    IFundsTransferBusinessLogicLayer fundsTransferBLL = new FundsTransferBusinessLogicLayer();
                    var transferDate = fundsTransferBLL.TransferFund(account, fundsTransfer);

                    WriteLine($"{fundsTransfer.Amount} was transfered to {account.UserName} at {transferDate}");
                }
                else
                    WriteLine("Fund not transfered");
            }
            catch (FundsTransferException)
            {
                throw;
            }

        }

        internal static void SearchTransfers()
        {
            try
            {
                WriteLine("\n********** Search transfers **********");
                IAccountsBusinessLogicLayer accountBLL = new AccountsBusinessLogicLayer();

                Write("Enter account user name: ");
                var accountUserName = ReadLine();
                IAccountsBusinessLogicLayer accountsBLL = new AccountsBusinessLogicLayer();
                var account = accountsBLL.GetAccountByCondition(a => a.UserName == accountUserName);

                if (account != null)
                {
                    Write("Enter transfer start date (yyyy-mm-dd): ");
                    var transferStartDate = Parse(ReadLine());

                    Write("Enter transfer end date (yyyy-mm-dd: ");
                    var transferEndDate = Parse(ReadLine());

                    var transfers = account.FundsTransfers.FindAll(ft => ft.TransferDate.CompareTo(transferStartDate) >= 0 && ft.TransferDate.CompareTo(transferEndDate) <= 0);
                    if (transfers.Any())
                    {
                        WriteLine($"Account user name: {account.UserName}");
                        foreach(var transfer in transfers)
                        {
                            WriteLine($"Transfer date: {transfer.TransferDate}");
                            WriteLine($"Amount: {transfer.Amount}");
                        }
                    }
                }
            }
            catch (FundsTransferException)
            {
                throw;
            }
        }

        internal static void ViewTransfers()
        {
            try
            {
                WriteLine("\n********** All funds transfers **********");
                IAccountsBusinessLogicLayer accountBLL = new AccountsBusinessLogicLayer();
                var accounts = accountBLL.GetAccounts();
                foreach (var account in accounts)
                {
                    WriteLine($"Account user name: {account.UserName}");
                    foreach (var transfer in account.FundsTransfers)
                    {
                        WriteLine($"Transfer date: {transfer.TransferDate}");
                        WriteLine($"Amount: {transfer.Amount}");
                        WriteLine();
                    }
                }
            }
            catch (FundsTransferException)
            {
                throw;
            }
        }
        #endregion
    }
}


namespace HarshaBank.Configuration
{
    public static class Settings
    {
        public static long BaseCustomerNumber { get; set; } = 1000;
    }
}


using static System.Console;

namespace HarshaBank.Exceptions
{
    public class AccountException : ApplicationException
    {
        #region Constructors
        public AccountException(string message) : base(message)
        {
            WriteLine(message);
        }

        public AccountException(string message, Exception innerException) : base(message, innerException)
        {
            WriteLine(message);
            WriteLine(innerException.GetType());
        }
        #endregion
    }
}


using static System.Console;

namespace HarshaBank.Exceptions
{
    public class CustomerException : ApplicationException
    {
        #region Constructors
        public CustomerException(string message) : base(message)
        {
            WriteLine(message);
        }

        public CustomerException(string message, Exception innerException) : base(message, innerException)
        {
            WriteLine(message);
            WriteLine(innerException.GetType());
        }
        #endregion
    }
}


using static System.Console;

namespace HarshaBank.Exceptions
{
    public class FundsTransferException : ApplicationException
    {
        #region Constructors
        public FundsTransferException(string message) : base(message)
        {
            WriteLine(message);
        }

        public FundsTransferException(string message, Exception innerException) : base(message, innerException)
        {
            WriteLine(message);
            WriteLine(innerException.GetType());
        }
        #endregion
    }
}


namespace HarshaBank.Entities.Contracts
{
    public interface IAccount
    {
        string UserName { get; set; }
        string Password { get; set; }
    }
}


namespace HarshaBank.Entities
{
    public interface ICustomer
    {
        #region Properties
        Guid ID { get; set; }
        long Code { get; set; }
        string Name { get; set; }
        string Address { get; set; }
        string Landmark { get; set; }
        string City { get; set; }
        string Country { get; set; }
        string Mobile { get; set; }
        #endregion
    }
}


namespace HarshaBank.Entities.Contracts
{
    public interface IFundsTransfer
    {
        #region Properties
        decimal Amount { get; set; }
        DateTime TransferDate { get; set; }
        #endregion
    }
}


using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;
using static System.Guid;
using static System.Text.RegularExpressions.Regex;

namespace HarshaBank.Entities
{
    public class Account : IAccount, ICloneable
    {
        #region Fields
        private Guid _id;
        private string _userName;
        private string _password;
        private List<FundsTransfer> _fundsTransfers;
        #endregion

        #region Properties
        public Guid ID 
        {
            get => _id; 
            set
            {
                if (value != Empty)
                    _id = value;
                else
                    throw new AccountException("ID should not be empty");
            }
        }
        public string UserName
        {
            get => _userName;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, @"^[\w\-]{2,20}$"))
                    _userName = value;
                else
                    throw new AccountException("Invalid username");
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, @"^\S{5,20}$"))
                    _password = value;
                else
                    throw new AccountException("Invalid password");
            }
        }
        public List<FundsTransfer> FundsTransfers { get => _fundsTransfers; set => _fundsTransfers = value; }
        #endregion

        #region Methods
        public object Clone()
        {
            return new Account
            {
                ID = _id,
                UserName = _userName,
                Password = _password,
                FundsTransfers = _fundsTransfers,
            };
        }
        #endregion
    }
}


using HarshaBank.Exceptions;
using static System.Guid;
using static System.Text.RegularExpressions.Regex;

namespace HarshaBank.Entities
{
    public class Customer : ICustomer, ICloneable
    {
        #region Fields
        private const string _patternGeneral = @"^[A-Za-zÀ-ÿ \'\-]{5,40}$";
        private Guid _id;
        private long _code;
        private string _name;
        private string _address;
        private string _landmark;
        private string _city;
        private string _country;
        private string _mobile;
        #endregion

        #region Properties
        public Guid ID 
        { 
            get => _id; 
            set
            {
                if (value != Empty)
                    _id = value;
                else
                    throw new CustomerException("ID should not be empty");
            }
        }
        public long Code
        { 
            get => _code; 
            set
            {
                if (value > 1000)
                    _code = value;
                else
                    throw new CustomerException("Code should be above 1000");
            }
        }
        public string Name 
        { 
            get => _name; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, _patternGeneral))
                    _name = value; 
                else
                    throw new CustomerException("Name should be between 5 and 40 characters long");
            }
        }
        public string Address 
        {
            get => _address; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, @"^[A-Za-zÀ-ÿ \'\-]{5,36}[\d]{1,3}[A-Za-z]?$"))
                    _address = value; 
                else
                    throw new CustomerException("Address should be between 5 and 40 characters long and should include an address number");
            }
        }
        public string Landmark
        {
            get => _landmark;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, @"^[A-Za-z]{1,3}$"))
                    _landmark = value;
                else
                    throw new CustomerException("Landmark should be between 1 and 3 characters long");
            }
        }
        public string City
        {
            get => _city;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, _patternGeneral))
                    _city = value;
                else
                    throw new CustomerException("City should be between 5 and 40 characters long");
            }
        }
        public string Country
        {
            get => _country;
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, _patternGeneral))
                    _country = value;
                else
                    throw new CustomerException("Country should be between 5 and 40 characters long");
            }
        }
        public string Mobile 
        {
            get => _mobile; 
            set
            {
                if (!string.IsNullOrWhiteSpace(value) && IsMatch(value, @"^[ \d\+\-\(\)]{10,20}$"))
                    _mobile = value; 
                else
                    throw new CustomerException("Mobile should contain at least 10 digits");
            }
        }
        #endregion

        #region Methods
        public object Clone()
        {
            return new Customer
            {
                ID = _id,
                Code = _code,
                Name = _name,
                Address = _address,
                Landmark = _landmark,
                City = _city,
                Country = _country,
                Mobile = _mobile
            };
        }
        #endregion
    }
}


using HarshaBank.Entities.Contracts;
using HarshaBank.Exceptions;
using static System.DateTime;

namespace HarshaBank.Entities
{
    public class FundsTransfer : IFundsTransfer, ICloneable
    {
        #region Fields
        private decimal _amount;
        private DateTime _transferDate;
        #endregion

        #region Properties
        public decimal Amount 
        {
            get => _amount; 
            set
            {
                if (value > 0)
                    _amount = value;
                else
                    throw new FundsTransferException("Amount should be larger than 0");
            }
        }
        public DateTime TransferDate 
        { 
            get => _transferDate; 
            set
            {
                if (Now.CompareTo(value) >= 0)
                    _transferDate = value;
                else
                    throw new FundsTransferException("Transfer date cannot be in the future");
            }
        }
        #endregion

        #region Methods
        public object Clone()
        {
            return new FundsTransfer
            {
                Amount = _amount,
                TransferDate = _transferDate
            };
        }
        #endregion
    }
}


using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer.DALContracts
{
    public interface IAccountsDataAccessLayer
    {
        #region Methods
        List<Account> GetAccounts();
        List<Account> GetAccountsByCondition(Predicate<Account> predicate);
        Account? GetAccountByCondition(Predicate<Account> predicate);
        Guid AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(Account account);
        #endregion
    }
}


using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer.DALContracts
{
    public interface ICustomersDataAccessLayer
    {
        #region Methods
        List<Customer> GetCustomers();
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);
        Customer? GetCustomerByCondition(Predicate<Customer> predicate);
        Guid AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        #endregion
    }
}


using HarshaBank.Entities;

namespace HarshaBank.DataAccessLayer.DALContracts
{
    public interface IFundsTransferDataAccessLayer
    {
        #region Methods
        DateTime TransferFund(Account account, FundsTransfer fundsTransfer);
        List<FundsTransfer> GetTransfers(Account account);
        List<FundsTransfer> GetTransfersByCondition(Account account, Predicate<FundsTransfer> predicate);
        FundsTransfer? GetTransferByCondition(Account account, Predicate<FundsTransfer> predicate);
        #endregion
    }
}


using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;

namespace HarshaBank.DataAccessLayer
{
    public class AccountsDataAccessLayer : IAccountsDataAccessLayer
    {
        #region Fields
        private static List<Account> _accounts;
        #endregion

        #region Constructors
        public AccountsDataAccessLayer()
        {
            if (_accounts == null)
                _accounts = new List<Account>();
        }
        #endregion

        #region Methods
        public Guid AddAccount(Account account)
        {
            try
            {
                account.ID = Guid.NewGuid();
                account.FundsTransfers = new List<FundsTransfer>();
                _accounts.Add(account);
                return account.ID;
            }
            catch (AccountException)
            {
                throw;
            }
        }

        public bool DeleteAccount(Account account) => _accounts.Remove(account);

        public List<Account> GetAccounts()
        {
            try
            {
                var clonedAccounts = new List<Account>();
                _accounts.ForEach(a => clonedAccounts.Add(a?.Clone() as Account));
                return clonedAccounts;
            }
            catch (AccountException)
            {
                throw;
            }
        }

        public List<Account> GetAccountsByCondition(Predicate<Account> predicate)
        {
            try
            {
                var clonedAccounts = new List<Account>();
                var filteredAccounts = _accounts.FindAll(predicate);
                filteredAccounts.ForEach(a => clonedAccounts.Add(a?.Clone() as Account));
                return clonedAccounts;
            }
            catch (AccountException)
            {
                throw;
            }
        }

        public Account? GetAccountByCondition(Predicate<Account> predicate)
        {
            try
            {
                var account = _accounts.Find(predicate);
                return account?.Clone() as Account;
            }
            catch (AccountException)
            {
                throw;
            }
        }

        public bool UpdateAccount(Account account)
        {
            try
            {
                var existingAccount = _accounts.Find(a => a.ID == account.ID);
                if (existingAccount != null)
                {
                    existingAccount.UserName = account.UserName;
                    existingAccount.Password = account.Password;
                    return true;
                }
                else
                    return false;
            }
            catch (AccountException)
            {
                throw;
            }
        }
        #endregion
    }
}


using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;
using static HarshaBank.Configuration.Settings;

namespace HarshaBank.DataAccessLayer
{
    public class CustomersDataAccessLayer : ICustomersDataAccessLayer
    {
        #region Fields
        private static List<Customer> _customers;
        #endregion

        #region Constructors
        static CustomersDataAccessLayer()
        {
            if (_customers == null)
                _customers = new List<Customer>();
        }
        #endregion

        #region Methods
        public Guid AddCustomer(Customer customer)
        {
            try
            {
                customer.ID = Guid.NewGuid();
                customer.Code = _customers.Any() 
                    ? _customers.Max(c => c.Code) + 1 
                    : BaseCustomerNumber + 1;
                _customers.Add(customer);
                return customer.ID;
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        public bool DeleteCustomer(Customer customer) => _customers.Remove(customer);

        public List<Customer> GetCustomers()
        {
            try
            {
                var clonedCustomers = new List<Customer>();
                _customers.ForEach(c => clonedCustomers.Add(c.Clone() as Customer));
                return clonedCustomers;
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate)
        {
            try
            {
                var clonedCustomers = new List<Customer>();
                var filteredCustomers = _customers.FindAll(predicate);
                filteredCustomers.ForEach(c => clonedCustomers.Add(c.Clone() as Customer));
                return clonedCustomers;
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        public Customer? GetCustomerByCondition(Predicate<Customer> predicate)
        {
            try
            {
                var customer = _customers.Find(predicate);
                return customer?.Clone() as Customer;
            }
            catch (CustomerException)
            {
                throw;
            }
        }

        public bool UpdateCustomer(Customer customer)
        {
            try
            {
                var existingCustomer = _customers.Find(c => c.ID == customer.ID);
                if (existingCustomer != null)
                {
                    existingCustomer.Code = customer.Code;
                    existingCustomer.Name = customer.Name;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Landmark = customer.Landmark;
                    existingCustomer.City = customer.City;
                    existingCustomer.Country = customer.Country;
                    existingCustomer.Mobile = customer.Mobile;

                    return true;
                }
                else
                    return false;
            }
            catch (CustomerException)
            {
                throw;
            }
        }
        #endregion
    }
}


using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;
using HarshaBank.Exceptions;

namespace HarshaBank.DataAccessLayer
{
    public class FundsTransferDataAccessLayer : IFundsTransferDataAccessLayer
    {
        #region Methods
        public List<FundsTransfer> GetTransfers(Account account)
        {
            try
            {
                var clonedTransfers = new List<FundsTransfer>();
                account.FundsTransfers.ForEach(ft => clonedTransfers.Add(ft.Clone() as FundsTransfer));
                return clonedTransfers;
            }
            catch (FundsTransferException)
            {
                throw;
            }
        }

        public List<FundsTransfer> GetTransfersByCondition(Account account, Predicate<FundsTransfer> predicate)
        {
            try
            {
                var clonedTransfers = new List<FundsTransfer>();
                var filteredTransfers = account.FundsTransfers.FindAll(predicate);
                filteredTransfers.ForEach(ft => clonedTransfers.Add(ft.Clone() as FundsTransfer));
                return clonedTransfers;
            }
            catch (FundsTransferException)
            {
                throw;
            }
        }

        public FundsTransfer? GetTransferByCondition(Account account, Predicate<FundsTransfer> predicate)
        {
            try
            {
                var transfer = account.FundsTransfers.Find(predicate);
                return transfer?.Clone() as FundsTransfer;
            }
            catch (FundsTransferException)
            {
                throw;
            }
        }

        public DateTime TransferFund(Account account, FundsTransfer fundsTransfer)
        {
            try
            {
                fundsTransfer.TransferDate = DateTime.Now;
                account.FundsTransfers.Add(fundsTransfer);
                return fundsTransfer.TransferDate;
            }
            catch (FundsTransferException)
            {
                throw;
            }
        }
        #endregion
    }
}


using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer.BALContracts
{
    public interface IAccountsBusinessLogicLayer
    {
        #region Methods
        List<Account> GetAccounts();
        List<Account> GetAccountsByCondition(Predicate<Account> predicate);
        Account? GetAccountByCondition(Predicate<Account> predicate);
        Guid AddAccount(Account account);
        bool UpdateAccount(Account account);
        bool DeleteAccount(Account account);
        #endregion
    }
}


using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer.BALContracts
{
    
    public interface ICustomersBusinessLogicLayer
    {
        #region Methods
        List<Customer> GetCustomers();
        List<Customer> GetCustomersByCondition(Predicate<Customer> predicate);
        Customer? GetCustomerByCondition(Predicate<Customer> predicate);
        Guid AddCustomer(Customer customer);
        bool UpdateCustomer(Customer customer);
        bool DeleteCustomer(Customer customer);
        #endregion
    }
}


using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer.BALContracts
{
    public interface IFundsTransferBusinessLogicLayer
    {
        #region Methods
        DateTime TransferFund(Account account, FundsTransfer fundsTransfer);
        List<FundsTransfer> GetTransfers(Account account);
        List<FundsTransfer> GetTransfersByCondition(Account account, Predicate<FundsTransfer> predicate);
        FundsTransfer? GetTransferByCondition(Account account, Predicate<FundsTransfer> predicate);
        #endregion
    }
}


using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.DataAccessLayer;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer
{
    public class AccountsBusinessLogicLayer : IAccountsBusinessLogicLayer
    {
        #region Fields
        private IAccountsDataAccessLayer _accountsDAL;
        #endregion

        #region Constructors
        public AccountsBusinessLogicLayer() => _accountsDAL = new AccountsDataAccessLayer();
        #endregion

        #region Methods
        public Guid AddAccount(Account customer) => _accountsDAL.AddAccount(customer);

        public bool DeleteAccount(Account account) => _accountsDAL.DeleteAccount(account);

        public List<Account> GetAccounts() => _accountsDAL.GetAccounts();

        public List<Account> GetAccountsByCondition(Predicate<Account> predicate) => _accountsDAL.GetAccountsByCondition(predicate);

        public Account? GetAccountByCondition(Predicate<Account> predicate) => _accountsDAL.GetAccountByCondition(predicate);
        public bool UpdateAccount(Account account) => _accountsDAL.UpdateAccount(account);
        #endregion
    }
}


using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.DataAccessLayer;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer
{
    public class CustomersBusinessLogicLayer : ICustomersBusinessLogicLayer
    {
        #region Fields
        private ICustomersDataAccessLayer _customersDAL;
        #endregion

        #region Constructors
        public CustomersBusinessLogicLayer() => _customersDAL = new CustomersDataAccessLayer();
        #endregion

        #region Methods
        public Guid AddCustomer(Customer customer) => _customersDAL.AddCustomer(customer);

        public bool DeleteCustomer(Customer customer) => _customersDAL.DeleteCustomer(customer);

        public List<Customer> GetCustomers() => _customersDAL.GetCustomers();

        public List<Customer> GetCustomersByCondition(Predicate<Customer> predicate) => _customersDAL.GetCustomersByCondition(predicate);

        public Customer? GetCustomerByCondition(Predicate<Customer> predicate) => _customersDAL.GetCustomerByCondition(predicate);

        public bool UpdateCustomer(Customer customer) => _customersDAL.UpdateCustomer(customer);
        #endregion
    }
}


using HarshaBank.BusinessLogicLayer.BALContracts;
using HarshaBank.DataAccessLayer;
using HarshaBank.DataAccessLayer.DALContracts;
using HarshaBank.Entities;

namespace HarshaBank.BusinessLogicLayer
{
    public class FundsTransferBusinessLogicLayer : IFundsTransferBusinessLogicLayer
    {
        #region Fields
        private IFundsTransferDataAccessLayer _fundsTransferDAL;
        #endregion

        #region Constructors
        public FundsTransferBusinessLogicLayer() => _fundsTransferDAL = new FundsTransferDataAccessLayer();
        #endregion

        #region Methods
        public List<FundsTransfer> GetTransfers(Account account) => _fundsTransferDAL.GetTransfers(account);

        public List<FundsTransfer> GetTransfersByCondition(Account account, Predicate<FundsTransfer> predicate) => _fundsTransferDAL.GetTransfersByCondition(account, predicate);

        public FundsTransfer? GetTransferByCondition(Account account, Predicate<FundsTransfer> predicate) => _fundsTransferDAL.GetTransferByCondition(account, predicate);

        public DateTime TransferFund(Account account, FundsTransfer fundsTransfer) => _fundsTransferDAL.TransferFund(account, fundsTransfer);
        #endregion
    }
}