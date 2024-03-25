using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;
namespace Q2.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_Spr22Context _context;

        public DeleteModel(PRN221_Spr22Context context)
        {
            _context = context;
        }
        public Service Service { get; set; }

        public IActionResult OnGet(string? Id)
        {
            Service = _context.Services.FirstOrDefault(x => x.Id == int.Parse(Id));
            _context.Services.Remove(Service);
            _context.SaveChanges();
            return RedirectToPage("./List");
        }
        
    }
}
