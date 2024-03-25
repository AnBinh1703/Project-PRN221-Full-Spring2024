using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Equipment
    {
        public int EqId { get; set; }
        public string EqCode { get; set; } = null!;
        public string? EqName { get; set; }
        public string? Description { get; set; }
        public string? Model { get; set; }
        public string? SupplierName { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? Quantity { get; set; }
        public int? Status { get; set; }
        public int? RoomId { get; set; }

        public virtual Room? Room { get; set; }
    }
}
