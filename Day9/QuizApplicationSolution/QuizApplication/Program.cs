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
            Console.WriteLine("    $$    Welcome to the Quiz Application!    $$   \n");
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
            Console.Write("Enter the Quiz title: ");
            string title = Console.ReadLine();
            Console.Write("Enter the Quiz description: ");
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
            try
            {
                bool res = ShowAllQuizzes();
                if (!res)
                {
                    return;
                }
                Console.Write("Enter quiz ID to publish: ");
                int id = Convert.ToInt32(Console.ReadLine());
                quizService.PublishQuiz(id);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void EditQuiz()
        {
            try
            {
                bool res = ShowAllQuizzes();
                if (!res)
                {
                    return;
                }   
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
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void DeleteQuiz()
        {
            try
            {
                bool res = ShowAllQuizzes();
                if (!res)
                {
                    return;
                }
                Console.Write("Enter quiz ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                quizService.DeleteQuiz(id);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void TakeQuiz()
        {
            try
            {
                bool res = ShowAllPublishedQuizzes();
                if(!res)
                {
                    return;
                }   
                Console.Write("Enter quiz ID to take: ");
                int id = Convert.ToInt32(Console.ReadLine());
                var quiz = quizService.GetQuiz(id);
                quizTakingService.TakeQuiz(quiz);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static void ReviewLastQuizAttempt()
        {
            try
            {
                quizTakingService.ReviewLastQuizAttempt(quizService);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"An error occurred while reviewing the last quiz attempt: {ex.Message}");
            }
            
        }

        static bool ShowAllPublishedQuizzes()
        {
            Console.WriteLine("List of All Published Quizzes:");
            bool flag = false;
            foreach (var quiz in quizService.GetPublishedQuizzes())
            {
                flag = true;
                Console.WriteLine($"ID: {quiz.Id}, Title: {quiz.Title}, Description: {quiz.Description}");
            }

            if(flag == false)
            {
                Console.WriteLine("No published quizzes found.");
            }
            Console.WriteLine();
            return flag;
        }
        static bool ShowAllQuizzes()
        {
            Console.WriteLine("List of All Quizzes:");
            bool flag = false;
            foreach (var quiz in quizService.GetAllQuizzes())
            {
                flag = true;
                Console.WriteLine($"ID: {quiz.Id}, Title: {quiz.Title}, Description: {quiz.Description}");
            }
            if (flag == false)
            {
                Console.WriteLine("No quizzes found.");
            }
            Console.WriteLine();
            return flag;
        }   
    }
}
