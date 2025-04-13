using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechLibrary.Communication.Responses
{
    public class ResponseBookJson
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public string? Title { get; set; } =string.Empty;
        public string? Author { get; set; } = string.Empty;
    }
}
