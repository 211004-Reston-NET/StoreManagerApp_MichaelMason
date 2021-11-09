using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class CustomerList : IMenu
    {
        private static string exceptionMessage;
        public static string email;
        public static Customer customer;

        private ICustomerBL BL;
        public CustomerList(ICustomerBL bl)
        {
            BL = bl;
        }

        List<int> custIds = new List<int>();

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----");
                exceptionMessage = null;
            }

            var custs = BL.GetAll();
            foreach (var item in custs)
            {
                custIds.Add(item.CustNumber);
                customer = BL.GetById(item.CustNumber);
                Console.WriteLine(customer.ToList());
            }
            Console.WriteLine("-----");

            Console.WriteLine("[0] Back to Customers Menu");
            Console.WriteLine("[1] Select customer");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    int selection = 0;
                    while (selection <= 0)
                    {
                        try
                        {
                            Console.WriteLine("Enter customer id");
                            selection = int.Parse(Console.ReadLine());
                            if (custIds.Contains(selection))
                            {
                                customer = BL.GetById(selection);
                            }
                            else
                            {
                                selection = 0;
                                throw new Exception("Invalid selection");
                            }
                        }
                        catch (Exception e)
                        {
                            exceptionMessage = e.Message;
                            return MenuType.CustomerList;
                        }
                    }
                    return MenuType.CustomerView;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.CustomerList;
            }
        }
    }
}