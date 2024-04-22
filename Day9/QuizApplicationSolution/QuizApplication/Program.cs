using QuizApplicationBLLibrary;
using QuizApplicationModelLibrary;
namespace QuizApplication
{
    class Program
    {
        static IQuizService quizService = new QuizService();
        static IQuizTakingService quizTakingService = new QuizTakingService();

        static void Main(string[] args)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.WriteLine("1. Create Quiz");
                Console.WriteLine("2. Publish Quiz");
                Console.WriteLine("3. Edit Quiz");
                Console.WriteLine("4. Delete Quiz");
                Console.WriteLine("5. Take Quiz");
                Console.WriteLine("6. Review Last Quiz Attempt");
                Console.WriteLine("7. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateQuiz();
                        break;
                    case "2":
                        PublishQuiz();
                        break;
                    case "3":
                        EditQuiz();
                        break;
                    case "4":
                        DeleteQuiz();
                        break;
                    case "5":
                        TakeQuiz();
                        break;
                    case "6":
                        ReviewLastQuizAttempt();
                        break;
                    case "7":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void CreateQuiz()
        {
            Console.Write("Enter quiz title: ");
            string title = Console.ReadLine();
            Console.Write("Enter quiz description: ");
            string description = Console.ReadLine();
            List<Question> questions = new List<Question>();

            bool addingQuestions = true;
            while (addingQuestions)
            {
                Console.WriteLine("Add a question:");
                Console.Write("Enter question text: ");
                string questionText = Console.ReadLine();
                List<string> options = new List<string>();
                Console.WriteLine("Enter options (type 'done' when finished):");
                string option = Console.ReadLine();
                while (option.ToLower() != "done")
                {
                    options.Add(option);
                    option = Console.ReadLine();
                }
                Console.Write("Enter index of correct answer(1 to ...): ");
                int correctAnswerIndex = Convert.ToInt32(Console.ReadLine()) - 1;

                questions.Add(new Question(questionText, options, correctAnswerIndex));

                Console.Write("Add another question? (yes/no): ");
                string addAnother = Console.ReadLine().ToLower();
                if (addAnother != "yes")
                {
                    addingQuestions = false;
                }
            }

            quizService.CreateQuiz(title, description, questions);
            Console.WriteLine("Quiz created successfully!");
        }

        static void PublishQuiz()
        {
            ShowAllQuizzes();   
            Console.Write("Enter quiz ID to publish: ");
            int id = Convert.ToInt32(Console.ReadLine());
            quizService.PublishQuiz(id);
        }
        static void EditQuiz()
        {
            ShowAllQuizzes();
            Console.Write("Enter quiz ID to edit: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var quiz = quizService.GetQuiz(id);

            // Display current quiz details
            Console.WriteLine($"Current Quiz Title: {quiz.Title}");
            Console.WriteLine($"Current Quiz Description: {quiz.Description}");

            // Get new quiz details from user
            Console.Write("Enter new quiz title: ");
            string newTitle = Console.ReadLine();
            Console.Write("Enter new quiz description: ");
            string newDescription = Console.ReadLine();

            // Update quiz
            quiz.Title = newTitle;
            quiz.Description = newDescription;
            quizService.EditQuiz(id, quiz);
        }

        static void DeleteQuiz()
        {
            ShowAllQuizzes();
            Console.Write("Enter quiz ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            quizService.DeleteQuiz(id);
        }
        static void TakeQuiz()
        {
            ShowAllPublishedQuizzes();
            Console.Write("Enter quiz ID to take: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var quiz = quizService.GetQuiz(id);
            quizTakingService.TakeQuiz(quiz);
        }

        static void ReviewLastQuizAttempt()
        {
            quizTakingService.ReviewLastQuizAttempt();
        }

        static void ShowAllPublishedQuizzes()
        {
            Console.WriteLine("List of All Quizzes:");
            foreach (var quiz in quizService.GetPublishedQuizzes())
            {
                Console.WriteLine($"ID: {quiz.Id}, Title: {quiz.Title}, Description: {quiz.Description}");
            }
            Console.WriteLine();
        }
        static void ShowAllQuizzes()
        {
            Console.WriteLine("List of All Quizzes:");
            foreach (var quiz in quizService.GetAllQuizzes())
            {
                Console.WriteLine($"ID: {quiz.Id}, Title: {quiz.Title}, Description: {quiz.Description}");
            }
            Console.WriteLine();
        }   
    }
}
