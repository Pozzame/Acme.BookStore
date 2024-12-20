using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Clienti;

public interface IClienteRepository : IRepository<Cliente, Guid>
{
    Task<Cliente> FindByNameAsync(string name);

    Task<List<Cliente>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}