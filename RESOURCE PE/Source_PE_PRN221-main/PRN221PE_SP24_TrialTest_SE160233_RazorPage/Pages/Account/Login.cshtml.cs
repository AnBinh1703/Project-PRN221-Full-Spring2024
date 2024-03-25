using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221PE_SP24_TrialTest_SE160233_Repo.Repo;
using System.ComponentModel.DataAnnotations;

namespace PRN221PE_SP24_TrialTest_SE160233_RazorPage.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Credential Credential { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }
        public Boolean isAuthenticated { get; set; }
        public LoginModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            //var user = unitOfWork.AccountRepository.GetAll().FirstOrDefault(o=>o.UserName==Credential.UserName&&o.Password==Credential.Password);
            var user = _unitOfWork.StoreAccountRepository.Get(o => o.EmailAddress == Credential.UserName && o.AccountPassword == Credential.Password);
            if (user != null)
            {
                if (user.Role == 1 || user.Role == 2)
                {
                    isAuthenticated = true;
                    HttpContext.Session.SetString("UserId", user.AccountId.ToString());
                    HttpContext.Session.SetString("UserName", user.FullName);
                    HttpContext.Session.SetString("UserRole", (user.Role == 1 ? "ADMIN" : "STAFF"));
                    return RedirectToPage("../Index");
                }
                else
                {
                    ErrorMessage = "You do not have permission";
                    return Page();
                }
            }
            else
            {
                ErrorMessage = "Invalid login";
                //ModelState.AddModelError(string.Empty, "Invalid login");
            }
            return Page();
        }

    }
    public class Credential
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
