using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Dipendenti
{
    public class DipendenteCommessa : AuditedEntity<Guid>
    {
        public Guid DipendenteId { get; set; }
        public Guid CommessaId { get; set; }
        public Ruoli Ruolo { get; set; }
        public int MonteOre { get; set; }
    }
}
