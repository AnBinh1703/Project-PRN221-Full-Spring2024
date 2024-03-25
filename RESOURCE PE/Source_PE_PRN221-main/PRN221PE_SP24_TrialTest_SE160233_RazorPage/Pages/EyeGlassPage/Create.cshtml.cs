using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221PE_SP24_TrialTest_SE160233_Repo;
using PRN221PE_SP24_TrialTest_SE160233_Repo.Repo;

namespace PRN221PE_SP24_TrialTest_SE160233_RazorPage.Pages.EyeGlassPage
{
    public class CreateModel : PageModel
    {
        protected IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult OnGet()
        {
            if (!HttpContext.Session.GetString("UserRole").Equals("ADMIN"))
            {
                TempData["ErrorMessage"] = "You do not have permission to access this page.";
                return RedirectToPage("/eyeglasspage/index");
            }
            ViewData["LensTypeId"] = new SelectList(_unitOfWork.LensTypeRepository.GetAll(), "LensTypeId", "LensTypeId");
            return Page();
        }

        [BindProperty]
        public Eyeglass Eyeglass { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (Eyeglass.Quantity < 0 || Eyeglass.Quantity > 999)
            {
                ModelState.AddModelError("Eyeglass.Quantity", "Quantity must be >=0 and <= 999");
                ViewData["LensTypeId"] = new SelectList(_unitOfWork.LensTypeRepository.GetAll(), "LensTypeId", "LensTypeId");
                return Page();
            }

            _unitOfWork.EyeglassRepository.Add(Eyeglass);
            _unitOfWork.SaveChanges();
            return RedirectToPage("./Index");
        }
    }
}
