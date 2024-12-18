using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Commesse
{
    public class Commessa : FullAuditedAggregateRoot<Guid>
    {
        public string Nome {  get; set; }
        public Tipologia Tipologia { get; set; }
        //public PianoDiFatturazione Piano{ get; set; }
        public Guid Cliente { get; set; }
        public decimal Totale { get; set; }
        public List<Guid> Dipendenti { get; set; }
        public bool IsActive { get; set; }

    }
}
