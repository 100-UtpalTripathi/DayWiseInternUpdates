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

        public AdminService(IRepository<int, Request> requestRepository, IRepository<int, RequestSolution> solutionRepository, IRepository<int, SolutionFeedback> feedbackRepository)
        {
            _requestRepository = requestRepository;
            _solutionRepository = solutionRepository;
            _feedbackRepository = feedbackRepository;
        }

        public async Task MarkRequestAsClosed(int requestId)
        {
            // Retrieve the request associated with the requestId
            var request = await _requestRepository.Get(requestId);
            if (request != null)
            {
                // Mark the request as closed
                request.RequestStatus = "Closed";

                // Save the changes to the repository
                await _requestRepository.Update(request);
            }
        }

        public async Task<ICollection<Request>> ViewAllRequests()
        {
            // Retrieve all requests from the repository
            var requests = await _requestRepository.GetAll();
            return requests;
        }

        public async Task<ICollection<RequestSolution>> ViewAllSolutions()
        {
            // Retrieve all solutions from the repository
            var solutions = await _solutionRepository.GetAll();
            return solutions;
        }

        public async Task<ICollection<SolutionFeedback>> ViewFeedbacks(Employee admin)
        {
            // Retrieve feedbacks given to the specified admin
            var feedbacks = await _feedbackRepository.GetAll();
            var adminFeedbacks = new List<SolutionFeedback>();

            foreach (var feedback in feedbacks)
            {
                if (feedback.FeedbackBy == admin.Id)
                {
                    adminFeedbacks.Add(feedback);
                }
            }

            // Return the feedbacks given to the admin
            return adminFeedbacks;
        }
    }
}
