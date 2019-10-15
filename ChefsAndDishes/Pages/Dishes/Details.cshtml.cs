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
    public class DetailsModel : PageModel
    {
        private readonly ChefsAndDishes.Data.KitchenContext _context;

        public DetailsModel(ChefsAndDishes.Data.KitchenContext context)
        {
            _context = context;
        }

        public Dish Dish { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Dish = await _context.Dishes.FirstOrDefaultAsync(m => m.ID == id);

            if (Dish == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
