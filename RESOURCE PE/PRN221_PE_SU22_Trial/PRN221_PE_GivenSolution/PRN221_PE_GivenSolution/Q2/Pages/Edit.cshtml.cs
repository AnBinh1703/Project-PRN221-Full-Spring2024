using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Q2.Hubs;
using Q2.Models;
namespace Q2.Pages
{
    public class EditModel : PageModel
    {
        private readonly PRN221_Spr22Context _context;
        private readonly IHubContext<SignR> _hubContext;


        public EditModel(PRN221_Spr22Context context, IHubContext<SignR> SignalRServer)
        {
            _context = context;
            _hubContext = SignalRServer;
        }
        public List<Employee> employees { get; set; }
        public Service service { get; set; }
        public void OnGet(string? Id)
        {
            service = _context.Services.FirstOrDefault(x => x.Id == int.Parse(Id));
            employees = _context.Employees.ToList();
        }

        public async Task<IActionResult> OnPost(Service editService)
        {
           
            //var context = new PRN221_Spr22Context();
            //context.Rooms.Update(edtRoom);
            //context.SaveChanges();

            _context.Services.Update(editService);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("cmf5edit");
            //await _hubContext.Clients.All.SendAsync("loadPageService");

            return RedirectToPage("./List");
        }
    }
}
