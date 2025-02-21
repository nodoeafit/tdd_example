using System.Collections.Generic;

namespace OrderService
{
    public class MenuService
    {

        private List<Menu> _menu = new List<Menu>();

        public void RegisterItems(List<string>? items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items), "La lista no puede ser nula.");
            }
            if (!items.Any())
            {
                throw new ArgumentException("La lista no puede estar vacía.", nameof(items));
            }

            foreach (var itemName in items)
            {
                _menu.Add(new Menu { Name = itemName });
            }
        }

        public List<Menu> GetMenu()
        {
            return _menu;
        }
    }
}
