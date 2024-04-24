using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class DuplicateItemFound : Exception
    {
        string message;
        public DuplicateItemFound()
        {
            message = "Item with the given Id is not present!";
        }
        public DuplicateItemFound(string msg)
        {
            message = msg;
        }
        public override string Message => message;
    }
}
