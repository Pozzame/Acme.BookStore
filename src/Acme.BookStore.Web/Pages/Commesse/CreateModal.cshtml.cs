using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.BookStore.Clienti;
using Acme.BookStore.Commesse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Volo.Abp.Domain.Repositories;

namespace Acme.BookStore.Web.Pages.Commesse
{
    public class CreateModalModel : BookStorePageModel
    {
        [BindProperty]
        public CreateUpdateCommessaDto Commessa { get; set; }
        public List<SelectListItem> ClienteList { get; set; }

        private readonly ICommessaAppService _commessaAppService;
        private readonly IRepository<Cliente, Guid> _clienteRepository;

        public CreateModalModel(ICommessaAppService commessaAppService,
            IRepository<Cliente, Guid> clienteRepository)
        {
            _commessaAppService = commessaAppService;
            _clienteRepository = clienteRepository;
        }

        public async Task OnGetAsync()
        {
            Commessa = new CreateUpdateCommessaDto();

            var clienti = await _clienteRepository.GetListAsync();
            ClienteList = clienti
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Name
                }).ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Console.WriteLine("Commessa: " + Commessa);
            await _commessaAppService.CreateAsync(Commessa);
            return NoContent();
        }
    }
}
