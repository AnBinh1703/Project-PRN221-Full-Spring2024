using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.ComponentModel.DataAnnotations;

namespace Eyeglasses_AnDB.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public int Id {  get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string FrameColor { get; set; }
        [BindProperty]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public Decimal Price { get; set; }

        [BindProperty]
        [Range(0, 999, ErrorMessage = "Quantity must be between 0 and 999.")]
        public int Quantity { get; set; }

        [BindProperty]
        public string LensTypeId { get; set; }
        public List<LensType> LensTypes { get; set; }

        LensTypeRepository _lensTypeRepository;
        EyeglassRepository _eyeglassRepository;
        public AddItemModel(LensTypeRepository lensRepo, EyeglassRepository eyeglassRepository)
        {
            _lensTypeRepository = lensRepo;
            _eyeglassRepository = eyeglassRepository;
        }

        public IActionResult OnGet()
        {
            LensTypes = _lensTypeRepository.GetAll();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (_eyeglassRepository.GetAll().FirstOrDefault(p => p.EyeglassesId == Id)!=null)
            {
                ModelState.AddModelError("Id", "Eyeglasses Id is exist!");
            }
            LensTypes = _lensTypeRepository.GetAll();
            if (Name ==null || Name.Length <= 10)
            {
                ModelState.AddModelError("Name", "Eyeglasses name must be greater than 10 characters and start with a capital letter.");
                return Page();
            }
            Eyeglass item = new Eyeglass()
            {
                EyeglassesId = Id,
                EyeglassesName = Name,
                EyeglassesDescription = Description,
                FrameColor = FrameColor,
                Price = Price,
                Quantity = Quantity,
                LensTypeId = LensTypeId,
                CreatedDate = DateTime.Now,
            };
            _eyeglassRepository.Save(item);
            return Redirect("/EyeclassRazorPage");
        }
    }
}
