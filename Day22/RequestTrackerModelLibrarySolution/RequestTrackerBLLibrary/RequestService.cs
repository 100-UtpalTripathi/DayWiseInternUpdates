﻿using RequestTrackerModelLibrary;
using RequestTrackerDALLibrary;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace RequestTrackerBLLibrary
{
    public class RequestService : IRequestService
    {
        private readonly IRepository<int, Request> _requestRepository;

        public RequestService(IRepository<int, Request> requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<Request> RaiseRequest(Request request)
        {
            var addedRequest = await _requestRepository.Add(request);
            return addedRequest;
        }

        public async Task<ICollection<Request>> ViewRequestStatus(Employee employee)
        {
            ICollection<Request> requests;

            // If the user is an admin, view all requests
            if (employee.Role == "Admin")
            {
                requests = await _requestRepository.GetAll();
            }
            else // For normal users, view only their requests
            {
                requests = await _requestRepository.GetAll();
                requests = requests.Where(r => r.RequestRaisedBy == employee.Id).ToList();
            }

            return requests;
        }

        public async Task<ICollection<RequestSolution>> ViewSolutions(int requestId)
        {
            // Retrieve solutions associated with the specified request ID
            var request = await _requestRepository.Get(requestId);
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
