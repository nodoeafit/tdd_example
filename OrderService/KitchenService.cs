namespace OrderService {
    public class KitchenService : IRegisterService {
        public object RegisterIngredients(List<string> list)
        {
            throw new NotImplementedException();
        }

        public List<string> RegisterItems(List<string>? items) {
            if (items == null) {
                throw new ArgumentNullException(nameof(items));
            }
            return items;
        }
    }
}
