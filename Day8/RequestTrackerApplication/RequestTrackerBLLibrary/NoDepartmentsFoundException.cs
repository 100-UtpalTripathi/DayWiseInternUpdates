using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class NoDepartmentsFoundException : Exception
    {
        private readonly string _msg;

        public NoDepartmentsFoundException()
        {
            _msg = "No departments found!";
        }

        public override string Message => _msg;
    }
}
