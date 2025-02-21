namespace MenuService
{
    public class MenuItem
    {
        public int Id { get; set; }  // Propiedad Id
        public string Name { get; set; } = string.Empty;  // Propiedad Name
        public decimal Price { get; set; }  // Propiedad Price

        public MenuItem(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}