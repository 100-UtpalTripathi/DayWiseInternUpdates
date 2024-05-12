using RequestTrackerBLLibrary;
using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            { 
                Console.WriteLine("  $$    Welcome to Request Tracker Application!   $$   ");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Switch statement to handle user's choice
                switch (choice)
                {
                    case "1":
                        await Login();
                        break;
                    case "2":
                        await Register();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please Choose Correct Option!");
                        break;
                }
            }
        }

        static async Task Login()
        {
            Console.Write("Enter your ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                return;
            }

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
        
            var employeeLoginBL = new EmployeeLoginBL();
            var employee = new Employee { Id = id, Password = password };

            bool isAuthenticated = await employeeLoginBL.Login(employee);

            if (isAuthenticated)
            {
                Console.WriteLine("Login successful!");

                if (employee.Role == "Admin")
                {
                    await AdminMenu(employee);
                }
                else
                {
                    await UserMenu(employee);
                }
            }
            else
            {
                Console.WriteLine("Login failed. Invalid ID or password.");
            }
            
        }

        static async Task Register()
        {
            Console.WriteLine("Registration:");
            Console.Write("Enter your ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                return;
            }

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            Console.Write("Enter your role (Admin/User): ");
            string role = Console.ReadLine();

            var employee = new Employee
            {
                Id = id,
                Name = name,
                Password = password,
                Role = role
            };

            IEmployeeLoginBL auth = new EmployeeLoginBL();
            var registeredEmployee = await auth.Register(employee);

            if (registeredEmployee != null)
            {
                Console.WriteLine("Registration successful!");
            }
            else
            {
                Console.WriteLine("Registration failed. Please try again.");
            }
        }


        static async Task UserMenu(Employee user)
        {
            bool exitUserMenu = false;

            while (!exitUserMenu)
            {
                Console.WriteLine("User Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status");
                Console.WriteLine("3. View Solutions");
                Console.WriteLine("4. Respond to Solution");
                Console.WriteLine("5. Give Feedback");
                Console.WriteLine("6. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RaiseRequest(user);
                        break;
                    case "2":
                        await ViewRequestStatus(user);
                        break;
                    case "3":
                        await ViewSolutions(user);
                        break;
                    case "4":
                        await RespondToSolution(user);
                        break;
                    case "5":
                        await GiveFeedback(user);
                        break;
                    case "6":
                        exitUserMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static async Task AdminMenu(Employee admin)
        {
            bool exitAdminMenu = false;

            while (!exitAdminMenu)
            {
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Raise Request");
                Console.WriteLine("2. View Request Status (All Requests)");
                Console.WriteLine("3. View Solutions (All Solutions)");
                Console.WriteLine("4. Provide Solution");
                Console.WriteLine("5. Mark Request as Closed");
                Console.WriteLine("6. View Feedbacks (Only feedbacks given to you)");
                Console.WriteLine("7. Logout");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        await RaiseRequest(admin);
                        break;
                    case "2":
                        await ViewRequestStatus(admin);
                        break;
                    case "3":
                        await ViewSolutions(admin);
                        break;
                    case "4":
                        // Implement logic to provide solution
                        break;
                    case "5":
                        Console.WriteLine("Enter the request ID to mark as closed:");
                        int closeRequestId;
                        if (!int.TryParse(Console.ReadLine(), out closeRequestId))
                        {
                            Console.WriteLine("Invalid request ID. Please try again.");
                            break;
                        }
                        var adminService = new AdminService();
                        await adminService.MarkRequestAsClosed(closeRequestId);
                        Console.WriteLine("Request marked as closed successfully!");
                        break;

                    case "6":
                        var adminSer = new AdminService();
                        var adminFeedbacks = await adminSer.ViewFeedbacks(admin);
                        if (adminFeedbacks.Count > 0)
                        {
                            Console.WriteLine("Feedbacks given to you:");
                            foreach (var feedback in adminFeedbacks)
                            {
                                Console.WriteLine($"Feedback ID: {feedback.FeedbackBy}, Rating: {feedback.Rating}, Remarks: {feedback.Remarks}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No feedbacks found.");
                        }
                        break;
                    case "7":
                        exitAdminMenu = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }


        static async Task RaiseRequest(Employee user)
        {
            Console.WriteLine("Enter your request message:");
            string requestMessage = Console.ReadLine();

       
            var request = new Request
            {
                RequestMessage = requestMessage,
                RequestDate = DateTime.Now,
                RequestStatus = "Open",
                RequestRaisedBy = user.Id
            };

        
            var requestService = new RequestService();
            var addedRequest = await requestService.RaiseRequest(request);

            if (addedRequest != null)
            {
                Console.WriteLine("Request raised successfully!");
            }
            else
            {
                Console.WriteLine("Failed to raise the request. Please try again.");
            }
        }

        static async Task ViewRequestStatus(Employee user)
        {
            var requestService = new RequestService();
            var userRequests = await requestService.ViewRequestStatus(user);

            if (userRequests.Count > 0)
            {
                Console.WriteLine("Your Requests:");
                foreach (var request in userRequests)
                {
                    Console.WriteLine($"Request Number: {request.RequestNumber}, Message: {request.RequestMessage}, Status: {request.RequestStatus}");
                }
            }
            else
            {
                Console.WriteLine("You have no requests.");
            }
        }

        static async Task ViewSolutions(Employee user)
        {
            await ViewRequestStatus(user);
            Console.WriteLine("Enter the request ID to view solutions:");
            int requestId;
            if (!int.TryParse(Console.ReadLine(), out requestId))
            {
                Console.WriteLine("Invalid request ID. Please try again.");
                return;
            }

            IRequestService requestService= new RequestService();
            var userSolutions = await requestService.ViewSolutions(requestId);

            if (userSolutions.Count > 0)
            {
                Console.WriteLine("Solutions for the Request:");
                foreach (var solution in userSolutions)
                {
                    Console.WriteLine($"Solution ID: {solution.SolutionId}, Description: {solution.SolutionDescription}");
                }
            }
            else
            {
                Console.WriteLine("No solutions found for the request.");
            }
        }


        static async Task RespondToSolution(Employee user)
        {
            IRequestService requestService= new RequestService();
            var userRequests = await requestService.ViewRequestStatus(user);

            if (userRequests.Count > 0)
            {
                Console.WriteLine("Select a request to respond to:");
                foreach (var request in userRequests)
                {
                    Console.WriteLine($"Request Number: {request.RequestNumber}, Message: {request.RequestMessage}");
                }

                Console.Write("Enter the request number: ");
                int requestNumber;
                if (!int.TryParse(Console.ReadLine(), out requestNumber))
                {
                    Console.WriteLine("Invalid request number. Please try again.");
                    return;
                }

                var selectedRequest = userRequests.FirstOrDefault(r => r.RequestNumber == requestNumber);


                if (selectedRequest != null)
                {
                    Console.WriteLine($"Enter your response for request {selectedRequest.RequestNumber}:");
                    string response = Console.ReadLine();

                    var solutionService = new SolutionService();
                    bool responseResult = await solutionService.RespondToSolution(selectedRequest.RequestNumber, response);

                    if (responseResult)
                    {
                        Console.WriteLine("Response submitted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Failed to submit the response. Please try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Request not found.");
                }
            }
            else
            {
                Console.WriteLine("You have no requests to respond to.");
            }
        }

        static async Task GiveFeedback(Employee user)
        {
            Console.WriteLine("Enter the solution ID to give feedback:");
            int solutionId;
            if (!int.TryParse(Console.ReadLine(), out solutionId))
            {
                Console.WriteLine("Invalid solution ID. Please try again.");
                return;
            }

            Console.WriteLine("Enter your rating (1-5):");
            float rating;
            if (!float.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating. Please enter a number between 1 and 5.");
                return;
            }

            Console.WriteLine("Enter your remarks (optional):");
            string remarks = Console.ReadLine();

            var feedback = new SolutionFeedback
            {
                Rating = rating,
                Remarks = remarks,
                SolutionId = solutionId,
                FeedbackBy = user.Id,
                FeedbackDate = DateTime.Now
            };
            var feedbackService = new FeedbackService();
            var addedFeedback = await feedbackService.GiveFeedback(feedback);

            if (addedFeedback != null)
            {
                Console.WriteLine("Feedback submitted successfully!");
            }
            else
            {
                Console.WriteLine("Failed to submit the feedback. Please try again.");
            }
        }
    }
}