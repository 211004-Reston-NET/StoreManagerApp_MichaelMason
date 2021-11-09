using System;
using Business;
using Data;
using System.Linq;

namespace UserInterface
{
    public class CustomerOrderList : IMenu
    {
                private static string exceptionMessage;

        Customer customer;
        private static ICustomerBL BL;
        public CustomerOrderList(ICustomerBL bl)
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

            Console.WriteLine("Orders\n-----\n");
            customer = CustomerView.customer;
            var orders = BL.GetOrders(customer);
            if (orders.Count() == 0)
            {
                Console.WriteLine("No orders yet");
            }
            else
            {
                foreach (var item in orders)
                {
                    
                    var store = BL.GetStoreByOrder(item);
                    Console.WriteLine($"order #{item.OrderId} | : {item.StoreNumber} | {store.StoreName} {store.StoreAddress} | total price: {item.TotalPrice}");
                }
            }
            Console.WriteLine("-----");
            Console.WriteLine("[0] Back");
            Console.WriteLine("[1] View order");
        }

        public MenuType UserSelection()
        {
            var userSelection = Console.ReadLine();
            switch(userSelection)
            {
                case "0":
                    return MenuType.CustomerView;
                case "1":
                    try{
                        Console.WriteLine("Enter order id");
                        SOrderView.sOrder = BL.GetOrderById(int.Parse(Console.ReadLine()));
                        SOrderView.is_cust = true;
                        return MenuType.SOrderView;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return MenuType.CustomerOrderList;
                    }
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.CustomerOrderList;
            }
        }
    }
}