using Acme.BookStore.Authors;
using Acme.BookStore.Books;
using Acme.BookStore.Dipendenti;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {


        ADD a NEW MAPPING
        CreateMap<Pages.Dipendenti.CreateModalModel.CreateDipendenteViewModel,
                    CreateDipendenteDto>();

        ADD THESE NEW MAPPINGS
        CreateMap<DipendenteDto, Pages.Dipendenti.EditModalModel.EditDipendenteViewModel>();
        CreateMap<Pages.Dipendenti.EditModalModel.DipendenteViewModel,
                    DipendenteDto>();
    }
}
