using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;

namespace Q2.Pages
{
    public class CreateModel : PageModel
    {
        public Service service { get; set; }
        private readonly PRN221_Spr22Context _context;
        //private readonly IHubContext<SignalRServer> _hubContext;

        public List<Employee> employees { get; set; }
        public CreateModel(PRN221_Spr22Context context)
        {
            _context = context;
            //_hubContext = SignalRServer;
        }
        public void OnGet()
        {
            service = new Service();
            employees = _context.Employees.ToList();
        }
        public async Task<IActionResult> OnPost(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();
            //await _hubContext.Clients.All.SendAsync("loadPageService");
            return RedirectToPage("./List");
        }
    }
}
