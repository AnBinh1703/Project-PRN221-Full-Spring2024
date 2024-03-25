using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221PE_SP24_TrialTest_SE160233_Repo;
using PRN221PE_SP24_TrialTest_SE160233_Repo.Repo;

namespace PRN221PE_SP24_TrialTest_SE160233_RazorPage.Pages.EyeGlassPage
{
    public class EditModel : PageModel
    {
        protected IUnitOfWork _unitOfWork;

        public EditModel(IUnitOfWork unitOfWork)
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
            Eyeglass = eyeglass;
            ViewData["LensTypeId"] = new SelectList(_unitOfWork.LensTypeRepository.GetAll(), "LensTypeId", "LensTypeId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            _unitOfWork.EyeglassRepository.Update(Eyeglass);
            _unitOfWork.SaveChanges();
            return RedirectToPage("./Index");
        }

    }
}
