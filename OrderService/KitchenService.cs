namespace OrderService {
    public class KitchenService {

        private Dictionary<string, int> _ingredients = new Dictionary<string, int>();
        public List<string> RegisterIngredients(List<string>? items)
        {
            if(items == null){
                throw new ArgumentNullException(nameof(items), "La lista de ingredientes no puede ser nula."
            );
            }
            foreach (var item in items)
            {
                if (!_ingredients.ContainsKey(item))
                {
                    _ingredients[item] = 2;
                }
            }
            return items;
        }

    public void ReceiveOrder(List<string> order)
    {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order), "El pedido no puede ser nulo.");
            }

            
            foreach (var item in order)
            {
                if (!_ingredients.ContainsKey(item) || _ingredients[item] <= 0)
                {
                    throw new InvalidOperationException($"No hay suficiente {item} para preparar el pedido.");
                }
            }

            
            foreach (var item in order)
            {
                _ingredients[item]--;
            }
        }

        public Dictionary<string, int> GetIngredients()
        {
            return _ingredients;
        }
        
    }
    
}