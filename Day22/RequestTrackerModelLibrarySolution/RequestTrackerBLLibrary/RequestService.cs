using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RequestTrackerBLLibrary
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _repository;
        public RequestService()
        {
            IRepository<int, Request> repo = new RequestRepository(new RequestTrackerContext());
            _repository = repo;
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            var addedRequest = await _repository.Add(request);
            return addedRequest;
        }

        public async Task<ICollection<Request>> ViewRequestStatus(Employee employee)
        {
            ICollection<Request> requests;

            // If the user is an admin, view all requests
            if (employee.Role == "Admin")
            {
                requests = await _repository.GetAll();
            }
            else // For normal users, view only their requests
            {
                requests = await _repository.GetAll();
                requests = requests.Where(r => r.RequestRaisedBy == employee.Id).ToList();
            }

            return requests;
        }

        public async Task<ICollection<RequestSolution>> ViewSolutions(int requestId)
        {
         
            var request = await _repository.Get(requestId);

            if (request != null)
            {
                return request.RequestSolutions;
            }
            else
            {
                return new List<RequestSolution>();
            }
        }

    }
}
