using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class CustomerCreate : IMenu
    {
        private static Customer customer = new Customer();
        private static string exceptionMessage;
        private ICustomerBL BL;
        public CustomerCreate(ICustomerBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----------------");
                exceptionMessage = null;
            }

            customer = new Customer();
            Console.WriteLine("Create a Customer");
            Console.WriteLine("-----");
            while (customer.CustName == null)
            {
                try
                {
                    Console.WriteLine("Enter a name");
                    customer.CustName = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (customer.CustAddress == null)
            {
                try
                {
                    Console.WriteLine("Enter address");
                    customer.CustAddress = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (customer.CustEmail == null)
            {
                try
                {
                    Console.WriteLine("Enter Email");
                    customer.CustEmail = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (customer.CustPhone == null)
            {
                try
                {
                    Console.WriteLine("Enter Phone");
                    customer.CustPhone = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("-----");

            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Save Customer");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    BL.Create(customer);
                    BL.Save();
                    return MenuType.CustomerList;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.CustomerCreate;
            }
        }
    }
}