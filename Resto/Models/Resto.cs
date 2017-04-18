using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Resto.Models
{

    [Table("Restos")]
    public class Resto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "le nom  du restaurant doit être rempli")]
        public string Nom { get; set; }

        [Display(Name ="Téléphone")]
        [RegularExpression(@"^0[0-9]{9}$",  ErrorMessage = "Le numéro de téléphone est incorrecte")]
        public string Telephone { get; set; }

        public bool Selected { get; set; }
    }
}