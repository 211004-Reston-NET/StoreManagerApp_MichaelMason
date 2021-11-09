using System;
using System.Collections.Generic;
using Business;
using Data;
using Models;
using System.Linq;

namespace UserInterface
{
    public class CustomerSearch : IMenu
    {
        private static string exceptionMessage;
        public static Customer customer;
        public static string email;
        List<int> custIds = new List<int>();

        private ICustomerBL BL;
        public CustomerSearch(ICustomerBL bl)
        {
            BL = bl;
        }

        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----");
                exceptionMessage = null;
            }

            var searchPrompt = $@"Customer search
[e] By email
[n] By name
[a] By address
[p] By phone
            ";

            IEnumerable<Customer> items = new List<Customer>();

            Console.WriteLine(searchPrompt);
            var searchBy = Console.ReadLine().ToLower();
            switch (searchBy)
            {
                case "e":

                    try
                    {
                        Console.WriteLine("Enter query");
                        var userInput = Console.ReadLine().ToLower();
                        items = BL.SearchByEmail(userInput);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "n":

                    try
                    {
                        Console.WriteLine("Enter query");
                        var userInput = Console.ReadLine().ToLower();
                        items = BL.SearchByName(userInput);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "a":

                    try
                    {
                        Console.WriteLine("Enter query");
                        var userInput = Console.ReadLine().ToLower();
                        items = BL.SearchByAddress(userInput);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                case "p":

                    try
                    {
                        Console.WriteLine("Enter query");
                        var userInput = Console.ReadLine().ToLower();
                        items = BL.SearchByPhone(int.Parse(userInput));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    break;
                default:
                    exceptionMessage = "Invalid selection";
                    break;
            }


            bool found = false;
            Console.WriteLine("-----");
            if (items.Count() == 0)
            {
                Console.WriteLine("Not found");
            }
            else
            {
                found = true;
                foreach (var item in items)
                {
                    custIds.Add(item.CustNumber);
                    CustomerM custM = new CustomerM(item);
                    Console.WriteLine(custM.ToList());
                }
            }

            Console.WriteLine("-------------------");
            Console.WriteLine("[0] Customer menu");
            Console.WriteLine("[1] Search again");
            if (found)
            {
                Console.WriteLine("[2] Select customer");
            }
        }


        public MenuType UserSelection()
        {

            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.CustomerMenu;
                case "1":
                    return MenuType.CustomerSearch;
                case "2":
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
                            Console.WriteLine(e.Message);
                        }
                    }
                    return MenuType.CustomerView;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.CustomerSearch;
            }
        }
    }
}