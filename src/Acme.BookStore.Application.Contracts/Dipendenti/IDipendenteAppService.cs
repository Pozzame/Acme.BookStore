using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Dipendenti;

public interface IDipendenteAppService : IApplicationService
{
    Task<DipendenteDto> GetAsync(Guid id);

    Task<PagedResultDto<DipendenteDto>> GetListAsync(GetDipendenteListDto input);

    Task<DipendenteDto> CreateAsync(CreateDipendenteDto input);

    Task UpdateAsync(Guid id, UpdateDipendenteDto input);

    Task DeleteAsync(Guid id);
}