namespace UserInterface
{
    public interface IFactory
    {
        IMenu GetMenu(MenuType menu);
    }
}