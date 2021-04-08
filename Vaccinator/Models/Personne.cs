﻿using System;
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateNaissance { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [Display(Name = "Membre du personnel")]
        public bool IsResident { get; set; }



        public Personne()
        {

        }
    }
}
