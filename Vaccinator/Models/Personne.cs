using System;
using System.ComponentModel.DataAnnotations;

namespace Vaccinator.Models
{
    public class Personne
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50)]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [MaxLength(50)]
        public string Prenom { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public string Sexe { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Date de naissance")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Est un membre du personnel ?")]
        public bool IsResident { get; set; }



        public Personne()
        {

        }
    }
}
