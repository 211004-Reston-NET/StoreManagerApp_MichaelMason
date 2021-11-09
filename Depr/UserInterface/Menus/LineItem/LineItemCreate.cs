using System;
using System.Linq;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class LineItemCreate : IMenu
    {
        LineItem lineItem;
        private static string exceptionMessage;
        private ILineItemBL BL;
        public LineItemCreate(ILineItemBL bl)
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
            lineItem = new LineItem();
            lineItem.OrderId = SOrderCreate.sOrder.OrderId;

            var items = BL.ListAllProducts((int)SOrderCreate.sOrder.StoreNumber);
            if (items.Count() == 0)
            {
                Console.WriteLine("This store has no items for sale");
                Console.WriteLine("[0] Back");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"[{item.ProdId}] | {item.ProdName} | {item.ProdPrice}");
                }
                Console.WriteLine("-----");

                while (!lineItem.ProdId.HasValue)
                {
                    try
                    {
                        Console.WriteLine("Enter product id");
                        lineItem.ProdId = int.Parse(Console.ReadLine());
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                while (lineItem.Quantity <= 0)
                {
                    try
                    {
                        Console.WriteLine("Enter quantity");
                        var quantity = int.Parse(Console.ReadLine());
                        var check = BL.CheckInventory((int)SOrderCreate.sOrder.StoreNumber, (int)lineItem.ProdId, lineItem.Quantity);
                        // while loop?
                        if (quantity < check)
                        {
                            lineItem.Quantity = quantity;
                        }
                        else
                        {
                            Console.WriteLine("Not enough stock");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }



                Console.WriteLine("-----");
                Console.WriteLine("[0] Back");
                Console.WriteLine("[1] Save line item");
            }

        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    BL.DeleteOrder(SOrderCreate.sOrder);
                    BL.Save();
                    return MenuType.LineItemMenu;
                case "1":
                    BL.Create(lineItem);
                    BL.Save();
                    exceptionMessage = "Line item created";
                    Console.WriteLine("Enter another item? [y]/[n]");
                    string confirm = "";
                    while (confirm != "y" || confirm != "n")
                    {
                        confirm = Console.ReadLine();
                        if (confirm == "y")
                        {
                            return MenuType.LineItemCreate;
                        }
                        else if (confirm == "n")
                        {
                            BL.UpdateInventory(SOrderCreate.sOrder);
                            BL.UpdateTotalPrice(SOrderCreate.sOrder);
                            BL.Save();
                            SOrderView.sOrder = SOrderCreate.sOrder;
                            SOrderCreate.creating = false;
                            return MenuType.SOrderView;
                        }
                        else
                        {
                            Console.WriteLine("Invalid selection");
                            Console.WriteLine("Enter another item? [y]/[n]");
                        }
                    }
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.LineItemCreate;
            }
        }
    }
}