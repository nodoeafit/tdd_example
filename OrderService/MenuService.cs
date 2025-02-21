namespace OrderService {
    public class MenuService {
        public List<string> RegisterItems(List<string>? items){
            if(items == null){
                throw new ArgumentNullException();
            }
            return items;
        }
        
    }
    
}