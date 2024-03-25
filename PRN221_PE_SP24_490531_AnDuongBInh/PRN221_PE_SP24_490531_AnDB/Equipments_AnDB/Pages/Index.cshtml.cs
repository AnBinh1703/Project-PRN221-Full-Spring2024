using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rpository;
using System.ComponentModel.DataAnnotations;

namespace Equipments_AnDB.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IConfiguration _configuration;
        private readonly AccountRepository storeAccount;
        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AccountRepository store)
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
            Account user = storeAccount.GetContext().Accounts.FirstOrDefault(p => p.Email.Equals(Email) && p.Password.Equals(Password));
            if (user == null)
            {
                ViewData["ErrorMessage"] = "Email or password is incorrect!";
                return Page();
            }
            if (user != null && user.RoleId == 1) // Admin
            {
                Equipments_AnDB.SessionExtensions.Set< Account> (HttpContext.Session, "User", user);
                return RedirectToPage("/Razorpage");
            }
            else if (user != null && user.RoleId == 2) // Staff
            {
                Equipments_AnDB.SessionExtensions.Set<Account>(HttpContext.Session, "User", user);
                return RedirectToPage("/Razorpage");
            }
            else
            {
                ViewData["ErrorMessage"] = "You do not have permission to do this function!";
                return Page();
            }
        }
    }
}
