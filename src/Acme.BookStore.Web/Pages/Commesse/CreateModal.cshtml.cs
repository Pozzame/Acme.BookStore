using System.Threading.Tasks;
using Acme.BookStore.Commesse;
using Microsoft.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Pages.Commesse
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateUpdateCommessaDto Commessa { get; set; }

        private readonly ICommessaAppService _commessaAppService;

        public CreateModalModel(ICommessaAppService clienteAppService)
        {
            _commessaAppService = clienteAppService;
        }

        public void OnGet()
        {
            Commessa = new CreateUpdateCommessaDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _commessaAppService.CreateAsync(Commessa);
            return NoContent();
        }
    }
}
