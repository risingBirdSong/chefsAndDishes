using ChefsAndDishes.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChefsAndDishes.Pages.Dishes
{
    public class HavingDropDown : PageModel 
    {
        public SelectList ChefDropDown { get; set; }

        public void PopulateDropDown(KitchenContext _context, object selected = null)
        {
            var chefQuery = from c in _context.Chefs
                            orderby c.FirstName
                            select c;
            ChefDropDown = new SelectList(chefQuery, "ID", "FirstName", selected);


        }

    }
}
