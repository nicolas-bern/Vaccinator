using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Vaccinator.Models
{
    public class Injection
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public Personne Personne { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public Vaccin Vaccin { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public int Lot { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Date d'administration du vaccin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAdministration { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Date de rappel du vaccin")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateRappel { get; set; }

        public Injection()
        {
            
        }
    }
}
