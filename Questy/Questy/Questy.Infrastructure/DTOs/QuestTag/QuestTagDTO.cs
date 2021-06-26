using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.DTOs.QuestTag
{
    public class QuestTagDTO
    {
        [Required]
        public int QuestID { get; set; }
        [Required]
        public int TagID { get; set; }
    }
}
