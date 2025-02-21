using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class KitchenService
    {
        private List<Kitchen> kitchens;
        public KitchenService()
        {
            kitchens = new List<Kitchen>
                {
                    new Kitchen { Id = 1, Ingredient = "tomato", Quantity = 1 },
                    new Kitchen { Id = 2, Ingredient = "union", Quantity = 2 },
                    new Kitchen { Id = 3, Ingredient = "carrot", Quantity = 3 }
                };
        }

       

        public List<Kitchen> FindIngredientsEgualsZero()
        {
            var kitchens = new List<Kitchen>();
            foreach(Kitchen kitchen in kitchens)
            {
                if (kitchen.Quantity == 0)
                {
                    kitchens.Add(kitchen);
                }
            }
            return kitchens;

        }
    }

  
}
