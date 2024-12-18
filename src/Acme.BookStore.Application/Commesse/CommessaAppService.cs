using System;
using Acme.BookStore.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

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
    public CommessaAppService(IRepository<Commessa, Guid> repository)
        : base(repository)
    {
        GetPolicyName = BookStorePermissions.Commesse.Default;
        GetListPolicyName = BookStorePermissions.Commesse.Default;
        CreatePolicyName = BookStorePermissions.Commesse.Create;
        UpdatePolicyName = BookStorePermissions.Commesse.Edit;
        DeletePolicyName = BookStorePermissions.Commesse.Delete;
    }
}
