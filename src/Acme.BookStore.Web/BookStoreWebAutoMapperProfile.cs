
using Acme.BookStore.Dipendenti;
using AutoMapper;

namespace Acme.BookStore.Web;

public class BookStoreWebAutoMapperProfile : Profile
{
    public BookStoreWebAutoMapperProfile()
    {
        //Define your object mappings here, for the Web project


        // ADD a NEW MAPPING
        CreateMap<Pages.Dipendenti.CreateModalModel.CreateDipendenteViewModel,
                    CreateDipendenteDto>();

        // ADD THESE NEW MAPPINGS
        CreateMap<DipendenteDto, Pages.Dipendenti.EditModalModel.EditDipendenteViewModel>();
        CreateMap<Pages.Dipendenti.EditModalModel.EditDipendenteViewModel,
                    UpdateDipendenteDto>();




        // ADD a NEW MAPPING
        //CreateMap<Pages.Dipendenti.CreateModalModel.CreateDipendenteViewModel,
        //            CreateDipendenteDto>();

        // ADD THESE NEW MAPPINGS
        //CreateMap<DipendenteDto, Pages.Dipendenti.EditModalModel.EditDipendenteViewModel>();
        //CreateMap<Pages.Dipendenti.EditModalModel.DipendenteViewModel,
        //            DipendenteDto>();
    }
}
