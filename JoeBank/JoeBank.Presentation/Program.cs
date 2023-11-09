using System;
using JoeBank.Presentation;

class Program
{

    static void Main()
    {

        Console.WriteLine("------JoeBank------");
        Console.WriteLine("LoginPage:");

        string userName = null, password = null;

        Console.Write("Username: ");
        userName = Console.ReadLine();


        if (userName != "")
        {
            Console.Write("Password: ");

            password = Console.ReadLine();
        } 

        if (userName == "system" && password == "manager" )
        {

            int mainMenuChoice = -1; // should be accessible outside do while block

            do
            {

                Console.WriteLine("\n:::Main Menu:::");
                Console.WriteLine("1. Customers");
                Console.WriteLine("2. Accounts");
                Console.WriteLine("3. Transfer ");
                Console.WriteLine("8. Generate Some Data");

                Console.WriteLine("0. Exit");

                Console.WriteLine("Enter Choice: ");

                mainMenuChoice = int.Parse(Console.ReadLine());

                switch (mainMenuChoice)
                {
                    case 1:
                        CustomerMenu();
                        break;
                    case 2:
                        AccountsMenu();
                        break;

                    case 3:
                        TransferMenu();
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 8:
                        FactoryPresentation.GenerateData();
                        break;
                    case 0:
                        break;
                }


            } while (mainMenuChoice != 0);
        }
        else
        {

            Console.WriteLine("Invalid");

        }

        Console.WriteLine("Invalid Credentials");
        Console.ReadKey();


        static void CustomerMenu()
        {

            int customerMenuChoice = -1;

            do
            {
                Console.WriteLine("\n:::Customer:::");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Edit");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. View All");
                Console.WriteLine("0. Exit");

                Console.WriteLine("Enter Choice: ");

                //customerMenuChoice = int.Parse(Console.ReadLine().Trim());
                customerMenuChoice = Convert.ToInt32(Console.ReadLine().Trim()); // Two ways to convert to int

                switch (customerMenuChoice)
                {
                    case 1: CustomersPresentation.AddCustomer(); break;
                    case 2: CustomersPresentation.DeleteCustomer(); break; 
                    case 3: CustomersPresentation.EditCustomer(); break; 
                    case 5: CustomersPresentation.ViewCustomers(); break;  

                }

            } while (customerMenuChoice != 0);


        }

        static void AccountsMenu()
        {

            int accountsMenuChoice = -1;

            do
            {
                Console.WriteLine("\n:::Accounts:::");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Edit");
                Console.WriteLine("4. Search");
                Console.WriteLine("5. View All");
                Console.WriteLine("6. Statement");

                Console.WriteLine("0. Exit");

                Console.WriteLine("Enter Choice: ");

                //accountsMenuChoice = int.Parse(Console.ReadLine().Trim());
                accountsMenuChoice = Convert.ToInt32(Console.ReadLine().Trim()); // Two ways to convert to int

                switch (accountsMenuChoice)
                {
                    case 1: AccountsPresentation.AddAccount(); break;
                    case 2: AccountsPresentation.DeleteAccount(); break; //need to make collection static for this to work
                    case 3: AccountsPresentation.EditAccount(); break; 
                    case 5: AccountsPresentation.ViewAccounts(); break; 
                    case 6: AccountsPresentation.ViewStatement(); break; 

                }


            } while (accountsMenuChoice != 0);

        }



        static void TransferMenu()
        {

            int transfersMenuChoice = -1;

            do
            {
                Console.WriteLine("\n:::Transfer:::");
                Console.WriteLine("1. Add Transfer");
                Console.WriteLine("2. View Transfers");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter Choice: ");

                transfersMenuChoice = Convert.ToInt32(Console.ReadLine().Trim());

                switch (transfersMenuChoice)
                {
                    case 1: TransfersPresentation.AddTransfer(); break;
                    case 2: TransfersPresentation.ViewTransfers(); break;

                }


            } while (transfersMenuChoice != 0);

        }

    }

}