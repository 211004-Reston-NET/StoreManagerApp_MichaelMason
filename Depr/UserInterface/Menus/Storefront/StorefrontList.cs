using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class StorefrontList : IMenu
    {
        static string exceptionMessage;
        public static Storefront storefront;
        List<int> storeIds = new List<int>();

        private IStorefrontBL BL;
        public StorefrontList(IStorefrontBL bl)
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

            IEnumerable<Storefront> items = BL.GetAll().ToList();

            Console.WriteLine("Storefront Listing");
            Console.WriteLine("-----");
            foreach (var item in items)
            {
                storeIds.Add(item.StoreNumber);
                StorefrontM storefrontM = new StorefrontM(item);
                Console.WriteLine(storefrontM.ListView());
            }
            Console.WriteLine("-----");
            Console.WriteLine("[0] Back to Storefront Menu");
            Console.WriteLine("[1] Select Storefront");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.StorefrontMenu;
                case "1":
                    int selection = 0;
                    while (selection <= 0)
                    {
                        try
                        {
                            Console.WriteLine("Enter storefront number");
                            selection = int.Parse(Console.ReadLine());
                            if (storeIds.Contains(selection))
                            {
                                storefront = BL.GetById(selection);
                            }
                            else
                            {
                                selection = 0;
                                throw new Exception("Invalid selection");
                            }

                        }
                        catch (Exception)
                        {
                            exceptionMessage = "Invalid selection";
                            return MenuType.StorefrontList;
                        }
                    }

                    return MenuType.StorefrontView;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.StorefrontList;
            }
        }
    }
}