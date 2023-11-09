using System;
using System.Collections.Generic;
using JoeBank.Entities;
using JoeBank.Exceptions;
using JoeBank.BusinessLogicLayer;
using JoeBank.BusinessLogicLayer.BALContracts;
namespace JoeBank.Presentation
{
    static class CustomersPresentation // make static to be easier to use in switch
    {
        //create an object of customer
        internal static void AddCustomer()
        {

            try
            {
                Customer customer = new Customer();
                //read all details from the user
                Console.WriteLine("\n********ADD CUSTOMER*************");
                Console.Write("Customer Name: ");
                customer.CustomerName = Console.ReadLine();
                Console.Write("Address: ");
                customer.Address = Console.ReadLine();
                Console.Write("Landmark: ");
                customer.Landmark = Console.ReadLine();
                Console.Write("City: ");
                customer.City = Console.ReadLine();
                Console.Write("Country: ");
                customer.Country = Console.ReadLine();
                Console.Write("Mobile: ");
                customer.Mobile = Console.ReadLine();

                //Create BL Object
                ICustomersBusinessLogicLayer customersBusinessLogicLayer = new CustomersBusinessLogicLayer();
                Guid newGuid = customersBusinessLogicLayer.AddCustomer(customer); //returns new guid

                //long customerCode = customer.CustomerCode; // always reutrns 1001 need to do logic as per below


                List<Customer> matchingCustomers = customersBusinessLogicLayer.GetCustomersByCondition(item => item.CustomerID == newGuid);

                if (matchingCustomers.Count >= 1)
                {
                    Console.WriteLine("New Customer Code: " + matchingCustomers[0].CustomerCode);
                    Console.WriteLine("Customer Added.\n");
                }
                else
                {
                    Console.WriteLine("Customer Not added");
                }
                //Console.WriteLine("Customer Added with Id: " + customerCode); // will return back to the top

            }
            catch (Exception ex) //have to speciy type of exception
            {
                Console.WriteLine(ex.Message); //caught in bll
                Console.WriteLine(ex.GetType());
                throw;
            }
   
            //exceptions need to be caugh

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
