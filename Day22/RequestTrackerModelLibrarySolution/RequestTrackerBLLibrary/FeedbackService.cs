using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RequestTrackerBLLibrary
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<int, SolutionFeedback> _repository;
        public FeedbackService()
        {
            IRepository<int, SolutionFeedback> repo = new SolutionFeedbackRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<SolutionFeedback> GiveFeedback(SolutionFeedback feedback)
        {
            var addedFeedback = await _repository.Add(feedback);
            return addedFeedback;
        }

        public async Task<ICollection<SolutionFeedback>> ViewFeedback(Employee employee)
        {
           
            var feedbacks = await _repository.GetAll();
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
