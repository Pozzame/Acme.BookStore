﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Clienti
{
    public class Cliente : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }
        public List<Guid>? CommesseId { get; set; }
    }
}
