using System;

namespace UserInterface
{
    public class SOrderMenu : IMenu
    {
        private static string exceptionMessage;
        public void Menu()
        {
            Console.WriteLine("Orders Menu");
            Console.WriteLine("---------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("---------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Main Menu");
            Console.WriteLine("[1] Create an Order");
            Console.WriteLine("[2] List all Orders");
            Console.WriteLine("[3] Search for an Order");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.SOrderCreate;
                case "2":
                    return MenuType.SOrderList;
                case "3":
                    return MenuType.SOrderSearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.SOrderMenu;
            }
        }
    }
}