using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Rpository;

namespace Equipments_AnDB.Pages
{
    public class RazorPageModel : PageModel
    {
        //Paging
        private const int PageSize = 5;
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }


        //Search
        [BindProperty(SupportsGet = true)]
        public string SearchQuatity { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchDescription { get; set; }

        //Delete
        [BindProperty]
        public string IdItem { get; set; }


        //List
        private readonly EquipmentRepository _EquipmentRepository;
        public List<Equipment> listEye;
        public RazorPageModel(EquipmentRepository EquipmentRepository)
        {
            _EquipmentRepository = EquipmentRepository;
        }


        public IActionResult OnGet()
        {
            var user = Equipments_AnDB.SessionExtensions.Get<Account>(HttpContext.Session, "User");
            if (user == null)
            {
                return Redirect("/index");
            }
            SearchAndPaginateEyeglasses();

            return Page();
        }
        //Search
        public IActionResult OnPostSearchItem()
        {
            CurrentPage = 1;
            SearchAndPaginateEyeglasses();

            return Page();
        }
        //Delete
        public IActionResult OnPostDeleteItem()
        {
            Equipment Item = _EquipmentRepository.GetAll().FirstOrDefault(p => p.EqId.ToString().Equals(IdItem));
            if (Item != null)
            {
                _EquipmentRepository.Delete(Item);
            }
            SearchAndPaginateEyeglasses();
            return Page();
        }

        //Paging function
        private void SearchAndPaginateEyeglasses()
        {
            try
            {   //Get list
                var allItem = _EquipmentRepository.GetContext().Equipments.Include(p => p.Room).ToList();
                var filteredItems = allItem.Where(p =>
                    (string.IsNullOrEmpty(SearchDescription) || p.Description.Contains(SearchDescription)) &&
                    (string.IsNullOrEmpty(SearchQuatity) || p.Quantity == Decimal.Parse(SearchQuatity)));
                //paging
                TotalPages = (int)Math.Ceiling(filteredItems.Count() / (double)PageSize);
                listEye = filteredItems.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            }
            catch (Exception ex)
            {
                listEye = _EquipmentRepository.GetContext().Equipments.Include(p => p.Room).ToList();
                ViewData["ErrorMessage"] = "Just input decimal to search quatity";
            }
        }
    }
}