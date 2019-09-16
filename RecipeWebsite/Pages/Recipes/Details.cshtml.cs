using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RecipeWebsite.Models;

namespace RecipeWebsite.Pages.Recipes
{
    public class DetailsModel : PageModel
    {
        private readonly RecipeWebsite.Models.RecipeWebsiteContext _context;

        public DetailsModel(RecipeWebsite.Models.RecipeWebsiteContext context)
        {
            _context = context;
        }

        public Recipe Recipe { get; set; }
        public Comment Comment { get; set; }
        public Rating Rating { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes.Include(i => i.Ingredients).Include(r => r.Ratings).Include(c => c.Comments).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Recipe == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(Request.Form["Type"] == "Comment")
            {
                Comment = new Comment { Username = Request.Form["CommentUsername"], Description = Request.Form["CommentDescription"], RecipeID = int.Parse(Request.Form["CommentRecipeID"]) };

                _context.Comments.Add(Comment);
            }
            else if(Request.Form["Type"] == "Rating")
            {
                Rating = new Rating { Score = int.Parse(Request.Form["Rating"]), RecipeID = int.Parse(Request.Form["RatingRecipeID"]) };

                _context.Ratings.Add(Rating);
            }

            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
