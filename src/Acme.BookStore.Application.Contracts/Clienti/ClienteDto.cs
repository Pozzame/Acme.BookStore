using System;
using System.Collections.Generic;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Clienti;

public class ClienteDto : AuditedEntityDto<Guid>
{
    public string Name { get; set; }
    public List<string>? Commesse { get; set; }
}