using System;
using System.Collections.Generic;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class StorefrontView : IMenu
    {
        private static string exceptionMessage;
        public static Storefront storefront;
        public static List<Inventory> inventory;
        private static IStorefrontBL BL;
        public StorefrontView(IStorefrontBL bl)
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

            if (StorefrontSearch.storefront != null)
            {
                storefront = StorefrontSearch.storefront;
                StorefrontSearch.storefront = null;
            }
            if (StorefrontList.storefront != null)
            {
                storefront = StorefrontList.storefront;
                StorefrontList.storefront = null;
            }

            StorefrontM storefrontM = new StorefrontM(storefront);
            Console.WriteLine(storefrontM);
            Console.WriteLine("-----");
            Console.WriteLine("[0] Back");
            Console.WriteLine("[1] View Inventory");
            Console.WriteLine("[2] View Orders");
        }


        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.StorefrontMenu;
                case "1":
                    return MenuType.StorefrontInventoryList;
                case "2":
                    return MenuType.StorefrontOrderList;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.StorefrontMenu;
            }
        }
    }
}