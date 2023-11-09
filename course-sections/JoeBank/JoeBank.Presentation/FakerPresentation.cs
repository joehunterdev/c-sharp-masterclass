using System;
using System.Collections.Generic;
using JoeBank.Entities;
using JoeBank.BusinessLogicLayer;
using JoeBank.BusinessLogicLayer.BALContracts;
namespace JoeBank.Presentation
{
    static class FactoryPresentation // make static to be easier to use in switch
    {
        //create an object of customer
        internal static void GenerateData()
        {

            try
            {
               // TODO: Strucutre this into layers

                //Create BL Object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                customersBusinessLogicLayer.AddCustomer(new Customer() { CustomerName = "Joe", Address = "123 C. Grenada, Malaga 20640", Landmark = "Ship", City = "Malage", Mobile = "600649329" });
                customersBusinessLogicLayer.AddCustomer(new Customer() { CustomerName = "James", Address = "123 Via. Cuesta ,  534640", Landmark = "Sardine", City = "Malaga", Mobile = "61149329" });
                customersBusinessLogicLayer.AddCustomer(new Customer() { CustomerName = "Carlos", Address = "123 Apt. Salvador Rueda, 40330", Landmark = "City", City = "Zaragoza", Mobile = "63369329" });
                customersBusinessLogicLayer.AddCustomer(new Customer() { CustomerName = "Jacobo", Address = "123 C. Real ,  10640", Landmark = "Coast", City = "Vigo", Mobile = "664234932" });
                customersBusinessLogicLayer.AddCustomer(new Customer() { CustomerName = "Alex", Address = "223 Captian St, WP0302", Landmark = "Old Mill", City = "Wigan", Mobile = "666932932" });//returns new guid


                Console.WriteLine(String.Format("{0}Faking Data{0}", new String('-', 10)));

                foreach (var item in customersBusinessLogicLayer.GetCustomers())
                {
                    Console.WriteLine("Customer: " + item.CustomerCode + " Created !");
                }


                IAccountsBusinessLogicLayer accountsBusinessLogicLayer = new AccountsBusinessLogicLayer(); 
                accountsBusinessLogicLayer.AddAccount(new Account() { AccountOwnerName = "Joe",     AccountPin = 1234,   AccountType = "debit",  AccountBalance = 10000}); 
                accountsBusinessLogicLayer.AddAccount(new Account() { AccountOwnerName = "James",   AccountPin = 2234, AccountType = "debit",    AccountBalance = 10000 }); 
                accountsBusinessLogicLayer.AddAccount(new Account() { AccountOwnerName = "Carlos",  AccountPin = 3234, AccountType = "credit",   AccountBalance = 10000 }); 
                accountsBusinessLogicLayer.AddAccount(new Account() { AccountOwnerName = "Jacobo",  AccountPin = 4234, AccountType = "savings",  AccountBalance = 10000 }); 
                accountsBusinessLogicLayer.AddAccount(new Account() { AccountOwnerName = "Alex",    AccountPin = 5234, AccountType = "credit",   AccountBalance = 10000 });


                foreach (var acc in accountsBusinessLogicLayer.GetAccounts())
                {

                }

                List<Account> accs = accountsBusinessLogicLayer.GetAccounts();

                for (int i = 0; i < accs.Count; i++)
                {

                    Console.WriteLine("Account: " + accs[i].AccountNumber + " Created !");

                    Random rd = new Random();
                    int rand_num = rd.Next(100, 200);

                    if(i < (accs.Count -1))
                    {

                        Console.WriteLine("Transfering from Account:" + accs[i].AccountNumber);
                        Console.WriteLine("Transfering to Account:" + accs[i+1].AccountNumber);

                        //toAccount
                        accountsBusinessLogicLayer.ProcessTransfer(accs[i], new Transfer() { TransferAmount = rand_num, TransferDate = DateTime.Now, ToAccountNumber = accs[i].AccountNumber, FromAccountNumber = accs[i+1].AccountNumber });

                        //fromAccount
                       accountsBusinessLogicLayer.ProcessTransfer(accs[i+1], new Transfer() { TransferAmount = rand_num * -1, TransferDate = DateTime.Now, ToAccountNumber = accs[i+1].AccountNumber, FromAccountNumber = accs[i].AccountNumber });
                    }

               
                }

            }
            catch (Exception ex) //have to specify type of exception
            {
                Console.WriteLine(ex.Message); //caught in bll
                Console.WriteLine(ex.GetType());
                throw;
            }
   

        }

        internal static void ViewCustomers()
        {
            try
            {
                // Create BL Object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                //List of type customers assign to allCustomers is equal to the Bl Object we created above access method
                List<Customer> allCustomers = customersBusinessLogicLayer.GetCustomers();

                Console.WriteLine("\n**********ALL CUSTOMERS*************");

                foreach (var item in allCustomers)
                {

                    Console.WriteLine("Customer Code: " + item.CustomerCode);
                    Console.WriteLine("Customer Name: " + item.CustomerName);
                    Console.WriteLine("Address: " + item.Address);
                    Console.WriteLine("Landmark: " + item.Landmark);
                    Console.WriteLine("City: " + item.City);
                    Console.WriteLine("Country: " + item.Country);
                    Console.WriteLine("Mobile: " + item.Mobile);
                    Console.WriteLine();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                throw;
            }

            //read all customers in loop and print the output

        }

        internal static void EditCustomer()
        {
            try
            {

                Console.WriteLine("\n**********UPDATE CUSTOMER AREA*************");


                // Create BL Object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                Console.WriteLine("\n**********Enter a customer code*************");

                long customerCode = Convert.ToInt32(Console.ReadLine());

                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode);
 

                ////Find customer 
                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("Customer Found : " + matchingCustomers[0].CustomerName);

                    Console.WriteLine("\n**********UPDATE CUSTOMER*************");
                    Console.Write("Customer Name: ");
                    matchingCustomers[0].CustomerName = Console.ReadLine();
                    Console.Write("Address: ");
                    matchingCustomers[0].Address = Console.ReadLine();
                    Console.Write("Landmark: ");
                    matchingCustomers[0].Landmark = Console.ReadLine();
                    Console.Write("City: ");
                    matchingCustomers[0].City = Console.ReadLine();
                    Console.Write("Country: ");
                    matchingCustomers[0].Country = Console.ReadLine();
                    Console.Write("Mobile: ");
                    matchingCustomers[0].Mobile = Console.ReadLine();

                    if (customersBusinessLogicLayer.UpdateCustomer(matchingCustomers[0])) {

                        Console.WriteLine("Customer Updated Successfully");

                    }  


                }
                else {

                    Console.WriteLine("No Customer found");
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
                throw;
            }

        }

        internal static void DeleteCustomer()
        {
            try
            {

                Console.WriteLine("\n**********DELETE CUSTOMER AREA*************");


                // Create BL Object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();

                Console.WriteLine("\n**********Enter a customer code*************");

                long customerCode = Convert.ToInt32(Console.ReadLine());

                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerCode == customerCode);


                ////Find customer 
                if (matchingCustomers.Count >= 1 && customersBusinessLogicLayer.DeleteCustomer(matchingCustomers[0].CustomerID))
                {
                    
                   Console.WriteLine("Customer Deleted Successfully");

                }
                else
                {

                    Console.WriteLine("No Customer found");
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
