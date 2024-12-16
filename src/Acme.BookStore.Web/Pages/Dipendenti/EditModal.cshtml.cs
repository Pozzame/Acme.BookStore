using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Acme.BookStore.Dipendenti;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bootstrap.TagHelpers.Form;

namespace Acme.BookStore.Web.Pages.Dipendenti;

public class EditModalModel : BookStorePageModel
{
    [BindProperty]
    public EditDipendenteViewModel Dipendente { get; set; }

    private readonly IDipendenteAppService _dipendenteAppService;

    public EditModalModel(IDipendenteAppService dipendenteAppService)
    {
        _dipendenteAppService = dipendenteAppService;
    }

    public async Task OnGetAsync(Guid id)
    {
        var dipendenteDto = await _dipendenteAppService.GetAsync(id);
        Dipendente = ObjectMapper.Map<DipendenteDto, EditDipendenteViewModel>(dipendenteDto);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _dipendenteAppService.UpdateAsync(
            Dipendente.Id,
            ObjectMapper.Map<EditDipendenteViewModel, UpdateDipendenteDto>(Dipendente)
        );

        return NoContent();
    }

    public class EditDipendenteViewModel
    {
        [HiddenInput]
        public Guid Id { get; set; }

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