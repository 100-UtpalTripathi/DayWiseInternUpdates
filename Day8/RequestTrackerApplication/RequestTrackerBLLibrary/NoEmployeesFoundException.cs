using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class NoEmployeesFoundException : Exception
    {
        private readonly string _msg;

        public NoEmployeesFoundException()
        {
            _msg = "No employees found!";
        }

        public override string Message => _msg;
    }
}
