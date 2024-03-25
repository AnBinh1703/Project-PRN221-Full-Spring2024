using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Models;
using System;
using System.Xml.Serialization;

namespace Q2.Pages
{
    public class ListModel : PageModel
    {
        PRN221_Spr22Context _context = new PRN221_Spr22Context();

        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _environment;

        public ListModel(Microsoft.AspNetCore.Hosting.IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public void OnGet()
        {
            DateTime dateTime = DateTime.Now;
            int month = Int32.Parse(dateTime.Month.ToString());
            List<Service> services = _context.Services.Include(o => o.EmployeeNavigation).Where(o => o.Month == month).ToList();
            ViewData["services"] = services;
        }

        public void OnPostSearch(String title)
        {
            
        }

        public async Task OnPostImport(IFormFile xmlFile)
        {
        }
    }
}
