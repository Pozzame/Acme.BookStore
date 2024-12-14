using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Dipendenti;

public class GetDipendenteListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}