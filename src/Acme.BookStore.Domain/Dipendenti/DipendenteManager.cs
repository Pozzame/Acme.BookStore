using System;
using System.Threading.Tasks;
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
        string surname,
        DateTime birthDate,
        DateTime startDate,
        decimal? hourlyRate)
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
            surname,
            birthDate,
            startDate,
            hourlyRate
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
    public async Task ChangeSurnameAsync(
        Dipendente dipendente,
        string newSurname)
    {
        Check.NotNull(dipendente, nameof(dipendente));
        Check.NotNullOrWhiteSpace(newSurname, nameof(newSurname));

        var existingDipendente = await _dipendenteRepository.FindBySurnameAsync(newSurname);
        if (existingDipendente != null && existingDipendente.Id != dipendente.Id)
        {
            throw new DipendenteAlreadyExistsException(newSurname);
        }

        dipendente.ChangeSurname(newSurname);
    }
}