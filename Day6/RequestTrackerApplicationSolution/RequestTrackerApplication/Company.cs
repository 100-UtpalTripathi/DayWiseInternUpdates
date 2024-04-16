using RequestTrackerModelLibrary;
using System;

namespace RequestTrackerApplication
{
    /// <summary>
    /// Represents a company that interacts with clients.
    /// </summary>
    internal class Company
    {
        /// <summary>
        /// Simulates a client visit by an employee.
        /// </summary>
        /// <param name="clientInteraction">The client interaction object.</param>
        public void EmployeeClientVisit(IClientInteraction clientInteraction)
        {
            clientInteraction.GetPayment();
        }
    }
}
