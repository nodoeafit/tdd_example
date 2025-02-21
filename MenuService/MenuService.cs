namespace MenuService;

public class MenuService
{
    private readonly IMenuRepository _menuRepository;

    public MenuService(IMenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    public void AddMenuItem(MenuItem item)
    {
        _menuRepository.AddMenuItem(item);
        _menuRepository.Save();
    }

    public List<MenuItem> GetMenuItems() 
    {
        return _menuRepository.GetMenu();
    }
}

