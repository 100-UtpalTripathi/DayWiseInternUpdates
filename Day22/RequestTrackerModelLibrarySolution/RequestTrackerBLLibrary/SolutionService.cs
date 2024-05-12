using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionService : ISolutionService
    {
        private readonly IRepository<int, RequestSolution> _repository;
        public SolutionService()
        {
            IRepository<int, RequestSolution> repo = new RequestSolutionRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            var addedSolution = await _repository.Add(solution);
            return addedSolution;
        }

        

        public async Task<bool> RespondToSolution(int requestId, string response)
        {
            
            var requestSolution = await _repository.Get(requestId);
            if (requestSolution == null)
            {
                
                return false;
            }
            if (string.IsNullOrEmpty(response))
            {
                return false;
            }

            requestSolution.RequestRaiserComment = response;
            await _repository.Update(requestSolution);
            return true;
        }
    }
}
