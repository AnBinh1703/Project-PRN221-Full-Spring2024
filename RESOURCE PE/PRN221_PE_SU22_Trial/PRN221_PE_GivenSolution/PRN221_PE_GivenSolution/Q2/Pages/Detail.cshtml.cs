using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Q2.Models;
namespace Q2.Pages
{
    public class DetailModel : PageModel
    {
        private readonly PRN221_Spr22Context _context;
        //private readonly IHubContext<SignalRServer> _hubContext;


        public DetailModel(PRN221_Spr22Context context)
        {
            _context = context;
            //_hubContext = SignalRServer;
        }

        public Service service { get; set; }
        public void OnGet(string? Id)
        {
            service = _context.Services.FirstOrDefault(x => x.Id == int.Parse(Id));
        }

    }
}
