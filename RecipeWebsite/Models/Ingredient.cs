using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }
        public string Name { get; set; }
    }
}
