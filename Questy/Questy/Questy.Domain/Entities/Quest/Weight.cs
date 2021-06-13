using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Weight : Entity
    {
        [Required]
        public int PrimaryPercentage { get; set; }

        [Required]
        public int SecondaryPercentage { get; set; }

        [Required]
        public int TertiaryPercentage { get; set; }
    }
}
