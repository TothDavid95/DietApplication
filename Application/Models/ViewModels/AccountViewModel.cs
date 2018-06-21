using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Models.ViewModels
{
    public class AccountViewModel
    {
        public class RegisterViewModel
        {
            [DataType(DataType.Password)]
            [Required(ErrorMessage = "{0} mező kötelező.")]
            [Compare("Password", ErrorMessage = "A két jelszó nem egyezik meg.")]
            [Display(Name = "Jelszó ismét")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} kötelező.")]
            [Display(Name = "Felhasználónév")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Az {0} mező kötelező.")]
            [EmailAddress(ErrorMessage = "Invalid e-mail cím.")]
            [Display(Name = "E-mail cím")]
            public string Email { get; set; }

            [DataType(DataType.Password)]
            [StringLength(100, ErrorMessage = "A {0}nak {2} és {1} közötti karaktermennyiséggel kell rendelkeznie.", MinimumLength = 8)]
            [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$", ErrorMessage = "A {0}nak tartalmaznia kell kis- és nagybetűt, valamint számot.")]
            [Required(ErrorMessage = "A {0} mező kötelező.")]
            [Display(Name = "Jelszó")]
            public string Password { get; set; }
        }

        public class LoginViewModel
        {
            [Required(ErrorMessage = "{0} kötelező.")]
            [Display(Name = "Felhasználónév")]
            public string UserName { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Jelszó")]
            public string Password { get; set; }
        }

        public class EditViewModel
        {
            [EmailAddress(ErrorMessage = "Invalid e-mail cím.")]
            [Display(Name = "E-mail cím")]
            public string Email { get; set; }

            [Display(Name = "Allergiák")]
            public int[] Allergies { get; set; }
        }
    }
}