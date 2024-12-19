using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Commesse;
using Acme.BookStore.Dipendenti;
using Acme.BookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

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

    public async Task<PagedResultDto<ClienteDto>> GetListAsync(GetClienteListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Cliente.Name);
        }

        var dipendenti = await repository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
        input.Filter
        );
        var totalCount = input.Filter == null
            ? await _dipendenteRepository.CountAsync()
            : await _dipendenteRepository.CountAsync(
                dipendente => dipendente.Name.Contains(input.Filter));

        List<DipendenteDto> dipendentiDto = ObjectMapper.Map<List<Dipendente>, List<DipendenteDto>>(dipendenti);

        var dipendenteCommessaQueryable = await _dipendenteCommessaRepository.GetQueryableAsync();
        var commessaQueryable = await _commessaRepository.GetQueryableAsync();

        foreach (DipendenteDto dipendenteDto in dipendentiDto)
        {
            dipendenteDto.Commesse = (await dipendenteCommessaQueryable
            .Where(dc => dc.DipendenteId == dipendenteDto.Id)
            .Join(
                commessaQueryable,
                dc => dc.CommessaId,
                c => c.Id,
                (dc, c) => c.Nome
            )
            .ToListAsync())  // Questo ToListAsync viene da System.Linq
            .ToList();       // Convertiamo il risultato in List<string>
        }
    }
