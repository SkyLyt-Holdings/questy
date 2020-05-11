using System;
using System.Collections.Generic;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Weight
    {
        public int ID { get; set; }
        public int PrimaryPercentage { get; set; }
        public int SecondaryPercentage { get; set; }
        public int TertiaryPercentage { get; set; }
        public string AuditUser { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
