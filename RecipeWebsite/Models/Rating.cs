using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class Rating
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        public double Score { get; set; }
    }
}
