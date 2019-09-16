﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Recipes
{
    public class IndexModel : PageModel
    {
        private readonly RecipeWebsite.Models.RecipeWebsiteContext _context;

        public IndexModel(RecipeWebsite.Models.RecipeWebsiteContext context)
        {
            _context = context;
        }

        public IList<Recipe> Recipe { get;set; }

        public async Task OnGetAsync()
        {
            Recipe = await _context.Recipes.Include(r => r.Ratings).ToListAsync();
        }
    }
}
