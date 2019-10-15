using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefsAndDishes.Models
{
    public class Chef
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public int Age
        {
            get
            {
                DateTime now = DateTime.Now;
                return now.Year - this.Birthday.Year;
            }
        }

        public ICollection<Dish> Dishes { get; set; }

   
    }


}
