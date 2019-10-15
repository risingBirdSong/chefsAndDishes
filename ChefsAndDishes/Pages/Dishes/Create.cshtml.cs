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
            var emptyDish = new Dish();

            if (await TryUpdateModelAsync<Dish>(
                emptyDish,
                "dish",
                s => s.Name, s => s.NumOfCals, s => s.Tastiness, s => s.Tastiness, s => s.ChefID, s => s.Description, s => s.MyChef
                ))

              emptyDish.MyChef = _context.Chefs.FirstOrDefault(c => c.ID == emptyDish.ChefID);
            { 
            _context.Dishes.Add(emptyDish);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            }

            PopulateDropDown(_context, emptyDish.ChefID);
            return Page();

        }
    }
}
