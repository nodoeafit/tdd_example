using System;
using System.Collections.Generic;

namespace OrderService.Models
{
    public class Menu
    {
        public DateTime Date { get; set; }
        public List<string> Items { get; set; }

        public Menu()
        {
            Items = new List<string>();
        }
    }
}
