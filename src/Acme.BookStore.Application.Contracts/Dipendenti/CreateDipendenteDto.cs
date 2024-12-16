using System;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Dipendenti;

public class CreateDipendenteDto
{
    [Required]
    [StringLength(DipendenteConsts.MaxNameLength)]
    public string Name { get; set; }
    [Required]
    [StringLength(DipendenteConsts.MaxNameLength)]
    public string Surname { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [DataType(DataType.Currency)]
    public decimal? HourlyRate { get; set; }
}