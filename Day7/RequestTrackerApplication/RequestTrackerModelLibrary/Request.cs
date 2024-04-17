using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrakerModelLibrary
{
    public class Request
    {
        public int Id { get; set; }
        public string RequestText { get; set; }
        public int Raised_By { get; set; }
        public string Status { get; set; }
        public int Closed_By { get; set; }
    }
}