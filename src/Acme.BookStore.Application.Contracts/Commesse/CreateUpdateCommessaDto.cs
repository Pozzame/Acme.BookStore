using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Commesse;

public class CreateUpdateCommessaDto
{
    [Required]
    [StringLength(128)]
    public string Nome { get; set; } = string.Empty;

    [Required]
    public Tipologia Tipologia { get; set; } = Tipologia.Indefinito;

    [Required]
    public Guid Cliente { get; set; }

    [Required]
    public decimal Totale { get; set; }
    [Required]
    public List<Guid> Dipendenti { get; set; }
    [Required]
    public bool IsActive { get; set; }
}
