using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChefsAndDishes.Data;
using ChefsAndDishes.Models;

namespace ChefsAndDishes.Pages.Dishes
{
    public class IndexModel : PageModel
    {
        private readonly ChefsAndDishes.Data.KitchenContext _context;

        public IndexModel(ChefsAndDishes.Data.KitchenContext context)
        {
            _context = context;
        }

        public IList<Dish> Dish { get;set; }

        public async Task OnGetAsync()
        {
            Dish = await _context.Dishes
                .Include(d => d.MyChef)
                .ToListAsync();
        }           
    }
}
