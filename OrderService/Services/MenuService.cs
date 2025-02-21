using OrderService.Models;

namespace OrderService.Services{
    public class MenuService {
        public List<string> RegisterItems(List<string>? items){
            
            if(items == null){
                throw new ArgumentNullException();
            }
            return items;
        }

        public Menu UpdateItemName(int id, string itemName){
            
            if (id == 5){
                throw new NotImplementedException();
            }

            return new Menu{ Id = id, ItemName = itemName };
        }

        public List<string> GetAllItems(List<string>? items){
 
            if(items == null){
                throw new ArgumentNullException(null, "No hay items registrados");
            }

            return items;
        }
        
    }
    
}