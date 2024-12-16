using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Dipendenti;

public interface IDipendenteRepository : IRepository<Dipendente, Guid>
{
    Task<Dipendente> FindByNameAsync(string name);
    Task<Dipendente> FindBySurnameAsync(string surname);

    Task<List<Dipendente>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}