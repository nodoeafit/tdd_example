namespace KitchenServiceNamespace
{

    public class KitchenService
    {
        public bool IsDishReady { get; private set; }

        public void PrepareDish()
        {
            IsDishReady = true;
        }

        public void CorrectDish()
        {
            IsDishReady = false;
        }
    }

}
