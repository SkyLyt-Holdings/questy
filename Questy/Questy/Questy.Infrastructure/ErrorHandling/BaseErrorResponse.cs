using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questy.Infrastructure.ErrorHandling
{
    public class BaseErrorResponse
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public string DetailedMessage { get; set; }
    }
}
