using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class DuplicateEmployeeIdException : Exception
    {
        private readonly string _msg;

        public DuplicateEmployeeIdException()
        {
            _msg = "An employee with the same ID already exists!";
        }

        public override string Message => _msg;
    }

}
