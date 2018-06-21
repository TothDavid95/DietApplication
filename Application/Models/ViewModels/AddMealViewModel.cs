using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Models.ViewModels
{
    public class AddMealViewModel
    {
        public List<int> Idlist { get; set; }
        [Required]
        [Display(Name = "Étel")]
        public List<string> FoodName { get; set; }
        [Required]
        [Display(Name = "Mennyiség (gramm)")]
        public List<int> Amount_g { get; set; }
        [Required]
        [Display(Name = "Étkezés időpontja")]
        public DateTime DateOfMeal { get; set; }
    }
}