using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class LensType
    {
        public LensType()
        {
            Eyeglasses = new HashSet<Eyeglass>();
        }

        public string LensTypeId { get; set; } = null!;
        public string LensTypeName { get; set; } = null!;
        public string LensTypeDescription { get; set; } = null!;
        public bool? IsPrescription { get; set; }

        public virtual ICollection<Eyeglass> Eyeglasses { get; set; }
    }
}
