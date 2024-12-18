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

    public BookStoreDataSeederContributor(
        IDipendenteRepository dipendenteRepository,
        DipendenteManager dipendenteManager,
        IRepository<Cliente, Guid> clienteRepository,
        IRepository<Commessa, Guid> commessaRepository)
    {
        _dipendenteManager = dipendenteManager;
        _dipendenteRepository = dipendenteRepository;
        _commessaRepository = commessaRepository;
        _clienteRepository = clienteRepository;
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
                    Dipendenti = new List<Guid>(),
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
                    Dipendenti = new List<Guid>(),
                    IsActive = true
                },
                autoSave: true
            );
        }
    }
}