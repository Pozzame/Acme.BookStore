using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Volo.Abp.AspNetCore.Mvc;

namespace Acme.BookStore.Web.Controllers;
public class ExampleController : AbpController // www.miosito.com/example.html
{
    public IActionResult Index()
    {
        return View();
    }
}

