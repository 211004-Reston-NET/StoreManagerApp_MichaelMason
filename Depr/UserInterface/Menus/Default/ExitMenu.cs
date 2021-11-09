using System;
namespace UserInterface
{
    public class ExitMenu : IMenu
    {
        public static string exceptionMessage;
        public void Menu(){}

        public MenuType UserSelection()
        {
            if (exceptionMessage != null)
            {
                Console.WriteLine(exceptionMessage);
                Console.WriteLine("-----");
                exceptionMessage = null;
            }
            Console.WriteLine("Are you sure you want to exit? [y]/[n]");
            string userSelection = Console.ReadLine().ToLower();
            switch(userSelection)
            {
                case "y":
                    Environment.Exit(0);
                    return MenuType.ExitMenu;
                case "n":
                    return MenuType.MainMenu;
                default:
                    exceptionMessage = "Invalid selection";
                    return MenuType.ExitMenu;      
            }
        }
    }
}