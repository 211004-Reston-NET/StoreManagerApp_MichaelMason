using System;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class SOrderView : IMenu
    {
        private static string exceptionMessage;
        public static SOrder sOrder;
        public static bool is_cust = true;
        private static ISOrderBL BL;
        public SOrderView(ISOrderBL bl)
        {
            BL = bl;
        }
        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-------------");
                exceptionMessage = null;
            }
           
            sOrder.LineItems = BL.GetLineItemsByOrder(sOrder).ToList();
            Console.WriteLine("Order View");
            Console.WriteLine($"Order #{sOrder.OrderId} | Total: ${sOrder.TotalPrice}");
            Console.WriteLine($"{BL.GetStorefrontById((int)sOrder.StoreNumber).StoreName}");
            Console.WriteLine($"{BL.GetCustomerById((int)sOrder.CustNumber).CustName}");
            foreach (var item in sOrder.LineItems)
            {

                Console.WriteLine($"product id: {BL.GetProductById((int)item.ProdId).ProdName} | price/unit: {BL.GetProductById((int)item.ProdId).ProdPrice} | quantity: {item.Quantity}");
            }
            Console.WriteLine("-----");
            
            if (SOrderCreate.creating)
            {
                Console.WriteLine("[0] Done");
                Console.WriteLine("[1] Cancel order");
            }
            else
            {
                Console.WriteLine("[0] Done");
            }
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                if (is_cust)
                {
                    return MenuType.CustomerView;
                }
                else
                {
                    return MenuType.StorefrontView;
                }
                case "1":
                        BL.Delete(sOrder);
                        BL.UpdateInventoryOnCancel(sOrder.OrderId);
                        BL.Save();
                        return MenuType.MainMenu;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.SOrderMenu;
            }
        }
    }
}