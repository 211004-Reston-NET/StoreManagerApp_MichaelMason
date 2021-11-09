namespace UserInterface
{
    public enum MenuType
    {
        MainMenu,
        ExitMenu,

        
        //PRODUCT
        ProductMenu,
        ProductCreate,
        ProductList,
        ProductSearch,
        ProductView,
        ProductUpdate,
        ProductDelete,

        

        //STORE
        StorefrontMenu,
        StorefrontCreate,
        StorefrontList,
        StorefrontSearch,
        StorefrontUpdate,
        StorefrontView,
        StorefrontDelete,
        StorefrontInventoryList,
        StorefrontOrderList,

        //CUSTOMER
        CustomerMenu,
        CustomerCreate,
        CustomerList,
        CustomerSearch,
        CustomerUpdate,
        CustomerView,
        CustomerDelete,
        CustomerOrderList,

    //LINEITEM
        LineItemMenu,
        LineItemCreate,
        LineItemList,
        LineItemSearch,
        LineItemUpdate,
        LineItemView,
        LineItemDelete,

        //STORE
        SOrderMenu,
        SOrderCreate,
        SOrderList,
        SOrderSearch,
        SOrderUpdate,
        SOrderView,
        SOrderDelete,

        //INVENTORY
        InventoryMenu,
        InventoryCreate,
        InventoryList,
        InventorySearch,
        InventoryUpdate,
        InventoryView,
        InventoryDelete
    }


    public interface IMenu
    {
        void Menu();
        MenuType UserSelection();
    }
}