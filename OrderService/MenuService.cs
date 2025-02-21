using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService
{
    public class MenuService
    {
        private List<Menu> menus;

        public MenuService()
        {
            menus = new List<Menu>
                {
                    new Menu { Id = 1, Name = "sancocho" },
                    new Menu { Id = 2, Name = "ajiaco" },
                    new Menu { Id = 3, Name = "mondongo" }
                    };
        }

        public List<Menu> AddMenu(Menu menu)
        {
            if (menu == null)
            {
                throw new ArgumentNullException(nameof(menu));
            }
            menus.Add(menu);
            return menus;
        }

        public Menu? GetMenu(string name)
        {
            if (menus.Any(x => x.Name == name))
            {
                return menus.FirstOrDefault(x => x.Name == name);
            }
            else
            {
                return null;
            }
        }

    }
}
