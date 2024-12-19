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
                    CommesseId = new List<Guid>()
                },
            autoSave: true
            );
            await _clienteRepository.InsertAsync(
                new Cliente
                {
                    Name = "ASTS",
                    CommesseId = new List<Guid>()
                },
            autoSave: true
            );
        }

        if (await _commessaRepository.GetCountAsync() <= 0)
        {
            await _commessaRepository.InsertAsync(
                new Commessa
                {
                    Nome = "ASTS",
                    Tipologia = Tipologia.AProgetto,
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
                    DipendenteId = Guid.Parse("b34e7e2a-ba13-2a11-a276-3a16f1779bbb"),
                    CommessaId = Guid.Parse("c819e79e-3f09-af09-8595-3a16f1779c32"),
                    Ruolo = 0,
                    MonteOre = 100
                },
                autoSave: true
            );
        }
    }
}