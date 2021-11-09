using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class SOrderCreate : IMenu
    {
        public static SOrder sOrder;
        private static string exceptionMessage;
        public static bool creating = false;
        private ISOrderBL BL;
        public SOrderCreate(ISOrderBL bl)
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
            Console.WriteLine("Create an Order");
            Console.WriteLine("-----");
            sOrder = new SOrder();
            creating = true;
            sOrder.CustNumber = CustomerView.customer.CustNumber;

            foreach (var item in BL.ListAllStores())
            {
                Console.WriteLine($"[{item.StoreNumber}] | {item.StoreName}");
            }
            Console.WriteLine("-----");
            while (!sOrder.StoreNumber.HasValue)
            {
                try
                {
                    Console.WriteLine("Select store id");
                    sOrder.StoreNumber = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }


            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Add line item");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    creating = false;
                    return MenuType.CustomerView;
                case "1":
                    try
                    {
                        BL.Create(sOrder);
                        BL.Save();
                        exceptionMessage = "Order saved";
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                    }
                    return MenuType.LineItemCreate;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.SOrderCreate;
            }
        }
    }
}