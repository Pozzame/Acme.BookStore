using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Dipendenti;

public class UpdateDipendenteDto
{
    [Required]
    [StringLength(DipendenteConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(DipendenteConsts.MaxNameLength)]
    public string Surname { get; set; } = string.Empty;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Currency)]
    public decimal? HourlyRate { get; set; }
}