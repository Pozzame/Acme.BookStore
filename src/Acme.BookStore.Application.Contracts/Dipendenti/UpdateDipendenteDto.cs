using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Dipendenti;

public class UpdateDipendenteDto
{
    [Required]
    [StringLength(DipendenteConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }

    public string? ShortBio { get; set; }
}