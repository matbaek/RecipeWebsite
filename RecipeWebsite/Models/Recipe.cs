using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class Recipe
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Fremgangsmåde:")]
        public string Description { get; set; }
        [Display(Name = "Navn:")]
        public string Username { get; set; }
        public DateTime PostingDate { get; set; }
        [Display(Name = "Ingredienser:")]
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        [Display(Name = "Kommentarer:")]
        public ICollection<Comment> Comments { get; set; }
        public double finalRatingScore {
            get
            {
                double tempScore = 0;
                foreach(var rate in Ratings)
                {
                    tempScore += rate.Score;
                }
                return tempScore / Ratings.Count;
            }
        } 
    }
}
