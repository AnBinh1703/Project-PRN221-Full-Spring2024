using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PRN221PE_SP24_AnDB.Pages
{
    public class EyeclassRazorpageModel : PageModel
    {
        //Paging
        private const int PageSize = 4;
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int TotalPages { get; set; }


        //Search
        [BindProperty(SupportsGet = true)]
        public string SearchPrice { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchDescription { get; set; }

        //Delete
        [BindProperty]
        public string IdItem {  get; set; }


        //List
        private readonly EyeglassRepository _eyeglassRepository;
        public List<Eyeglass> listEye;
        public EyeclassRazorpageModel(EyeglassRepository eyeglassRepository)
        {
            _eyeglassRepository = eyeglassRepository;
        }
        

        public IActionResult OnGet()
        {
            var user = PRN221PE_SP24_AnDB.SessionExtensions.Get<StoreAccount>(HttpContext.Session, "User");
            if(user == null)
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
            Eyeglass Item = _eyeglassRepository.GetAll().FirstOrDefault(p => p.EyeglassesId.ToString().Equals(IdItem));
            if (Item != null)
            {
                _eyeglassRepository.Delete(Item);
            }
            SearchAndPaginateEyeglasses();
            return Page();
        }

        //Paging function
        private void SearchAndPaginateEyeglasses()
        {
            try
            {   //Get list
                var allItem = _eyeglassRepository.GetContext().Eyeglasses.Include(p => p.LensType).ToList();
                var filteredItems = allItem.Where(p =>
                    (string.IsNullOrEmpty(SearchDescription) || p.EyeglassesDescription.Contains(SearchDescription)) &&
                    (string.IsNullOrEmpty(SearchPrice) || p.Price == Decimal.Parse(SearchPrice)));
                //paging
                TotalPages = (int)Math.Ceiling(filteredItems.Count() / (double)PageSize);
                listEye = filteredItems.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
            }
            catch (Exception ex)
            {
                listEye = _eyeglassRepository.GetContext().Eyeglasses.Include(p => p.LensType).ToList();
                ViewData["ErrorMessage"] = "Just input decimal to search price";
            }
        }
    }
}
