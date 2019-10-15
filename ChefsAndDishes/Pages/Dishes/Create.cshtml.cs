using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChefsAndDishes.Data;
using ChefsAndDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsAndDishes.Pages.Dishes
{
    public class CreateModel : HavingDropDown
    {
        private readonly ChefsAndDishes.Data.KitchenContext _context;

      

        public CreateModel(ChefsAndDishes.Data.KitchenContext context)
        {
            _context = context;
        }

        public IList<Chef> AllChefs { get; set; }

        public IActionResult OnGet()
        {
            PopulateDropDown(_context);
            return Page();
        }

        [BindProperty]
        public Dish Dish { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var stop = true;
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Dishes.Add(Dish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
