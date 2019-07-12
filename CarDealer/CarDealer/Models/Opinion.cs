using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace CarDealer.Models
{
    public class Opinion
    {
        [BindNever]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        [StringLength(100, ErrorMessage = "Nazwa użytkownika jest za długa")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Adres email jest wymagany")]
        [StringLength(100, ErrorMessage ="Adres email jest za długi")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "To nie jest adres email")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Wiadomość jest wymagana")]
        [StringLength(5000, ErrorMessage = "Wiadomość jest za długa")]
        public string Message { get; set; }

        public bool RequireAnswer { get; set; }


    }
}
