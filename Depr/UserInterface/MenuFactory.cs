using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Business;
using Data;
using Models;

namespace UserInterface
{
    public class MenuFactory : IFactory
    {
        public IMenu GetMenu(MenuType menu)
        {
            var configuration = new ConfigurationBuilder() //Configurationbuilder is the class that came from the Microsoft.extensions.configuration package
                   .SetBasePath(Directory.GetCurrentDirectory()) //Gets the current directory of the RRUI file path
                   .AddJsonFile("appsetting.json") //Adds the appsetting.json file in our RRUI
                   .Build(); //Builds our configuration

            DbContextOptions<StoreManagerContext> options = new DbContextOptionsBuilder<StoreManagerContext>()
                .UseSqlServer(configuration.GetConnectionString("StoreManager"))
                .Options;

            var storefrontRepo = new Repository<Storefront>(new StoreManagerContext());
            var customerRepo = new Repository<Customer>(new StoreManagerContext());
            var orderRepo = new Repository<SOrder>(new StoreManagerContext());

            switch (menu)
            {
                // DEFAULT
                case MenuType.MainMenu:
                    return new MainMenu();
                case MenuType.ExitMenu:
                    return new ExitMenu();
                
                // PRODUCT


                // STOREFRONT
                case MenuType.StorefrontMenu:
                    return new StorefrontMenu();
                case MenuType.StorefrontCreate:
                    return new StorefrontCreate(new StorefrontBL(storefrontRepo));
                case MenuType.StorefrontList:
                    return new StorefrontList(new StorefrontBL(storefrontRepo));
                case MenuType.StorefrontSearch:
                    return new StorefrontSearch(new StorefrontBL(storefrontRepo));
                case MenuType.StorefrontView:
                    return new StorefrontView(new StorefrontBL(storefrontRepo));
                case MenuType.StorefrontInventoryList:
                    return new StorefrontInventoryList(new StorefrontBL(storefrontRepo));
                case MenuType.StorefrontOrderList:
                    return new StorefrontOrderList(new StorefrontBL(storefrontRepo));

                //CUSTOMER
                case MenuType.CustomerMenu:
                    return new CustomerMenu();
                case MenuType.CustomerCreate:
                    return new CustomerCreate(new CustomerBL(customerRepo, orderRepo, storefrontRepo));
                case MenuType.CustomerList:
                    return new CustomerList(new CustomerBL(customerRepo, orderRepo, storefrontRepo));
                case MenuType.CustomerSearch:
                    return new CustomerSearch(new CustomerBL(customerRepo, orderRepo, storefrontRepo));
                case MenuType.CustomerView:
                    return new CustomerView(new CustomerBL(customerRepo, orderRepo, storefrontRepo));
                case MenuType.CustomerOrderList:
                    return new CustomerOrderList(new CustomerBL(customerRepo, orderRepo, storefrontRepo));

                // SOrder
                case MenuType.SOrderMenu:
                    return new SOrderMenu();
                case MenuType.SOrderCreate:
                    return new SOrderCreate(new SOrderBL(orderRepo));
                case MenuType.SOrderView:
                    return new SOrderView(new SOrderBL(orderRepo));

                // LINEITEM
                case MenuType.LineItemCreate:
                    return new LineItemCreate(new LineItemBL(new Repository<LineItem>(new StoreManagerContext(options))));

                // Inventory
                case MenuType.InventoryCreate:
                    return new InventoryCreate(new InventoryBl(new Repository<Inventory>(new StoreManagerContext(options))));

                default:
                    return new MainMenu();
            }
        }
    }
}