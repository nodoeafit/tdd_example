namespace OrderService {
    public class MenuService {
        public List<string> RegisterItems(List<string>? items){
            if(items == null){
                throw new ArgumentNullException();
            }
            if (items.GroupBy(x => x).Any(g => g.Count() > 1))
            {
                throw new ArgumentException("No se pueden registrar platillos duplicados.");
            }
            return items;
        }
        
    }
    
}