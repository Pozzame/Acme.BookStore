using System;
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
    public ClienteAppService(IRepository<Cliente, Guid> repository)
        : base(repository)
    {
        GetPolicyName = BookStorePermissions.Clienti.Default;
        GetListPolicyName = BookStorePermissions.Clienti.Default;
        CreatePolicyName = BookStorePermissions.Clienti.Create;
        UpdatePolicyName = BookStorePermissions.Clienti.Edit;
        DeletePolicyName = BookStorePermissions.Clienti.Delete;
    }
}
