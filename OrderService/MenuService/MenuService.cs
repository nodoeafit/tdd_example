using System;
using System.Collections.Generic;
using OrderService.Models; // Asegúrate de importar el modelo Menu

namespace OrderService.Services
{
    public class MenuService
    {
        public Menu GetMenu(DateTime date)
        {
            if (date == DateTime.MinValue)
                throw new ArgumentException("Fecha no válida");

            return new Menu
            {
                Date = date,
                Items = new List<string> { "Pizza", "Pasta", "Ensalada" }
            };
        }
    }
}


