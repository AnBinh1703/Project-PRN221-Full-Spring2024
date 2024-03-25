using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class StoreAccount
    {
        public int AccountId { get; set; }
        public string AccountPassword { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string? EmailAddress { get; set; }
        public int? Role { get; set; }
    }
}
