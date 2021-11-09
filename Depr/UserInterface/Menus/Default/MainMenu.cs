using System;

namespace UserInterface
{
    public class MainMenu : IMenu
    {
        public static string exceptionMessage;
        public void Menu()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----");
                exceptionMessage = null;
            }
            Console.WriteLine("Main Menu");
            Console.WriteLine("---------");
            Console.WriteLine("[0] Exit");
            Console.WriteLine("[1] Customer Menu");
            Console.WriteLine("[2] Storefront Menu");
        }

        public MenuType UserSelection()
        {
            string userSelection = Console.ReadLine();
            switch (userSelection)
            {
                case "0":
                    return MenuType.ExitMenu;
                case "1":
                    return MenuType.CustomerMenu;
                case "2":
                    return MenuType.StorefrontMenu;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.MainMenu;
            }
        }
    }
}