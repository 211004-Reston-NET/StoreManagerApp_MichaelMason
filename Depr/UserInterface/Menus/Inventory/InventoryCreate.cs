using System;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class InventoryCreate : IMenu
    {
        private static Inventory inventory;
        private static string exceptionMessage;
        private IInventoryBl BL;
        public InventoryCreate(IInventoryBl bl)
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
            Console.WriteLine("Add a Product");
            Console.WriteLine("-----");
            inventory = new Inventory();
            inventory.Prod = new Product();
            while (inventory.Prod.ProdName == null)
            {
                try
                {
                    Console.WriteLine("Product name");
                    inventory.Prod.ProdName = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (inventory.Prod.ProdPrice.Equals(0))
            {
                try
                {
                    Console.WriteLine("Product price");
                    inventory.Prod.ProdPrice = decimal.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            while (inventory.Prod.ProdDescription == null)
            {
                try
                {
                    Console.WriteLine("Product Description");
                    inventory.Prod.ProdDescription = Console.ReadLine();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("-----");
            inventory.StoreNumber = StorefrontView.storefront.StoreNumber;

            while (inventory.Quantity <= 0)
            {
                try
                {
                    Console.WriteLine("Quantity");
                    inventory.Quantity = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("-----");


            Console.WriteLine("[0] Go Back");
            Console.WriteLine("[1] Save Inventory");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.StorefrontInventoryList;
                case "1":
                    try
                    {
                        Console.WriteLine(BL.Create(inventory));
                        BL.Save();
                        return MenuType.StorefrontInventoryList;
                    }
                    catch (NullReferenceException e)
                    {
                        exceptionMessage = e.Message;
                        return MenuType.InventoryCreate;

                    }
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.InventoryCreate;
            }
        }
    }
}