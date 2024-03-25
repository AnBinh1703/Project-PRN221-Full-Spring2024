using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repository;
using System.ComponentModel.DataAnnotations;

namespace Eyeglasses_AnDB.Pages
{
    public class UpdateItemModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int IdItemUpdate { get; set; }
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

        public UpdateItemModel(LensTypeRepository lensRepo, EyeglassRepository eyeglassRepository)
        {
            _eyeglassRepository = eyeglassRepository;
            _lensTypeRepository = lensRepo;
        }
        public IActionResult OnGet()
        {
            //Check login user
            StoreAccount user = PRN221PE_SP24_AnDB.SessionExtensions.Get<StoreAccount>(HttpContext.Session, "User");
            if(user ==null || user.Role!=1)
            {
                return Redirect("/Index");
            }

            var item = _eyeglassRepository.GetAll().FirstOrDefault(p => p.EyeglassesId == IdItemUpdate);
            if (item != null)
            {
                Name = item.EyeglassesName;
                Description = item.EyeglassesDescription;
                FrameColor = item.FrameColor;
                Price = item.Price ?? 0;
                Quantity = item.Quantity ?? 0;
                LensTypeId = item.LensTypeId;
            }
            LensTypes = _lensTypeRepository.GetAll().ToList();
            return Page();
        }
        public IActionResult OnPost()
        {
            LensTypes = _lensTypeRepository.GetAll().ToList();
            //Validate
            if (Name == null || Name.Length <= 10)
            {
                ModelState.AddModelError("Name", "Eyeglasses name must be greater than 10 characters and start with a capital letter.");
                return Page();
            }
            //Update
            Eyeglass item = _eyeglassRepository.GetAll().FirstOrDefault(p => p.EyeglassesId == IdItemUpdate);
            if (item == null)
            {
                return Page();
            }
            item.EyeglassesName = Name;
            item.EyeglassesDescription = Description;
            item.FrameColor = FrameColor;
            item.Price = Price;
            item.Quantity = Quantity;
            item.LensTypeId = LensTypeId;
            _eyeglassRepository.Update(item);
            return Redirect("/EyeclassRazorPage");
        }
    }
}
