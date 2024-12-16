using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.BookStore.Dipendenti;

public class Dipendente : FullAuditedAggregateRoot<Guid>
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public DateTime BirthDate { get; set; }
    public DateTime StartDate { get; set; }
    public decimal? HourlyRate { get; set; }

    private Dipendente()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Dipendente(
        Guid id,
        string name,
        string surname,
        DateTime birthDate,
        DateTime startDate,
        decimal? hourlyRate)
        : base(id)
    {
        SetName(name);
        SetSurname(surname);
        BirthDate = birthDate;
        StartDate = startDate;
        HourlyRate = hourlyRate;
    }

    internal Dipendente ChangeName(string name)
    {
        SetName(name);
        return this;
    }
    internal Dipendente ChangeSurname(string surname)
    {
        SetSurname(surname);
        return this;
    }

    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: DipendenteConsts.MaxNameLength
        );
    }
    private void SetSurname(string surname)
    {
        Surname = Check.NotNullOrWhiteSpace(
            surname,
            nameof(surname),
            maxLength: DipendenteConsts.MaxNameLength
        );
    }
}