using System;
using System.Collections.Generic;
using Acme.BookStore.Commesse;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Commesse;

public class CommessaDto : AuditedEntityDto<Guid>
{
    public string Nome { get; set; }

    public Tipologia Tipologia { get; set; }

    public string Cliente { get; set; }
    public Guid ClienteId { get; set; }

    public decimal Totale { get; set; }
    //public List<Guid>? Dipendenti { get; set; }
    public bool IsActive { get; set; }
}
