
using Acme.BookStore.Clienti;
using Acme.BookStore.Dipendenti;
using Acme.BookStore.Commesse;
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

        CreateMap<ClienteDto, CreateUpdateClienteDto>();
        CreateMap<CommessaDto, CreateUpdateCommessaDto>();
        //// ADD a NEW MAPPING
        //CreateMap<Pages.Clienti.CreateModalModel.CreateClienteViewModel,
        //            CreateClienteDto>();

        //// ADD THESE NEW MAPPINGS
        //CreateMap<ClienteDto, Pages.Clienti.EditModalModel.EditClienteViewModel>();
        //CreateMap<Pages.Clienti.EditModalModel.EditClienteViewModel,
        //            UpdateClienteDto>();

        //// ADD a NEW MAPPING
        //CreateMap<Pages.Commesse.CreateModalModel.CreateCommessaViewModel,
        //            CreateCommessaDto>();

        //// ADD THESE NEW MAPPINGS
        //CreateMap<CommessaDto, Pages.Commesse.EditModalModel.EditCommessaViewModel>();
        //CreateMap<Pages.Commesse.EditModalModel.EditCommessaViewModel,
        //            UpdateCommessaDto>();




        // ADD a NEW MAPPING
        //CreateMap<Pages.Dipendenti.CreateModalModel.CreateDipendenteViewModel,
        //            CreateDipendenteDto>();

        // ADD THESE NEW MAPPINGS
        //CreateMap<DipendenteDto, Pages.Dipendenti.EditModalModel.EditDipendenteViewModel>();
        //CreateMap<Pages.Dipendenti.EditModalModel.DipendenteViewModel,
        //            DipendenteDto>();
    }
}
