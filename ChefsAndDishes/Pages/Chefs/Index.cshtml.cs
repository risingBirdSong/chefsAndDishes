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
    public class IndexModel : PageModel
    {
        private readonly ChefsAndDishes.Data.KitchenContext _context;

        public IndexModel(ChefsAndDishes.Data.KitchenContext context)
        {
            _context = context;
        }

        public IList<Chef> Chef { get;set; }

        public async Task OnGetAsync()
        {
            Chef = await _context.Chefs.ToListAsync();
        }
    }
}
