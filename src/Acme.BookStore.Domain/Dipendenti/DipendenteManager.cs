using System;
using System.Threading.Tasks;
using Acme.BookStore.Authors;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Acme.BookStore.Dipendenti;

public class DipendenteManager : DomainService
{
    private readonly IDipendenteRepository _dipendenteRepository;

    public DipendenteManager(IDipendenteRepository dipendenteRepository)
    {
        _dipendenteRepository = dipendenteRepository;
    }

    public async Task<Dipendente> CreateAsync(
        string name,
        DateTime birthDate,
        string? shortBio = null)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingDipendente = await _dipendenteRepository.FindByNameAsync(name);
        if (existingDipendente != null)
        {
            throw new DipendenteAlreadyExistsException(name);
        }

        return new Dipendente(
            GuidGenerator.Create(),
            name,
            birthDate,
            shortBio
        );
    }

    public async Task ChangeNameAsync(
        Dipendente dipendente,
        string newName)
    {
        Check.NotNull(dipendente, nameof(dipendente));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingDipendente = await _dipendenteRepository.FindByNameAsync(newName);
        if (existingDipendente != null && existingDipendente.Id != dipendente.Id)
        {
            throw new DipendenteAlreadyExistsException(newName);
        }

        dipendente.ChangeName(newName);
    }
}