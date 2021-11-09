using System;
using Data;
using System.Linq;
using Business;

namespace UserInterface
{
    public class StorefrontInventoryList : IMenu
    {
        private static string exceptionMessage;
        Storefront storefront;

        private static IStorefrontBL BL;
        public StorefrontInventoryList(IStorefrontBL bl)
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

            storefront = StorefrontView.storefront;
            Console.WriteLine("Inventory");
            Console.WriteLine("[id] | Product Name | Quantity");
            var inventory = BL.GetInventoryByStore(storefront.StoreNumber).ToList();
            if (inventory.Count() == 0)
            {
                Console.WriteLine("No products in stock");
            }
            else
            {
                foreach (var item in inventory)
                {
                    Console.WriteLine($"[{item.InvId}] | {BL.GetProductByProdId((int)item.ProdId).ProdName} | {item.Quantity}");
                }
            }
            Console.WriteLine("-----");
            Console.WriteLine("[0] Back");
            Console.WriteLine("[1] Add Product");
            Console.WriteLine("[2] Update inventory");
        }

        public MenuType UserSelection()
        {
            var userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.StorefrontView;
                case "1":
                    return MenuType.InventoryCreate;
                case "2":
                    int invId = 0;
                    while (invId <= 0)
                    {
                        try
                        {
                            Console.WriteLine("Enter product id");
                            invId = int.Parse(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    int invQuantity = -1;
                    while (invQuantity <= -1)
                    {
                        try
                        {
                            Console.WriteLine("Enter new quantity");
                            invQuantity = int.Parse(Console.ReadLine());
                            Console.WriteLine(BL.UpdateInventory(invId, invQuantity));
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    return MenuType.StorefrontInventoryList;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.StorefrontInventoryList;
            }
        }
    }
}