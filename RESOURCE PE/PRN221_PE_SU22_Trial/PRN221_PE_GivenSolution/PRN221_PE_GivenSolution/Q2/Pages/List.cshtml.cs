using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Q2.Dao;
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
            List<Service> services = ServiceDao.Instance.search(title);
            ViewData["services"] = services;
        }

        public async Task OnPostImport(IFormFile xmlFile)
        {
            List<Service> services = new List<Service>();

            if (xmlFile != null)
            {
                var file = Path.Combine(_environment.ContentRootPath, "uploads", xmlFile.FileName);
                using (var fileStream = new FileStream(file, FileMode.Create))
                {
                    await xmlFile.CopyToAsync(fileStream);
                }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(ServiceList));
            using (FileStream fileStream = new FileStream(Path.Combine(_environment.ContentRootPath, "uploads", xmlFile.FileName), FileMode.Open))
            {
                ServiceList result = (ServiceList)serializer.Deserialize(fileStream);
                services = result.Services;
            }

            foreach (var s in services)
            {
                s.Id = 0;

                _context.Services.Add(s);
                _context.SaveChanges();
            }

            List<Service> allServices = _context.Services.Include(s => s.EmployeeNavigation).Where(s => s.Month == 3).ToList();

            ViewData["services"] = allServices;
        }
    }
}
