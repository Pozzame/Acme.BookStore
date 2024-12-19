using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Commesse;
using Acme.BookStore.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Reflection.Metadata.BlobBuilder;

namespace Acme.BookStore.Dipendenti;

[Authorize(BookStorePermissions.Dipendenti.Default)]
public class DipendenteAppService : BookStoreAppService, IDipendenteAppService
{
    private readonly IDipendenteRepository _dipendenteRepository;
    private readonly IRepository<DipendenteCommessa, Guid> _dipendenteCommessaRepository;
    private readonly IRepository<Commessa, Guid> _commessaRepository;
    private readonly DipendenteManager _dipendenteManager;

    public DipendenteAppService(
        IDipendenteRepository dipendenteRepository,
        DipendenteManager dipendenteManager,
        IRepository<DipendenteCommessa, Guid> dipendenteCommessaRepository, 
        IRepository<Commessa, Guid> commessaRepository)
    {
        _dipendenteRepository = dipendenteRepository;
        _dipendenteManager = dipendenteManager;
        _dipendenteCommessaRepository = dipendenteCommessaRepository;
        _commessaRepository = commessaRepository;
    }

    //...SERVICE METHODS WILL COME HERE...
    public async Task<DipendenteDto> GetAsync(Guid id)
    {
        // Otteniamo il dipendente e lo mappiamo al DTO
        Dipendente dipendente = await _dipendenteRepository.GetAsync(id);
        DipendenteDto dipendenteDto = ObjectMapper.Map<Dipendente, DipendenteDto>(dipendente);

        // Otteniamo gli IQueryable in modo asincrono
        var dipendenteCommessaQueryable = await _dipendenteCommessaRepository.GetQueryableAsync();
        var commessaQueryable = await _commessaRepository.GetQueryableAsync();

        // Costruiamo la query e la eseguiamo usando i metodi di ABP
        dipendenteDto.Commesse = (await dipendenteCommessaQueryable
            .Where(dc => dc.DipendenteId == id)
            .Join(
                commessaQueryable,
                dc => dc.CommessaId,
                c => c.Id,
                (dc, c) => c.Nome
            )
            .ToListAsync())  // Questo ToListAsync viene da System.Linq
            .ToList();       // Convertiamo il risultato in List<string>
        Console.WriteLine(dipendenteDto);
        return dipendenteDto;
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

        List<DipendenteDto> dipendentiDto = ObjectMapper.Map<List<Dipendente>, List<DipendenteDto>>(dipendenti);

        var dipendenteCommessaQueryable = await _dipendenteCommessaRepository.GetQueryableAsync();
        var commessaQueryable = await _commessaRepository.GetQueryableAsync();

        foreach (DipendenteDto dipendenteDto in dipendentiDto) {
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

        return new PagedResultDto<DipendenteDto>(
            totalCount,
            dipendentiDto
        );
    }
    [Authorize(BookStorePermissions.Dipendenti.Create)]
    public async Task<DipendenteDto> CreateAsync(CreateDipendenteDto input)
    {
        var dipendente = await _dipendenteManager.CreateAsync(
            input.Name,
            input.Surname,
            input.BirthDate,
            input.StartDate,
            input.HourlyRate
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
        dipendente.StartDate = input.StartDate;
        dipendente.HourlyRate = input.HourlyRate;

        await _dipendenteRepository.UpdateAsync(dipendente);
    }
    [Authorize(BookStorePermissions.Dipendenti.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _dipendenteRepository.DeleteAsync(id);
    }
}