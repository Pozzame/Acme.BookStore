using System;
using Acme.BookStore.Clienti;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Microsoft.EntityFrameworkCore;

namespace Acme.BookStore.Commesse;

public class CommessaAppService :
    CrudAppService<
        Commessa, //The Book entity
        CommessaDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCommessaDto>, //Used to create/update a book
    ICommessaAppService //implement the IBookAppService
{
    private readonly IRepository<Cliente, Guid> _clienteRepository;
    public CommessaAppService(IRepository<Commessa, Guid> repository,
        IRepository<Cliente, Guid> clienteRepository)
        : base(repository)
    {
        _clienteRepository = clienteRepository;

        GetPolicyName = BookStorePermissions.Commesse.Default;
        GetListPolicyName = BookStorePermissions.Commesse.Default;
        CreatePolicyName = BookStorePermissions.Commesse.Create;
        UpdatePolicyName = BookStorePermissions.Commesse.Edit;
        DeletePolicyName = BookStorePermissions.Commesse.Delete;
    }

    public async Task<PagedResultDto<CommessaDto>> GetFullListAsync(PagedAndSortedResultRequestDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Commessa.Nome);
        }

        var commesse = await Repository.GetListAsync();

        List<CommessaDto> commesseDto = ObjectMapper.Map<List<Commessa>, List<CommessaDto>>(commesse);

        IQueryable<Cliente> clientiQueryable = await _clienteRepository.GetQueryableAsync();

        foreach (CommessaDto commessaDto in commesseDto)
        {
            commessaDto.Cliente = await clientiQueryable
                .Where(c => c.Id == commessaDto.ClienteId)
                .Select(c => c.Name)
                .FirstOrDefaultAsync();  // Questo seleziona direttamente il nome
        }

        return new PagedResultDto<CommessaDto>(
            await Repository.CountAsync(),
            commesseDto
        );
    }
}
