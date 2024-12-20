using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Commesse;
using Acme.BookStore.Dipendenti;
using Acme.BookStore.Permissions;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Acme.BookStore.Clienti;

public class ClienteAppService :
    CrudAppService<
        Cliente, //The Book entity
        ClienteDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateClienteDto>, //Used to create/update a book
    IClienteAppService //implement the IBookAppService
{
    private readonly IRepository<Commessa, Guid> _commessaRepository;
    public ClienteAppService(IRepository<Cliente, Guid> repository,
        IRepository<Commessa, Guid> commessaRepository)
        : base(repository)
    {
        _commessaRepository = commessaRepository;

        GetPolicyName = BookStorePermissions.Clienti.Default;
        GetListPolicyName = BookStorePermissions.Clienti.Default;
        CreatePolicyName = BookStorePermissions.Clienti.Create;
        UpdatePolicyName = BookStorePermissions.Clienti.Edit;
        DeletePolicyName = BookStorePermissions.Clienti.Delete;
    }

    public async Task<PagedResultDto<ClienteDto>> GetFullListAsync(GetClienteListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Cliente.Name);
        }

        var clienti = await Repository.GetListAsync(
            //input.SkipCount,
            //input.MaxResultCount,
            //input.Sorting,
            //input.Filter
        );


        //var queryable = await Repository.GetQueryableAsync();

        //var clienti = await AsyncExecuter.ToListAsync(
        //    queryable
        //        .WhereIf(!input.Filter.IsNullOrWhiteSpace(), x => x.Name.Contains(input.Filter))
        //        .OrderBy(x => EF.Property<object>(x, input.Sorting))
        //        .Skip(input.SkipCount)
        //        .Take(input.MaxResultCount)
        //);

        var totalCount = input.Filter == null
            ? await Repository.CountAsync()
            : await Repository.CountAsync(
                cliente => cliente.Name.Contains(input.Filter));

        List<ClienteDto> clientiDto = ObjectMapper.Map<List<Cliente>, List<ClienteDto>>(clienti);

        IQueryable<Commessa> commesseQueryable = await _commessaRepository.GetQueryableAsync();
        
        foreach (ClienteDto clienteDto in clientiDto)
        {
            clienteDto.Commesse = await commesseQueryable
                .Where(c => c.ClienteId == clienteDto.Id)
                .Select(c => c.Nome)  // Questo seleziona direttamente il nome
                .ToListAsync();
        }

        return new PagedResultDto<ClienteDto>(
            totalCount,
            clientiDto
        );
    }
}
