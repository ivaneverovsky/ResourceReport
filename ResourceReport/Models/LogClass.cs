using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceReport.Models
{
    internal class LogClass
    {
        public string Message { get; set; }
        public LogClass(string message)
        {
            Message = message;
        }
    }
}
