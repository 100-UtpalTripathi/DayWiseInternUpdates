using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class AdminService : IAdminService
    {
        private readonly IRepository<int, Request> _requestRepository;
        private readonly IRepository<int, RequestSolution> _solutionRepository;
        private readonly IRepository<int, SolutionFeedback> _feedbackRepository;

        public AdminService()
        {
            _requestRepository = new RequestRepository(new RequestTrackerContext());
            _solutionRepository = new RequestSolutionRepository(new RequestTrackerContext());
            _feedbackRepository = new SolutionFeedbackRepository(new RequestTrackerContext());
        }

        public async Task MarkRequestAsClosed(int requestId)
        {
            var request = await _requestRepository.GetByKey(requestId);
            if (request != null)
            {
                request.RequestStatus = "Closed";
                await _requestRepository.Update(request);
            }
        }

        public async Task<ICollection<Request>> ViewAllRequests()
        {
            var requests = await _requestRepository.GetAll();
            return requests;
        }

        public async Task<ICollection<RequestSolution>> ViewAllSolutions()
        {
            var solutions = await _solutionRepository.GetAll();
            return solutions;
        }

        public async Task<ICollection<SolutionFeedback>> ViewFeedbacks(Employee admin)
        {
            var feedbacks = await _feedbackRepository.GetAll();
            var adminFeedbacks = new List<SolutionFeedback>();

            foreach (var feedback in feedbacks)
            {
                if (feedback.FeedbackBy == admin.Id)
                {
                    adminFeedbacks.Add(feedback);
                }
            }
            return adminFeedbacks;
        }
    }
}
