using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Acme.BookStore.Clienti;

public class CreateUpdateClienteDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public List<Guid> CommesseId { get; set; }
}
