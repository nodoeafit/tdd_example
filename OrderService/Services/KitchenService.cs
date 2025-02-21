using OrderService.Models;

namespace OrderService.Services {
    public class KitchenService {
        public List<string> RegisterIngredients(List<string>? items){
            
            if(items == null){
                throw new ArgumentNullException();
            }

            return items;
        }

        public Kitchen DeleteIngredient(int id){

            if (id == 5){
                throw new NotImplementedException();
            }

            return new Kitchen{ Id = id, IngredientName = "Ingredient deleted" };
        }
        
    }
    
}