namespace OrderService {
    public class KitchenService {
        public List<string> RegisterIngredients(List<string>? items){
            if(items == null){
                throw new ArgumentNullException();
            }
            if(items.Any(item => string.IsNullOrWhiteSpace(item)))
            {
            throw new ArgumentException("La lista no puede contener ingredientes vacíos o espacios en blanco");
            }
            return items;
        }
        
    }
    
}