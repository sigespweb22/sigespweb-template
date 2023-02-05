using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sigesp.WebUI.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class AccessDenied : PageModel
    {
        public void OnGet()
        {
            // ViewData["UrlAnterior"] = Request.Headers["Referer"].ToString();            
            // Response.Redirect(urlAnterior); //Redireciona pra url anterior.
        }
    }
}
