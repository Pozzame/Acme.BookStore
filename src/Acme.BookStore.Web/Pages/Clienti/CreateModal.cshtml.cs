using System.Threading.Tasks;
using Acme.BookStore.Clienti;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Clienti
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateUpdateClienteDto Cliente { get; set; }

        private readonly IClienteAppService _clienteAppService;

        public CreateModalModel(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        public void OnGet()
        {
            Cliente = new CreateUpdateClienteDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _clienteAppService.CreateAsync(Cliente);
            return NoContent();
        }
    }
}
