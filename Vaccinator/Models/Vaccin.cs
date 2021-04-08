using System;
using System.ComponentModel.DataAnnotations;

namespace Vaccinator.Models
{
    public class Vaccin
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50)]
        [Display(Name = "Type de vaccin")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50)]
        [Display(Name = "Laboratoire")]
        public string Marque { get; set; }

        public Vaccin()
        {

        }
    }
}
