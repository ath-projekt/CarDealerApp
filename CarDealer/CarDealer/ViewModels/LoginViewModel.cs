using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Przed zalogowaniem podaj nazwę użytkownika!")]
        [Display(Name = "Nazwa użytkownika")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Przed zalogowaniem podaj hasło!")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
