﻿

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace VaabenbogenConsumer.Models
{
    public class Vaaben
    {
        public int Id { get; set; }
        public string Navn { get; set; } 
        public string Fabrikant { get; set; }
        [Display(Name = "Ladefunktion")]
        public Ladefunktion? Ladefunktion { get; set; }
        [Display(Name = "Ladefunktion fritekst")]
        public string? LadefunktionFritekst { get; set; }
        [Display(Name = "Løbenummer")]
        public string Loebenummer { get; set; }
        [Display(Name = "Våben type")]
        public VaabenType Type { get; set; }
        [Display(Name = "Våben status")]
        public VaabenStatus Status { get; set; }
        [Display(Name = "Oprettet")]
        public DateTime? Created { get; set; }
        [Display(Name = "Oprettet af")]
        public string? CreatedBy { get; set; }
        [Display(Name ="Opdateret")]
        public DateTime? Updated { get; set; }
        [Display(Name = "Opdateret af")]
        public string? UpdatedBy { get; set; }
        [Display(Name = "Udskrevet")]
        public bool? IsUdskrevet { get; set; }
        public DateTime? Udskrevet { get; set; }
        [ValidateNever]
        public Ejer Indskriver { get; set; }
        [Display(Name = "Udskrevet til")]
        public Ejer? UdskrevetTil {  get; set; }

        public Vaaben()
        {
            Created = DateTime.UtcNow;
            IsUdskrevet = false;
            Navn = "";
            Fabrikant = "";
            Loebenummer = "00001";
            Indskriver = new Ejer();
        }

        public Vaaben(int id, string navn, string fabrikant, Ladefunktion ladefunktion, string loebenummer, VaabenType type, VaabenStatus status, Ejer indskriver)
        {
            Id = id;
            Navn = navn ?? throw new ArgumentNullException(nameof(navn));
            Fabrikant = fabrikant ?? throw new ArgumentNullException(nameof(fabrikant));
            Ladefunktion = ladefunktion;
            Loebenummer = loebenummer ?? throw new ArgumentNullException(nameof(loebenummer));
            Type = type;
            Status = status;
            Created = DateTime.UtcNow;
            IsUdskrevet = false;
            Indskriver = indskriver;
        }
    }

    public enum VaabenType
    {
        Haglgevær = 0,
        Pibe = 1,
        Riffel = 2,
    }

    public enum VaabenStatus
    {
        [Display(Name = "Køb og salg")]
        KoebOgSalg = 0,
        Reparation = 2,
        Opbevaring = 3,
        Kommision = 4,
    }

    public enum Ladefunktion
    {
        Enkeltlader = 0,
        Repeter = 1,
        Halvautomatisk = 2
    }
}
