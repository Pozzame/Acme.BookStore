
using Acme.BookStore.Clienti;
using Acme.BookStore.Commesse;
using Acme.BookStore.Dipendenti;
using AutoMapper;

namespace Acme.BookStore;

public class BookStoreApplicationAutoMapperProfile : Profile
{
    public BookStoreApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Dipendente, DipendenteDto>();
        CreateMap<Cliente, ClienteDto>();
        CreateMap<Commessa, CommessaDto>();
        CreateMap<CreateUpdateClienteDto, Cliente>();
        CreateMap<CreateUpdateCommessaDto, Commessa>();
    }
}
