using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Commesse;

public class CreateUpdateCommessaDto
{
    [Required(ErrorMessage = "Il nome della commessa è obbligatorio")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "La tipologia è obbligatoria")]
    public Tipologia Tipologia { get; set; }

    [Required(ErrorMessage = "Il cliente è obbligatorio")]
    public Guid ClienteId { get; set; }

    [Required(ErrorMessage = "Il totale è obbligatorio")]
    public decimal Totale { get; set; }

    public bool IsActive { get; set; }
}
