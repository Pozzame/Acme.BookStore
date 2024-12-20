using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Clienti;
using Acme.BookStore.Commesse;
using Acme.BookStore.Dipendenti;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore;

public class BookStoreDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IDipendenteRepository _dipendenteRepository;
    private readonly DipendenteManager _dipendenteManager;
    private readonly IRepository<Cliente, Guid> _clienteRepository;
    private readonly IRepository<Commessa, Guid> _commessaRepository;
    private readonly IRepository<DipendenteCommessa, Guid> _dipendenteCommessaRepository;

    public BookStoreDataSeederContributor(
        IDipendenteRepository dipendenteRepository,
        DipendenteManager dipendenteManager,
        IRepository<Cliente, Guid> clienteRepository,
        IRepository<Commessa, Guid> commessaRepository,
        IRepository<DipendenteCommessa, Guid> dipendenteCommessaRepository)
    {
        _dipendenteManager = dipendenteManager;
        _dipendenteRepository = dipendenteRepository;
        _commessaRepository = commessaRepository;
        _clienteRepository = clienteRepository;
        _dipendenteCommessaRepository = dipendenteCommessaRepository;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _dipendenteRepository.GetCountAsync() <= 0)
        {
            var ciuccio = await _dipendenteRepository.InsertAsync(
                await _dipendenteManager.CreateAsync(
                    "Ciuccio",
                    "Ciuccione",
                    new DateTime(1992, 03, 11),
                    new DateTime(2012, 03, 11),
                    10
                )
            );
            var antani = await _dipendenteRepository.InsertAsync(
                await _dipendenteManager.CreateAsync(
                    "Antani",
                    "Pisquano",
                    new DateTime(1992, 03, 11),
                    new DateTime(2012, 03, 11),
                    12
                )
            );
        }

        if (await _clienteRepository.GetCountAsync() <= 0)
        {
           await _clienteRepository.InsertAsync(
                new Cliente
                {
                    Name = "Syntia",
                    //CommesseId = new List<Guid> { Guid.Parse("6322a357-bb7b-4e8a-fd0f-3a16f283ece8") }
                },
            autoSave: true
            );
            await _clienteRepository.InsertAsync(
                new Cliente
                {
                    Name = "ASTS",
                    //CommesseId = new List<Guid>()
                },
            autoSave: true
            );
        }

        if (await _commessaRepository.GetCountAsync() <= 0)
        {
            await _commessaRepository.InsertAsync(
                new Commessa
                {
                    Nome = "Ferrovia",
                    Tipologia = Tipologia.AProgetto,
                    ClienteId = Guid.Parse("78136bc9-7630-8663-fe24-3a16f3d35e8e"),
                    Totale = 0,
                    IsActive = false
                },
                autoSave: true
                );
            await _commessaRepository.InsertAsync(
                new Commessa
                {
                    Nome = "Cuccelleria",
                    Tipologia = Tipologia.AProgetto,
                    Totale = 0,
                    IsActive = true
                },
                autoSave: true
            );
        }

        if (await _dipendenteCommessaRepository.GetCountAsync() <= 0)
        {
            await _dipendenteCommessaRepository.InsertAsync(
                new DipendenteCommessa
                {
                    DipendenteId = Guid.Parse("b9c39ac9-3c89-efbd-0c88-3a16f3d35e6e"),
                    CommessaId = Guid.Parse("9150b291-05b9-cb4a-56ce-3a16f3d534b3"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
        }
    }
}