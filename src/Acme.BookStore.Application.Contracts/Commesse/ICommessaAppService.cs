using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.BookStore.Commesse;

public interface ICommessaAppService :
    ICrudAppService< //Defines CRUD methods
        CommessaDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCommessaDto> //Used to create/update a book
{

}
