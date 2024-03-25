using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Rpository;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Equipments_AnDB.Pages
{
    public class AddItemModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string EqCode { get; set; }
        [BindProperty]
        public string EqName { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public string Model { get; set; }
        [BindProperty]
        public string SupplierName { get; set; }
        [BindProperty]
        public string FrameColor { get; set; }
        [BindProperty]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public Decimal Price { get; set; }

        [BindProperty]
        [Range(0, 999, ErrorMessage = "Quantity must be between 0 and 999.")]
        public int Quantity { get; set; }

        [BindProperty]
        public string RoomId { get; set; }
        public List<Room> Rooms { get; set; }

        RoomRepository _RoomRepository;
        EquipmentRepository _eyeglassRepository;
        public AddItemModel(RoomRepository lensRepo, EquipmentRepository eyeglassRepository)
        {
            _RoomRepository = lensRepo;
            _eyeglassRepository = eyeglassRepository;
        }

        public IActionResult OnGet()
        {
            Rooms = _RoomRepository.GetAll();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (_eyeglassRepository.GetAll().FirstOrDefault(p => p.EqId == Id) != null)
            {
                ModelState.AddModelError("Id", "eq Id is exist!");
            }
            Rooms = _RoomRepository.GetAll();
            if (EqName == null || EqName.Length <= 10)
            {
                ModelState.AddModelError("Name", "eq name must be greater than 10 characters and start with a capital letter.");
                return Page();
            }
            Equipment item = new Equipment()
            {
                EqId = Id,
           EqCode = EqCode,
                EqName = EqName,
                Description = Description,
                Model = Model,
                SupplierName = SupplierName,
                Quantity = Quantity,
               CreatedAt = DateTime.Now,
               UpdatedAt = DateTime.Now,


            };
            _eyeglassRepository.Save(item);
            return Redirect("/RazorPage");
        }
    }
}