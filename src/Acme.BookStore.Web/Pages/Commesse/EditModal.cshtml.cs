using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.BookStore.Clienti;
using Acme.BookStore.Commesse;
using Acme.BookStore.Dipendenti;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Web.Pages.Commesse;

public class EditModalModel : BookStorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateCommessaDto Commessa { get; set; }

    [BindProperty]
    public Guid? SelectedDipendenteId { get; set; } // ID del dipendente selezionato

    public string ClienteNome { get; set; } // Nome del cliente

    public List<SelectListItem> DipendentiList { get; set; } // Lista per il menù a tendina


    private readonly ICommessaAppService _commessaAppService;
    private readonly IDipendenteRepository _dipendenteRepository; // Repository dei dipendenti
    private readonly IRepository<Cliente, Guid> _clienteRepository; // Repository per i clienti
    private readonly IRepository<DipendenteCommessa, Guid> _dipendenteCommessaRepository; // Repository per la relazione


    public EditModalModel (ICommessaAppService commessaAppService,
            IDipendenteRepository dipendenteRepository,
            IRepository<Cliente, Guid> clienteRepository,
            IRepository<DipendenteCommessa, Guid> dipendenteCommessaRepository)
        {
            _commessaAppService = commessaAppService;
            _dipendenteRepository = dipendenteRepository;
            _clienteRepository = clienteRepository;
            _dipendenteCommessaRepository = dipendenteCommessaRepository;
        }

    public async Task OnGetAsync()
    {
        var commessaDto = await _commessaAppService.GetAsync(Id);
        Commessa = ObjectMapper.Map<CommessaDto, CreateUpdateCommessaDto>(commessaDto);

        // Ottieni il nome del cliente
        var cliente = await _clienteRepository.GetAsync(Commessa.ClienteId);
        ClienteNome = cliente?.Name ?? "N/A"; // Assumi che il cliente abbia una proprietà Nome

        // Popola la lista dei dipendenti
        var dipendenti = await _dipendenteRepository.GetListAsync();
        DipendentiList = new List<SelectListItem>();
        foreach (var dipendente in dipendenti)
        {
            DipendentiList.Add(new SelectListItem
            {
                Value = dipendente.Id.ToString(),
                Text = dipendente.Name // Assumi che il nome sia una proprietà del dipendente
            });
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Aggiorna la Commessa
        await _commessaAppService.UpdateAsync(Id, Commessa);

        // Se è stato selezionato un dipendente, aggiorna la relazione
        if (SelectedDipendenteId.HasValue)
        {
            await _dipendenteCommessaRepository.InsertAsync(new DipendenteCommessa
            {
                DipendenteId = SelectedDipendenteId.Value,
                CommessaId = Id,
                Ruolo = 0, // Aggiungi un valore predefinito per il ruolo
                MonteOre = 0 // Aggiungi un valore predefinito per il monte ore
            });
        }

        return NoContent();
    }
}
