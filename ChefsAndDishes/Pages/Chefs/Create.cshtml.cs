using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChefsAndDishes.Data;
using ChefsAndDishes.Models;

namespace ChefsAndDishes.Pages.Chefs
{
    public class CreateModel : PageModel
    {
        private readonly ChefsAndDishes.Data.KitchenContext _context;

        public CreateModel(ChefsAndDishes.Data.KitchenContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Chef Chef { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Chefs.Add(Chef);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
