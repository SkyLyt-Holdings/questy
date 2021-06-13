using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class Tag : Entity
    {
        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Description { get; set; }
    }
}
