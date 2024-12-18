using System;
using System.Threading.Tasks;
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
    private readonly IDipendenteRepository _clienteRepository;
    private readonly DipendenteManager _clienteManager;
    private readonly IDipendenteRepository _commessaRepository;
    private readonly DipendenteManager _commessaManager;

    public BookStoreDataSeederContributor(
        IDipendenteRepository dipendenteRepository,
        DipendenteManager dipendenteManager,
        IDipendenteRepository clienteRepository,
        DipendenteManager clienteManager,
        IDipendenteRepository commessaRepository,
        DipendenteManager commessaManager)
    {
        _dipendenteRepository = dipendenteRepository;
        _dipendenteManager = dipendenteManager;

        _commessaRepository = commessaRepository;
        _commessaManager = commessaManager;
        _clienteRepository = clienteRepository;
        _clienteManager = clienteManager;
    }

    public async Task SeedAsync(DataSeedContext context)
    {
        if (await _dipendenteRepository.GetCountAsync() < 1)
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

        if (await _clienteRepository.GetCountAsync() < 1)
        {
            var ciuccio = await _clienteRepository.InsertAsync(
                await _clienteManager.CreateAsync(
                    "Ciuccio",
                    "Ciuccione",
                    new DateTime(1992, 03, 11),
                    new DateTime(2012, 03, 11),
                    10
                )
            );
            var antani = await _clienteRepository.InsertAsync(
                await _clienteManager.CreateAsync(
                    "Antani",
                    "Pisquano",
                    new DateTime(1992, 03, 11),
                    new DateTime(2012, 03, 11),
                    12
                )
            );
        }

        if (await _commessaRepository.GetCountAsync() < 1)
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
    }
}