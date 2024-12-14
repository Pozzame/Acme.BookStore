using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Dipendenti;

[Authorize(BookStorePermissions.Dipendenti.Default)]
public class DipendenteAppService : BookStoreAppService, IDipendenteAppService
{
    private readonly IDipendenteRepository _dipendenteRepository;
    private readonly DipendenteManager _dipendenteManager;

    public DipendenteAppService(
        IDipendenteRepository dipendenteRepository,
        DipendenteManager dipendenteManager)
    {
        _dipendenteRepository = dipendenteRepository;
        _dipendenteManager = dipendenteManager;
    }

    //...SERVICE METHODS WILL COME HERE...
    public async Task<DipendenteDto> GetAsync(Guid id)
    {
        var dipendente = await _dipendenteRepository.GetAsync(id);
        return ObjectMapper.Map<Dipendente, DipendenteDto>(dipendente);
    }
    public async Task<PagedResultDto<DipendenteDto>> GetListAsync(GetDipendenteListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Dipendente.Name);
        }

        var dipendenti = await _dipendenteRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _dipendenteRepository.CountAsync()
            : await _dipendenteRepository.CountAsync(
                dipendente => dipendente.Name.Contains(input.Filter));

        return new PagedResultDto<DipendenteDto>(
            totalCount,
            ObjectMapper.Map<List<Dipendente>, List<DipendenteDto>>(dipendenti)
        );
    }
    [Authorize(BookStorePermissions.Dipendenti.Create)]
    public async Task<DipendenteDto> CreateAsync(CreateDipendenteDto input)
    {
        var dipendente = await _dipendenteManager.CreateAsync(
            input.Name,
            input.BirthDate,
            input.ShortBio
        );

        await _dipendenteRepository.InsertAsync(dipendente);

        return ObjectMapper.Map<Dipendente, DipendenteDto>(dipendente);
    }
    [Authorize(BookStorePermissions.Dipendenti.Edit)]
    public async Task UpdateAsync(Guid id, UpdateDipendenteDto input)
    {
        var dipendente = await _dipendenteRepository.GetAsync(id);

        if (dipendente.Name != input.Name)
        {
            await _dipendenteManager.ChangeNameAsync(dipendente, input.Name);
        }

        dipendente.BirthDate = input.BirthDate;
        dipendente.ShortBio = input.ShortBio;

        await _dipendenteRepository.UpdateAsync(dipendente);
    }
    [Authorize(BookStorePermissions.Dipendenti.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _dipendenteRepository.DeleteAsync(id);
    }

}