﻿using System.ComponentModel.DataAnnotations;

namespace Semesterprojekt.Models
{
    public class Person
    {

        [Display(Name = "Navn")]
        [Required(ErrorMessage = "Du skal angive dit navn")]
        public string? Navn { get; set; }
        [Display(Name = "Alder")]
        [Required(ErrorMessage = "Du skal angive din alder")]
        public int? Alder { get; set; }
        [Display(Name = "Telefonnummer")]
        [Required(ErrorMessage = "Du skal angive dit telefonnummer")]
        public int? Telefonnummer { get; set; }
        [Display(Name = "Adresse")]
        [Required(ErrorMessage = "Du skal angive din adresse")]
        public string? Adresse { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Du skal angive din email")]
        public string? Email { get; set; }
        public Person()
        {
        }
        public Person(string navn, int alder, int telefonnummer, string adresse, string email)
        {
            Navn = navn;
            Alder = alder;
            Telefonnummer = telefonnummer;
            Adresse = adresse;
            Email = email;
        }

    }
}
