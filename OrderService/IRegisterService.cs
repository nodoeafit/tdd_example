public interface IRegisterService {
    List<string> RegisterItems(List<string>? items); // <- Permitir null
}

public class KitchenService : IRegisterService {
    public List<string> RegisterItems(List<string>? items) {
        if (items == null) {
            throw new ArgumentNullException(nameof(items));
        }
        return items;
    }
}
