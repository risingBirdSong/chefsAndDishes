using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChefsAndDishes.Models
{
    public class Dish
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public float NumOfCals { get; set; }

        public string Description { get; set; }

        [Display(Name="the Chef")]
        public int ChefID { get; set; }

        public int Tastiness { get; set; }
    }
}
