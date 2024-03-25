using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221PE_SP24_TrialTest_SE160233_Repo;
using PRN221PE_SP24_TrialTest_SE160233_Repo.Repo;

namespace PRN221PE_SP24_TrialTest_SE160233_RazorPage.Pages.EyeGlassPage
{
    public class DeleteModel : PageModel
    {
        protected IUnitOfWork _unitOfWork;
        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (!HttpContext.Session.GetString("UserRole").Equals("ADMIN"))
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/eyeglasspage/index");
            }
            var eyeglass = _unitOfWork.EyeglassRepository.GetById(id);
            if (eyeglass == null)
            {
                return NotFound();
            }
            else
            {
                Eyeglass = eyeglass;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            var eyeglass = _unitOfWork.EyeglassRepository.GetById(id);

            if (eyeglass != null)
            {
                Eyeglass = eyeglass;
                _unitOfWork.EyeglassRepository.Delete(id);
                _unitOfWork.SaveChanges()
;
            }

            return RedirectToPage("./Index");
        }
    }
}
