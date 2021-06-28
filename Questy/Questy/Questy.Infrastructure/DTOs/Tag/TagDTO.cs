﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.DTOs.Tag
{
    public class TagDTO
    {
        public int? ID { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
