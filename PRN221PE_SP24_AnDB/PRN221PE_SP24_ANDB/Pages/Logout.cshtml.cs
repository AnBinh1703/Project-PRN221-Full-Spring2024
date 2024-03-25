using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Eyeglasses_AnDB.Pages
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            PRN221PE_SP24_AnDB.SessionExtensions.Set<StoreAccount>(HttpContext.Session, "User", null);
            return Redirect("/index");
        }
    }
}
