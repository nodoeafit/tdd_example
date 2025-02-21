namespace MenuServiceNamespace
{
    public class MenuService()
    {
        Menu menu = new Menu
        {
            Items = new Dictionary<string, decimal>
            {
                { "Hamburguesa", 5.99m },
                { "Papas Fritas", 2.99m },
                { "Refresco", 1.99m }
            }
        };

        public Dictionary<string, decimal> GetMenu()
        {
            return menu.Items;
        }

        public decimal GetPrice(string item)
        {
            if (!menu.Items.ContainsKey(item))
            {
                throw new InvalidOperationException("Item no encontrado");
            }
            return menu.Items[item];
        }

        public void AddMenuItem(string item, decimal price)
        {
            menu.Items.Add(item, price);
        }

        public int RemoveMenuItem(string item)
        {
            menu.Items.Remove(item);

            if (!menu.Items.ContainsKey(item))
            {
                // Si se borro correctamente el item devuelve 0
                return 0;
            }

            // Si no se borro correctamente el item devuelve 1
            return 1;
        }

        public void UpdateMenuItemPrice(string item, decimal price)
        {
            menu.Items[item] = price;
        }
    }
}