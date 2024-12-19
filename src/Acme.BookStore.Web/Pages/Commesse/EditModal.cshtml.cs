using System;
using System.Threading.Tasks;
using Acme.BookStore.Commesse;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Commesse;

public class EditModalModel : BookStorePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public CreateUpdateCommessaDto Commessa { get; set; }

    private readonly ICommessaAppService _clienteAppService;

    public EditModalModel(ICommessaAppService clienteAppService)
    {
        _clienteAppService = clienteAppService;
    }

    public async Task OnGetAsync()
    {
        var clienteDto = await _clienteAppService.GetAsync(Id);
        Commessa = ObjectMapper.Map<CommessaDto, CreateUpdateCommessaDto>(clienteDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _clienteAppService.UpdateAsync(Id, Commessa);
        return NoContent();
    }
}
