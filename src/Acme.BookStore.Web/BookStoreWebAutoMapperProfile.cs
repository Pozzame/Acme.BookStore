using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Dipendenti;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project
        CreateMap<BookDto, CreateUpdateBookDto>();

        // ADD a NEW MAPPING
        CreateMap<Pages.Authors.CreateModalModel.CreateAuthorViewModel,
                    CreateAuthorDto>();

        // ADD THESE NEW MAPPINGS
        CreateMap<AuthorDto, Pages.Authors.EditModalModel.EditAuthorViewModel>();
        CreateMap<Pages.Authors.EditModalModel.EditAuthorViewModel,
                    UpdateAuthorDto>();

        CreateMap<Pages.Books.CreateModalModel.CreateBookViewModel, CreateUpdateBookDto>();
        CreateMap<BookDto, Pages.Books.EditModalModel.EditBookViewModel>();
        CreateMap<Pages.Books.EditModalModel.EditBookViewModel, CreateUpdateBookDto>();


        // ADD a NEW MAPPING
        //CreateMap<Pages.Dipendenti.CreateModalModel.CreateDipendenteViewModel,
        //            CreateDipendenteDto>();

        // ADD THESE NEW MAPPINGS
        //CreateMap<DipendenteDto, Pages.Dipendenti.EditModalModel.EditDipendenteViewModel>();
        //CreateMap<Pages.Dipendenti.EditModalModel.DipendenteViewModel,
        //            DipendenteDto>();
    }
}
