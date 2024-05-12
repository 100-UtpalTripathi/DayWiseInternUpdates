using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public interface ISolutionService
    {
        Task<RequestSolution> ProvideSolution(RequestSolution solution);
        //Task<ICollection<RequestSolution>> ViewSolutions();

        Task<bool> RespondToSolution(int requestId, string response);
    }
}
