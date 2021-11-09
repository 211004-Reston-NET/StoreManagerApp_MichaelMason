using System;

namespace UserInterface
{
    class Program
    {
        IFactory factory1;
        public static bool running = true;
        static void Main(string[] args)
        {
            IFactory factory = new MenuFactory();
            IMenu page = factory.GetMenu(MenuType.MainMenu);
            while(running)
            {
                Console.Clear();
                page.Menu();
                MenuType currentPage = page.UserSelection();
                
                page = factory.GetMenu(currentPage);
            }
        }
    }
}
