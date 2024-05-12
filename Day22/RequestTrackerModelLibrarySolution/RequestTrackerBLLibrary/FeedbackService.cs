using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<int, SolutionFeedback> _feedbackRepository;

        public FeedbackService(IRepository<int, SolutionFeedback> feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        public async Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback)
        {
            var addedFeedback = await _feedbackRepository.Add(feedback);
            return addedFeedback;
        }

        public async Task<ICollection<SolutionFeedback>> ViewFeedback(Employee employee)
        {
           
            var feedbacks = await _feedbackRepository.GetAll();
            var employeeFeedbacks = new List<SolutionFeedback>();

            foreach (var feedback in feedbacks)
            {
                if (feedback.FeedbackBy == employee.Id)
                {
                    employeeFeedbacks.Add(feedback);
                }
            }
            return employeeFeedbacks;
        }
    }
}
