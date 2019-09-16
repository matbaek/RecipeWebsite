using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebsite.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public int RecipeID { get; set; }
        [Display(Name = "Kommentar:")]
        public string Description { get; set; }
        [Display(Name = "Navn:")]
        public string Username { get; set; }
    }
}
