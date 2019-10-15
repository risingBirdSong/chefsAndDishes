using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ChefsAndDishes.Data;
using ChefsAndDishes.Models;

namespace ChefsAndDishes.Pages.Chefs
{
    public class DetailsModel : PageModel
    {
        private readonly ChefsAndDishes.Data.KitchenContext _context;

        public DetailsModel(ChefsAndDishes.Data.KitchenContext context)
        {
            _context = context;
        }

        public Chef Chef { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Chef = await _context.Chefs.FirstOrDefaultAsync(m => m.ID == id);

            if (Chef == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
