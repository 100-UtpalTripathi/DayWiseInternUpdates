using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface IRequestService   // handles operations related to requests for both users and admins.
    {
        Task<Request> RaiseRequest(Request request);
        Task<ICollection<Request>> ViewRequestStatus(Employee employee);
        Task<ICollection<RequestSolution>> ViewSolutions(int requestId);
        Task<bool> RespondToSolution(int requestId, string response);
    }
}
