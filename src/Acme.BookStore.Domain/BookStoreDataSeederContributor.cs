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
            var pepito = await _dipendenteRepository.InsertAsync(
                await _dipendenteManager.CreateAsync(
                    "Pepito",
                    "Sbezzeguti",
                    new DateTime(1992, 04, 11),
                    new DateTime(2011, 03, 11),
                    12
                )
            );
            var ciro = await _dipendenteRepository.InsertAsync(
                await _dipendenteManager.CreateAsync(
                    "Ciro",
                    "Esposito",
                    new DateTime(1982, 03, 11),
                    new DateTime(2022, 03, 11),
                    12
                )
            );
            var coso = await _dipendenteRepository.InsertAsync(
                await _dipendenteManager.CreateAsync(
                    "Coso",
                    "Altro",
                    new DateTime(1982, 03, 21),
                    new DateTime(2002, 03, 11),
                    12
                )
            );
            var primo = await _dipendenteRepository.InsertAsync(
                await _dipendenteManager.CreateAsync(
                    "Primo",
                    "Carnera",
                    new DateTime(1912, 03, 11),
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
            await _clienteRepository.InsertAsync(
                new Cliente
                {
                    Name = "Fire",
                    //CommesseId = new List<Guid> { Guid.Parse("6322a357-bb7b-4e8a-fd0f-3a16f283ece8") }
                },
            autoSave: true
            );
            await _clienteRepository.InsertAsync(
                new Cliente
                {
                    Name = "Lenovo",
                    //CommesseId = new List<Guid> { Guid.Parse("6322a357-bb7b-4e8a-fd0f-3a16f283ece8") }
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
                    ClienteId = Guid.Parse("b6a09a0a-206e-9b45-12a9-3a16f58cd5f6"),
                    Totale = 1000,
                    IsActive = false
                },
                autoSave: true
                );
            await _commessaRepository.InsertAsync(
                new Commessa
                {
                    Nome = "Cuccelleria",
                    Tipologia = Tipologia.AProgetto,
                    ClienteId = Guid.Parse("b6a09a0a-206e-9b45-12a9-3a16f58cd5f6"),
                    Totale = 10,
                    IsActive = true
                },
                autoSave: true
            );
            await _commessaRepository.InsertAsync(
                new Commessa
                {
                    Nome = "Avvocatura",
                    Tipologia = Tipologia.AProgetto,
                    ClienteId = Guid.Parse("b6a09a0a-206e-9b45-12a9-3a16f58cd5f6"),
                    Totale = 10,
                    IsActive = true
                },
                autoSave: true
            );
            await _commessaRepository.InsertAsync(
                new Commessa
                {
                    Nome = "Hornet",
                    Tipologia = Tipologia.AProgetto,
                    ClienteId = Guid.Parse("c9d38c74-6ffd-185b-4a8f-3a16f58cd643"),
                    Totale = 10,
                    IsActive = true
                },
                autoSave: true
            );
            await _commessaRepository.InsertAsync(
               new Commessa
               {
                   Nome = "Cucina",
                   Tipologia = Tipologia.AProgetto,
                   ClienteId = Guid.Parse("5ae38fda-118b-584d-0c59-3a16f58cd646"),
                   Totale = 100000,
                   IsActive = true
               },
               autoSave: true
           );
            await _commessaRepository.InsertAsync(
               new Commessa
               {
                   Nome = "Bar",
                   Tipologia = Tipologia.AProgetto,
                   Totale = 9990,
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
                    DipendenteId = Guid.Parse("32bd5565-73bd-930f-8e1e-3a16f58cd5c3"),
                    CommessaId = Guid.Parse("2e55ea43-a222-f74a-1e4f-3a16f5913f12"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
            await _dipendenteCommessaRepository.InsertAsync(
                new DipendenteCommessa
                {
                    DipendenteId = Guid.Parse("32bd5565-73bd-930f-8e1e-3a16f58cd5c3"),
                    CommessaId = Guid.Parse("88a144d4-88ba-2a24-7f52-3a16f5914054"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
            await _dipendenteCommessaRepository.InsertAsync(
                new DipendenteCommessa
                {
                    DipendenteId = Guid.Parse("32bd5565-73bd-930f-8e1e-3a16f58cd5c3"),
                    CommessaId = Guid.Parse("03bcced3-3dc1-8305-d41b-3a16f5914059"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
            await _dipendenteCommessaRepository.InsertAsync(
                new DipendenteCommessa
                {
                    DipendenteId = Guid.Parse("b221bbde-b893-f1a2-5006-3a16f58cd5e4"),
                    CommessaId = Guid.Parse("03bcced3-3dc1-8305-d41b-3a16f5914059"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
            await _dipendenteCommessaRepository.InsertAsync(
                new DipendenteCommessa
                {
                    DipendenteId = Guid.Parse("80249caa-65d2-968b-57da-3a16f58cd5e9"),
                    CommessaId = Guid.Parse("03bcced3-3dc1-8305-d41b-3a16f5914059"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
            await _dipendenteCommessaRepository.InsertAsync(
                new DipendenteCommessa
                {
                    DipendenteId = Guid.Parse("4f23806a-153c-9ba1-5d68-3a16f58cd5eb"),
                    CommessaId = Guid.Parse("c5eb41f9-c581-6b2a-86a3-3a16f591405c"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
            await _dipendenteCommessaRepository.InsertAsync(
                new DipendenteCommessa
                {
                    DipendenteId = Guid.Parse("d53ef7ed-8910-a676-10e1-3a16f58cd5ea"),
                    CommessaId = Guid.Parse("3d143924-5df7-2066-ac29-3a16f591405e"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
        }
    }
}