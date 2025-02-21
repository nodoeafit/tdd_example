namespace MenuServiceNamespace
{
    public class MenuService() 
    {
        private Menu menu = new Menu();
        menu.Items.Add("Hamburguesa", 5.99m);
        menu.Items.Add("Papas Fritas", 2.99m);
        menu.Items.Add("Refresco", 1.99m);

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

        public void RemoveMenuItem(string item)
        {
            menu.Items.Remove(item);
        }

        public void UpdateMenuItemPrice(string item, decimal price)
        {
            menu.Items[item] = price;
        }
    }
}