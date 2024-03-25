using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221PE_SP24_TrialTest_SE160233_Repo;
using PRN221PE_SP24_TrialTest_SE160233_Repo.Repo;

namespace PRN221PE_SP24_TrialTest_SE160233_RazorPage.Pages.EyeGlassPage
{
    public class IndexModel : PageModel
    {
        protected IUnitOfWork _unitOfWork;
        private int pageCount;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Eyeglass> Eyeglass { get; set; } = default!;
        public int PageCount = 0;
        public decimal? MinPrice;
        public decimal? MaxPrice;
        public string? Des;
        public async Task OnGetAsync(int? PageIndex, decimal? minPrice, decimal? maxPrice, string? des)
        {
            if (HttpContext.Session.GetString("UserId") == null)
            {
                Response.Redirect("/Account/Login");
            }
            MinPrice = minPrice;
            MaxPrice = maxPrice;
            Des = des;

            Eyeglass = _unitOfWork.EyeglassRepository.GetPagination(
            filter: eyeglass =>
                (minPrice == null || eyeglass.Price >= minPrice) &&
                (maxPrice == null || eyeglass.Price <= maxPrice) &&
                (des == null || eyeglass.EyeglassesDescription.Contains(des)),
            orderBy: null,
            includeProperties: "LensType",
            pageIndex: PageIndex ?? 1,
            pageSize: 4
         );
            var tmp = _unitOfWork.EyeglassRepository.GetPagination(
           filter: eyeglass =>
               (minPrice == null || eyeglass.Price >= minPrice) &&
               (maxPrice == null || eyeglass.Price <= maxPrice) &&
               (des == null || eyeglass.EyeglassesDescription.Contains(des)),
           orderBy: null,
           includeProperties: "LensType"
        );
            PageCount = tmp.Count() / 4 + (tmp.Count() % 4 > 0 ? 1 : 0);
        }
    }
}
