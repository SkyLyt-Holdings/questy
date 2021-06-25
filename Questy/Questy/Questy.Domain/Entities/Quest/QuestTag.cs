using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities
{
    public class QuestTag : Entity
    {
        public int QuestID { get; set; }
        
        public int TagID { get; set; }
        
        public Quest Quest { get; set; }
        
        public Tag Tag { get; set; }
    }
}
