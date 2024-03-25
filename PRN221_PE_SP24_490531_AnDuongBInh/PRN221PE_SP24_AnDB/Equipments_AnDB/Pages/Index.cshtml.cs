using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Repository;
using System.ComponentModel.DataAnnotations;

namespace PRN221PE_SP24_AnDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IConfiguration _configuration;
        private readonly StoreAccountRepository storeAccount;
        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger, StoreAccountRepository store)
        {
            _logger = logger;
            storeAccount = store;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            StoreAccount user = storeAccount.GetContext().StoreAccounts.FirstOrDefault(p=>p.EmailAddress.Equals(Email) && p.AccountPassword.Equals(Password));
            if (user == null)
            {
                ViewData["ErrorMessage"] = "Email or password is incorrect!";
                return Page();
            }
            if (user != null && user.Role == 1) // Admin
            {
                PRN221PE_SP24_AnDB.SessionExtensions.Set<StoreAccount>(HttpContext.Session, "User", user);
                return RedirectToPage("/EyeClassRazorpage");
            }
            else if (user != null && user.Role == 2) // Staff
            {
                PRN221PE_SP24_AnDB.SessionExtensions.Set<StoreAccount>(HttpContext.Session, "User", user);
                return RedirectToPage("/EyeClassRazorpage");
            }
            else
            {
                ViewData["ErrorMessage"] = "You do not have permission to do this function!";
                return Page();
            }
        }
    }
}
