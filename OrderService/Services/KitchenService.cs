namespace OrderService.Services {
    public class KitchenService {
        public List<string> RegisterIngredients(List<string>? items){
            if(items == null){
                throw new ArgumentNullException();
            }
            return items;
        }
        
    }
    
}