using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class EmployeeNotFoundException : Exception
    {
        private readonly string _msg;

        public EmployeeNotFoundException()
        {
            _msg = "Employee not found!";
        }

        public override string Message => _msg;
    }

}
