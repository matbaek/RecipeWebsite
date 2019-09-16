using RecipeWebsite.Data;
using RecipeWebsite.Models;
using System;
using System.Linq;

namespace RecipeWebsite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RecipeWebsiteContext context)
        {
            context.Database.EnsureCreated();

            if (context.Recipes.Any())
            {
                return;   // DB has been seeded
            }

            var recipes = new Recipe[]
            {
                new Recipe{Name="Pandekager", Description="Dette er panderkager, daaah", Username="Mathias", PostingDate=DateTime.Parse("2019-09-01")},
                new Recipe{Name="Pandekager2", Description="Dette er panderkager, daaah", Username="Mathias2", PostingDate=DateTime.Parse("2019-09-02")},
                new Recipe{Name="Pandekager3", Description="Dette er panderkager, daaah", Username="Mathias3", PostingDate=DateTime.Parse("2019-09-03")}
            };
            foreach (Recipe r in recipes)
            {
                context.Recipes.Add(r);
            }
            context.SaveChanges();

            var ingredients = new Ingredient[]
            {
                new Ingredient{RecipeID=1, Amount=200, Unit="g", Name="Mel"},
                new Ingredient{RecipeID=1, Amount=100, Unit="g", Name="Sukker"},
                new Ingredient{RecipeID=2, Amount=100, Unit="g", Name="Sukker"},
                new Ingredient{RecipeID=3, Amount=100, Unit="g", Name="Sukker"}
            };
            foreach (Ingredient c in ingredients)
            {
                context.Ingredients.Add(c);
            }
            context.SaveChanges();

            var ratings = new Rating[]
            {
                new Rating{RecipeID=1, Score=4},
                new Rating{RecipeID=1, Score=5},
                new Rating{RecipeID=1, Score=1},
                new Rating{RecipeID=2, Score=0},
                new Rating{RecipeID=3, Score=1}
            };
            foreach (Rating r in ratings)
            {
                context.Ratings.Add(r);
            }
            context.SaveChanges();

            var comments = new Comment[]
            {
                new Comment{RecipeID=1, Description="Dette er de bedste pandekager evaaaaar!", Username="Hans"}
            };
            foreach (Comment c in comments)
            {
                context.Comments.Add(c);
            }
            context.SaveChanges();
        }
    }
}