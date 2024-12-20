using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Clienti;

public class GetClienteListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}