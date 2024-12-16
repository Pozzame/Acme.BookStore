using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Acme.BookStore.Dipendenti;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Dipendenti;

public class CreateModalModel : BookStorePageModel
{
    [BindProperty]
    public CreateDipendenteViewModel Dipendente { get; set; }

    private readonly IDipendenteAppService _dipendenteAppService;

    public CreateModalModel(IDipendenteAppService dipendenteAppService)
    {
        _dipendenteAppService = dipendenteAppService;
    }

    public void OnGet()
    {
        Dipendente = new CreateDipendenteViewModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<CreateDipendenteViewModel, CreateDipendenteDto>(Dipendente);
        await _dipendenteAppService.CreateAsync(dto);
        return NoContent();
    }

    public class CreateDipendenteViewModel
    {
        [Required]
        [StringLength(DipendenteConsts.MaxNameLength)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(DipendenteConsts.MaxNameLength)]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Currency)]
        public decimal? HourlyRate { get; set; }
    }
}