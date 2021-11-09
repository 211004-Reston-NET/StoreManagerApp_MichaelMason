using System;

namespace UserInterface
{
    public class StorefrontMenu : IMenu
    {
        private static string exceptionMessage;
        public void Menu()
        {
            Console.WriteLine("Storefront Menu");
            Console.WriteLine("---------------");
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("---------------");
                exceptionMessage = null;
            }
            Console.WriteLine("[0] Back to Main Menu");
            Console.WriteLine("[1] Create a Storefront");
            Console.WriteLine("[2] List all Storefronts");
            Console.WriteLine("[3] Search for a Storefront");
        }

        public MenuType UserSelection()
        {
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "0":
                    return MenuType.MainMenu;
                case "1":
                    return MenuType.StorefrontCreate;
                case "2":
                    return MenuType.StorefrontList;
                case "3":
                    return MenuType.StorefrontSearch;
                default:
                    exceptionMessage = "INVALID SELECTION";
                    return MenuType.StorefrontMenu;
            }
        }
    }
}