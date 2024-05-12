using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class SolutionService : ISolutionService
    {
        private readonly IRepository<int, RequestSolution> _solutionRepository;

        public SolutionService(IRepository<int, RequestSolution> solutionRepository)
        {
            _solutionRepository = solutionRepository;
        }

        public async Task<RequestSolution> ProvideSolution(RequestSolution solution)
        {
            var addedSolution = await _solutionRepository.Add(solution);
            return addedSolution;
        }

        public async Task<ICollection<RequestSolution>> ViewSolutions()
        {
            var solutions = await _solutionRepository.GetAll();
            return solutions;
        }

        public async Task<bool> RespondToSolution(int requestId, string response)
        {
            
            var requestSolution = await _solutionRepository.Get(requestId);
            if (requestSolution == null)
            {
                
                return false;
            }
            if (string.IsNullOrEmpty(response))
            {
                return false;
            }

            requestSolution.RequestRaiserComment = response;
            await _solutionRepository.Update(requestSolution);
            return true;
        }
    }
}
