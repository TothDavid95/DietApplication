using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Models
{
    [MetadataType(typeof(DecoratedUser))]
    public partial class User
    {
        public class DecoratedUser
        {
            [Display(Name = "Felhasználónév")]
            public string UserName { get; set; }
            [Display(Name = "E-mail cím")]
            public string Email { get; set; }
            [Display(Name = "Jelszó")]
            public string Password { get; set; }
            [Display(Name = "Allergia")]
            public virtual ICollection<Allergy> Allergy { get; set; }
        }
    }

    [MetadataType(typeof(DecoratedFood))]
    public partial class Food
    {
        public class DecoratedFood
        {
            [Display(Name = "Név")]
            public string Name { get; set; }
            [Display(Name = "Energia<br>(kJ&nbsp;/&nbsp;100g)")]
            public int Energy_kJ { get; set; }
            [Display(Name = "Energia<br>(kcal&nbsp;/&nbsp;100g)")]
            public int Energy_kcal { get; set; }
            [Display(Name = "Fehérje<br>(‰)")]
            public int Protein_g { get; set; }
            [Display(Name = "Zsír<br>(‰)")]
            public int Fat_g { get; set; }
            [Display(Name = "Szénhidrát<br>(‰)")]
            public int Carbohydrate_g { get; set; }
            [Display(Name = "Nátrium<br>(mg&nbsp;/&nbsp;100g)")]
            public int Sodium_mg { get; set; }
            [Display(Name = "Kálium<br>(mg&nbsp;/&nbsp;100g)")]
            public int Potassium_mg { get; set; }
            [Display(Name = "Kalcium<br>(mg&nbsp;/&nbsp;100g)")]
            public int Calcium_mg { get; set; }
            [Display(Name = "Magnézium<br>(mg&nbsp;/&nbsp;100g)")]
            public int Magnesium_mg { get; set; }
        }
    }

    [MetadataType(typeof(DecoratedAllergy))]
    public partial class Allergy
    {
        public class DecoratedAllergy
        {
            [Display(Name = "Név")]
            public string Name { get; set; }
        }
    }

    [MetadataType(typeof(DecoratedTimeOfMeal))]
    public partial class TimeOfMeal
    {
        public class DecoratedTimeOfMeal
        {
            [Display(Name = "Időpont")]
            public System.DateTime Time { get; set; }
        }
    }

    public partial class Diary
    {
        public class DecoratedDiary
        {
            [Display(Name = "Mennyiség (g)")]
            public decimal Amount_g { get; set; }
        }
    }
}