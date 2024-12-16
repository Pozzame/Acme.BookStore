﻿using System;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Dipendenti;

public class DipendenteDto : EntityDto<Guid>
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public DateTime BirthDate { get; set; }

    public DateTime StartDate { get; set; }

    public decimal? HourlyRate { get; set; }
}