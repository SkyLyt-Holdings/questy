using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Questy.Domain.Entities.System
{
    public class ErrorLog : Entity
    {
        public string App { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
        public DateTime Date { get; set; }
    }
}
